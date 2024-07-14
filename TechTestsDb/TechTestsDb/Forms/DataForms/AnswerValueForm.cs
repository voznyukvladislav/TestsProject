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
    public partial class AnswerValueForm : Form
    {
        private ManagementForm ManagementForm { get; set; }
        private TechTestsDbContext DbContext { get; set; }
        private string Action { get; set; } = string.Empty;
        private AnswerValue AnswerValue { get; set; } = new();
        internal AnswerValueForm(TechTestsDbContext dbContext, string action, ManagementForm managementForm)
        {
            InitializeComponent();
            this.DbContext = dbContext;
            this.Action = action;
            ManagementForm = managementForm;
        }
        internal AnswerValueForm(TechTestsDbContext dbContext, string action, AnswerValue answerValue, ManagementForm managementForm)
        {
            InitializeComponent();
            this.DbContext = dbContext;
            this.Action = action;
            this.AnswerValue = answerValue;
            this.ManagementForm = managementForm;

            this.idTextBox.Text = $"{this.AnswerValue.Id}";
            this.answerIdTextBox.Text = $"{this.AnswerValue.AnswerId}";
            this.valueTextBox.Text = this.AnswerValue.Value;
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.AnswerValue.AnswerId = Convert.ToInt32(this.answerIdTextBox.Text);
                this.AnswerValue.Answer = this.DbContext.Answers.First(a => a.Id == this.AnswerValue.AnswerId);
                this.AnswerValue.Value = this.valueTextBox.Text;
                if (this.Action == Constants.ACTION_ADD)
                {
                    this.DbContext.AnswerValues.Add(this.AnswerValue);
                }
                else if (this.Action == Constants.ACTION_UPDATE)
                {
                    this.DbContext.AnswerValues.Update(this.AnswerValue);
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

        private void AnswerValueForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.applyButton_Click(sender, e);
                this.ManagementForm.UpdateTableDataListBox();
            }
        }
    }
}
