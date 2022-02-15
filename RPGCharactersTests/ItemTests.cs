using System;
using Xunit;

using RPGCharacters.Models;
using RPGCharacters.Custom_Exceptions;

namespace RPGCharactersTests
{
    public class ItemTests
    {
        #region Item and Equipment
        [Fact]
        // [InlineData("Character tries to equip a high level weapon.")]
        public void CharacterWarrior_EquipAxeAndRequiredLevel2_ShouldThrowInvalidWeaponException()
        {
            // Arrange
            int expectedDamage = 12;
            double expectedAttackSpeed = 0.8;
            int expectedRequiredLevel = 2;
            Character warrior = new Warrior();
            WeaponAttributes weaponAttr = new WeaponAttributes() { damage = expectedDamage, attackSpeed = expectedAttackSpeed };
            Weapon weapon = new Weapon(Weapons.Axes, weaponAttr);
            weapon.RequiredLevel = expectedRequiredLevel;
            // Act and assert
            Assert.Throws<InvalidWeaponException>(() => warrior.Equip(weapon, Slot.Weapon));
        }

        [Fact]
        // [InlineData("Character tries to equip a high level armor piece.")]
        public void CharacterWarrior_EquipPlateBodyArmorAndRequiredLevel2_ShouldThrowInvalidArmorException()
        {
            // Arrange
            int expectedStrength = 1;
            int expectedRequiredLevel = 2;
            Character warrior = new Warrior();
            PrimaryAttributes primaryAttr = new PrimaryAttributes() { Strength = expectedStrength };
            Armor armor = new Armor(Armors.Plate, primaryAttr);
            armor.RequiredLevel = expectedRequiredLevel;
            // Act and assert
            Assert.Throws<InvalidArmorException>(() => warrior.Equip(armor, Slot.Body));
        }

        [Fact]
        // [InlineData("Character tries to equip the wrong weapon type.")]
        public void CharacterWarrior_EquipWrongWeaponType_ShouldThrowInvalidWeaponException()
        {
            // Arrange
            int expectedDamage = 12;
            double expectedAttackSpeed = 0.8;
            Character warrior = new Warrior();
            WeaponAttributes weaponAttr = new WeaponAttributes() { damage = expectedDamage, attackSpeed = expectedAttackSpeed };
            Weapon weapon = new Weapon(Weapons.Bows, weaponAttr);
            // Act and assert
            Assert.Throws<InvalidWeaponException>(() => warrior.Equip(weapon, Slot.Weapon));
        }

        [Fact]
        // [InlineData("Character tries to equip the wrong armor type.")]
        public void CharacterWarrior_EquipWrongArmorType_ShouldThrowInvalidArmorException()
        {
            // Arrange
            int expectedIntelligence = 5;
            Character warrior = new Warrior();
            PrimaryAttributes primaryAttr = new PrimaryAttributes() { Intelligence = expectedIntelligence };
            Armor armor = new Armor(Armors.Cloth, primaryAttr);
            // Act and assert
            Assert.Throws<InvalidArmorException>(() => warrior.Equip(armor, Slot.Head));
        }

        [Fact]
        public void CharacterMage_EquipValidWeapon_ShouldAddingIntoMageEquipment()
        {
            // Arrange
            int expectedDamage = 1;
            double expectedAttackSpeed = 1.0;
            string expected = "New weapon equipped!";
            Character mage = new Mage();
            WeaponAttributes weaponAttr = new WeaponAttributes() { attackSpeed = expectedAttackSpeed, damage = expectedDamage };
            Weapon weapon = new Weapon(Weapons.Wands, weaponAttr);
            // Act
            string actual = mage.Equip(weapon, Slot.Weapon);
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CharacterMage_EquipValidArmor_ShouldAddingIntoMageEquipment()
        {
            // Arrange
            string expected = "New armour equipped!";
            Character mage = new Mage();
            PrimaryAttributes primaryAttr = new PrimaryAttributes() { Intelligence = 5 };
            Armor armor = new Armor(Armors.Cloth, primaryAttr);
            // Act
            string actual = mage.Equip(armor, Slot.Body);
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CharacterWarrior_CalculateDamageWithNoWeaponEquip_ShouldReturnDamage()
        {
            // Arrange
            double expected = 1.05;
            Character warrior = new Warrior();
            // Act
            double actual = warrior.Damage;
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CharacterWarrior_CalculateDamageWithValidWeaponEquip_ShouldReturnDamage()
        {
            // Arrange
            int expectedDamage = 7;
            double expectedAttackSpeed = 1.1;
            double expected = 8.085;
            Character warrior = new Warrior();
            WeaponAttributes weaponAttr = new WeaponAttributes() { attackSpeed = expectedAttackSpeed, damage = expectedDamage };
            Weapon weapon = new Weapon(Weapons.Axes, weaponAttr);
            // Act
            warrior.Equip(weapon, Slot.Weapon);
            double actual = warrior.Damage;
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CharacterWarrior_CalculateDamageWithValidWeaponAndArmor_ShouldReturnDamage()
        {
            // Arrange
            int expectedDamage = 7;
            double expectedAttackSpeed = 1.1;
            double expected = 8.162;
            Character warrior = new Warrior();
            WeaponAttributes weaponAttr = new WeaponAttributes() { attackSpeed = expectedAttackSpeed, damage = expectedDamage };
            Weapon weapon = new Weapon(Weapons.Axes, weaponAttr);
            PrimaryAttributes primaryAttr = new PrimaryAttributes() { Intelligence = 1 };
            Armor armor = new Armor(Armors.Plate, primaryAttr);
            // Act
            weapon = new Weapon(Weapons.Axes, weaponAttr);
            warrior.Equip(weapon, Slot.Weapon);
            warrior.Equip(armor, Slot.Body);
            double actual = warrior.Damage;
            // Assert
            Assert.Equal(expected, actual);
        }
        #endregion

    }
}
