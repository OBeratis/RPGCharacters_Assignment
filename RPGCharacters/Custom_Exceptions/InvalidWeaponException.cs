﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacters.Custom_Exceptions
{
    public class InvalidWeaponException : Exception
    {
        public InvalidWeaponException()
        {

        }

        public InvalidWeaponException(string message) : base(message)
        {
        }

        public override string Message => "Invalid weapon error";
    }
}
