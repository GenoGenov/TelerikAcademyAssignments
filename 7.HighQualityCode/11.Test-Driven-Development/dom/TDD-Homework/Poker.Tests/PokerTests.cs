using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;
using System.Collections.Generic;

namespace Poker.Tests
{
    [TestClass]
    public class PokerTests
    {
        private static IHand validHand;

        private static IHand invalidHand;

        private static IHand invalidNumberOfCardsHand;

        [ClassInitialize]
        public static void InitializeData(TestContext context)
        {
            validHand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds),
            });

            invalidHand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds),
            });

            invalidNumberOfCardsHand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Hearts),
            });
        }

        [TestMethod]
        public void CardToStringShouldReturnProperCardName()
        {
            for (int i = 2; i <= (int)CardFace.Ace; i++)
            {
                for (int j = 1; j <= (int)CardSuit.Spades; j++)
                {
                    var card = new Card((CardFace)i, (CardSuit)j);
                    Assert.AreEqual(string.Format("{0} of {1}", (CardFace)i, (CardSuit)j), card.ToString());
                }
            }
        }

        [TestMethod]
        public void HandToStringShouldReturnProperCardNames()
        {
            var sb = new StringBuilder();
            sb.AppendLine("-------------Current hand:-----------------");
            foreach (var card in validHand.Cards)
            {
                sb.AppendLine(card.ToString());
            }

            sb.AppendLine("-------------------------------------------");

            Assert.AreEqual(sb.ToString(), validHand.ToString());
        }

        [TestMethod]
        public void HandsCheckerShouldDetectSimilarCards()
        {
            var checker = new PokerHandsChecker();
            Assert.IsFalse(checker.IsValidHand(invalidHand));
        }

        [TestMethod]
        public void HandsCheckerShouldDetectWrongnumberOfCards()
        {
            var checker = new PokerHandsChecker();
            Assert.IsFalse(checker.IsValidHand(invalidNumberOfCardsHand));
        }

        [TestMethod]
        public void HandsCheckerShouldDetectFlush()
        {
            var checker = new PokerHandsChecker();

            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Clubs),
            });

            
            Assert.IsTrue(checker.IsFlush(hand));
        }

        [TestMethod]
        public void HandsCheckerShouldDetectDifferentColors()
        {
            var checker = new PokerHandsChecker();

            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Clubs),
            });

            Assert.IsFalse(checker.IsFlush(hand));
        }

        [TestMethod]
        public void HandsCheckerShouldDetectFourOfAKind()
        {
            var checker = new PokerHandsChecker();

            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
            });

            Assert.IsTrue(checker.IsFourOfAKind(hand));
        }

        [TestMethod]
        public void HandsCheckerShouldIgnoreLessThanFourOfAKind()
        {
            var checker = new PokerHandsChecker();

            var hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Clubs),
            });

            Assert.IsFalse(checker.IsFourOfAKind(hand));
        }
    }
}