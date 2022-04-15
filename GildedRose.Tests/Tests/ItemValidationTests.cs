using GildedRose.Helpers.Constants;
using GildedRose.Validations;
using System.ComponentModel;
using Xunit;

namespace GildedRose.Tests.Tests
{
    public class ItemValidationTests
    {

        #region ItemValidation

        [Fact]
        [Trait("ItemValidation", "Conjured")]
        [Description("Retorna true se o item informado é conjurado.")]
        public void ItemValidation_ShouldBeTrue_WhenItemIsConjured()
        {
            //Arrange
            Item item = new Item { Name = "Conjured foo", Quality = 11, SellIn = 10 };

            //Act
            var act = ItemValidation.IsConjuredItem(item.Name);

            //Assert
            Assert.True(act);
        }

        [Fact]
        [Trait("ItemValidation", "Conjured")]
        [Description("Retorna false se o item informado não é conjurado.")]
        public void ItemValidation_ShouldBeFalse_WhenItemIsNotConjured()
        {
            //Arrange
            Item item = new Item { Name = "foo", Quality = 11, SellIn = 10 };

            //Act
            var act = ItemValidation.IsConjuredItem(item.Name);

            //Assert
            Assert.False(act);
        }

        [Fact]
        [Trait("ItemValidation", "MinQuality")]
        [Description("Retorna true se a qualidade do item passou da qualidade mínima.")]
        public void ItemValidation_ShouldBeTrue_WhenItemQualityHasPassedMinQuality()
        {
            //Arrange
            Item item = new Item { Name = "foo", Quality = -1, SellIn = 10 };

            //Act
            var act = ItemValidation.ItemQualityHasPassedMinQuality(item.Quality);

            //Assert
            Assert.True(act);
        }

        [Fact]
        [Trait("ItemValidation", "MinQuality")]
        [Description("Retorna false se a qualidade do item não passou da qualidade mínima.")]
        public void ItemValidation_ShouldBeFalse_WhenItemQualityHasNotPassedMinQuality()
        {
            //Arrange
            Item item = new Item { Name = "foo", Quality = 11, SellIn = 10 };

            //Act
            var act = ItemValidation.ItemQualityHasPassedMinQuality(item.Quality);

            //Assert
            Assert.False(act);
        }

        [Fact]
        [Trait("ItemValidation", "MaxQuality")]
        [Description("Retorna true se a qualidade do item passou da qualidade máxima.")]
        public void ItemValidation_ShouldBeTrue_WhenItemQualityHasPassedMaxQuality()
        {
            //Arrange
            Item item = new Item { Name = "foo", Quality = 51, SellIn = 10 };

            //Act
            var act = ItemValidation.ItemQualityHasPassedMaxQuality(item.Quality);

            //Assert
            Assert.True(act);
        }

        [Fact]
        [Trait("ItemValidation", "MaxQuality")]
        [Description("Retorna false se a qualidade do item não passou da qualidade máxima.")]
        public void ItemValidation_ShouldBeFalse_WhenItemQualityHasNotPassedMaxQuality()
        {
            //Arrange
            Item item = new Item { Name = "foo", Quality = 15, SellIn = 10 };

            //Act
            var act = ItemValidation.ItemQualityHasPassedMaxQuality(item.Quality);

            //Assert
            Assert.False(act);
        }

        [Fact]
        [Trait("ItemValidation", "SellInValueTreshold")]
        [Description("Retorna true se o sellIn do item passou do limite de valor.")]
        public void ItemValidation_ShouldBeTrue_WhenItemSellInHasPassedValueTreshold()
        {
            //Arrange
            Item item = new Item { Name = "foo", Quality = 15, SellIn = 10 };

            //Act
            var act = ItemValidation.ItemSellInHasPassedValueTreshold(item.SellIn, ItemSellInValueThreshold.BackStagePass);

            //Assert
            Assert.True(act);
        }

        [Fact]
        [Trait("ItemValidation", "SellInValueTreshold")]
        [Description("Retorna false se o sellIn do item não tiver passado do limite de valor.")]
        public void ItemValidation_ShouldBeFalse_WhenItemSellInHasNotPassedValueTreshold()
        {
            //Arrange
            Item item = new Item { Name = "foo", Quality = 15, SellIn = 12 };

            //Act
            var act = ItemValidation.ItemSellInHasPassedValueTreshold(item.SellIn, ItemSellInValueThreshold.BackStagePass);

            //Assert
            Assert.False(act);
        }

        [Fact]
        [Trait("ItemValidation", "SellInValueTreshold")]
        [Description("Retorna true se o sellIn do item tiver passado.")]
        public void ItemValidation_ShouldBeTrue_WhenItemSellInHasPassed()
        {
            //Arrange
            Item item = new Item { Name = "foo", Quality = 15, SellIn = 0 };

            //Act
            var act = ItemValidation.ItemSellInHasPassed(item.SellIn);

            //Assert
            Assert.True(act);
        }

        [Fact]
        [Trait("ItemValidation", "SellInValueTreshold")]
        [Description("Retorna false se o sellIn do item não tiver passado.")]
        public void ItemValidation_ShouldBeFalse_WhenItemSellInHasNotPassed()
        {
            //Arrange
            Item item = new Item { Name = "foo", Quality = 15, SellIn = 12 };

            //Act
            var act = ItemValidation.ItemSellInHasPassed(item.SellIn);

            //Assert
            Assert.False(act);
        }

        #endregion
    }
}
