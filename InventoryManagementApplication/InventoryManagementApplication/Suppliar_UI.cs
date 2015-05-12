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
    public partial class Suppliar_UI : Form
    {
        InventoryManager manager = new InventoryManager();
        public Suppliar_UI()
        {
            InitializeComponent();
        }
        Suppliar aSuppliar = new Suppliar();
        private void SaveButton_Click(object sender, EventArgs e)
        {
            string supppliarname = SuppliarNameTextBox.Text;
            aSuppliar.suppliarName = supppliarname;
            MessageBox.Show(manager.Insert(aSuppliar));
        }
    }
}
