using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacters.Models
{
    public class Warrior: Character
    {
       public Warrior()
        {
            classType = CharacterClass.Warrior;
            InitializePrimaryAttributes();
            UsableWeapons = new List<Weapons> { Weapons.Swords, Weapons.Hammers, Weapons.Axes };
            UsableArmor = new List<Armors> { Armors.Mail, Armors.Plate };
        }

        protected override void InitializePrimaryAttributes()
        {
            PrimaryAttributes = new PrimaryAttributes();
            PrimaryAttributes.Strength = 5;
            PrimaryAttributes.Dexterity = 2;
            PrimaryAttributes.Intelligence = 1;
        }

        public override void LevelUp()
        {
            IncreaseLevel();
            PrimaryAttributes.Strength += 3;
            PrimaryAttributes.Dexterity += 2;
            PrimaryAttributes.Intelligence += 1;
        }
    }
}
