using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class WithdrawalLog
    {
        public WithdrawalLog()
        {
            this.LogDate = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        [MinLength(10)]
        [MaxLength(10)]
        public string CardNumber { get; set; }

        public virtual CardAccount CardAcc { get; set; }

        public virtual DateTime LogDate { get; set; }

        public decimal OldBalance { get; set; }

        public decimal NewBalance { get; set; }
    }
}
