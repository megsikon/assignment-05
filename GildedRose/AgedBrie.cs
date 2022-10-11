namespace GildedRose
{
    public class AgedBrie : Item
    {
        public override void UpdateQuality() {
            Quality++;
            if (SellIn < 0) { Quality++;}
        }
    }
}