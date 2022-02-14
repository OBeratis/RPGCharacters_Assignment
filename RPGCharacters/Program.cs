using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using RPGCharacters.Custom_Exceptions;
using RPGCharacters.Models;

namespace RPGCharacters
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool bThrowCustomException = true;

            // Weapon exception test
            try
            {
                TestWeaponException(bThrowCustomException);
            }
            catch (InvalidWeaponException wex)
            {
                Console.WriteLine($"Weapon exception: {wex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General weapon exception: {ex.Message}");
            }

            // Armor exception test
            try
            {
                TestArmorException(bThrowCustomException);
            }
            catch (InvalidArmorException aex)
            {
                Console.WriteLine($"Armor exception: {aex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General armor exception: {ex.Message}");
            }

            Character mage = new Mage();
            // mage.DisplayCharacterStatistics();
            Character ranger = new Ranger();
            // ranger.DisplayCharacterStatistics();
            Character rogue = new Rogue();
            // rogue.DisplayCharacterStatistics();
            Character warrior = new Warrior();
            // warrior.DisplayCharacterStatistics();
            Console.WriteLine();

            // should throw exception
            //WeaponAttributes attr = new WeaponAttributes() { damage = 12, attackSpeed = 0.8 };
            //Weapon staff = new Weapon(Weapons.Staffs, attr);
            //warrior.Equip(staff, Slot.Weapon);

            WeaponAttributes weaponAttr = new WeaponAttributes() { damage = 12, attackSpeed = 0.8 };
            Weapon weapon = new Weapon(Weapons.Axes, weaponAttr);
            weapon.RequiredLevel = 2;
            try
            {
                warrior.Equip(weapon, Slot.Weapon);
            }
            catch (InvalidWeaponException wex)
            {
                Console.WriteLine($"Test 1: {wex.Message}");
            }

            PrimaryAttributes primaryAttr = new PrimaryAttributes() { Strength = 1 };
            Armor armor = new Armor(Armors.Plate, primaryAttr);
            armor.RequiredLevel = 2;
            try
            {
                warrior.Equip(armor, Slot.Body);
            }
            catch (InvalidArmorException aex)
            {
                Console.WriteLine($"Test 2: {aex.Message}");
            }

            weaponAttr = new WeaponAttributes() { damage = 12, attackSpeed = 0.8 };
            weapon = new Weapon(Weapons.Bows, weaponAttr);
            try
            {
                warrior.Equip(weapon, Slot.Weapon);
            }
            catch (InvalidWeaponException wex)
            {
                Console.WriteLine($"Test 3: {wex.Message}");
            }

            primaryAttr = new PrimaryAttributes() { Intelligence = 5 };
            armor = new Armor(Armors.Cloth, primaryAttr);
            try
            {
                warrior.Equip(armor, Slot.Head);
            }
            catch (InvalidArmorException aex)
            {
                Console.WriteLine($"Test 4: {aex.Message}");
            }

            weaponAttr = new WeaponAttributes() { attackSpeed = 1.0, damage = 1 };
            weapon = new Weapon(Weapons.Wands, weaponAttr);
            try
            {
                mage.Equip(weapon, Slot.Weapon);
                Console.WriteLine("New weapon equipped!");
            }
            catch (InvalidWeaponException wex)
            {
                Console.WriteLine($"Test 5: {wex.Message}");
            }

            primaryAttr = new PrimaryAttributes() { Intelligence = 5 };
            armor = new Armor(Armors.Cloth, primaryAttr);
            try
            {
                mage.Equip(armor, Slot.Body);
                Console.WriteLine("New armor equipped!");
            }
            catch (InvalidArmorException aex)
            {
                Console.WriteLine($"Test 6: {aex.Message}");
            }

            warrior = new Warrior();
            try
            {
                var damage = warrior.Damage;
                Console.WriteLine($"Test 7: should return 1.05");
                Console.WriteLine($"Test 7: {damage}");
            }
            catch 
            {

            }

            warrior = new Warrior();
            weaponAttr = new WeaponAttributes() { attackSpeed = 1.1, damage = 7 };
            weapon = new Weapon(Weapons.Axes, weaponAttr);
            try
            {
                warrior.Equip(weapon, Slot.Weapon);
                var damage = warrior.Damage;
                Console.WriteLine($"Test 8: should return 8.085");
                Console.WriteLine($"Test 8: {damage}");
            }
            catch (InvalidWeaponException wex)
            {
                Console.WriteLine($"Test 8: {wex.Message}");
            }

            warrior = new Warrior();
            weaponAttr = new WeaponAttributes() { attackSpeed = 1.1, damage = 7 };
            weapon = new Weapon(Weapons.Axes, weaponAttr);
            primaryAttr = new PrimaryAttributes() { Intelligence = 1 };
            armor = new Armor(Armors.Plate, primaryAttr);
            try
            {
                weapon = new Weapon(Weapons.Axes, weaponAttr);
                warrior.Equip(weapon, Slot.Weapon);
                warrior.Equip(armor, Slot.Body);
                var damage = warrior.Damage;
                Console.WriteLine($"Test 9: should return 8.162");
                Console.WriteLine($"Test 9: {damage}");
            }
            catch (InvalidWeaponException wex)
            {
                Console.WriteLine($"Test 9: {wex.Message}");
            }

        }

        public static void TestWeaponException(bool throwException)
        {
            if (throwException)
            {
                throw new InvalidWeaponException();
            }

            throw new Exception();
        }

        public static void TestArmorException(bool throwException)
        {
            if (throwException)
            {
                throw new InvalidArmorException();
            }

            throw new Exception();
        }
    }
}
