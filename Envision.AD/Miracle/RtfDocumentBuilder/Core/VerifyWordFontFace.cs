using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Miracle.RtfDocumentBuilder.Core
{
    public class VerifyWordFontFace
    {
        /// <summary>
        /// This struct use to verified text from original text
        /// </summary>
        public struct VerifyFontFace
        {
            public string OriginalText { get; set; }
            public string VerifiedText { get; set; }
            public RTFFont Font { get; set; }
        }

        /// <summary>
        /// Use to verdify string text
        /// </summary>
        /// <param name="trimText">plain text</param>
        /// <param name="font">font</param>
        /// <returns></returns>
        public static string VerifyFromText(string trimText, RTFFont font)
        {
            CharSet charset = CharSetTable.GetCharset(trimText);
            // Create two different encodings.
            Encoding unicode = Encoding.GetEncoding(charset.CodePageId);
            byte[] unicodeByte = unicode.GetBytes(trimText);
            // hex string 
            string hexString = string.Empty;
            // no change
            if (charset.CodePageId == 0)
                return trimText;
            //Update charset
            RTFFont.SetCharset(font, charset);
            //int newfontId = RTFDocumentBase.UpdateCharSet(font.FontFamily, charset);

            foreach (byte b in unicodeByte)
                hexString += @"\'" + string.Format("{0:x2}", b);

            return hexString;
        }

        /// <summary>
        /// Verify word string 
        /// </summary>
        /// <param name="word">word</param>
        /// <returns></returns>
        public static VerifyFontFace[] VerifyFromWord(string word)
        {
            int _start = 0; // set default start
            int _end = word.Length; //set default end
            int _defaultCodePage = 0;
            for (int i = 0; i < word.Length; i++)
            {
                CharSet charset = CharSetTable.GetCharset(word[i].ToString());
                if (charset.CodePageId != _defaultCodePage)
                {
                    _start = i;
                    //for
                }
            }

            return null;
        }
    }
}
