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
        public void x_ShouldPass()
        {
            // Arrange

            // Act

            // Assert
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
