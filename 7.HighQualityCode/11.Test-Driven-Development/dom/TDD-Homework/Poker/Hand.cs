using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    public class Hand : IHand
    {
        public IList<ICard> Cards { get; private set; }

        public Hand(IList<ICard> cards)
        {
            this.Cards = new List<ICard>(cards);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("-------------Current hand:-----------------");
            foreach (var card in this.Cards)
            {
                sb.AppendLine(card.ToString());
            }

            sb.AppendLine("-------------------------------------------");

            return sb.ToString();
        }
    }
}
