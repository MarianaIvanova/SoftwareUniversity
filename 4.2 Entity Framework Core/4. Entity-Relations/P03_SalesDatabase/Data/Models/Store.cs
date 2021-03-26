using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P03_SalesDatabase.Data.Models
{
    public class Store
    {
        public Store()
        {
            this.Sales = new HashSet<Sale>();
        }
        //StoreId
        public int StoreId { get; set; }
        //Name(up to 80 characters, unicode)
        [MaxLength(80)]
        public string Name { get; set; }
        //Sales
        public ICollection<Sale> Sales { get; set; }
    }
}
