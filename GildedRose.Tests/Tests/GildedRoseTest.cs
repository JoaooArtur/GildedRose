using GildedRose.Helpers.Constants;
using System.Collections.Generic;
using System.ComponentModel;
using Xunit;

namespace GildedRose.Tests.Tests
{
    public class GildedRoseTest
    {
        #region Setup

        private static IList<Item> SetupItems(string name,int sellIn, int quality)
        {
            return new List<Item> { SetupItem(name, sellIn, quality) };
        }

        private static Item SetupItem(string name, int sellIn, int quality)
        {
            return new Item { Name = name, SellIn = sellIn, Quality = quality };
        }

        #endregion

        #region Normal Itens

        [Fact]
        [Trait("Item", "Normal")]
        [Description("SellIn deveria diminuir.")]
        public void NormalItem_SellInShouldDecrease_WhenQualityUpdates()
        {
            //Arrange
            IList<Item> Items = SetupItems("foo", 10, 10);
            GildedRose app = new GildedRose(Items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.Equal(9, Items[0].SellIn);
        }

        [Fact]
        [Trait("Item", "Normal")]
        [Description("Quality abaixa quando SellIn diminui.")]
        public void NormalItem_QualityShouldDecrease_WhenSellInAproaches()
        {
            //Arrange
            IList<Item> Items = SetupItems("foo", 5, 10);
            GildedRose app = new GildedRose(Items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.Equal(9, Items[0].Quality);
        }

        [Fact]
        [Trait("Item", "Normal")]
        [Description("Quality nunca passa de 0 quando SellIn diminui.")]
        public void NormalItem_QualityShouldNeverBeNegative_WhenSellInAproaches()
        {
            //Arrange
            IList<Item> Items = SetupItems("foo", 5, 0);
            GildedRose app = new GildedRose(Items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.Equal(0, Items[0].Quality);
        }

        [Fact]
        [Trait("Item", "Normal")]
        [Description("Quality abaixa 2 vezes mais quando SellIn ja tiver passado.")]
        public void NormalItem_QualityShouldDecrease2times_WhenSellInHasPassed()
        {
            //Arrange
            IList<Item> Items = SetupItems("foo", -1, 10);
            GildedRose app = new GildedRose(Items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.Equal(8, Items[0].Quality);
        }

        [Fact]
        [Trait("Item", "Normal")]
        [Description("Quality nunca passa de 0 quando SellIn ja tiver passado.")]
        public void NormalItem_QualityShouldNeverBeNegative_WhenSellInHasPassed()
        {
            //Arrange
            IList<Item> Items = SetupItems("foo", -1, 0);
            GildedRose app = new GildedRose(Items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.Equal(0, Items[0].Quality);
        }

        #endregion

        #region Conjured Itens

        [Fact]
        [Trait("Item", "Conjured")]
        [Description("Quality abaixa quando SellIn diminui.")]
        public void ConjuredItem_QualityShouldDecrease_WhenSellInAproaches()
        {
            //Arrange
            IList<Item> Items = SetupItems("Conjured foo", 5, 10);
            GildedRose app = new GildedRose(Items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.Equal(8, Items[0].Quality);
        }

        [Fact]
        [Trait("Item", "Conjured")]
        [Description("Quality nunca passa de 0 quando SellIn diminui.")]
        public void ConjuredItem_QualityShouldNeverBeNegative_WhenSellInAproaches()
        {
            //Arrange
            IList<Item> Items = SetupItems("Conjured foo", 5, 0);
            GildedRose app = new GildedRose(Items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.Equal(0, Items[0].Quality);
        }

        [Fact]
        [Trait("Item", "Conjured")]
        [Description("Quality abaixa 2 vezes mais quando SellIn ja tiver passado.")]
        public void ConjuredItem_QualityShouldDecrease2times_WhenSellInHasPassed()
        {
            //Arrange
            IList<Item> Items = SetupItems("Conjured foo", -1, 10);
            GildedRose app = new GildedRose(Items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.Equal(6, Items[0].Quality);
        }

        [Fact]
        [Trait("Item", "Conjured")]
        [Description("Quality nunca passa de 0 quando SellIn ja tiver passado.")]
        public void ConjuredItem_QualityShouldNeverBeNegative_WhenSellInHasPassed()
        {
            //Arrange
            IList<Item> Items = SetupItems("Conjured foo", -1, 0);
            GildedRose app = new GildedRose(Items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.Equal(0, Items[0].Quality);
        }

        #endregion

        #region Aged Brie

        [Fact]
        [Trait("Item", "AgedBrie")]
        [Description("SellIn deveria diminuir.")]
        public void AgedBrie_SellInShouldDecrease_WhenQualityUpdates()
        {
            //Arrange
            IList<Item> Items = SetupItems(ItemNames.AgedBrie, 10, 10);
            GildedRose app = new GildedRose(Items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.Equal(9, Items[0].SellIn);
        }

        [Fact]
        [Trait("Item", "AgedBrie")]
        [Description("Quality aumenta quando SellIn diminui.")]
        public void AgedBrie_QualityShouldIncrease_WhenSellInAproaches()
        {
            //Arrange
            IList<Item> Items = SetupItems(ItemNames.AgedBrie, 5, 10);
            GildedRose app = new GildedRose(Items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.Equal(11, Items[0].Quality);
        }

        [Fact]
        [Trait("Item", "AgedBrie")]
        [Description("Quality nunca pode ser maior que 50 quando SellIn diminui.")]
        public void AgedBrie_QualityShouldNeverBeMoreThan50_WhenSellInAproaches()
        {
            //Arrange
            IList<Item> Items = SetupItems(ItemNames.AgedBrie, 5, 50);
            GildedRose app = new GildedRose(Items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.Equal(50, Items[0].Quality);
        }

        [Fact]
        [Trait("Item", "AgedBrie")]
        [Description("Quality aumenta 2 vezes mais quando SellIn ja tiver passado.")]
        public void AgedBrie_QualityShouldIncrease2times_WhenSellInHasPassed()
        {
            //Arrange
            IList<Item> Items = SetupItems(ItemNames.AgedBrie, -1, 10);
            GildedRose app = new GildedRose(Items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.Equal(12, Items[0].Quality);
        }

        [Fact]
        [Trait("Item", "AgedBrie")]
        [Description("Quality nunca pode ser maior que 50 quando SellIn ja tiver passado.")]
        public void AgedBrie_QualityShouldNeverBeMoreThan50_WhenSellInHasPassed()
        {
            //Arrange
            IList<Item> Items = SetupItems(ItemNames.AgedBrie, -1, 50);
            GildedRose app = new GildedRose(Items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.Equal(50, Items[0].Quality);
        }

        #endregion

        #region Backstage passes

        [Fact]
        [Trait("Item", "BackStagePass")]
        [Description("Quality aumenta quando SellIn diminui.")]
        public void BackStagePass_QualityShouldIncrease_WhenSellInAproaches()
        {
            //Arrange
            IList<Item> Items = SetupItems(ItemNames.BackStagePass, 15, 10);
            GildedRose app = new GildedRose(Items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.Equal(11, Items[0].Quality);
        }

        [Fact]
        [Trait("Item", "BackStagePass")]
        [Description("Quality nunca pode ser maior que 50 quando SellIn diminui.")]
        public void BackStagePass_QualityShouldNeverBeMoreThan50_WhenSellInAproaches()
        {
            //Arrange
            IList<Item> Items = SetupItems(ItemNames.BackStagePass, 15, 50);
            GildedRose app = new GildedRose(Items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.Equal(50, Items[0].Quality);
        }

        [Fact]
        [Trait("Item", "BackStagePass")]
        [Description("Quality aumenta 2 vezes mais quando SellIn for menor que 10.")]
        public void BackStagePass_QualityShouldIncrease2times_WhenSellInCloserThan10()
        {
            //Arrange
            IList<Item> Items = SetupItems(ItemNames.BackStagePass, 9, 10);
            GildedRose app = new GildedRose(Items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.Equal(12, Items[0].Quality);
        }

        [Fact]
        [Trait("Item", "BackStagePass")]
        [Description("Quality nunca pode ser maior que 50 quando SellIn for menor que 10.")]
        public void BackStagePass_QualityShouldNeverBeMoreThan50_WhenSellInCloserThan10()
        {
            //Arrange
            IList<Item> Items = SetupItems(ItemNames.BackStagePass, 9, 50);
            GildedRose app = new GildedRose(Items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.Equal(50, Items[0].Quality);
        }

        [Fact]
        [Trait("Item", "BackStagePass")]
        [Description("Quality aumenta 3 vezes mais quando SellIn for menor que 5.")]
        public void BackStagePass_QualityShouldIncrease3times_WhenSellInCloserThan5()
        {
            //Arrange
            IList<Item> Items = SetupItems(ItemNames.BackStagePass, 4, 10);
            GildedRose app = new GildedRose(Items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.Equal(13, Items[0].Quality);
        }

        [Fact]
        [Trait("Item", "BackStagePass")]
        [Description("Quality nunca pode ser maior que 50 quando SellIn for menor que 5.")]
        public void BackStagePass_QualityShouldNeverBeMoreThan50_WhenSellInCloserThan5()
        {
            //Arrange
            IList<Item> Items = SetupItems(ItemNames.BackStagePass, 4, 50);
            GildedRose app = new GildedRose(Items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.Equal(50, Items[0].Quality);
        }

        [Fact]
        [Trait("Item", "BackStagePass")]
        [Description("Quality aumenta 3 vezes mais quando SellIn for menor que 5.")]
        public void BackStagePass_QualityShouldBe0_WhenSellInHasPassed()
        {
            //Arrange
            IList<Item> Items = SetupItems(ItemNames.BackStagePass, -1, 10);
            GildedRose app = new GildedRose(Items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.Equal(0, Items[0].Quality);
        }

        #endregion

        #region Sulfuras

        [Fact]
        [Trait("Item", "Sulfuras")]
        [Description("Quality não muda quando item for Sulfuras e SellIn ja tiver passado.")]
        public void Sulfuras_QualityShouldntChange_WhenSellInHasPassed()
        {
            //Arrange
            IList<Item> Items = SetupItems(ItemNames.Sulfuras, -1, 80);
            GildedRose app = new GildedRose(Items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.Equal(80, Items[0].Quality);
        }

        #endregion

    }
}
