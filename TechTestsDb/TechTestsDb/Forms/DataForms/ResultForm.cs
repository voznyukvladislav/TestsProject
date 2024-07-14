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
    public partial class ResultForm : Form
    {
        private ManagementForm ManagementForm { get; set; }
        private TechTestsDbContext DbContext { get; set; }
        private string Action { get; set; } = string.Empty;
        private Result Result { get; set; } = new();
        internal ResultForm(TechTestsDbContext dbContext, string action, ManagementForm managementForm)
        {
            InitializeComponent();
            this.DbContext = dbContext;
            this.Action = action;
            ManagementForm = managementForm;
        }
        internal ResultForm(TechTestsDbContext dbContext, string action, Result result, ManagementForm managementForm)
        {
            InitializeComponent();
            this.DbContext = dbContext;
            this.Action = action;
            this.Result = result;
            this.ManagementForm = managementForm;

            this.idTextBox.Text = $"{this.Result.Id}";
            this.userIdTextBox.Text = $"{this.Result.UserId}";
            this.questionGroupIdTextBox.Text = $"{this.Result.QuestionGroupId}";
            this.resultTextBox.Text = this.Result.ResultJson;
            this.dateTimeTextBox.Text = this.Result.DateTime.ToString();
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Result.UserId = Convert.ToInt32(this.userIdTextBox.Text);
                this.Result.QuestionGroupId = Convert.ToInt32(this.questionGroupIdTextBox.Text);
                this.Result.DateTime = DateTime.Parse(this.dateTimeTextBox.Text);
                this.Result.ResultJson = this.resultTextBox.Text;

                this.Result.User = this.DbContext.Users.First(u => u.Id == this.Result.UserId);
                this.Result.QuestionGroup = this.DbContext.QuestionGroups.First(qg => qg.Id == this.Result.QuestionGroupId);
                if (this.Action == Constants.ACTION_ADD)
                {
                    this.DbContext.Add(this.Result);
                }
                else if (this.Action == Constants.ACTION_UPDATE)
                {
                    this.DbContext.Update(this.Result);
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

        private void ResultForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.applyButton_Click(sender, e);
                this.ManagementForm.UpdateTableDataListBox();
            }
        }
    }
}
