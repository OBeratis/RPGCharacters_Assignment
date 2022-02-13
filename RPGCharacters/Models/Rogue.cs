using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacters.Models
{
    public class Rogue: Character
    {
        public Rogue()
        {
            classType = CharacterClass.Rogue;
            InitializePrimaryAttributes();
            UsableWeapons = new List<Weapons> { Weapons.Daggers };
            UsableArmor = new List<Armors> { Armors.Leather, Armors.Mail };
        }

        protected override void InitializePrimaryAttributes()
        {
            PrimaryAttributes = new PrimaryAttributes();
            PrimaryAttributes.Strength = 2;
            PrimaryAttributes.Dexterity = 6;
            PrimaryAttributes.Intelligence = 1;
        }

        public override void LevelUp()
        {
            IncreaseLevel();
            PrimaryAttributes.Strength += 1;
            PrimaryAttributes.Dexterity += 4;
            PrimaryAttributes.Intelligence += 1;
        }
    }
}
