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
            // Set characters classs type
            classType = CharacterClass.Warrior;

            // Initialize with default values
            InitializePrimaryAttributes();

            // Assign to shich weapons and armor a warrior can have
            UsableWeapons = new List<Weapons> { Weapons.Swords, Weapons.Hammers, Weapons.Axes };
            UsableArmor = new List<Armors> { Armors.Mail, Armors.Plate };
        }

        /// <summary>
        /// Initialize characters attributes when the warrior class is created.
        /// </summary>
        protected override void InitializePrimaryAttributes()
        {
            PrimaryAttributes = new PrimaryAttributes();
            PrimaryAttributes.Strength = 5;
            PrimaryAttributes.Dexterity = 2;
            PrimaryAttributes.Intelligence = 1;
        }

        /// <summary>
        /// Instantiate character when level up required.
        /// </summary>
        public override void LevelUp()
        {
            // Increase level of character
            IncreaseLevel();

            // Increase attributes with values of the warrior
            PrimaryAttributes.Strength += 3;
            PrimaryAttributes.Dexterity += 2;
            PrimaryAttributes.Intelligence += 1;
        }

        protected override double GetBaseTotalAttribute()
        {
            TotalPrimaryAttributes = PrimaryAttributes.Strength;

            return TotalPrimaryAttributes;
        }
    }
}
