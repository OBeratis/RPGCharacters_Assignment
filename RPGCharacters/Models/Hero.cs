using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacters.Models
{
    public abstract class Hero
    {
        // Fields
        protected CharacterClass classType;
        protected string name = "";
        protected int level = 1;
        protected int basePrimaryAttributes = 0;
        protected int totalPrimaryAttributes = 0;

        // Properties
        public abstract CharacterClass ClassType { get; set; }
        public abstract string Name { get; set; }
        public abstract int Level { get; set; }
        public abstract int BasePrimaryAttributes { get; set; }
        public abstract int TotalPrimaryAttributes { get; set; }

        // Methods
        public abstract void IncreaseLevel();
        public abstract void IncreasePrimaryAttributes();
        public abstract void LevelUp();
        public abstract void DisplayCharacterStatistics();
    }

}
