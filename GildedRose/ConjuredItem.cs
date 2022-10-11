namespace GildedRose
{
    public class ConjuredItem : Item
    {
        public override void UpdateQuality() {
            Quality = Quality - 2;
            if (SellIn < 0) Quality = Quality - 2;            
        }
    }
}