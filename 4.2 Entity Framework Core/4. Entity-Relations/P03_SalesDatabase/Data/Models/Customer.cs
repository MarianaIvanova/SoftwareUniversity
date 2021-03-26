using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P03_SalesDatabase.Data.Models
{
    public class Customer
    {
        public Customer()
        {
            this.Sales = new HashSet<Sale>();
        }
        //CustomerId
        public int CustomerId { get; set; }
        //Name(up to 100 characters, unicode)
        [MaxLength(100)]
        public string Name { get; set; }
        //Email(up to 80 characters, not unicode)
        [Column(TypeName = "varchar(80)")]
        public string Email { get; set; }

        //CreditCardNumber(string)
        public string CreditCardNumber { get; set; }
        //Sales
        public ICollection<Sale> Sales { get; set; }
    }
}
