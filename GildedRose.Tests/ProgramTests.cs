namespace GildedRose.Tests;

public class ProgramTests
{
    [Fact]
    public void Main_Test() {
      var app = new Program()
      {

      };

      
    }

    [Fact]
    public void Sulfuras_does_not_degrade_in_quality()
    {
        //arrange
        var app = new Program()
        {
            Items = new List<Item>() { new Legendary { Name = "Sulfuras, Hand of Ragnaros", SellIn = 3, Quality = 80 } }
        };

        var exp = 80;

        //act
        app.Update();

        //assert
        app.Items[0].Quality.Should().Be(exp);
    }


    [Fact]
    public void An_items_quality_degrades_twice_as_fast_after_the_sellIn_expires()
    {
        //arrange
        var app = new Program()
        {
            Items = new List<Item>() { new Item { Name = "+5 Dexterity Vest", SellIn = 1, Quality = 20 } }
        };

        var exp = 15;

        //act
        app.Update();
        app.Update();
        app.Update();

        //assert
        app.Items[0].Quality.Should().Be(exp);
    }

    [Fact]
    public void Quality_of_given_item_does_not_go_further_down_than_0()
    {
        //Create item and degrade is past 0 and check if it goes into the negative or stays at 0
        //arrange
        var app = new Program()
        {
            Items = new List<Item>() { new Item { Name = "+5 Dex Vest", SellIn = 1, Quality = 1 } }
        };

        var exp = 0;

        //act
        app.Update();
        app.Update();
        app.Update();

        //assert
        app.Items[0].Quality.Should().Be(exp);
    }

    [Fact]
    public void The_aged_brie_item_increases_in_quality_as_older_it_gets()
    {
        // Create a aged brie and check if the quality increases with time instead of decreases
        //arrange
        var app = new Program()
        {
            Items = new List<Item>() { new AgedBrie { Name = "Aged Brie", SellIn = 3, Quality = 0 } }
        };

        var expSell = 2;
        var expQual = 1;

        //act
        app.Update();

        //assert
        app.Items[0].SellIn.Should().Be(expSell);
        app.Items[0].Quality.Should().Be(expQual);
    }

    [Fact]
    public void The_aged_brie_item_increases_in_quality_as_older_it_gets_sell_in_starts_at_0()
    {
        // Create a aged brie and check if the quality increases with time instead of decreases
        //arrange
        var app = new Program()
        {
            Items = new List<Item>() { new AgedBrie { Name = "Aged Brie", SellIn = 0, Quality = 2 } }
        };

        var expSell = -1;
        var expQual = 4;

        //act
        app.Update();

        //assert
        app.Items[0].SellIn.Should().Be(expSell);
        app.Items[0].Quality.Should().Be(expQual);
    }

    [Fact]
    public void Quality_of_an_item_should_not_go_past_50()
    {
        //Create a brie and check it's quality does not go past 50 - even when it 'should'
        //arrange
        var app = new Program()
        {
            Items = new List<Item>() { new AgedBrie { Name = "Aged Brie", SellIn = 3, Quality = 50 } }
        };

        var expSell = 2;
        var expQual = 50;

        //act
        app.Update();

        //assert
        app.Items[0].SellIn.Should().Be(expSell);
        app.Items[0].Quality.Should().Be(expQual);
    }

    [Fact]
    public void Backstage_pass_increase_value_by_time_first_by_2_then_by_3()
    {
        //Three checks, checking if the backstage pass' quality drops accordingly to the description
        //increase by 2 when there are 10 days or less left
        //Increase by 3 when there are 5 days or less left
        //arrange
        var app = new Program()
        {
            Items = new List<Item>() {
                new BSPass { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 40 },
                new BSPass { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 40}
            }
        };

        var exp1 = 42;
        var exp2 = 43;

        //act
        app.Update();

        //assert
        app.Items[0].Quality.Should().Be(exp1);
        app.Items[1].Quality.Should().Be(exp2);
    }

    [Fact]
    public void Backstage_pass_quality_should_drop_to_0_after_the_concert()
    {
        //Check if backstage pass quality drops to 0 after the concert has been held
        //arrange
        var app = new Program()
        {
            Items = new List<Item>() { new BSPass { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 80 } }
        };

        var exp = 0;

        //act
        app.Update();

        //assert
        app.Items[0].Quality.Should().Be(exp);
    }

    [Fact]
    public void Backstage_pass_quality_should_stay_at_50_if_above()
    {
        //Check if backstage pass quality drops to 0 after the concert has been held
        //arrange
        var app = new Program()
        {
            Items = new List<Item>() { new BSPass { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 30, Quality = 50 } }
        };

        var exp = 50;

        //act
        app.Update();

        //assert
        app.Items[0].Quality.Should().Be(exp);
    }

    [Fact]
    public void Conjured_item_degrades_twice_as_fast_as_normal_item()
    {
        //arrange
        var app = new Program()
        {
            Items = new List<Item>() { new ConjuredItem { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 } }
        };

        var exp = 4;

        //act
        app.Update();

        //assert
        app.Items[0].Quality.Should().Be(exp);
    }

    [Fact]
    public void Conjured_item_should_not_go_down_in_quality_below_0()
    {
        //arrange
        var app = new Program()
        {
            Items = new List<Item>() { new ConjuredItem { Name = "Conjured Mana Cake", SellIn = 1, Quality = 0 } }
        };

        var expSell = 0;
        var expQuality = 0;

        //act
        app.Update();

        //assert
        app.Items[0].Quality.Should().Be(expQuality);
        app.Items[0].SellIn.Should().Be(expSell);
    }
    [Fact]
    public void Conjured_item_should_go_double_quality_down_when_sellin_isbelow_0()
    {
        //arrange
        var app = new Program()
        {
            Items = new List<Item>() { new ConjuredItem { Name = "Conjured Mana Cake", SellIn = 1, Quality = 10 } }
        };

        var expSell = -1;
        var expQuality = 4;

        //act
        app.Update();
        app.Update();

        //assert
        app.Items[0].Quality.Should().Be(expQuality);
        app.Items[0].SellIn.Should().Be(expSell);
    }

}