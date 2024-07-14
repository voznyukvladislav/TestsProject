using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechTestsDb.Data;
using TechTestsDb.Models;

namespace TechTestsDb.Forms.DataForms
{
    public partial class CategoryForm : Form
    {
        private ManagementForm ManagementForm { get; set; }
        private TechTestsDbContext DbContext { get; set; }
        private string Action { get; set; } = string.Empty;
        private Category Category { get; set; } = new();
        internal CategoryForm(TechTestsDbContext dbContext, string action, ManagementForm managementForm)
        {
            InitializeComponent();
            this.DbContext = dbContext;
            this.Action = action;
            ManagementForm = managementForm;
        }
        internal CategoryForm(TechTestsDbContext dbContext, string action, Category category, ManagementForm managementForm)
        {
            InitializeComponent();
            this.DbContext = dbContext;
            this.Action = action;
            this.Category = category;
            this.ManagementForm = managementForm;

            this.idTextBox.Text = $"{this.Category.Id}";
            this.nameTextBox.Text = this.Category.Name;
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Category.Name = this.nameTextBox.Text;

                if (this.Action == Constants.ACTION_ADD)
                {
                    this.DbContext.Categories.Add(this.Category);
                }
                else if (this.Action == Constants.ACTION_UPDATE)
                {
                    this.DbContext.Categories.Update(this.Category);
                }

                this.DbContext.SaveChanges();
                this.Close();
            }
            catch
            {
                MessageBox.Show(Constants.ERR_INVALID_INPUT_VALUE);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CategoryForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.applyButton_Click(sender, e);
                this.ManagementForm.UpdateTableDataListBox();
            }
        }
    }
}
