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
            return MatchInternal(aPattern, 0, aText.ToLowerInvariant(), 0);
        }

        private static bool MatchInternal(string aPattern, int aPatternIndex, string aText, int aTextIndex)
        {
            if (aTextIndex >= aText.Length)
                return true;
            if (aPatternIndex >= aPattern.Length)
                return true;
            if (Char.ToLower(aPattern[aPatternIndex]) == aText[aTextIndex])
                return MatchInternal(aPattern, aPatternIndex + 1, aText, aTextIndex + 1);
            return false;
        }
    }


}
