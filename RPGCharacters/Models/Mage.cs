using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacters.Models
{
    public class Mage: Character
    {
        public Mage()
        {
            classType = CharacterClass.Mage;
            InitializePrimaryAttributes();
            UsableWeapons = new List<Weapons> { Weapons.Staffs, Weapons.Wands };
            UsableArmor = new List<Armors> { Armors.Cloth };
        }

        protected override void InitializePrimaryAttributes()
        {
            PrimaryAttributes = new PrimaryAttributes();
            PrimaryAttributes.Strength = 1;
            PrimaryAttributes.Dexterity = 1;
            PrimaryAttributes.Intelligence = 8;
        }

        public override void LevelUp()
        {
            IncreaseLevel();
            PrimaryAttributes.Strength += 1;
            PrimaryAttributes.Dexterity += 1;
            PrimaryAttributes.Intelligence += 5;
        }
    }
}

