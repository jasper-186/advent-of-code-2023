namespace AdventOfCode.Day07;

using AdventOfCode.Common;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public enum HandStrength
{
    Unknown = 0,
    HighCard = 1,
    OnePair = 2,
    TwoPair = 3,
    ThreeOfAKind = 4,
    FullHouse = 5,
    FourOfAKind = 6,
    FiveOfAKind = 7
}

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
        var thisHandStrength = GetHandStrength();
        var otherHandStrength = other?.GetHandStrength();

        if (thisHandStrength != otherHandStrength)
        {
            return thisHandStrength.CompareTo(otherHandStrength);
        }

        if (other == null)
        {
            return 1;
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

public class HandWithJoker : IComparable<HandWithJoker>
{
    public HandWithJoker(String handString, int bid)
    {
        this.cards = handString;
        this.bid = bid;
    }

    public String cards { get; private set; }
    public int bid { get; private set; }
    private Dictionary<char, int> cardValues = new Dictionary<char, int>(){
        {'J',1},
        {'2',2},
        {'3',3},
        {'4',4},
        {'5',5},
        {'6',6},
        {'7',7},
        {'8',8},
        {'9',9},
        {'T',10},
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

        var jokerCount = cardCount['J'];
        //reset Joker count so we dont double count them
        cardCount['J'] = 0;


        if (cardCount.Values.Any(i => i == 5) || jokerCount == 5)
        {
            return HandStrength.FiveOfAKind;
        }

        if (cardCount.Values.Any(i => i == 4))
        {
            if (jokerCount > 0)
            {
                return HandStrength.FiveOfAKind;
            }

            return HandStrength.FourOfAKind;
        }

        if (jokerCount == 4)
        {
            return HandStrength.FourOfAKind;
        }

        if (cardCount.Values.Any(i => i == 3) || jokerCount == 3)
        {
            if (jokerCount == 2)
            {
                return HandStrength.FiveOfAKind;
            }

            if (jokerCount == 1)
            {
                return HandStrength.FourOfAKind;
            }

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
            if (jokerCount == 1)
            {
                return HandStrength.FullHouse;
            }
            return HandStrength.TwoPair;
        }


        if (cardCount.Values.Any(i => i == 2))
        {
            if (jokerCount == 2)
            {
                return HandStrength.FourOfAKind;
            }

            if (jokerCount == 1)
            {
                return HandStrength.ThreeOfAKind;
            }

            return HandStrength.OnePair;
        }

        if (jokerCount == 2)
        {
            return HandStrength.ThreeOfAKind;
        }

        if (jokerCount == 1)
        {
            return HandStrength.OnePair;
        }

        return HandStrength.HighCard;
    }

    public long getScore(long rank)
    {
        return this.bid * rank;
    }

    public int CompareTo(HandWithJoker? other)
    {
        var thisHandStrength = GetHandStrength();
        var otherHandStrength = other?.GetHandStrength();

        if (thisHandStrength != otherHandStrength)
        {
            return thisHandStrength.CompareTo(otherHandStrength);
        }

        if (other == null)
        {
            return 1;
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
