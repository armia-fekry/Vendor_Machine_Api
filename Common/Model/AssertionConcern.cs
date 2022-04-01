using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JWT_NET_5.Common.Model
{
    public static class AssertionConcern
    {
        private const string EmailRegex = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
        public static void AssertionAgainstNotNull(object object1, string message)
        {
            if(object1 is null)
                throw new ArgumentNullException(nameof(object1));
        }
        public static void AssertionAgainstNotNullOrEmplty(string object1, string message)
        {
            if (string.IsNullOrEmpty(object1))
                throw new ArgumentNullException(nameof(object1));
        }
        public static void AssertionAgainstNotValidEmail(string email, string message)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentNullException(nameof(email));
            var regex = new Regex(EmailRegex);
            if(regex.IsMatch(email))
                throw new Exception(message);
        }
    }
}
