using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacters.Models
{
    public class Ranger: Character
    {
        public Ranger()
        {
            classType = CharacterClass.Ranger;
            InitializePrimaryAttributes();
            UsableWeapons = new List<Weapons> { Weapons.Bows };
            UsableArmor = new List<Armors> { Armors.Leather, Armors.Mail };
        }

        protected override void InitializePrimaryAttributes()
        {
            PrimaryAttributes = new PrimaryAttributes();
            PrimaryAttributes.Strength = 1;
            PrimaryAttributes.Dexterity = 7;
            PrimaryAttributes.Intelligence = 1;
        }

        public override void LevelUp()
        {
            IncreaseLevel();
            PrimaryAttributes.Strength += 1;
            PrimaryAttributes.Dexterity += 5;
            PrimaryAttributes.Intelligence += 1;
        }
    }
}
