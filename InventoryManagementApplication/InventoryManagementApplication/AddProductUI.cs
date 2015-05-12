using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventoryManagementApplication.BLL;
using InventoryManagementApplication.MODEL;

namespace InventoryManagementApplication
{
    public partial class AddProductUI : Form
    {
        public AddProductUI()
        {
            InitializeComponent();
        }

    
        InventoryManager manager = new InventoryManager();
        List<Product> products = new List<Product>(); 
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadAllProducts();
            LoadAllSuppliars();
        }

        private void LoadAllSuppliars()
        {
            List<Suppliar> suppliars= manager.GetAllSuppliars();

            suppliarNameComboBox.DisplayMember = "suppliarName";
            suppliarNameComboBox.ValueMember = "SuppliarID";
            suppliarNameComboBox.DataSource = null;
            suppliarNameComboBox.DataSource = suppliars;
        }

        Product aProduct = new Product();
        private void saveButton_Click(object sender, EventArgs e)
        {
            string product_code = productCodeTextBox.Text;
            string description = descriptionTextBox.Text;
            int quantity = Convert.ToInt32(quantityTextBox.Text);
            int suppliarId = int.Parse(suppliarNameComboBox.SelectedValue.ToString());

            aProduct.product_code = product_code;
            aProduct.description = description;
            aProduct.quantity = quantity;
            aProduct.suppliarId = suppliarId;
            MessageBox.Show(manager.InsertProduct(aProduct));
            DoBlank();

            products = manager.GetAllProduct();
            LoadAllProducts();

        }
        
        public bool DoBlank()
        {
            productCodeTextBox.Text = String.Empty;
            descriptionTextBox.Text = String.Empty;
            quantityTextBox.Text = String.Empty;
            return true;
        }

        private void productListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public void LoadAllProducts()
        {

            products = manager.GetAllProduct();
            productListView.Items.Clear();
            foreach (var product in products)
            {
                ListViewItem item = new ListViewItem(product.product_code.ToString());
                item.SubItems.Add(product.description);
                item.SubItems.Add(product.quantity.ToString());

                item.SubItems.Add(product.suppliarName);
                productListView.Items.Add(item);
               
            }
        }

        private void suppliarNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
