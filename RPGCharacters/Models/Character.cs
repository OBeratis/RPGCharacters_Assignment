using RPGCharacters.Custom_Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacters.Models
{
    public abstract class Character : Hero
    {
        // Fields
        private double damage = 1.0;
        private PrimaryAttributes primaryAttributes;
        private Dictionary<Slot, Item> equipment;
        private List<Weapons> usableWeapons;
        private List<Armors> usableArmor;

        protected Character()
        {
            this.Equipment = new Dictionary<Slot, Item>();
        }

        // Properties
        public override string Name { get => name; set => name = value; }
        public override int Level { get => level; set => level = value; }
        public override int BasePrimaryAttributes { get => basePrimaryAttributes; set => basePrimaryAttributes = value; }
        public override int TotalPrimaryAttributes { get => totalPrimaryAttributes; set => totalPrimaryAttributes = value; }

        public List<Weapons> UsableWeapons { get => usableWeapons; set => usableWeapons = value; }
        public List<Armors> UsableArmor { get => usableArmor; set => usableArmor = value; }
        public double Damage { 
            get
            {
                double dps = 1.0;
                double characterAttributes = this.GetBaseTotalAttribute();

                if (Equipment.Count == 0)
                {
                    damage = dps * (Level + (characterAttributes / 100));
                    return damage;
                }

                if (Equipment.Any(a => a.Value is Armor))
                {
                    foreach (var item in Equipment)
                    {
                        if (item.Value is Armor)
                        {
                            TotalPrimaryAttributes = ((Armor)item.Value).PrimaryAttributes.Strength + 
                                ((Armor)item.Value).PrimaryAttributes.Dexterity + 
                                ((Armor)item.Value).PrimaryAttributes.Intelligence;
                        }
                        else if (item.Value is Weapon)
                        {
                            dps = ((Weapon)item.Value).Dps;
                        }
                    }

                    damage = dps * (Level + ((characterAttributes + TotalPrimaryAttributes) / 100));
                    return damage;
                }
                else
                {
                    foreach (var item in Equipment)
                    {
                        if (item.Value is Weapon)
                        {
                            dps = ((Weapon)item.Value).Dps;
                        }
                    }

                    damage = dps * (Level + ((characterAttributes) / 100));
                    return damage;
                }
            }
        }
        public Dictionary<Slot, Item> Equipment { get => equipment; set => equipment = value; }
        public PrimaryAttributes PrimaryAttributes { get => primaryAttributes; set => primaryAttributes = value; }
        public override CharacterClass ClassType { get => classType; set => classType = value; }
        protected abstract void InitializePrimaryAttributes();
        protected abstract Double GetBaseTotalAttribute();

        // Methods

        /// <summary>
        /// Increase level of a character by 1.
        /// </summary>
        public override void IncreaseLevel() { Level++; }

        /// <summary>
        /// Increase base primary attributes of each character by 1.
        /// </summary>
        public override void IncreasePrimaryAttributes() { basePrimaryAttributes++; }

        /// <summary>
        /// Display statistics to a character sheet to console.
        /// </summary>
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

        /// <summary>
        /// Adds a new weapon to the equipment in the available slot.
        /// </summary>
        /// <param name="weapon">Item that is added to the equipment.</param>
        /// <param name="slot">The slot the item was added into.</param>
        /// <exception cref="InvalidWeaponException"></exception>
        /// <exception cref="InvalidWeaponException">When the weapon check is not passed.</exception>
        public string Equip(Weapon weapon, Slot slot)
        {
            // prüfe level des characters -> ist dieser ausreichend? wenn nein -> exception
            // weapon.requiredLevel > this.Level?
            if (weapon.RequiredLevel > this.Level)
            {
                throw new InvalidWeaponException("Character tries to equip a high level weapon.");
            }

            // prüfe Klasse des characters -> ist diese erlaubt für den waffentyp? wenn nein -> exception
            if (!this.usableWeapons.Contains(weapon.Type))
            {
                throw new InvalidWeaponException("Character tries to equip a wrong weapon type.");
            }

            // throw exception -> ich kann eine Waffe nicht in einem nicht-waffen slot ausrüsten
            if (slot != Slot.Weapon)
            {
                throw new InvalidWeaponException("Weapon can only equipped in a weapon slot.");
            }

            // alle prüfungen überstanden? -> in das equipment eintragen 
            this.Equipment.Add(slot, weapon);

            return "New weapon equipped!";
        }

        /// <summary>
        /// Add a new armor to the equipment in the available slot.
        /// </summary>
        /// <param name="armor">Item that is added to the equipment.</param>
        /// <param name="slot">The slot the item was added into.</param>
        /// <exception cref="InvalidArmorException">When the armor check is not passed.</exception>
        public string Equip(Armor armor, Slot slot)
        {
            if (armor.RequiredLevel > this.Level)
            {
                throw new InvalidArmorException("Character tries to equip a high level armor.");
            }

            if (!this.usableArmor.Contains(armor.Type))
            {
                throw new InvalidArmorException("Character tries to equip a wrong armor type.");
            }

            // throw exception -> ich kann eine rüstung nicht in einem waffen slot ausrüsten
            if (slot == Slot.Weapon)
            {
                throw new InvalidArmorException("Armor can only equipped in an non-weapon slot.");
            }

            this.Equipment.Add(slot, armor);

            return "New armour equipped!";
        }
    }
}
