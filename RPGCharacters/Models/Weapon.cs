using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacters.Models
{

    public class Weapon : Item
    {
        private Weapons type;
        private int damage;

        public Dictionary<Weapons, CharacterClass> usableBy = new Dictionary<Weapons, CharacterClass>() 
        {  
            { Weapons.Staffs, CharacterClass.Mage },
            { Weapons.Wands, CharacterClass.Mage },
            { Weapons.Bows, CharacterClass.Ranger },
            { Weapons.Daggers, CharacterClass.Rogue },
            { Weapons.Swords, CharacterClass.Rogue },
            { Weapons.Swords, CharacterClass.Warrior },
            { Weapons.Hammers, CharacterClass.Warrior },
            { Weapons.Axes, CharacterClass.Warrior }
        }; 

        public Weapon(Weapons weapon)
        {
            this.type = weapon;
        }

        // Properties
        public Weapons Type { get => type; set => type = value; }
        public int Damage { get => damage; set => damage = value; }

        // Overrided
        public override string Name { get => name; set => name = value; }
        public override string Equip { get => equip; set => equip = value; }
        public override int Slot { get => slot; set => slot = value; }
        public override int RequiredLevel { get => requiredLevel; set => requiredLevel = value; }
    }

}
