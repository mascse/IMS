using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagementApplication
{
    public partial class MenuUI: Form
    {
        public MenuUI()
        {
            InitializeComponent();
        }

        private void MenuUI_Load(object sender, EventArgs e)
        {

        }

        private void AddSuppliarButton_Click(object sender, EventArgs e)
        {
            Suppliar_UI suppliarUi = new Suppliar_UI();
            suppliarUi.Show();
        }

        private void addProductButton_Click(object sender, EventArgs e)
        {
            AddProductUI addProductUi = new AddProductUI();
            addProductUi.Show();
        }
    }
}
