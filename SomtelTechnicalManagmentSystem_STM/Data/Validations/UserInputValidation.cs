namespace SomtelTechnicalManagmentSystem_STM.Data.Validations
{
    public class UserInputValidation
    {
        public static bool ValidatePhoneNumber(string pnum)
        {
            bool pass = true;
            var positiveIntRegex = new System.Text.RegularExpressions.Regex(@"^[0-9]+$");
            if (positiveIntRegex.IsMatch(pnum) == false)
            {
                pass = false;
            }
            if (pnum.Trim().Length == 9 && pnum.Trim().StartsWith("65"))
            {

            }
            else
            {
                pass = false;
            }
            return pass;
        }

        public static bool ValidateNumber(string pnum)
        {
            bool pass = true;
            var positiveIntRegex = new System.Text.RegularExpressions.Regex(@"^[0-9]+$");
            if (positiveIntRegex.IsMatch(pnum) == false)
            {
                pass = false;
            }
            return pass;
        }

        public static bool ValidateName(string input)
        {
            bool pass = true;
            var positiveIntRegex = new System.Text.RegularExpressions.Regex(@"^[A-Za-z ' ']+$");
            if (positiveIntRegex.IsMatch(input) == false)
            {
                pass = false;
            }
            if (input.Trim().Length < 1)
            {
                pass = false;
            }
            return pass;
        }

        public static bool ValidateUserName(string input)
        {
            bool pass = true;
            var positiveIntRegex = new System.Text.RegularExpressions.Regex(@"^(?!\s*$)[A-Za-z\d-_.]+$");
            if (positiveIntRegex.IsMatch(input) == false)
            {
                pass = false;
            }
            if (input.Trim().Length < 6 || input.Trim().Length > 15)
            {
                pass = false;
            }
            return pass;
        }

        public static bool ValidateEmail(string email)
        {
            bool pass = true;
            int index1 = email.IndexOf("@");
            int index2 = email.LastIndexOf("@");

            if (email.Split('@').Length - 1 > 1) //if @ occurs more than once, then its invalid
            {

            }
            if (index1 != index2) //those will check if multiple @ is added
            {
                pass = false;
            }

            if (email.Trim() == "")
            {
                pass = false;
            }
            var positiveIntRegex = new System.Text.RegularExpressions.Regex(@"^[A-Za-z\d-_.@]+$");
            if (positiveIntRegex.IsMatch(email) == false)
            {
                pass = false;
            }
            if (!email.Trim().Contains("somtelnetwork.net"))
            {
                pass = false;
            }

            return pass;
        }

    }
}
