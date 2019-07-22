using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;



namespace AssignmentX.Models
{
    public enum bid_type
    {
        Debit,
        Credit
    }
    public class Transactions
    {   
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int tid { get; set; }
        public int user_id { get; set; }
        public decimal amount { get; set; }
        public bid_type type { get; set; }

    }
}