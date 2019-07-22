using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AssignmentX.Models
{
    public class BankAccount
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int acc_id { get; set; }
            public int userid { get; set; }
            public string iban { get; set; }
            public decimal balance { get; set; }

        }
    
}