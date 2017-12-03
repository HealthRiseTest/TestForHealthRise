using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;

namespace HealthRiseTest.Controllers
{
    public class HealthRiseController : ApiController
    {
        public int Get()
        {
            return 0;
        }

        public int TestPasswordStrengthGet(string sPassword)
        {
            //First do some cleaning on the password
            //Handle blank passwords
            if (sPassword ==null || sPassword.Length < 1)
                return 0;

            //I'm a assuming an upper limit of 30 characters
            if (sPassword.Length > 30)
                return 0;

            /*This is not the place to do validation for SQL injection since
             * we are not sending anything to the DB,
             * but I assume this will be done somewhere else.
             */
             
            /*
             * Scoring params:
             * Length: 0-4 points
             * Contians Lower Case: 0-2 points
             * Contains Upper Case: 0-2 points
             * Contains Special Characters: 0-2 points
             * Contains Numbers: 0-2 points
             */
            int score = 0;
            //Length
            score = (int)Math.Floor(sPassword.Length / 7.5d);

            if (containsLowerCase(sPassword))
                score += 2;
            if (containsNumbers(sPassword))
                score += 2;
            if (containsUpperCase(sPassword))
                score += 2;
            if (containsSpecialCharacters(sPassword))
                score += 2;
            // Just to comply with specifications
            if (score == 0)
                score = 1;
            return score;
        }
#region Regex Methods
        private bool containsUpperCase(string sPassword)
        {
            //Regex item = new Regex(@"[A-Z]+");
            Regex item = new Regex(@"[\p{Lu}\p{Lt}]");
            if (item.IsMatch(sPassword))
                return true;
            return false;
        }
        private bool containsNumbers(string sPassword)
        {
            Regex item = new Regex(@"[0-9]+");
            if (item.IsMatch(sPassword))
                return true;
            return false;
        }
        

        private bool containsLowerCase(string sPassword)
        {
            //Regex item = new Regex(@"[A-Z]+");
            Regex item = new Regex(@"[\p{Ll}\p{Lm}\p{Lo}]");
            if (item.IsMatch(sPassword))
                return true;
            return false;
        }
        private bool containsSpecialCharacters(string sPassword)
        {
            Regex item = new Regex(@"((?![\p{Lu}\p{Lt}\p{Ll}\p{Lm}\p{Lo}0-9]).)+");
            if (item.IsMatch(sPassword))
                return true;
            return false;
        }
#endregion
    }
}
