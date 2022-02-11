using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacters.Models
{
    public abstract class Item
    {
        protected string name = "";
        protected string equip = "";
        protected int slot = 0;
        protected int requiredLevel = 0;

        // Properties
        public abstract string Name { get; set; }
        public abstract string Equip { get; set; }
        public abstract int Slot { get; set; }
        public abstract int RequiredLevel { get; set; }

    }

}
