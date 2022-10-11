using System;
using System.Collections.Generic;

namespace GildedRose
{
  public class Program
  {
    public IList<Item> Items;
    static void Main(string[] args){}

    public void Update()
    {
      for (var i = 0; i < Items.Count; i++)
      {
        if (Items[i] is Legendary) {
            Items[i].UpdateQuality();
        } else {
          Items[i].SellIn--;
          Items[i].UpdateQuality();
          if (Items[i].Quality < 0) Items[i].Quality = 0;
          if (Items[i].Quality > 50) Items[i].Quality = 50;
          }
      }
    }
  }
}