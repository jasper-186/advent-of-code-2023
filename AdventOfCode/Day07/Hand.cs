namespace AdventOfCode.Day07;
using System;
using System.Collections.Generic;

public class Hand : IComparable<Hand>
{
    public Hand(String handString, int bid)
    {
        this.cards = handString;
        this.bid = bid;
    }

    public String cards { get; private set; }
    public int bid { get; private set; }
    private Dictionary<char, int> cardValues = new Dictionary<char, int>(){
        {'2',2},
        {'3',3},
        {'4',4},
        {'5',5},
        {'6',6},
        {'7',7},
        {'8',8},
        {'9',9},
        {'T',10},
        {'J',11},
        {'Q',12},
        {'K',13},
        {'A',14}
    };


    public HandStrength GetHandStrength()
    {
        var cardCount = new Dictionary<Char, int>();
        foreach (var key in cardValues.Keys)
        {
            cardCount[key] = 0;
        }

        for (int i = 0; i < cards.Length; i++)
        {
            char card = this.cards[i];
            cardCount[card] += 1;
        }

        if (cardCount.Values.Any(i => i == 5))
        {
            return HandStrength.FiveOfAKind;
        }

        if (cardCount.Values.Any(i => i == 4))
        {
            return HandStrength.FourOfAKind;
        }

        if (cardCount.Values.Any(i => i == 3))
        {
            if (cardCount.Values.Any(i => i == 2))
            {
                return HandStrength.FullHouse;
            }
            else
            {
                return HandStrength.ThreeOfAKind;
            }
        }

        if (cardCount.Values.Where(i => i == 2).Count() == 2)
        {
            return HandStrength.TwoPair;
        }

        if (cardCount.Values.Any(i => i == 2))
        {
            return HandStrength.OnePair;
        }

        return HandStrength.HighCard;
    }

    public long getScore(long rank)
    {
        return this.bid * rank;
    }

    public int CompareTo(Hand? other)
    {
        if (other == null)
        {
            return 1;
        }

        var thisHandStrength = GetHandStrength();
        var otherHandStrength = other.GetHandStrength();

        if (thisHandStrength != otherHandStrength)
        {
            return thisHandStrength.CompareTo(otherHandStrength);
        }

        for (int i = 0; i < this.cards.Length; i++)
        {
            var thisAmount = cardValues[this.cards[i]];
            var otherAmount = cardValues[other.cards[i]];
            if (thisAmount != otherAmount)
            {
                return thisAmount.CompareTo(otherAmount);
            }
        }


        return 0;
    }
}
