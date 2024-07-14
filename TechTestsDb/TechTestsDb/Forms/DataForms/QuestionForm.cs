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
    public partial class QuestionForm : Form
    {
        private ManagementForm ManagementForm { get; set; }
        private TechTestsDbContext DbContext { get; set; }
        private string Action { get; set; } = string.Empty;
        private Question Question { get; set; } = new();
        internal QuestionForm(TechTestsDbContext dbContext, string action, ManagementForm managementForm)
        {
            InitializeComponent();
            this.DbContext = dbContext;
            this.Action = action;
            ManagementForm = managementForm;
        }
        internal QuestionForm(TechTestsDbContext dbContext, string action, Question question, ManagementForm managementForm)
        {
            InitializeComponent();
            this.DbContext = dbContext;
            this.Action = action;
            this.Question = question;
            this.ManagementForm = managementForm;

            this.idTextBox.Text = $"{this.Question.Id}";
            this.typeIdTextBox.Text = $"{this.Question.TypeId}";
            this.descriptionIdTextBox.Text = $"{this.Question.DescriptionId}";
            this.valueTextBox.Text = $"{this.Question.Value}";
            this.isCaseSensitiveCheckBox.Checked = this.Question.IsCaseSensitive;
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Question.TypeId = Convert.ToInt32(this.typeIdTextBox.Text);
                this.Question.DescriptionId = Convert.ToInt32(this.descriptionIdTextBox.Text);
                this.Question.Type = this.DbContext.Types.First(t => t.Id == this.Question.TypeId);
                this.Question.Description = this.DbContext.Descriptions.First(d => d.Id == this.Question.DescriptionId);

                this.Question.Value = this.valueTextBox.Text;
                this.Question.IsCaseSensitive = this.isCaseSensitiveCheckBox.Checked;

                if (this.Action == Constants.ACTION_ADD)
                {
                    this.DbContext.Questions.Add(this.Question);
                }
                else if (this.Action == Constants.ACTION_UPDATE)
                {
                    this.DbContext.Questions.Update(this.Question);
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

        private void QuestionForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.applyButton_Click(sender, e);
                this.ManagementForm.UpdateTableDataListBox();
            }
        }
    }
}
