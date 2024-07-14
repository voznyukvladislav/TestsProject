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
    public partial class AnswerForm : Form
    {
        private ManagementForm ManagementForm { get; set; }
        private TechTestsDbContext DbContext { get; set; }
        private string Action { get; set; } = string.Empty;
        private Answer Answer { get; set; } = new();
        internal AnswerForm(TechTestsDbContext dbContext, string action, ManagementForm managementForm)
        {
            InitializeComponent();
            this.DbContext = dbContext;
            this.Action = action;
            this.ManagementForm = managementForm;
        }
        internal AnswerForm(TechTestsDbContext dbContext, string action, Answer answer, ManagementForm managementForm)
        {
            InitializeComponent();
            this.DbContext = dbContext;
            this.Action = action;
            this.Answer = answer;
            this.ManagementForm = managementForm;

            this.idTextBox.Text = $"{answer.Id}";
            this.questionIdTextBox.Text = $"{answer.QuestionId}";
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Answer.QuestionId = Convert.ToInt32(this.questionIdTextBox.Text);
                this.Answer.Question = this.DbContext.Questions.First(q => q.Id == this.Answer.QuestionId);
                if (this.Action == Constants.ACTION_ADD)
                {
                    this.DbContext.Answers.Add(this.Answer);
                }
                else if (this.Action == Constants.ACTION_UPDATE)
                {
                    this.DbContext.Answers.Update(this.Answer);
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

        private void AnswerForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.applyButton_Click(sender, e);
                this.ManagementForm.UpdateTableDataListBox();
            }
        }
    }
}
