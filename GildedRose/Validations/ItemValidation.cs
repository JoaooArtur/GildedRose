using GildedRose.Helpers.Constants;

namespace GildedRose.Validations
{
    public static class ItemValidation
    {
        public static bool ItemQualityHasPassedMinQuality(int itemQuality) => itemQuality < ItemQuality.NormalItemMinQuality;
        public static bool ItemQualityHasPassedMaxQuality(int quality) => quality > ItemQuality.NormalItemMaxQuality;
        public static bool ItemSellInHasPassedValueTreshold(int itemSellIn, int threshold) => itemSellIn < threshold;
        public static bool IsConjuredItem(string itemName) => itemName.ToLower().StartsWith(ItemNames.Conjured.ToLower());
        public static bool ItemSellInHasPassed(int sellIn) => sellIn <= 0;
    }
}
