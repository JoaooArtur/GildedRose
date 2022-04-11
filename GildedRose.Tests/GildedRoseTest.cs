using GildedRose.Constantes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xunit;

namespace GildedRose.Tests
{
    public class GildedRoseTest
    {
        #region Itens Normais

        [Fact]
        [Trait("Item", "Normal")]
        [Description("Quality abaixa quando SellIn diminui.")]
        public void ItemNormal_QualityDeveAbaixar_QuandoSellInDiminuir()
        {
            //Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 5, Quality = 10 } };
            GildedRose app = new GildedRose(Items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.Equal(9, Items[0].Quality);
        }

        [Fact]
        [Trait("Item", "Normal")]
        [Description("Quality nunca passa de 0 quando SellIn diminui.")]
        public void ItemNormal_QualityNuncaNegativa_QuandoSellInDiminuir()
        {
            //Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 5, Quality = 0 } };
            GildedRose app = new GildedRose(Items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.Equal(0, Items[0].Quality);
        }

        [Fact]
        [Trait("Item", "Normal")]
        [Description("Quality abaixa 2 vezes mais quando SellIn ja tiver passado.")]
        public void ItemNormal_QualityDeveAbaixar2Vezes_QuandoSellInPassar()
        {
            //Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = -1, Quality = 10 } };
            GildedRose app = new GildedRose(Items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.Equal(8, Items[0].Quality);
        }

        [Fact]
        [Trait("Item", "Normal")]
        [Description("Quality nunca passa de 0 quando SellIn ja tiver passado.")]
        public void ItemNormal_QualityNuncaNegativa_QuandoSellInPassar()
        {
            //Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = -1, Quality = 0 } };
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
        public void QueijoBrie_QualityDeveAumentar_QuandoSellInDiminuir()
        {
            //Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 5, Quality = 10 } };
            GildedRose app = new GildedRose(Items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.Equal(11, Items[0].Quality);
        }

        [Fact]
        [Trait("Item", "Queijo Brie")]
        [Description("Quality nunca pode ser maior que 50 quando SellIn diminui.")]
        public void QueijoBrie_QualityNuncaMaiorQue50_QuandoSellInDiminuir()
        {
            //Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 5, Quality = 50 } };
            GildedRose app = new GildedRose(Items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.Equal(50, Items[0].Quality);
        }

        [Fact]
        [Trait("Item", "Queijo Brie")]
        [Description("Quality aumenta 2 vezes mais quando SellIn ja tiver passado.")]
        public void QueijoBrie_QualityDeveAumentar2Vezes_QuandoSellInPassar()
        {
            //Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = -1, Quality = 10 } };
            GildedRose app = new GildedRose(Items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.Equal(12, Items[0].Quality);
        }

        [Fact]
        [Trait("Item", "Queijo Brie")]
        [Description("Quality nunca pode ser maior que 50 quando SellIn ja tiver passado.")]
        public void QueijoBrie_QualityNuncaMaiorQue50_QuandoSellInPassar()
        {
            //Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = -1, Quality = 50 } };
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
        public void AcessoAosBastidores_QualityDeveAumentar_QuandoSellInDiminuir()
        {
            //Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 10 } };
            GildedRose app = new GildedRose(Items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.Equal(11, Items[0].Quality);
        }

        [Fact]
        [Trait("Item", "Acesso aos Bastidores")]
        [Description("Quality nunca pode ser maior que 50 quando SellIn diminui.")]
        public void AcessoAosBastidores_QualityNuncaMaiorQue50_QuandoSellInDiminuir()
        {
            //Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 50 } };
            GildedRose app = new GildedRose(Items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.Equal(50, Items[0].Quality);
        }

        [Fact]
        [Trait("Item", "Acesso aos Bastidores")]
        [Description("Quality aumenta 2 vezes mais quando SellIn for menor que 10.")]
        public void AcessoAosBastidores_QualityDeveAumentar2vezes_QuandoSellInForMenorQue10()
        {
            //Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 9, Quality = 10 } };
            GildedRose app = new GildedRose(Items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.Equal(12, Items[0].Quality);
        }

        [Fact]
        [Trait("Item", "Acesso aos Bastidores")]
        [Description("Quality nunca pode ser maior que 50 quando SellIn for menor que 10.")]
        public void AcessoAosBastidores_QualityNuncaMaiorQue50_QuandoSellInForMenorQue10()
        {
            //Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 9, Quality = 50 } };
            GildedRose app = new GildedRose(Items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.Equal(50, Items[0].Quality);
        }

        [Fact]
        [Trait("Item", "Acesso aos Bastidores")]
        [Description("Quality aumenta 3 vezes mais quando SellIn for menor que 5.")]
        public void AcessoAosBastidores_QualityDeveAumentar3vezes_QuandoSellInForMenorQue5()
        {
            //Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 4, Quality = 10 } };
            GildedRose app = new GildedRose(Items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.Equal(13, Items[0].Quality);
        }

        [Fact]
        [Trait("Item", "Acesso aos Bastidores")]
        [Description("Quality nunca pode ser maior que 50 quando SellIn for menor que 5.")]
        public void AcessoAosBastidores_QualityNuncaMaiorQue50_QuandoSellInForMenorQue5()
        {
            //Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 4, Quality = 50 } };
            GildedRose app = new GildedRose(Items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.Equal(50, Items[0].Quality);
        }

        [Fact]
        [Trait("Item", "Acesso aos Bastidores")]
        [Description("Quality aumenta 3 vezes mais quando SellIn for menor que 5.")]
        public void AcessoAosBastidores_QualityDeveZerar_QuandoSellInPassar()
        {
            //Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -1, Quality = 10 } };
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
        public void Sulfuras_QualityNaoDeveMudar_QuandoSellInDiminuir()
        {
            //Arrange
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 5, Quality = 80 } };
            GildedRose app = new GildedRose(Items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.Equal(80, Items[0].Quality);
        }

        [Fact]
        [Trait("Item", "Sulfuras")]
        [Description("Quality não muda quando item for Sulfuras e SellIn ja tiver passado.")]
        public void Sulfuras_QualityNaoDeveMudar_QuandoSellInPassar()
        {
            //Arrange
            IList<Item> Items = new List<Item> { new Item { Name = ItemNames.Sulfuras, SellIn = -1, Quality = 80 } };
            GildedRose app = new GildedRose(Items);

            //Act
            app.UpdateQuality();

            //Assert
            Assert.Equal(80, Items[0].Quality);
        }

        #endregion
    }
}
