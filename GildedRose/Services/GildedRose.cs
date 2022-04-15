using GildedRose.Helpers.Constants;
using GildedRose.Validations;
using System.Collections.Generic;

namespace GildedRose
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach(var item in Items)
            {
                switch (item.Name)
                {
                    case ItemNames.AgedBrie:
                        UpdateAgedBrie(item);
                        break;
                    case ItemNames.Sulfuras:
                        DecreaseItemSellIn(item);
                        break;
                    case ItemNames.BackStagePass:
                        UpdateBackstagePass(item);
                        break;
                    default:
                        HandleNormalItem(item);
                        break;
                }
            }
        }

        #region ItemsHandlers

        private static void HandleNormalItem(Item item)
        {
            if (ItemValidation.IsConjuredItem(item.Name))
                UpdateConjuredItem(item);
            else
                UpdateNormalItem(item);
        }

        private static void UpdateBackstagePass(Item item)
        {
            DecreaseItemSellIn(item);
            IncreaseItemQuality(item);

            if (ItemValidation.ItemSellInHasPassedValueTreshold(item.SellIn, ItemSellInValueThreshold.BackStagePass))
                IncreaseItemQuality(item);

            if (ItemValidation.ItemSellInHasPassedValueTreshold(item.SellIn, ItemSellInValueThreshold.BackStagePass2Times))
                IncreaseItemQuality(item);

            if (ItemValidation.ItemSellInHasPassed(item.SellIn))
                SetItemMinQuality(item);

            if (ItemValidation.ItemQualityHasPassedMaxQuality(item.Quality))
                SetItemMaxQuality(item);
        }

        private static void UpdateAgedBrie(Item item)
        {
            DecreaseItemSellIn(item);
            IncreaseItemQuality(item);

            if (ItemValidation.ItemSellInHasPassed(item.SellIn))
                IncreaseItemQuality(item);

            if (ItemValidation.ItemQualityHasPassedMaxQuality(item.Quality))
                SetItemMaxQuality(item);
        }

        private static void UpdateNormalItem(Item item)
        {
            DecreaseItemSellIn(item);
            DecreaseItemQuality(item);

            if (ItemValidation.ItemSellInHasPassed(item.SellIn))
                DecreaseItemQuality(item);

            if (ItemValidation.ItemQualityHasPassedMinQuality(item.Quality))
                SetItemMinQuality(item);
        }

        private static void UpdateConjuredItem(Item item)
        {
            DecreaseItemSellIn(item);
            DecreaseItemQuality(item,2);

            if (ItemValidation.ItemSellInHasPassed(item.SellIn))
                DecreaseItemQuality(item,2);

            if (ItemValidation.ItemQualityHasPassedMinQuality(item.Quality))
                SetItemMinQuality(item);
        }

        #endregion

        #region ItemQuality

        private static void IncreaseItemQuality(Item item) => item.Quality++;

        private static void DecreaseItemQuality(Item item,int value = 1) => item.Quality -= value;

        private static void SetItemMaxQuality(Item item) => item.Quality = ItemQuality.NormalItemMaxQuality;

        private static void SetItemMinQuality(Item item) => item.Quality = ItemQuality.NormalItemMinQuality;

        #endregion

        #region ItemSellIn

        private static void DecreaseItemSellIn(Item item) => item.SellIn--;

        #endregion
    }
}
