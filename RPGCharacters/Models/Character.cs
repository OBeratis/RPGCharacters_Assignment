using RPGCharacters.Custom_Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacters.Models
{
    public abstract class Character : Hero, ICalculatorTotal
    {
        // Fields
        private double damage = 1.0;
        private PrimaryAttributes primaryAttributes;
        private Dictionary<Slot, Item> equipment;
        private List<Weapons> usableWeapons;
        private List<Armors> usableArmor;

        // Properties
        public override string Name { get => name; set => name = value; }
        public override int Level { get => level; set => level = value; }
        public override int BasePrimaryAttributes { get => basePrimaryAttributes; set => basePrimaryAttributes = value; }
        public override int TotalPrimaryAttributes { get => totalPrimaryAttributes; set => totalPrimaryAttributes = value; }

        public List<Weapons> UsableWeapons { get => usableWeapons; set => usableWeapons = value; }
        public List<Armors> UsableArmor { get => usableArmor; set => usableArmor = value; }
        public double Damage { get => damage; set => damage = value; }
        public Dictionary<Slot, Item> Equipment { get => equipment; set => equipment = value; }
        public PrimaryAttributes PrimaryAttributes { get => primaryAttributes; set => primaryAttributes = value; }
        public override CharacterClass ClassType { get => classType; set => classType = value; }

        protected abstract void InitializePrimaryAttributes();

        // Methods
        public override void IncreaseLevel() { Level++; }
        public override void IncreasePrimaryAttributes() { basePrimaryAttributes++; }

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

        public void Equip(Weapon weapon, Slot slot)
        {
            // prüfe level des characters -> ist dieser ausreichend? wenn nein -> exception
            // weapon.requiredLevel <= this.Level?
            if (weapon.RequiredLevel > this.Level)
            {
                throw new InvalidWeaponException();
            }

            // prüfe Klasse des characters -> ist diese erlaubt für den waffentyp? wenn nein -> exception
            if (!this.usableWeapons.Contains(weapon.Type))
            {
                throw new InvalidWeaponException();
            }

            // throw exception -> ich kann eine Waffe nicht in einem nicht-waffen slot ausrüsten
            if (slot != Slot.Weapon)
            {
                throw new InvalidWeaponException();
            }

            // alle prüfungen überstanden? -> in das equipment eintragen 
            this.Equipment.Add(slot, weapon);
        }
        public void Equip(Armor armor, Slot slot)
        {
            if (armor.RequiredLevel > this.Level)
            {
                throw new InvalidArmorException();
            }

            if (!this.usableArmor.Contains(armor.Type))
            {
                throw new InvalidArmorException();
            }

            // throw exception -> ich kann eine rüstung nicht in einem waffen slot ausrüsten
            if (slot == Slot.Weapon)
            {
                throw new InvalidArmorException();
            }

            this.Equipment.Add(slot, armor);
        }

        public void CalculateTotalAttribute()
        {
            foreach (var item in Equipment)
            {
                if (item.Value is Armor)
                {
                    // Total attribute = attributes from level + attributes from all equipped armor
                    TotalPrimaryAttributes = Level + ((Armor) item.Value).PrimaryAttributes.Strength + ((Armor)item.Value).PrimaryAttributes.Dexterity + ((Armor)item.Value).PrimaryAttributes.Intelligence;
                }
                else if (item.Value is Weapon)
                {
                    // Character damage = Weapon DPS * (1+TotalPrimaryAttribute/100)
                    Damage = ((Weapon)item.Value).Dps * (1 + (TotalPrimaryAttributes / 100));
                }
            }
        }
    }
}
