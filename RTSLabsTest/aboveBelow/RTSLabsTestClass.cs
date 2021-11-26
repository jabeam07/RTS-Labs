using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aboveBelow
{
    internal class RTSLabsTestClass
    {
        public static AboveBelowResult CompareInts(int[]? intList, int compareInt)
        {
            AboveBelowResult result = new AboveBelowResult();  

            for (int i = 0; i < intList.Length; i++)
            {
                if (compareInt < intList[i])
                {
                    result.Above += 1;
                } 
                else if (compareInt > intList[i])
                {
                    result.Below += 1;
                }
            }

            return result;
        }

        public static string RotateString(string currentString, int rotationCount)
        {

            char[] charSplit = currentString.ToCharArray();
            char[] newCharSplit = currentString.ToCharArray();

            for (int i = currentString.Length - 1; i >= 0; i--)
            {
                int newLoc = i + rotationCount;

                if (newLoc >= currentString.Length)
                {
                    newLoc = newLoc % currentString.Length;
                }

                newCharSplit[newLoc] = charSplit[i];
            }

            return new String(newCharSplit);

        }
    }

    
}
