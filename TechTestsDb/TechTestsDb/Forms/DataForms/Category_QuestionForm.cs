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
    public partial class Category_QuestionForm : Form
    {
        private ManagementForm ManagementForm { get; set; }
        private TechTestsDbContext DbContext { get; set; }
        private string Action { get; set; } = string.Empty;
        private Category_Question Category_Question { get; set; } = new();
        internal Category_QuestionForm(TechTestsDbContext dbContext, string action, ManagementForm managementForm)
        {
            InitializeComponent();
            this.DbContext = dbContext;
            this.Action = action;
            ManagementForm = managementForm;
        }
        internal Category_QuestionForm(TechTestsDbContext dbContext, string action, Category_Question category_Question, ManagementForm managementForm)
        {
            InitializeComponent();
            this.DbContext = dbContext;
            this.Action = action;
            this.Category_Question = category_Question;
            this.ManagementForm = managementForm;

            this.categoryIdTextBox.Text = $"{this.Category_Question.CategoryId}";
            this.questionIdTextBox.Text = $"{this.Category_Question.QuestionId}";

            this.categoryIdTextBox.ReadOnly = true;
            this.questionIdTextBox.ReadOnly = true;
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Category_Question.QuestionId = Convert.ToInt32(this.categoryIdTextBox.Text);
                this.Category_Question.CategoryId = Convert.ToInt32(this.questionIdTextBox.Text);
                this.Category_Question.Category = this.DbContext.Categories.First(c => c.Id == this.Category_Question.CategoryId);
                this.Category_Question.Question = this.DbContext.Questions.First(q => q.Id == this.Category_Question.QuestionId);
                if (this.Action == Constants.ACTION_ADD)
                {
                    this.DbContext.Category_Questions.Add(this.Category_Question);
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

        private void Category_QuestionForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.applyButton_Click(sender, e);
                this.ManagementForm.UpdateTableDataListBox();
            }
        }
    }
}
