using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApplication.MODEL
{
    public class Product
    {
        public int Id { get; set; }
        public string product_code { get; set; }
        public string description { get; set; }
        public int quantity { get; set; }
        public int suppliarId { get; set; }
        public string suppliarName { get; set; }

    }
}
