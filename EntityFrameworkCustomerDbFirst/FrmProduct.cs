using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrameworkCustomerDbFirst
{
    public partial class FrmProduct: Form
    {
        public FrmProduct()
        {
            InitializeComponent();
        }
        DbFirstEFEntities db = new DbFirstEFEntities();

        void ProductList()
        {
            dataGridView1.DataSource = db.TblProducts.ToList();
        }
        private void btnList_Click(object sender, EventArgs e)
        {
            ProductList();
        }
        private void FrmProduct_Load(object sender, EventArgs e)
        {
            var values = db.TblCategories.ToList();
            cmbProductCategory.DisplayMember = "CategoryName";
            cmbProductCategory.ValueMember = "CategoryId";
            cmbProductCategory.DataSource = values;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            TblProduct tblProduct = new TblProduct();
            tblProduct.ProductName = cmbCategory.Text;
            tblProduct.ProductPrice = decimal.Parse(txtProductPrice.Text);
            tblProduct.CategoryId = (int)cmbProductCategory.SelectedValue;
            tblProduct.ProductStock = int.Parse(txtProductStock.Text);
            db.TblProducts.Add(tblProduct);
            db.SaveChanges();
            ProductList();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtProductId.Text);
            var value = db.TblProducts.Find(int.Parse(txtProductId.Text));
            db.TblProducts.Remove(value);
            db.SaveChanges();
            ProductList();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtProductId.Text);
            var value = db.TblProducts.Find(id);
            value.ProductName = cmbCategory.Text;
            value.ProductPrice = decimal.Parse(txtProductPrice.Text);
            value.CategoryId = (int)cmbProductCategory.SelectedValue;
            value.ProductStock = int.Parse(txtProductStock.Text);
            db.SaveChanges();
            ProductList();
        }
        private void btnCategoryList_Click(object sender, EventArgs e)
        {
            FrmCategory frmCategory = new FrmCategory();
            frmCategory.Show();
        }
        private void btnCategoryAdd_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(cmbProductCategory.Text);
            var value = db.TblCategories.Find(id);
            cmbCategory.Text = value.CategoryName;
        }
    }
}
