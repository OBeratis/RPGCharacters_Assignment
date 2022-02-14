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
            // Set characters classs type
            classType = CharacterClass.Mage;

            // Initialize with default values
            InitializePrimaryAttributes();

            // Assign to shich weapons and armor a mage can have
            UsableWeapons = new List<Weapons> { Weapons.Staffs, Weapons.Wands };
            UsableArmor = new List<Armors> { Armors.Cloth };
        }

        /// <summary>
        /// Initialize characters attributes when the mage class is created.
        /// </summary>
        protected override void InitializePrimaryAttributes()
        {
            PrimaryAttributes = new PrimaryAttributes();
            PrimaryAttributes.Strength = 1;
            PrimaryAttributes.Dexterity = 1;
            PrimaryAttributes.Intelligence = 8;
        }

        /// <summary>
        /// Instantiate character when level up required.
        /// </summary>
        public override void LevelUp()
        {
            // Increase level of character
            IncreaseLevel();

            // Increase attributes with values of the mage
            PrimaryAttributes.Strength += 1;
            PrimaryAttributes.Dexterity += 1;
            PrimaryAttributes.Intelligence += 5;
        }

        protected override double GetBaseTotalAttribute()
        {
            TotalPrimaryAttributes = PrimaryAttributes.Intelligence;

            return TotalPrimaryAttributes;
        }
    }
}

