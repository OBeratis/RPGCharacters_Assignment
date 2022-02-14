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
            // Set characters classs type
            classType = CharacterClass.Rogue;

            // Initialize with default values
            InitializePrimaryAttributes();

            // Assign to shich weapons and armor a rogue can have
            UsableWeapons = new List<Weapons> { Weapons.Daggers };
            UsableArmor = new List<Armors> { Armors.Leather, Armors.Mail };
        }

        /// <summary>
        /// Initialize characters attributes when the roque class is created.
        /// </summary>
        protected override void InitializePrimaryAttributes()
        {
            PrimaryAttributes = new PrimaryAttributes();
            PrimaryAttributes.Strength = 2;
            PrimaryAttributes.Dexterity = 6;
            PrimaryAttributes.Intelligence = 1;
        }

        /// <summary>
        /// Instantiate character when level up required.
        /// </summary>
        public override void LevelUp()
        {
            // Increase level of character
            IncreaseLevel();

            // Increase attributes with values of the roque
            PrimaryAttributes.Strength += 1;
            PrimaryAttributes.Dexterity += 4;
            PrimaryAttributes.Intelligence += 1;
        }

        protected override double GetBaseTotalAttribute()
        {
            TotalPrimaryAttributes = PrimaryAttributes.Dexterity;

            return TotalPrimaryAttributes;
        }
    }
}
