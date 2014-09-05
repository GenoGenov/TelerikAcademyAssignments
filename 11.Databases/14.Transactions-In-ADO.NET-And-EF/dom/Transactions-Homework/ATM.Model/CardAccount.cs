using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Model
{
    using System.Collections.ObjectModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class CardAccount
    {
        private ICollection<WithdrawalLog> logs;

        public CardAccount()
        {
            this.logs=new HashSet<WithdrawalLog>();
        }

        [Key]
        [Column("Card Number",Order = 1)]
        [MinLength(10)]
        [MaxLength(10)]
        [Required]
        public string Cardnumber { get; set; }

        [Column("Card PIN")]
        [MaxLength(4)]
        [MinLength(4)]
        [Required]
        public string CardPIN { get; set; }

        [Column("Balance")]
        [Required]
        public decimal CardCash { get; set; }

        public ICollection<WithdrawalLog> Logs
        {
            get
            {
                return this.logs;
            }
            set
            {
                this.logs = value;
            }
        } 
    }
}
