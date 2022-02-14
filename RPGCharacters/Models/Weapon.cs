using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacters.Models
{

    public class Weapon : Item
    {
        // Fields
        private Weapons type;
        private int damage;
        private WeaponAttributes weaponAttributes;
        private double dps; //damagePerSecond

        // Contructor
        public Weapon(Weapons weapon, WeaponAttributes weaponAttributes)
        {
            this.type = weapon;
            this.Slot = Slot.Weapon;
            this.weaponAttributes = weaponAttributes;
            CalculateDps();
        }

        // Properties
        public Weapons Type { get => type; set => type = value; }
        public int Damage { get => damage; set => damage = value; }
        public double Dps { get => dps; set => dps = value; }
        public WeaponAttributes WeaponAttributes { get => weaponAttributes; set => weaponAttributes = value; }
        public override string Name { get => name; set => name = value; }
        public override string Equip { get => equip; set => equip = value; }
        public override Slot Slot { get => slot; set => slot = value; }
        public override int RequiredLevel { get => requiredLevel; set => requiredLevel = value; }

        /// <summary>
        /// Calculate weapons damage per second (DPS)
        /// </summary>
        private void CalculateDps()
        {
            Dps = weaponAttributes.damage * this.weaponAttributes.attackSpeed;
        }

    }

}
