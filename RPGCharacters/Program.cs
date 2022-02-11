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
            Character ranger = new Character(CharacterClass.Ranger);
            Character rogue = new Character(CharacterClass.Rogue);
            Character warrior = new Character(CharacterClass.Warrior);

            Console.WriteLine();
            DisplayCharacterStatistics(mage);
            DisplayCharacterStatistics(ranger);
            DisplayCharacterStatistics(rogue);
            DisplayCharacterStatistics(warrior);
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

        public static void DisplayCharacterStatistics(Character character)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Character statistics");
            sb.AppendLine("-----------------------");
            sb.AppendLine($"Character name: {character.ClassType.ToString()}");
            sb.AppendLine($"Character level: {character.Level}");
            sb.AppendLine($"Strength: {character.PrimaryAttributes.Strength}");
            sb.AppendLine($"Dexterity: {character.PrimaryAttributes.Dexterity}");
            sb.AppendLine($"Intelligence: {character.PrimaryAttributes.Intelligence}");
            sb.AppendLine($"Damage: {character.Damage}");

            Console.WriteLine(sb.ToString());
        }
    }
}
