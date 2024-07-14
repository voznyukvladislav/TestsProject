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
    public partial class QuestionGroupForm : Form
    {
        private ManagementForm ManagementForm { get; set; }
        private TechTestsDbContext DbContext { get; set; }
        private string Action { get; set; } = string.Empty;
        private QuestionGroup QuestionGroup { get; set; } = new();
        internal QuestionGroupForm(TechTestsDbContext dbContext, string action, ManagementForm managementForm)
        {
            InitializeComponent();
            this.DbContext = dbContext;
            this.Action = action;
            ManagementForm = managementForm;
        }
        internal QuestionGroupForm(TechTestsDbContext dbContext, string action, QuestionGroup questionGroup, ManagementForm managementForm)
        {
            InitializeComponent();
            this.DbContext = dbContext;
            this.Action = action;
            this.QuestionGroup = questionGroup;
            this.ManagementForm = managementForm;

            this.idTextBox.Text = $"{this.QuestionGroup.Id}";
            this.nameTextBox.Text = this.QuestionGroup.Name;
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.QuestionGroup.Name = this.nameTextBox.Text;
                if (this.Action == Constants.ACTION_ADD)
                {
                    this.DbContext.QuestionGroups.Add(this.QuestionGroup);
                }
                else if (this.Action == Constants.ACTION_UPDATE)
                {
                    this.DbContext.QuestionGroups.Update(this.QuestionGroup);
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

        private void QuestionGroupForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.applyButton_Click(sender, e);
                this.ManagementForm.UpdateTableDataListBox();
            }
        }
    }
}
