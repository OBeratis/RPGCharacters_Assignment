using RPGCharacters.Custom_Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacters.Models
{
    public class Character : Hero, ICalculatorTotal
    {
        // Fields
        private int damage;
        private int attackSpeed;

        private PrimaryAttributes primaryAttributes;
        private Dictionary<Slot, Item> equipment;

        // Constructors
        public Character()
        {
        }
        public Character(CharacterClass classType)
        {
            this.ClassType = classType;

            InitializePrimaryAttributes();
        }

        // Properties
        public override string Name { get => name; set => name = value; }
        public override int Level { get => level; set => level = value; }
        public override int BasePrimaryAttributes { get => basePrimaryAttributes; set => basePrimaryAttributes = value; }
        public override int TotalPrimaryAttributes { get => totalPrimaryAttributes; set => totalPrimaryAttributes = value; }
        public int Damage { get => damage; set => damage = value; }
        public int AttackSpeed { get => attackSpeed; set => attackSpeed = value; }
        public Dictionary<Slot, Item> Equipment { get => equipment; set => equipment = value; }
        public PrimaryAttributes PrimaryAttributes { get => primaryAttributes; set => primaryAttributes = value; }
        public override CharacterClass ClassType { get => classType; set => classType = value; }

        // Methods
        public override void IncreaseLevel() { Level++; }
        public override void IncreasePrimaryAttributes() { basePrimaryAttributes++; }
        public override void LevelUp()
        {
            switch (this.ClassType)
            {
                case CharacterClass.Mage:
                    IncreaseLevel();
                    PrimaryAttributes.Strength += 1;
                    PrimaryAttributes.Dexterity += 1;
                    PrimaryAttributes.Intelligence += 5;
                    break;
                case CharacterClass.Ranger:
                    IncreaseLevel();
                    PrimaryAttributes.Strength += 1;
                    PrimaryAttributes.Dexterity += 5;
                    PrimaryAttributes.Intelligence += 1;
                    break;
                case CharacterClass.Rogue:
                    IncreaseLevel();
                    PrimaryAttributes.Strength += 1;
                    PrimaryAttributes.Dexterity += 4;
                    PrimaryAttributes.Intelligence += 1;
                    break;
                case CharacterClass.Warrior:
                    IncreaseLevel();
                    PrimaryAttributes.Strength += 3;
                    PrimaryAttributes.Dexterity += 2;
                    PrimaryAttributes.Intelligence += 1;
                    break;
                default:
                    break;
            }
        }
        public override void DisplayCharacterStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Character statistics");
            sb.AppendLine("-----------------------");
            sb.AppendLine($"Character name: {this.ClassType.ToString()}");
            sb.AppendLine($"Character level: {this.Level}");
            sb.AppendLine($"Strength: {this.PrimaryAttributes.Strength}");
            sb.AppendLine($"Dexterity: {this.PrimaryAttributes.Dexterity}");
            sb.AppendLine($"Intelligence: {this.PrimaryAttributes.Intelligence}");
            sb.AppendLine($"Damage: {this.Damage}");

            Console.WriteLine(sb.ToString());
        }
        private void InitializePrimaryAttributes()
        {
            PrimaryAttributes = new PrimaryAttributes();
            switch (this.ClassType)
            {
                case CharacterClass.Mage:
                    PrimaryAttributes.Strength = 1;
                    PrimaryAttributes.Dexterity = 1;
                    PrimaryAttributes.Intelligence = 8;
                    break;
                case CharacterClass.Ranger:
                    PrimaryAttributes.Strength = 1;
                    PrimaryAttributes.Dexterity = 7;
                    PrimaryAttributes.Intelligence = 1;
                    break;
                case CharacterClass.Rogue:
                    PrimaryAttributes.Strength = 2;
                    PrimaryAttributes.Dexterity = 6;
                    PrimaryAttributes.Intelligence = 1;
                    break;
                case CharacterClass.Warrior:
                    PrimaryAttributes.Strength = 5;
                    PrimaryAttributes.Dexterity = 2;
                    PrimaryAttributes.Intelligence = 1;
                    break;
                default:
                    break;
            }
        }
        public void Equip(Weapon weapon, Slot slot)
        {
            // prüfe level des characters -> ist dieser ausreichend? wenn nein -> exception
            // weapon.requiredLevel <= this.Level?
            if (weapon.RequiredLevel <= this.Level)
            {
                throw new InvalidWeaponException();
            }

            // prüfe Klasse des characters -> ist diese erlaubt für den waffentyp? wenn nein -> exception
            if (!weapon.usableBy.Any(w => w.Key == weapon.Type && w.Value == this.ClassType))
            {
                throw new InvalidWeaponException();
            }

            // prüfe slot für waffe -> macht dieser sinn? wenn nein -> exception


            // alle prüfungen überstanden? -> in das equipment eintragen 
            this.Equipment.Add(slot, weapon);
        }
        public void Equip(Armor armor, Slot slot)
        {
            if (armor.RequiredLevel <= this.Level)
            {
                throw new InvalidArmorException();
            }

            if (!armor.usableBy.Any(w => w.Key == armor.Type && w.Value == this.ClassType))
            {
                throw new InvalidArmorException();
            }

            this.Equipment.Add(slot, armor);
        }
        public void CalculateAttributes()
        {
            switch(this.ClassType)
            {
                case CharacterClass.Mage:
                    PrimaryAttributes.Strength += 1;
                    PrimaryAttributes.Dexterity += 1;
                    PrimaryAttributes.Intelligence += 5;
                    break;
                case CharacterClass.Ranger:
                    PrimaryAttributes.Strength += 1;
                    PrimaryAttributes.Dexterity += 5;
                    PrimaryAttributes.Intelligence += 1;
                    break;
                case CharacterClass.Rogue:
                    PrimaryAttributes.Strength += 1;
                    PrimaryAttributes.Dexterity += 4;
                    PrimaryAttributes.Intelligence += 1;
                    break;
                case CharacterClass.Warrior:
                    PrimaryAttributes.Strength += 3;
                    PrimaryAttributes.Dexterity += 2;
                    PrimaryAttributes.Intelligence += 1;
                    break;
                default:
                    break;
            }
        }
        public void CalculateTotalAttribute()
        {
            foreach (var item in Equipment)
            {
                if (item.Value is Armor)
                {
                    // Total attribute = attributes from level + attributes from all equipped armor
                    TotalPrimaryAttributes = Level + 
                        (PrimaryAttributes.Dexterity + PrimaryAttributes.Strength + PrimaryAttributes.Intelligence);
                }
                else if (item.Value is Weapon)
                {
                    // Character damage = Weapon DPS * (1+TotalPrimaryAttribute/100)
                    Damage = item.Value.RequiredLevel * (1 + (TotalPrimaryAttributes / 100));
                }
                else
                {
                    throw new Exception("Something went wrong!");
                }
            }
        }
    }
}
