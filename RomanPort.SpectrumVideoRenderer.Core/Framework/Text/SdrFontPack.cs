using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace RomanPort.SpectrumVideoRenderer.Core.Framework.Text
{
    //Adapation of the font loader I wrote for my RaptorSDR Mobile client
    public class SdrFontPack
    {
        public const int FILE_HEADER_SIZE = 76;
        public const int FILE_ENTRY_HEADER_SIZE = 4;

        public Dictionary<char, SdrFontPackCharacter> characters;
        public string name;
        public int fullHeight; //Includes overdraw. Also format of all payloads
        public int height;
        public int width;
        public int characterCount;
        public int maxOverdrawTop;
        public int maxOverdrawBottom;

        public static SdrFontPack LoadFromEmbeddedResource(string tag)
        {
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("RomanPort.SpectrumVideoRenderer.Core.Framework.Text.Data." + tag + ".sdrfnt"))
            {
                byte[] data = new byte[stream.Length];
                stream.Read(data, 0, data.Length);
                return LoadFromBytes(data);
            }
        }

        public static SdrFontPack LoadFromBytes(byte[] data)
        {
            //Verify type
            if (data[0] != (byte)'S' || data[1] != (byte)'D' || data[2] != (byte)'F' || data[3] != (byte)'T')
                throw new Exception("This is not an SDR Font File. You need to convert fonts to this special format.");

            //Read in header
            byte version = data[4];
            byte charCount = data[5];
            byte realWidth = data[6];
            byte realHeight = data[7];
            byte maxOverdrawTop = data[8];
            byte maxOverdrawBottom = data[9];
            byte height = data[10];
            byte style = data[11];
            string name = Encoding.ASCII.GetString(data, 12, 64);

            //Create pack
            SdrFontPack pack = new SdrFontPack
            {
                characters = new Dictionary<char, SdrFontPackCharacter>(),
                fullHeight = realHeight,
                height = height,
                width = realWidth,
                characterCount = charCount,
                maxOverdrawBottom = maxOverdrawBottom,
                maxOverdrawTop = maxOverdrawTop,
                name = name
            };

            //Read in characters
            for (int i = 0; i < charCount; i++)
            {
                //Get index
                int index = FILE_HEADER_SIZE + (((realWidth * realHeight) + FILE_ENTRY_HEADER_SIZE) * i);

                //Read header
                char character = (char)data[index + 0];
                byte overdrawTop = data[index + 2];
                byte overdrawBottom = data[index + 3];

                //Read payload
                byte[] payload = new byte[realWidth * realHeight];
                Array.Copy(data, index + FILE_ENTRY_HEADER_SIZE, payload, 0, payload.Length);

                //Set
                pack.characters.Add(character, new SdrFontPackCharacter
                {
                    character = character,
                    overdrawTop = overdrawTop,
                    overdrawBottom = overdrawBottom,
                    payload = payload
                });
            }

            return pack;
        }

        public int CalculateHeight()
        {
            return height + maxOverdrawBottom + maxOverdrawTop;
        }

        public int CalculateWidth(int chars)
        {
            return (chars * width) + ((chars - 1) * 1);
        }

        public unsafe void RenderCharacter(UnsafeColor* ptr, int canvasWidth, char character, UnsafeColor color)
        {
            //Try to find character data
            if (character == (char)0x00 || character == '\n' || character == '\r')
            {
                //Ignore. This is a null or invisible character
            }
            else if (characters.ContainsKey(character))
            {
                //Copy pixel data
                var cha = characters[character];
                for (int i = 0; i < width * fullHeight; i++)
                {
                    //Check if this is black to save CPU
                    if (cha.payload[i] == 0)
                        continue;

                    //Get location in memory
                    UnsafeColor* pxl = ptr + (canvasWidth * (i / width)) + (i % width);
                    
                    //Update
                    if(cha.payload[i] == byte.MaxValue)
                    {
                        //Full brightness. Cheat
                        *pxl = color;
                    } else
                    {
                        //Mix
                        float scale = (float)cha.payload[i] / 256;
                        float scaleR = 1 - scale;
                        *pxl = new UnsafeColor(
                            (byte)(((*pxl).r * scaleR) + (color.r * scale)),
                            (byte)(((*pxl).g * scaleR) + (color.g * scale)),
                            (byte)(((*pxl).b * scaleR) + (color.b * scale))
                        );
                    }
                }
            }
            else
            {
                //Write a blank spot, as this character isn't found
            }
        }

        public unsafe void RenderLine(UnsafeColor* ptr, int canvasWidth, char[] chars, int count, UnsafeColor color)
        {
            for (int i = 0; i < Math.Min(chars.Length, count); i++)
            {
                RenderCharacter(ptr, canvasWidth, chars[i], color);
                ptr += width + 1;
            }
        }

        public unsafe void RenderLine(UnsafeColor* ptr, int canvasWidth, int x, int y, char[] chars, int count, UnsafeColor color)
        {
            RenderLine(ptr + (y * canvasWidth) + x, canvasWidth, chars, count, color);
        }

        public unsafe void RenderLine(UnsafeColor* ptr, int canvasWidth, int x, int y, char[] chars, int count)
        {
            RenderLine(ptr, canvasWidth, x, y, chars, count, UnsafeColor.WHITE);
        }
    }
}
