using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;

namespace Miracle.RtfDocumentBuilder.Core
{
    /// <summary>
    /// Glossary
    /// 
    /// Charset: A set of characters used in Windows. Charsets refer to the same collections of characters
    /// defined by Windows code pages, but their ID numbers can be expressed in a single byte.
    /// 
    /// Big font: A single font file that contains glyphs representing characters from multiple charsets.
    /// 
    /// Western European editions of Windows 3.x supported three character sets per installation: 
    /// a single Windows character set (ANSI), an OEM character set, and the symbol character set. 
    /// Because different language editions of Windows 3.1 supported different default Windows and OEM character sets, 
    /// sharing documents among different systems was not always feasible. 
    /// (See Chapter 3 for more information on character sets in Windows.)
    /// 
    /// See more : http://msdn.microsoft.com/en-us/library/cc194829.aspx
    /// </summary>
    public class CharSetTable
    {
        //public const CharSet Default = new CharSet(0x00, 0, 0);
        // Define character of error text
        private const byte BYTE_ERROR = 63;
        // Define charset dictionary for mapping
        private static HybridDictionary charsetDictionary;
        /// <summary>
        /// Get number of charset in table
        /// </summary>
        private int Count { get { return charsetDictionary.Count; } }
        /// <summary>
        /// Use create charset dictionary and add value
        /// </summary>
        static CharSetTable()
        {
            //create dictionary
            charsetDictionary = new HybridDictionary(false);
            charsetDictionary.Add(CharSetName.ANSI_CHARSET, new CharSet(CharSetName.ANSI_CHARSET, 0x00, 0, 1252));
            charsetDictionary.Add(CharSetName.DEFAULT_CHARSET, new CharSet(CharSetName.DEFAULT_CHARSET, 0x01, 1, 0));
            charsetDictionary.Add(CharSetName.SYMBOL_CHARSET, new CharSet(CharSetName.SYMBOL_CHARSET, 0x02, 2, 0));
            charsetDictionary.Add(CharSetName.SHIFTJIS_CHARSET, new CharSet(CharSetName.SHIFTJIS_CHARSET, 0x80, 128, 932));
            charsetDictionary.Add(CharSetName.HANGUL_CHARSET, new CharSet(CharSetName.HANGUL_CHARSET, 0x81, 129, 949));
            charsetDictionary.Add(CharSetName.GB2312_CHARSET, new CharSet(CharSetName.GB2312_CHARSET, 0x86, 134, 936));
            charsetDictionary.Add(CharSetName.CHINESEBIG5_CHARSET, new CharSet(CharSetName.CHINESEBIG5_CHARSET, 0x88, 136, 950));
            charsetDictionary.Add(CharSetName.GREEK_CHARSET, new CharSet(CharSetName.GREEK_CHARSET, 0xA1, 161, 1253));
            charsetDictionary.Add(CharSetName.TURKISH_CHARSET, new CharSet(CharSetName.TURKISH_CHARSET, 0xA2, 162, 1254));
            charsetDictionary.Add(CharSetName.HEBREW_CHARSET, new CharSet(CharSetName.HEBREW_CHARSET, 0xB1, 177, 1255));
            charsetDictionary.Add(CharSetName.ARABIC_CHARSET, new CharSet(CharSetName.ARABIC_CHARSET, 0xB2, 178, 1256));
            charsetDictionary.Add(CharSetName.BALTIC_CHARSET, new CharSet(CharSetName.BALTIC_CHARSET, 0xBA, 186, 1257));
            charsetDictionary.Add(CharSetName.RUSSIAN_CHARSET, new CharSet(CharSetName.RUSSIAN_CHARSET, 0xCC, 204, 1251));
            charsetDictionary.Add(CharSetName.THAI_CHARSET, new CharSet(CharSetName.THAI_CHARSET, 0xDE, 222, 874));
            charsetDictionary.Add(CharSetName.EE_CHARSET, new CharSet(CharSetName.EE_CHARSET, 0xEE, 238, 1250));
            charsetDictionary.Add(CharSetName.OEM_CHARSET, new CharSet(CharSetName.OEM_CHARSET, 0xFF, 255, 0));
        }
        /// <summary>
        /// Get Charset by Charset name
        /// </summary>
        /// <param name="charsetName">charset name</param>
        /// <returns>Charset value</returns>
        public static CharSet GetCharset(CharSetName charsetName) { return (CharSet)charsetDictionary[charsetName]; }
        /// <summary>
        /// Get Charset by origin text
        /// </summary>
        /// <param name="origText">origin text</param>
        /// <returns>Charset value</returns>
        public static CharSet GetCharset(string origText)
        {
            foreach (CharSet _charSet in charsetDictionary.Values)
            {
                // get origin enacoding with code page id
                Encoding origCode = Encoding.GetEncoding(_charSet.CodePageId);
                //get byte 
                byte[] origByte = origCode.GetBytes(origText);
                //Check byte error
                if (origByte.Length <= 0)
                    continue;
                else
                {
                    if (origByte[0] != CharSetTable.BYTE_ERROR)
                        return _charSet;
                }
            }
            return null;
        } 
    }

    #region Charset name
    /// <summary>
    /// Charset name with enum collection
    /// </summary>
    public enum CharSetName
    {
        // ansi (UTF-8) charset
        ANSI_CHARSET,
        // default charset (set by font family with default charset)
        DEFAULT_CHARSET,
        // symbol charset
        SYMBOL_CHARSET,
        // shifjis charset
        SHIFTJIS_CHARSET,
        // hangul (korea) charset
        HANGUL_CHARSET,
        // gb2312 charset
        GB2312_CHARSET,
        // chiness big5 charset
        CHINESEBIG5_CHARSET,
        // Greek charset
        GREEK_CHARSET,
        // Turkish charset
        TURKISH_CHARSET,
        // hebrew charset
        HEBREW_CHARSET,
        // arabic charset
        ARABIC_CHARSET,
        // baltic charset
        BALTIC_CHARSET,
        // Russian charset
        RUSSIAN_CHARSET,
        // Thai charset**
        THAI_CHARSET,
        // East euro charset
        EE_CHARSET,
        // oem charset
        OEM_CHARSET
    }
    #endregion
}
