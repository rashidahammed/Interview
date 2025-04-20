using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INT.Utility
{
    public class Enums
    {
        public enum Language
        {
            Arabic = 1,
            English = 2
        }

        public class AllowedCharector
        {
            public const string ArabicExpresssion = @"^[\u0600-\u06FF0-9 _!@#$%^&*.:;^\-,'=+)(&~/|?><{}]+$";
            public const string EnglishExpresssion = @"^[a-zA-Z0-9 _!@#$%^&*.:;^\-,'=+)(&~/|?><{}]+$";
            public const string HindiExpression = @"^[\u0900-\u097F0-9 _!@#$%^&*.:;^\-,'=+)(&~/|?><{}]+$";
        }
    }
}
