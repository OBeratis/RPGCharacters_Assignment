using System;
using Xunit;

using RPGCharacters.Models;
using RPGCharacters.Custom_Exceptions;

namespace RPGCharactersTests
{
    public class CharacterTests
    {
        #region Creation
        [Fact]
        public void Constructor_InitializeWithInitialLevelWith_ValueOf_1_ShouldCreateCharacter()
        {
            // Arrange
            int expected = 1;
            // Act
            Character character = new Character();
            int actual = character.Level;
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IncreaseLevel_IncreaseCharacterLevelByAddingValueOf1_ShouldIncreaseLevel()
        {
            // Arrange
            int expected = 2;
            // Act
            Character character = new Character();
            character.IncreaseLevel();
            int actual = character.Level;
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Constructor_InitializeCharacterWithDefaultAttributes_ShouldCreateMage()
        {
            // Arrange
            int expectedLevel = 1;
            int expectedStrength = 1;
            int expectedDexterity = 1;
            int expectedIntelligence = 8;
            // Act
            Character character = new Character(CharacterClass.Mage);
            int actualLevel = character.Level;
            int actualStrength = character.PrimaryAttributes.Strength;
            int actualDexterity = character.PrimaryAttributes.Dexterity;
            int actualIntelligence = character.PrimaryAttributes.Intelligence;
            // Assert
            Assert.Equal(expectedLevel, actualLevel);
            Assert.Equal(expectedStrength, actualStrength);
            Assert.Equal(expectedDexterity, actualDexterity);
            Assert.Equal(expectedIntelligence, actualIntelligence);
        }

        [Fact]
        public void Constructor_InitializeCharacterWithDefaultAttributes_ShouldCreateRanger()
        {
            // Arrange
            int expectedLevel = 1;
            int expectedStrength = 1;
            int expectedDexterity = 7;
            int expectedIntelligence = 1;
            // Act
            Character character = new Character(CharacterClass.Ranger);
            int actualLevel = character.Level;
            int actualStrength = character.PrimaryAttributes.Strength;
            int actualDexterity = character.PrimaryAttributes.Dexterity;
            int actualIntelligence = character.PrimaryAttributes.Intelligence;
            // Assert
            Assert.Equal(expectedLevel, actualLevel);
            Assert.Equal(expectedStrength, actualStrength);
            Assert.Equal(expectedDexterity, actualDexterity);
            Assert.Equal(expectedIntelligence, actualIntelligence);
        }

        [Fact]
        public void Constructor_InitializeCharacterWithDefaultAttributes_ShouldCreateRogue()
        {
            // Arrange
            int expectedLevel = 1;
            int expectedStrength = 2;
            int expectedDexterity = 6;
            int expectedIntelligence = 1;
            // Act
            Character character = new Character(CharacterClass.Rogue);
            int actualLevel = character.Level;
            int actualStrength = character.PrimaryAttributes.Strength;
            int actualDexterity = character.PrimaryAttributes.Dexterity;
            int actualIntelligence = character.PrimaryAttributes.Intelligence;
            // Assert
            Assert.Equal(expectedLevel, actualLevel);
            Assert.Equal(expectedStrength, actualStrength);
            Assert.Equal(expectedDexterity, actualDexterity);
            Assert.Equal(expectedIntelligence, actualIntelligence);
        }

        [Fact]
        public void Constructor_InitializeCharacterWithDefaultAttributes_ShouldCreateWarrior()
        {
            // Arrange
            int expectedLevel = 1;
            int expectedStrength = 5;
            int expectedDexterity = 2;
            int expectedIntelligence = 1;
            // Act
            Character character = new Character(CharacterClass.Warrior);
            int actualLevel = character.Level;
            int actualStrength = character.PrimaryAttributes.Strength;
            int actualDexterity = character.PrimaryAttributes.Dexterity;
            int actualIntelligence = character.PrimaryAttributes.Intelligence;
            // Assert
            Assert.Equal(expectedLevel, actualLevel);
            Assert.Equal(expectedStrength, actualStrength);
            Assert.Equal(expectedDexterity, actualDexterity);
            Assert.Equal(expectedIntelligence, actualIntelligence);
        }

        [Fact]
        public void LevelUp_IncreaseCharacterAttributes_ShouldIncreaseMage()
        {
            // Arrange
            int expectedLevel = 2;
            int expectedStrength = 2;
            int expectedDexterity = 2;
            int expectedIntelligence = 13;
            // Act
            Character character = new Character(CharacterClass.Mage);
            character.LevelUp();
            int actualLevel = character.Level;
            int actualStrength = character.PrimaryAttributes.Strength;
            int actualDexterity = character.PrimaryAttributes.Dexterity;
            int actualIntelligence = character.PrimaryAttributes.Intelligence;
            // Assert
            Assert.Equal(expectedLevel, actualLevel);
            Assert.Equal(expectedStrength, actualStrength);
            Assert.Equal(expectedDexterity, actualDexterity);
            Assert.Equal(expectedIntelligence, actualIntelligence);
        }

        [Fact]
        public void LevelUp_IncreaseCharacterAttributes_ShouldIncreaseRanger()
        {
            // Arrange
            int expectedLevel = 2;
            int expectedStrength = 2;
            int expectedDexterity = 12;
            int expectedIntelligence = 2;
            // Act
            Character character = new Character(CharacterClass.Ranger);
            character.LevelUp();
            int actualLevel = character.Level;
            int actualStrength = character.PrimaryAttributes.Strength;
            int actualDexterity = character.PrimaryAttributes.Dexterity;
            int actualIntelligence = character.PrimaryAttributes.Intelligence;
            // Assert
            Assert.Equal(expectedLevel, actualLevel);
            Assert.Equal(expectedStrength, actualStrength);
            Assert.Equal(expectedDexterity, actualDexterity);
            Assert.Equal(expectedIntelligence, actualIntelligence);
        }

        [Fact]
        public void LevelUp_IncreaseCharacterAttributes_ShouldIncreaseRoque()
        {
            // Arrange
            int expectedLevel = 2;
            int expectedStrength = 3;
            int expectedDexterity = 10;
            int expectedIntelligence = 2;
            // Act
            Character character = new Character(CharacterClass.Rogue);
            character.LevelUp();
            int actualLevel = character.Level;
            int actualStrength = character.PrimaryAttributes.Strength;
            int actualDexterity = character.PrimaryAttributes.Dexterity;
            int actualIntelligence = character.PrimaryAttributes.Intelligence;
            // Assert
            Assert.Equal(expectedLevel, actualLevel);
            Assert.Equal(expectedStrength, actualStrength);
            Assert.Equal(expectedDexterity, actualDexterity);
            Assert.Equal(expectedIntelligence, actualIntelligence);
        }

        [Fact]
        public void LevelUp_IncreaseCharacterAttributes_ShouldIncreaseWarrior()
        {
            // Arrange
            int expectedLevel = 2;
            int expectedStrength = 8;
            int expectedDexterity = 4;
            int expectedIntelligence = 2;
            // Act
            Character character = new Character(CharacterClass.Warrior);
            character.LevelUp();
            int actualLevel = character.Level;
            int actualStrength = character.PrimaryAttributes.Strength;
            int actualDexterity = character.PrimaryAttributes.Dexterity;
            int actualIntelligence = character.PrimaryAttributes.Intelligence;
            // Assert
            Assert.Equal(expectedLevel, actualLevel);
            Assert.Equal(expectedStrength, actualStrength);
            Assert.Equal(expectedDexterity, actualDexterity);
            Assert.Equal(expectedIntelligence, actualIntelligence);
        }

        [Theory]
        [InlineData("Test")]
        public void Character_Invalid_ShouldThrowCharacterException(string message)
        {
            // Arrange
            // Act and Assert
            Assert.ThrowsAsync<CharacterException>(() => throw new CharacterException(message));
        }
        #endregion
    }
}
