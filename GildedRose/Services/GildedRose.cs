using GildedRose.Constantes;
using GildedRose.Constants;
using System;
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
            for (var i = 0; i < Items.Count; i++)
            {
                Item item = Items[i];
                if (item.Name != ItemNames.AgedBrie && item.Name != ItemNames.BackStagePass)
                {
                    if (item.Quality > 0)
                    {
                        if (item.Name != ItemNames.Sulfuras)
                        {
                            item.Quality--;
                        }
                    }
                }
                else
                {
                    if (item.Quality < ItemMaxQuality.NormalItemMaxQuality)
                    {
                        item.Quality++;

                        if (item.Name == ItemNames.BackStagePass)
                        {
                            if (item.SellIn < ItemSellInValueThreshold.BackStagePassX1)
                            {
                                if (item.Quality < ItemMaxQuality.NormalItemMaxQuality)
                                {
                                    item.Quality++;
                                }
                            }

                            if (item.SellIn < ItemSellInValueThreshold.BackStagePassX2)
                            {
                                if (item.Quality < ItemMaxQuality.NormalItemMaxQuality)
                                {
                                    item.Quality++;
                                }
                            }
                        }
                    }
                }

                if (item.Name != ItemNames.Sulfuras)
                {
                    item.SellIn--;
                }

                if (item.SellIn < 0)
                {
                    if (item.Name != ItemNames.AgedBrie)
                    {
                        if (item.Name != ItemNames.BackStagePass)
                        {
                            if (item.Quality > 0)
                            {
                                if (item.Name != ItemNames.Sulfuras)
                                {
                                    item.Quality--;
                                }
                            }
                        }
                        else
                        {
                            item.Quality--;
                        }
                    }
                    else
                    {
                        if (item.Quality < ItemMaxQuality.NormalItemMaxQuality)
                        {
                            item.Quality++;
                        }
                    }
                }
            }
        }
    }
}
