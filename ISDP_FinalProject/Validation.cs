using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISDP_FinalProject
{
    internal class Validation
    {
        public static bool passwordCheck(string Password)
        {
            string specialChar = @"\|!#$%&/()=?»«@£§€{}.-;'<>_,";
            int capitalLength = 0;
            int specialLength = 0;
            int testInt;
            bool result = false;
            //Is there at least one capital letter?
            foreach (char c in Password)
            {
                if (Char.IsUpper(c) == true)
                {
                    capitalLength++;
                }
            }
            //Is at least one character a special character
            foreach (char c in Password)
            {
                if (specialChar.Contains(c) == true)
                {
                    specialLength++;
                }
            }
            //Does it have 8 characters?
            if (Password.Length < 8)
            {
                result = false;
            }
            //Does the password start with a letter?
            else if (int.TryParse(Password[0].ToString(), out testInt))
            {
                result = false;
            }

            //Did those two foreach pass?
            else if (capitalLength > 0 && specialLength > 0)
            {
                result = true;
            }

            System.Diagnostics.Debug.WriteLine(specialLength + "" + capitalLength + " Test");
            return result;
        }
    }
}
