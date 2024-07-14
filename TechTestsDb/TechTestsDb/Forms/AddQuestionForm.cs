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

namespace TechTestsDb
{
    public partial class AddQuestionForm : Form
    {
        internal TechTestsDbContext DbContext { get; set; } = new();

        internal Question Question { get; set; } = new();

        internal List<Description> Descriptions { get; set; }
        internal List<Category> Categories { get; set; }

        internal int SelectedAnswearIndex { get; set; } = -1;
        public AddQuestionForm()
        {
            InitializeComponent();

            this.Descriptions = DbContext.Descriptions.ToList();
            List<int> descriptionIdsDataSource = new List<int>() { 0 };
            descriptionIdsDataSource.AddRange(this.Descriptions.Select(d => d.Id).ToList());
            this.descriptionIdsComboBox.DataSource = descriptionIdsDataSource;

            this.Categories = DbContext.Categories.ToList();
            this.categoriesComboBox.DataSource = this.Categories.Select(c => c.Name).ToList();
        }

        private void addQuestionButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Question.IsCaseSensitive = this.isCaseSensitive.Checked;
                this.Question.Value = this.questionTextBox.Text;

                this.DbContext.Questions.Add(this.Question);
                this.DbContext.SaveChanges();

                this.Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void descriptionIdsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.descriptionIdsComboBox.SelectedIndex == 0)
            {
                this.Question.Description = null;
                this.Question.DescriptionId = null;
            }
            else if (this.descriptionIdsComboBox.SelectedIndex != 0)
            {
                this.descriptionTextBox.Text = this.Descriptions
                .First(d => d.Id == Convert.ToInt32(this.descriptionIdsComboBox.SelectedItem.ToString()))
                .Value;
                this.Question.DescriptionId = Convert.ToInt32(this.descriptionIdsComboBox.Text);
                this.Question.Description = this.DbContext.Descriptions.First(d => d.Id == this.Question.DescriptionId);
            }
        }

        private void addAnswearButton_Click(object sender, EventArgs e)
        {
            List<string> answears = new List<string>();
            this.Question.Answers.Add(new Answer());
            for (int i = 1; i <= this.Question.Answers.Count; i++)
            {
                answears.Add($"{i}");
            }

            this.answearsComboBox.DataSource = answears;

            this.answearsComboBox.SelectedIndex = this.Question.Answers.Count - 1;
        }

        private void addAnswearsButton_Click(object sender, EventArgs e)
        {
            this.Question.Answers[this.SelectedAnswearIndex].AnswerValues = new();
            List<string> answearValues = this.answearTextBox.Text.Split('\n').ToList();
            for (int i = 0; i < answearValues.Count; i++)
            {
                this.Question.Answers[this.SelectedAnswearIndex].AnswerValues.Add(new AnswerValue() { Value = answearValues[i] });
            }
        }

        private void answearsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedAnswearIndex = this.answearsComboBox.SelectedIndex;
            this.answearTextBox.Text = string.Empty;
            for (int i = 0; i < this.Question.Answers[this.SelectedAnswearIndex].AnswerValues.Count; i++)
            {
                this.answearTextBox.Text += $"{this.Question.Answers[this.SelectedAnswearIndex].AnswerValues[i].Value}\r\n";
            }
        }

        private void type1RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.Question.Type = this.DbContext.Types.First(t => t.Name == this.type1RadioButton.Text);
        }

        private void type2RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.Question.Type = this.DbContext.Types.First(t => t.Name == this.type2RadioButton.Text);
        }

        private void type3RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.Question.Type = this.DbContext.Types.First(t => t.Name == this.type3RadioButton.Text);
        }

        private void categoriesComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            /*Category? category = this.DbContext.Categories.FirstOrDefault(c => c.Name == this.categoriesComboBox.Text);
            if (this.Question.Categories.Contains(category))
            {
                this.Question.Categories.Remove(category);
                this.categoriesTextBox.Text = string.Empty;
                for (int i = 0; i < this.Question.Categories.Count; i++)
                {
                    this.categoriesTextBox.Text += $"{this.Question.Categories[i].Name}\r\n";
                }
            }
            else
            {
                this.Question.Categories.Add(category);
                this.categoriesTextBox.Text = string.Empty;
                for (int i = 0; i < this.Question.Categories.Count; i++)
                {
                    this.categoriesTextBox.Text += $"{this.Question.Categories[i].Name}\r\n";
                }
            }*/
        }

        private void yesRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.Question.Answers = new();
            this.Question.Answers.Add(new Answer() { AnswerValues = new List<AnswerValue>() { new AnswerValue { Value = "Так" } } });
        }

        private void noRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.Question.Answers = new();
            this.Question.Answers.Add(new Answer() { AnswerValues = new List<AnswerValue>() { new AnswerValue { Value = "Так" } } });
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            this.Reset();
        }

        private void Reset()
        {
            this.descriptionIdsComboBox.SelectedIndex = 0;
            this.descriptionTextBox.Text = string.Empty;

            this.type1RadioButton.Checked = false;
            this.type2RadioButton.Checked = false;
            this.type3RadioButton.Checked = false;

            this.yesRadioButton.Checked = false;
            this.noRadioButton.Checked = false;

            this.questionTextBox.Text = string.Empty;

            this.categoriesTextBox.Text = string.Empty;

            this.answearTextBox.Text = string.Empty;

            this.isCaseSensitive.Checked = false;

            this.answearsComboBox.DataSource = new List<string>();

            this.SelectedAnswearIndex = -1;

            this.Question = new();
            this.Question.Description = null;
            this.Question.DescriptionId = null;
        }
    }
}
