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
            mage.DisplayCharacterStatistics();
            Character ranger = new Ranger();
            ranger.DisplayCharacterStatistics();
            Character rogue = new Rogue();
            rogue.DisplayCharacterStatistics();
            Character warrior = new Warrior();
            warrior.DisplayCharacterStatistics();

            // should throw exception
            //WeaponAttributes attr = new WeaponAttributes() { damage = 12, attackSpeed = 0.8 };
            //Weapon staff = new Weapon(Weapons.Staffs, attr);
            //warrior.Equip(staff, Slot.Weapon);

            WeaponAttributes attrAxe = new WeaponAttributes() { damage = 12, attackSpeed = 0.8 };
            Weapon axe = new Weapon(Weapons.Axes, attrAxe);
            axe.RequiredLevel = 2;
            warrior.Equip(axe, Slot.Weapon);

            Console.WriteLine();
            
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
