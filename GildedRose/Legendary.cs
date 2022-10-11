namespace GildedRose
{
    public class Legendary : Item
    {
        public override void UpdateQuality() {
            SellIn = SellIn;
            Quality = Quality;
        }
    }
}