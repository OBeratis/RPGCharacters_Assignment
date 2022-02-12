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
