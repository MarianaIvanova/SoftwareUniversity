using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P03_SalesDatabase.Data.Models
{
    public class Product
    {
        public Product()
        {
            this.Sales = new HashSet<Sale>();
        }
        //ProductId
        public int ProductId { get; set; }
        //Name(up to 50 characters, unicode)
        [MaxLength(50)]
        public string Name { get; set; }
        //Quantity(real number)
        public decimal Quantity { get; set; }//Possible errors in Judge
        //Price
        public decimal Price { get; set; }
        //Sales
        public ICollection<Sale> Sales { get; set; }
        // Add Description, up to 250 symbols, with default value "No description" - task 4
        [MaxLength(250)]
        public string Description { get; set; } = "No description";//Or in the constructor!
    }
}
