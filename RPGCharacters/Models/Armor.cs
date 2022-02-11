using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacters.Models
{

    public class Armor : Item
    {
        private Armors type;
        private int damage;

        public Dictionary<Armors, CharacterClass> usableBy = new Dictionary<Armors, CharacterClass>()
        {
            { Armors.Cloth, CharacterClass.Mage },
            { Armors.Leather, CharacterClass.Ranger },
            { Armors.Mail, CharacterClass.Ranger },
            { Armors.Leather, CharacterClass.Rogue },
            { Armors.Mail, CharacterClass.Rogue },
            { Armors.Mail, CharacterClass.Warrior },
            { Armors.Plate, CharacterClass.Warrior }
        };

        // Properties
        public Armors Type { get => type; set => type = value; }
        public int Damage { get => damage; set => damage = value; }

        // Overrided
        public override string Name { get => name; set => name = value; }
        public override string Equip { get => equip; set => equip = value; }
        public override int Slot { get => slot; set => slot = value; }
        public override int RequiredLevel { get => requiredLevel; set => requiredLevel = value; }
    }

}
