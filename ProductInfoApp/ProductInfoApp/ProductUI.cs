using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProductInfoApp.BLL;
using ProductInfoApp.DAL.DAO;

namespace ProductInfoApp
{
    public partial class ProductUI : Form
    {
        ProductBLL aProductBll=new ProductBLL();
        public ProductUI()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Product aProduct = new Product();
            aProduct.Code = codeTextBox.Text;
            aProduct.Name = nameTextBox.Text;
            aProduct.Quantity = Convert.ToInt32(quantityTextBox.Text);

            string msg = aProductBll.Save(aProduct);

            MessageBox.Show(msg);
        }

        private void viewAllButton_Click(object sender, EventArgs e)
        {
            List<Product> products = new List<Product>();

            products = ProductBll.GetAllProduct();
            ListViewItem item = new ListViewItem();
            foreach (Product aProduct in products)
            {
                ListViewItem item = new ListViewItem(aProduct.Code);
                item.SubItems.Add(aProduct.Name);
                item.SubItems.Add(aProduct.Quantity.ToString());
            }
        }

      
    }
}
