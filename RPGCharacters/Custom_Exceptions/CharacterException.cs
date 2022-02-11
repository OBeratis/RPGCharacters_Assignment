using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacters.Custom_Exceptions
{
    public class CharacterException : Exception
    {
        public CharacterException()
        {
        }

        public CharacterException(string message) : base(message)
        {

        }

        public override string Message => "Character exception occurs.";
    }
}
