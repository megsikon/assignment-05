namespace GildedRose
{
    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
        public virtual void UpdateQuality() {
            Quality--;
            if (SellIn < 0) Quality--;
        }
    }
}