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
            //bool bThrowCustomException = true;

            // Weapon exception test
            //try
            //{
            //    TestWeaponException(bThrowCustomException);
            //}
            //catch (InvalidWeaponException wex)
            //{
            //    Console.WriteLine($"Weapon exception: {wex.Message}");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"General weapon exception: {ex.Message}");
            //}

            // Armor exception test
            //try
            //{
            //    TestArmorException(bThrowCustomException);
            //}
            //catch (InvalidArmorException aex)
            //{
            //    Console.WriteLine($"Armor exception: {aex.Message}");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"General armor exception: {ex.Message}");
            //}

            Character mage = new Character(CharacterClass.Mage);
            mage.DisplayCharacterStatistics();
            Character ranger = new Character(CharacterClass.Ranger);
            ranger.DisplayCharacterStatistics();
            Character rogue = new Character(CharacterClass.Rogue);
            rogue.DisplayCharacterStatistics();
            Character warrior = new Character(CharacterClass.Warrior);
            warrior.DisplayCharacterStatistics();

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
