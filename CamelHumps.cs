using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamelHumps
{
    public class CamelHumps
    {
        /// <summary>
        /// Metoda zwraca true, jeśli aText jest zgodny ze wzorcem przekazanym jako aPattern
        /// Porównanie jest wykonywane z uwzględnieniem CamelHumps, czyli CreateRoom pasuje do wzorców CreateRoom, Create, CreR, CRoom itp.
        /// </summary>
        /// <param name="aPattern"></param>
        /// <param name="aText"></param>
        /// <returns></returns>
        public static bool Match(string aPattern, string aText)
        {
            if (aPattern.Length == 0)
                return true;
            return MatchInternal(aPattern.ToLowerInvariant(), 0, aText, 0);
        }

        private static bool MatchInternal(string aPattern, int aPatternIndex, string aText, int aTextIndex)
        {
            if (aTextIndex >= aText.Length)
                return true;
            if (aPatternIndex >= aPattern.Length)
                return true;
            var result = false;
            //najpier sprawdzamy, czy kolejne litery pasują wprost
            if(CharsMatch(aPattern, aPatternIndex, aText, aTextIndex))
                //jeśli tak, to wynikiem częściowym jest porównanie następnych znaków
                result = MatchInternal(aPattern, aPatternIndex + 1, aText, aTextIndex + 1);
            //drugą możliwością jest dopasowanie następnej litery w patternie do następnej dużej litery w tekście
            //wyszukujemy indeks następnej dużej litery
            var newTextIndex = GetNextUpperCaseIndex(aText, aTextIndex);
            //jeśli takiej nie ma to zwracamy wynik dla porównania wprost
            if (newTextIndex < 0)
                return result;
            //jeśli taka jest i pasuje do następnego znaku w patternie, to wykonujemy dalsze porównanie od niej
            if (CharsMatch(aPattern, aPatternIndex, aText, newTextIndex))
                return result || MatchInternal(aPattern, aPatternIndex+1, aText, newTextIndex+1);
            else
                return result;
        }

        private static bool CharsMatch(string aPattern, int aPatternIndex, string aText, int aTextIndex)
        {
            return aPattern[aPatternIndex] == Char.ToLower(aText[aTextIndex]);
        }

        /// <summary>
        /// Zwraca indeks następnej dużej litery w aText, rozpoczynając od indexu aStartIndex
        /// Jeśli nie ma juz dużych znaków, to zwraca -1
        /// </summary>
        /// <param name="aText"></param>
        /// <param name="aStartIndex"></param>
        /// <returns></returns>
        private static int GetNextUpperCaseIndex(string aText, int aStartIndex)
        {
            var result = -1;
            for (var i = aStartIndex; i < aText.Length; i++)
            {
                if (Char.IsUpper(aText[i]))
                {
                    result = i;
                    break;
                }
            }
            return result;
        }
    }


}
