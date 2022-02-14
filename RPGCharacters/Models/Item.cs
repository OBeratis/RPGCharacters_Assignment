using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacters.Models
{
    public abstract class Item
    {
        // Fields
        protected string name = "";
        protected string equip = "";
        protected Slot slot;
        protected int requiredLevel = 0;

        // Properties
        public abstract string Name { get; set; }
        public abstract string Equip { get; set; }
        public abstract Slot Slot { get; set; }
        public abstract int RequiredLevel { get; set; }

    }

}
