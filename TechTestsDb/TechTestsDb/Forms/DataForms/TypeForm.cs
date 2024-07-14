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

namespace TechTestsDb.Forms.DataForms
{
    public partial class TypeForm : Form
    {
        private ManagementForm ManagementForm { get; set; }
        private TechTestsDbContext DbContext { get; set; }
        private string Action { get; set; } = string.Empty;
        private Models.Type Type { get; set; } = new();
        internal TypeForm(TechTestsDbContext dbContext, string action, ManagementForm managementForm)
        {
            InitializeComponent();
            this.DbContext = dbContext;
            this.Action = action;
            ManagementForm = managementForm;
        }
        internal TypeForm(TechTestsDbContext dbContext, string action, Models.Type type, ManagementForm managementForm)
        {
            InitializeComponent();
            this.DbContext = dbContext;
            this.Action = action;
            this.Type = type;
            this.ManagementForm = managementForm;

            this.idTextBox.Text = $"{this.Type.Id}";
            this.nameTextBox.Text = this.Type.Name;
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Type.Name = this.nameTextBox.Text;
                if (this.Action == Constants.ACTION_ADD)
                {
                    this.DbContext.Types.Add(this.Type);
                }
                else if (this.Action == Constants.ACTION_UPDATE)
                {
                    this.DbContext.Types.Update(this.Type);
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

        private void TypeForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.applyButton_Click(sender, e);
                this.ManagementForm.UpdateTableDataListBox();
            }
        }
    }
}
