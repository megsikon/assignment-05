namespace GildedRose
{
    public class BSPass : Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }

        public override void UpdateQuality() {
            if (SellIn > 0) {
                SellIn--;
                Quality++;
                if (SellIn <= 10)
                {
                    if (Quality < 50)
                    {
                        Quality++;
                        if (SellIn <= 5)
                        {
                            if (Quality < 50)
                            {
                                Quality++;
                            }
                        }
                    }
                }
            }
            else { Quality = 0; }
        }
    }
}