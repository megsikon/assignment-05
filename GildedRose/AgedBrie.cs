namespace GildedRose
{
    public class AgedBrie : Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }

        public override void UpdateQuality() {
            if (this.SellIn > 0) {
                this.SellIn--;
            } else {
                this.Quality++;
            }
            this.Quality++;
        }
    }
}