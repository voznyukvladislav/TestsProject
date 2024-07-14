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
    public partial class Question_QuestionGroupForm : Form
    {
        private ManagementForm ManagementForm { get; set; }
        private TechTestsDbContext DbContext { get; set; }
        private string Action { get; set; } = string.Empty;
        private Question_QuestionGroup Question_QuestionGroup { get; set; } = new();
        internal Question_QuestionGroupForm(TechTestsDbContext dbContext, string action, ManagementForm managementForm)
        {
            InitializeComponent();
            this.DbContext = dbContext;
            this.Action = action;
            ManagementForm = managementForm;
        }
        internal Question_QuestionGroupForm(TechTestsDbContext dbContext, string action, Question_QuestionGroup question_QuestionGroup, ManagementForm managementForm)
        {
            InitializeComponent();
            this.DbContext = dbContext;
            this.Action = action;
            this.Question_QuestionGroup = question_QuestionGroup;
            this.ManagementForm = managementForm;

            this.questionIdTextBox.ReadOnly = true;
            this.questionGroupIdTextBox.ReadOnly = true;

            this.questionIdTextBox.Text = $"{this.Question_QuestionGroup.QuestionId}";
            this.questionGroupIdTextBox.Text = $"{this.Question_QuestionGroup.QuestionGroupId}";
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Action == Constants.ACTION_ADD)
                {
                    this.Question_QuestionGroup.QuestionId = Convert.ToInt32(this.questionIdTextBox.Text);
                    this.Question_QuestionGroup.QuestionGroupId = Convert.ToInt32(this.questionGroupIdTextBox.Text);
                    this.Question_QuestionGroup.Question = this.DbContext.Questions.First(q => q.Id == this.Question_QuestionGroup.QuestionId);
                    this.Question_QuestionGroup.QuestionGroup = this.DbContext.QuestionGroups.First(qg => qg.Id == this.Question_QuestionGroup.QuestionGroupId);

                    this.DbContext.Question_QuestionGroup.Add(this.Question_QuestionGroup);
                    this.DbContext.SaveChanges();
                }
                else if (this.Action == Constants.ACTION_UPDATE)
                {
                    this.Close();
                }
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

        private void Question_QuestionGroupForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.applyButton_Click(sender, e);
                this.ManagementForm.UpdateTableDataListBox();
            }
        }
    }
}
