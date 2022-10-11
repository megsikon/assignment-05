namespace GildedRose
{
  public class BSPass : Item
  {
    public override void UpdateQuality()
    {
      if (SellIn > 0)
      {
        Quality++;
        if (SellIn <= 10)
        {
          Quality++;
          if (SellIn <= 5)
          {
            Quality++;

          }

        }
      }
      else { Quality = 0; }
    }
  }
}