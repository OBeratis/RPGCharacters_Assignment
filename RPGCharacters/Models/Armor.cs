using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacters.Models
{
    public class Armor : Item
    {
        // Fields
        private Armors type;
        private int damage;
        private PrimaryAttributes primaryAttributes;

        // Constructor
        public Armor(Armors type, PrimaryAttributes primaryAttributes)
        {
            Type = type;
            this.primaryAttributes = primaryAttributes;
        }

        // Properties
        public Armors Type { get => type; set => type = value; }
        public int Damage { get => damage; set => damage = value; }
        public PrimaryAttributes PrimaryAttributes { get => primaryAttributes; set => primaryAttributes = value; }
        public override string Name { get => name; set => name = value; }
        public override string Equip { get => equip; set => equip = value; }
        public override Slot Slot { get => slot; set => slot = value; }
        public override int RequiredLevel { get => requiredLevel; set => requiredLevel = value; }
    }

}
