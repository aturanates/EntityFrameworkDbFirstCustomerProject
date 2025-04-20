using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace EntityFrameworkCustomerDbFirst
{
    public partial class FrmCategory: Form
    {
        public FrmCategory()
        {
            InitializeComponent();
        }

        DbFirstEFEntities db = new DbFirstEFEntities();
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        void CategoryList()
        {
            dataGridView1.DataSource = db.TblCategories.ToList();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            CategoryList();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            TblCategory tblCategory = new TblCategory();
            tblCategory.CategoryName = txtCategoryName.Text;
            db.TblCategories.Add(tblCategory);
            db.SaveChanges();
            CategoryList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCategoryId.Text);
            var value = db.TblCategories.Find(int.Parse(txtCategoryId.Text));
            db.TblCategories.Remove(value);
            db.SaveChanges();
            CategoryList();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id=Convert.ToInt32(txtCategoryId.Text);
            var value = db.TblCategories.Find(id);
            value.CategoryName = txtCategoryName.Text;
            db.SaveChanges();
            CategoryList();
        }
    }
}
