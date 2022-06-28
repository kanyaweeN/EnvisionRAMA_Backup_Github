using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;

namespace Miracle.RtfDocumentBuilder.Core
{
    /// <summary>
    /// This class use to direct truetype of font. 
    /// Because some font in window95 may need to specific font family such as 
    /// ------------------------------
    /// Malgun Gothic
    /// ------------------------------
    ///     Malgun Gothic is a Korean font developed by taking advantage of ClearType technology, 
    /// and it provides excellent reading experience particularly onscreen. 
    /// Its elements are created based on the typeface of Hunminjeongeum, 
    /// and streamlined with modern form of characters as well as upright and well-regulated strokes. 
    /// The font is very legible at small sizes with its moderate open counters, 
    /// and its even inter-character spacing and visual center line maximize the readability.
    /// </summary>
    public class SpecificallyFontTable
    {
        private static HybridDictionary spFontTable;
        // add specifically font
        static SpecificallyFontTable()
        {
            spFontTable = new HybridDictionary();
            spFontTable.Add(CharSetName.HANGUL_CHARSET, FontFamilys.MalgunGothic);
            spFontTable.Add(CharSetName.GB2312_CHARSET, FontFamilys.MSMincho);
        }
        /// <summary>
        /// Get Spcifically font family
        /// </summary>
        /// <param name="charsetName">charset name</param>
        /// <returns>font family</returns>
        public static FontFamilys GetFontFamily(CharSetName charsetName){
            if (spFontTable.Contains(charsetName))
                return (FontFamilys)spFontTable[charsetName];
            else
                return FontFamilys.None;
        }
    }
}
