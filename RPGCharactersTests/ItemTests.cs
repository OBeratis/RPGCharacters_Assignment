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
        public void CharacterWarrior_EquipAxeAndRequiredLevel2_ShouldThrowInvalidWeaponException()
        {
            // Arrange
            Character warrior = new Warrior();
            WeaponAttributes weaponAttr = new WeaponAttributes() { damage = 12, attackSpeed = 0.8 };
            Weapon weapon = new Weapon(Weapons.Axes, weaponAttr);
            weapon.RequiredLevel = 2;
            // Act
            warrior.Equip(weapon, Slot.Weapon);
            // Assert
            Assert.ThrowsAsync<InvalidWeaponException>(() => throw new InvalidWeaponException("Character tries to equip a high level weapon."));
        }

        [Fact]
        public void CharacterWarrior_EquipPlateBodyArmorAndRequiredLevel2_ShouldThrowInvalidArmorException()
        {
            // Arrange
            Character warrior = new Warrior();
            PrimaryAttributes primaryAttr = new PrimaryAttributes() { Strength = 1 };
            Armor armor = new Armor(Armors.Plate, primaryAttr);
            armor.RequiredLevel = 2;
            // Act
            warrior.Equip(armor, Slot.Body);
            // Assert
            Assert.ThrowsAsync<InvalidArmorException>(() => throw new InvalidArmorException("Character tries to equip a high level armor piece."));
        }

        [Fact]
        public void CharacterWarrior_EquipWrongWeaponType_ShouldThrowInvalidWeaponException()
        {
            // Arrange
            Character warrior = new Warrior();
            WeaponAttributes weaponAttr = new WeaponAttributes() { damage = 12, attackSpeed = 0.8 };
            Weapon weapon = new Weapon(Weapons.Bows, weaponAttr);
            // Act
            warrior.Equip(weapon, Slot.Weapon);
            // Assert
            Assert.ThrowsAsync<InvalidWeaponException>(() => throw new InvalidWeaponException("Character tries to equip the wrong weapon type."));
        }

        [Fact]
        public void CharacterWarrior_EquipWrongArmorType_ShouldThrowInvalidArmorException()
        {
            // Arrange
            Character warrior = new Warrior();
            PrimaryAttributes primaryAttr = new PrimaryAttributes() { Intelligence = 5 };
            Armor armor = new Armor(Armors.Cloth, primaryAttr);
            // Act
            warrior.Equip(armor, Slot.Head);
            // Assert
            Assert.ThrowsAsync<InvalidArmorException>(() => throw new InvalidArmorException("Character tries to equip the wrong armor type."));
        }

        [Fact]
        public void CharacterMage_EquipValidWeapon_ShouldAddingIntoMageEquipment()
        {
            // Arrange
            Character mage = new Mage();
            WeaponAttributes weaponAttr = new WeaponAttributes() { attackSpeed = 1.0, damage = 1 };
            Weapon weapon = new Weapon(Weapons.Wands, weaponAttr);
            // Act
            mage.Equip(weapon, Slot.Weapon);
            // Assert

        }

        [Fact]
        public void CharacterMage_EquipValidArmor_ShouldAddingIntoMageEquipment()
        {
            // Arrange
            Character mage = new Mage();
            PrimaryAttributes primaryAttr = new PrimaryAttributes() { Intelligence = 5 };
            Armor armor = new Armor(Armors.Cloth, primaryAttr);
            // Act
            mage.Equip(armor, Slot.Body);
            //Assert

        }

        [Fact]
        public void CharacterWarrior_CalculateDamageWithNoWeaponEquip_ShouldReturnDamage()
        {
            // Arrange
            double expected = 0.0;
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
            double expected = 0.0;
            Character warrior = new Warrior();
            WeaponAttributes weaponAttr = new WeaponAttributes() { attackSpeed = 1.1, damage = 1 };
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
            double expected = 0.0;
            Character warrior = new Warrior();
            WeaponAttributes weaponAttr = new WeaponAttributes() { attackSpeed = 1.1, damage = 1 };
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

        [Theory]
        [InlineData("Test")]
        public void Character_Invalid_ShouldThrowArmorException(string message)
        {
            // Arrange
            // Act and Assert
            Assert.ThrowsAsync<InvalidArmorException>(() => throw new InvalidArmorException(message));
        }

        [Theory]
        [InlineData("Test")]
        public void Character_Invalid_ShouldThroWeaponException(string message)
        {
            // Arrange
            // Act and Assert
            Assert.ThrowsAsync<InvalidWeaponException>(() => throw new InvalidWeaponException(message));
        }
        #endregion

    }
}
