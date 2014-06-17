using System;
using System.Collections;
using System.Linq;

namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        public bool IsValidHand(IHand hand)
        {
            if (hand.Cards.Count!=5)
            {
                return false;
            }

            for (int i = 0; i < hand.Cards.Count; i++)
            {
                var card = hand.Cards.ElementAt(i);
                if (hand.Cards.Count(x => x.Face == card.Face && x.Suit == card.Suit) > 1)
                {
                    return false;   
                }
            }

            return true;
        }

        public bool IsStraightFlush(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFourOfAKind(IHand hand)
        {
            var cards = hand.Cards;

            foreach (var face in Enum.GetNames(typeof(CardFace)).ToList())
            {
                if (cards.Count(x=>x.Face.ToString()==face)==4)
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsFullHouse(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFlush(IHand hand)
        {
            var color = hand.Cards.ElementAt(0).Suit;
            return !hand.Cards.Any(x => x.Suit != color);
        }

        public bool IsStraight(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsTwoPair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsOnePair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsHighCard(IHand hand)
        {
            throw new NotImplementedException();
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }
    }
}