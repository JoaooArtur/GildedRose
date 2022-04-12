using GildedRose.Constantes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xunit;

namespace GildedRose.Tests
{
    public class GildedRoseTest
    {
        #region Setup

        private static IList<Item> SetupItem(string name,int sellIn, int quality)
        {
            return new List<Item> { new Item { Name = name, SellIn = sellIn, Quality = quality } };
        }

        #endregion

        #region Itens Normais

        [Fact]
        [Trait("Item", "Normal")]
        [Description("Quality abaixa quando SellIn diminui.")]
        public void NormalItem_QualityShouldDecrease_WhenSellInAproaches()
        {
            //Arrange
            IList<Item> Items = SetupItem("foo", 5, 10);
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
            IList<Item> Items = SetupItem("foo", 5, 0);
            GildedRose app = new GildedRose(Items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.Equal(0, Items[0].Quality);
        }

        [Fact]
        [Trait("Item", "Normal")]
        [Description("Quality abaixa 2 vezes mais quando SellIn ja tiver passado.")]
        public void NormalItem_QualityShouldDecrease2x_WhenSellInHasPassed()
        {
            //Arrange
            IList<Item> Items = SetupItem("foo", -1, 10);
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
            IList<Item> Items = SetupItem("foo", -1, 0);
            GildedRose app = new GildedRose(Items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.Equal(0, Items[0].Quality);
        }

        #endregion

        #region Item Queijo Brie Envelhecido (Aged Brie)

        [Fact]
        [Trait("Item", "Queijo Brie")]
        [Description("Quality aumenta quando SellIn diminui.")]
        public void AgedBrie_QualityShouldIncrease_WhenSellInAproaches()
        {
            //Arrange
            IList<Item> Items = SetupItem("Aged Brie", 5, 10);
            GildedRose app = new GildedRose(Items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.Equal(11, Items[0].Quality);
        }

        [Fact]
        [Trait("Item", "Queijo Brie")]
        [Description("Quality nunca pode ser maior que 50 quando SellIn diminui.")]
        public void AgedBrie_QualityShouldNeverBeMoreThan50_WhenSellInAproaches()
        {
            //Arrange
            IList<Item> Items = SetupItem("Aged Brie", 5, 50);
            GildedRose app = new GildedRose(Items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.Equal(50, Items[0].Quality);
        }

        [Fact]
        [Trait("Item", "Queijo Brie")]
        [Description("Quality aumenta 2 vezes mais quando SellIn ja tiver passado.")]
        public void AgedBrie_QualityShouldIncrease2x_WhenSellInHasPassed()
        {
            //Arrange
            IList<Item> Items = SetupItem("Aged Brie", -1, 10);
            GildedRose app = new GildedRose(Items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.Equal(12, Items[0].Quality);
        }

        [Fact]
        [Trait("Item", "Queijo Brie")]
        [Description("Quality nunca pode ser maior que 50 quando SellIn ja tiver passado.")]
        public void AgedBrie_QualityShouldNeverBeMoreThan50_WhenSellInHasPassed()
        {
            //Arrange
            IList<Item> Items = SetupItem("Aged Brie", -1, 50);
            GildedRose app = new GildedRose(Items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.Equal(50, Items[0].Quality);
        }

        #endregion

        #region Item Acesso aos Bastidores (Backstage passes to a TAFKAL80ETC concert)

        [Fact]
        [Trait("Item", "Acesso aos Bastidores")]
        [Description("Quality aumenta quando SellIn diminui.")]
        public void BackStagePass_QualityShouldIncrease_WhenSellInAproaches()
        {
            //Arrange
            IList<Item> Items = SetupItem("Backstage passes to a TAFKAL80ETC concert", 15, 10);
            GildedRose app = new GildedRose(Items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.Equal(11, Items[0].Quality);
        }

        [Fact]
        [Trait("Item", "Acesso aos Bastidores")]
        [Description("Quality nunca pode ser maior que 50 quando SellIn diminui.")]
        public void BackStagePass_QualityShouldNeverBeMoreThan50_WhenSellInAproaches()
        {
            //Arrange
            IList<Item> Items = SetupItem("Backstage passes to a TAFKAL80ETC concert", 15, 50);
            GildedRose app = new GildedRose(Items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.Equal(50, Items[0].Quality);
        }

        [Fact]
        [Trait("Item", "Acesso aos Bastidores")]
        [Description("Quality aumenta 2 vezes mais quando SellIn for menor que 10.")]
        public void BackStagePass_QualityShouldIncrease2x_WhenSellInCloserThan10()
        {
            //Arrange
            IList<Item> Items = SetupItem("Backstage passes to a TAFKAL80ETC concert", 9, 10);
            GildedRose app = new GildedRose(Items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.Equal(12, Items[0].Quality);
        }

        [Fact]
        [Trait("Item", "Acesso aos Bastidores")]
        [Description("Quality nunca pode ser maior que 50 quando SellIn for menor que 10.")]
        public void BackStagePass_QualityShouldNeverBeMoreThan50_WhenSellInCloserThan10()
        {
            //Arrange
            IList<Item> Items = SetupItem("Backstage passes to a TAFKAL80ETC concert", 9, 50);
            GildedRose app = new GildedRose(Items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.Equal(50, Items[0].Quality);
        }

        [Fact]
        [Trait("Item", "Acesso aos Bastidores")]
        [Description("Quality aumenta 3 vezes mais quando SellIn for menor que 5.")]
        public void BackStagePass_QualityShouldIncrease3x_WhenSellInCloserThan5()
        {
            //Arrange
            IList<Item> Items = SetupItem("Backstage passes to a TAFKAL80ETC concert", 4, 10);
            GildedRose app = new GildedRose(Items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.Equal(13, Items[0].Quality);
        }

        [Fact]
        [Trait("Item", "Acesso aos Bastidores")]
        [Description("Quality nunca pode ser maior que 50 quando SellIn for menor que 5.")]
        public void BackStagePass_QualityShouldNeverBeMoreThan50_WhenSellInCloserThan5()
        {
            //Arrange
            IList<Item> Items = SetupItem("Backstage passes to a TAFKAL80ETC concert", 4, 50);
            GildedRose app = new GildedRose(Items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.Equal(50, Items[0].Quality);
        }

        [Fact]
        [Trait("Item", "Acesso aos Bastidores")]
        [Description("Quality aumenta 3 vezes mais quando SellIn for menor que 5.")]
        public void BackStagePass_QualityShouldBe0_WhenSellInHasPassed()
        {
            //Arrange
            IList<Item> Items = SetupItem("Backstage passes to a TAFKAL80ETC concert", -1, 10);
            GildedRose app = new GildedRose(Items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.Equal(0, Items[0].Quality);
        }

        #endregion

        #region Item Sulfuras

        [Fact]
        [Trait("Item", "Sulfuras")]
        [Description("Quality não muda quando item for Sulfuras.")]
        public void Sulfuras_QualityShouldntChange_WhenSellInAproaches()
        {
            //Arrange
            IList<Item> Items = SetupItem("Sulfuras, Hand of Ragnaros", 5, 80);
            GildedRose app = new GildedRose(Items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.Equal(80, Items[0].Quality);
        }

        [Fact]
        [Trait("Item", "Sulfuras")]
        [Description("Quality não muda quando item for Sulfuras e SellIn ja tiver passado.")]
        public void Sulfuras_QualityShouldntChange_WhenSellInHasPassed()
        {
            //Arrange
            IList<Item> Items = SetupItem("Sulfuras, Hand of Ragnaros", -1, 80);
            GildedRose app = new GildedRose(Items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.Equal(80, Items[0].Quality);
        }

        #endregion
    }
}
