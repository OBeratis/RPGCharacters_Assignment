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
            // Set characters classs type
            classType = CharacterClass.Ranger;

            // Initialize with default values
            InitializePrimaryAttributes();

            // Assign to shich weapons and armor a ranger can have
            UsableWeapons = new List<Weapons> { Weapons.Bows };
            UsableArmor = new List<Armors> { Armors.Leather, Armors.Mail };
        }

        /// <summary>
        /// Initialize characters attributes when the ranger class is created.
        /// </summary>
        protected override void InitializePrimaryAttributes()
        {
            PrimaryAttributes = new PrimaryAttributes();
            PrimaryAttributes.Strength = 1;
            PrimaryAttributes.Dexterity = 7;
            PrimaryAttributes.Intelligence = 1;
        }

        /// <summary>
        /// Instantiate character when level up required.
        /// </summary>
        public override void LevelUp()
        {
            // Increase level of character
            IncreaseLevel();

            // Increase attributes with values of the ranger
            PrimaryAttributes.Strength += 1;
            PrimaryAttributes.Dexterity += 5;
            PrimaryAttributes.Intelligence += 1;
        }

        protected override double GetBaseTotalAttribute()
        {
            TotalPrimaryAttributes = PrimaryAttributes.Dexterity;

            return TotalPrimaryAttributes;
        }
    }
}
