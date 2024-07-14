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
    public partial class DescriptionForm : Form
    {
        private ManagementForm ManagementForm { get; set; }
        private TechTestsDbContext DbContext { get; set; }
        private string Action { get; set; } = string.Empty;
        private Description Description { get; set; } = new();
        internal DescriptionForm(TechTestsDbContext dbContext, string action, ManagementForm managementForm)
        {
            InitializeComponent();
            this.DbContext = dbContext;
            this.Action = action;
            ManagementForm = managementForm;
        }
        internal DescriptionForm(TechTestsDbContext dbContext, string action, Description description, ManagementForm managementForm)
        {
            InitializeComponent();
            this.DbContext = dbContext;
            this.Action = action;
            this.Description = description;
            this.ManagementForm = managementForm;

            this.idTextBox.Text = $"{this.Description.Id}";
            this.valueTextBox.Text = this.Description.Value;
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Description.Value = this.valueTextBox.Text;
                if (this.Action == Constants.ACTION_ADD)
                {
                    this.DbContext.Descriptions.Add(this.Description);
                }
                else if (this.Action == Constants.ACTION_UPDATE)
                {
                    this.DbContext.Descriptions.Update(this.Description);
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

        private void DescriptionForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.applyButton_Click(sender, e);
                this.ManagementForm.UpdateTableDataListBox();
            }
        }
    }
}
