using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventoryManagementApplication.DAL;
using InventoryManagementApplication.MODEL;

namespace InventoryManagementApplication.BLL
{

    public class InventoryManager
    {
        private InventoryGateway gateway = new InventoryGateway();

        public string InsertProduct(Product aProduct)
        {

            if (gateway.ChechProductCode(aProduct.product_code) == null)
            {
                if (gateway.Insert(aProduct) > 0)
                {
                    return "Insert Successfully";
                    
                }

                else
                {
                    return "Failed To insert";
                }
            }
            else
            {
                return "Unique Product!";
            }
        }

        public List<Product> GetAllProduct()
        {
            return gateway.GetProduct();
        }

        public string Insert(Suppliar aSuppliar)
        {
            if (gateway.InsertSuppliar(aSuppliar) > 0)
            {
                return "Successfully insert";
            }
            else
            {
                return "Failed to insert";
            }
        }

        public List<Suppliar> GetAllSuppliars()
        {
            return gateway.GetAllSuppliars();
        }
    }
}
