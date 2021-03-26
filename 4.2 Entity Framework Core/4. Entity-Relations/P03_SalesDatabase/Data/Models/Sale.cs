using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace P03_SalesDatabase.Data.Models
{
    public class Sale
    {
        //SaleId
        public int SaleId { get; set; }
        //Date
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Date { get; set; } 
        //Product
        public int ProductId { get; set; }
        public Product Product { get; set; }
        //Customer
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        //Store
        public int StoreId { get; set; }
        public Store Store { get; set; }
    }
}
