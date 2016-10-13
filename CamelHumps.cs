using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamelHumps
{
    public class CamelHumps
    {
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
            if (aPattern[aPatternIndex] == Char.ToLower(aText[aTextIndex]))
                return MatchInternal(aPattern, aPatternIndex + 1, aText, aTextIndex + 1);
            var newTextIndex = GetNextUpperCaseIndex(aText, aTextIndex);
            if (newTextIndex < 0)
                return false;            
            return MatchInternal(aPattern, aPatternIndex+1, aText, newTextIndex+1);
        }

        private static int GetNextUpperCaseIndex(string aText, int aTextIndex)
        {
            var result = -1;
            for (var i = aTextIndex; i < aText.Length; i++)
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
