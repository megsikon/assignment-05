namespace GildedRose
{
    public class Legendary : Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }

        public override void UpdateQuality() {
            SellIn = SellIn;
            Quality = Quality;
        }
    }
}