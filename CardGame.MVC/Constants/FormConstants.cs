using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardGame.MVC.Constants
{
    public static class FormConstants
    {
        public const string EmailDisplay = "Email";
        public const string EmailRequired = "Email is required.";

        public const string PasswordDisplay = "Password";
        public const string PasswordRequired = "Password is required.";
        public const string PasswordValid = "Password is invalid.";

        public const string RepeatPasswordDisplay = "Repeat Password";
        public const string RepeatPasswordRequired = "Repeated Password is required.";
        public const string RepeatPasswordNotEqual = "Passwords do not match.";
    }
}
