namespace GildedRose
{
    public class ConjuredItem : Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }

        public override void UpdateQuality() {
            if (SellIn > 0) {
                SellIn--;
            } else {
                Quality = Quality - 2;
            }
            Quality = Quality - 2;
        }
    }
}