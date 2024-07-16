using Microsoft.IdentityModel.Tokens;
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

namespace TechTestsDb.Forms
{
    public partial class NewAddQuestionForm : Form
    {
        private TechTestsDbContext DbContext { get; set; }

        private Question Question { get; set; } = new();

        List<Description> Descriptions { get; set; } = new();
        List<Category> Categories { get; set; } = new();

        private List<int> SelectedCategoryIndexes { get; set; } = new();
        internal NewAddQuestionForm(TechTestsDbContext dbContext)
        {
            InitializeComponent();
            this.DbContext = dbContext;

            this.UpdateFromDb();

            this.firstTypeGroupBox.Enabled = false;
            this.secondThirdTypeGroupBox.Enabled = false;
            this.fourthFifthTypeGroupBox.Enabled = false;

            this.firstTypeRadioButton.Checked = false;
            this.secondTypeRadioButton.Checked = false;
            this.thirdTypeRadioButton.Checked = false;
            this.fourthTypeRadioButton.Checked = false;
            this.fifthTypeRadioButton.Checked = false;
        }

        private void UpdateFromDb()
        {
            this.Descriptions = this.DbContext.Descriptions.ToList();
            List<string> descriptions = this.Descriptions
                .Select(d => $"Id: {d.Id}, Value: {d.Value}")
                .ToList();
            this.descriptionsListBox.DataSource = (new List<string>() { "Id: 0, Value: Without description" })
                .Concat(descriptions)
                .ToList();

            this.Categories = this.DbContext.Categories.ToList();
            List<string> categories = this.Categories
                .Select(c => $"Id: {c.Id}, Name: {c.Name}")
                .ToList();
            this.categoriesListBox.DataSource = categories;
        }

        private void UpdateAnswerSetsComboBox()
        {
            List<string> answerSets = new();
            for (int i = 0; i < this.Question.Answers.Count; i++)
            {
                answerSets.Add($"{i + 1}");
            }

            this.answerSetsComboBox.DataSource = answerSets;
        }

        private void UpdateAnswers1ListBox()
        {
            Answer selectedSet = this.Question.Answers[this.answerSetsComboBox.SelectedIndex];
            List<string> answers = new();
            for (int i = 0; i < selectedSet.AnswerValues.Count; i++)
            {
                answers.Add($"{selectedSet.AnswerValues[i].Value}");
            }

            this.answer1ListBox.DataSource = answers;
        }

        private void UpdateAnswers2ListBox()
        {
            Answer selectedSet = this.Question.Answers[0];
            List<string> answers = new();
            for (int i = 0; i < selectedSet.AnswerValues.Count; i++)
            {
                answers.Add($"Is correct: {selectedSet.AnswerValues[i].IsCorrect}, Value: {selectedSet.AnswerValues[i].Value}");
            }

            this.answer2ListBox.DataSource = answers;
        }

        private void UpdateForm()
        {
            this.SelectedCategoryIndexes = new();
            this.Question = new();
            this.UpdateFromDb();

            this.isCaseSensitiveCheckBox.Checked = false;
            this.isCorrectAnswerCheckBox.Checked = false;

            this.firstTypeRadioButton.Checked = false;
            this.secondTypeRadioButton.Checked = false;
            this.thirdTypeRadioButton.Checked = false;
            this.fourthTypeRadioButton.Checked = false;
            this.fifthTypeRadioButton.Checked = false;

            this.questionTextBox.Text = string.Empty;
            this.answer1TextBox.Text = string.Empty;
            this.answer2TextBox.Text = string.Empty;

            this.answerSetsComboBox.DataSource = new List<string>();
            this.answerSetsComboBox.SelectedIndex = -1;
            this.answerSetsComboBox.Text = string.Empty;

            this.answer1ListBox.DataSource = new List<string>();
            this.answer2ListBox.DataSource = new List<string>();
            this.UpdateAnswerSetsComboBox();

            this.yesRadioButton.Checked = false;
            this.noRadioButton.Checked = false;

            this.firstTypeGroupBox.Enabled = false;
            this.secondThirdTypeGroupBox.Enabled = false;
            this.fourthFifthTypeGroupBox.Enabled = false;
        }

        private void descriptionsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.descriptionsListBox.SelectedIndex != 0)
            {
                this.Question.Description = this.Descriptions[this.descriptionsListBox.SelectedIndex - 1];
                this.Question.DescriptionId = this.Descriptions[this.descriptionsListBox.SelectedIndex - 1].Id;
            }
            else
            {
                this.Question.Description = null;
                this.Question.DescriptionId = null;
            }
        }

        private void categoriesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedCategoryIndexes = this.categoriesListBox.SelectedIndices.Cast<int>().ToList();
        }

        private void addAnswerSetButton_Click(object sender, EventArgs e)
        {
            this.Question.Answers.Add(new());
            this.UpdateAnswerSetsComboBox();

            this.answerSetsComboBox.SelectedIndex = this.Question.Answers.Count - 1;
        }

        private void deleteSetButton_Click(object sender, EventArgs e)
        {
            if (this.Question.Answers.Count > 0)
            {
                this.Question.Answers.RemoveAt(this.answerSetsComboBox.SelectedIndex);
                this.UpdateAnswerSetsComboBox();
            }
        }

        private void add1Button_Click(object sender, EventArgs e)
        {
            if (this.Question.Answers.Count > 0 && !String.IsNullOrEmpty(this.answer1TextBox.Text))
            {
                this.Question.Answers[this.answerSetsComboBox.SelectedIndex].AnswerValues.Add(new AnswerValue()
                {
                    IsCorrect = true,
                    Value = this.answer1TextBox.Text
                });
                this.answer1TextBox.Text = string.Empty;

                this.UpdateAnswers1ListBox();
            }
            else if (this.Question.Answers.Count == 0)
            {
                MessageBox.Show(Constants.ERR_ANSWER_SETS_COUNT_0);
            }
            else if (String.IsNullOrEmpty(this.answer1TextBox.Text))
            {
                MessageBox.Show(Constants.ERR_INPUT_IS_EMPTY);
            }
        }

        private void delete1Button_Click(object sender, EventArgs e)
        {
            Answer selectedSet = this.Question.Answers[this.answerSetsComboBox.SelectedIndex];
            selectedSet.AnswerValues.RemoveAt(this.answer1ListBox.SelectedIndex);
            this.UpdateAnswers1ListBox();
        }

        private void answerSetsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.UpdateAnswers1ListBox();
        }

        private void add2Button_Click(object sender, EventArgs e)
        {
            if (this.Question.Answers.Count == 0)
                this.Question.Answers.Add(new Answer());

            if (!String.IsNullOrEmpty(this.answer2TextBox.Text))
            {
                this.Question.Answers[0].AnswerValues.Add(new AnswerValue()
                {
                    Answer = this.Question.Answers[0],
                    IsCorrect = this.isCorrectAnswerCheckBox.Checked,
                    Value = this.answer2TextBox.Text
                });

                this.answer2TextBox.Text = string.Empty;
                this.isCorrectAnswerCheckBox.Checked = false;

                this.UpdateAnswers2ListBox();
            }
            else
            {
                MessageBox.Show(Constants.ERR_INPUT_IS_EMPTY);
            }
        }

        private void delete2Button_Click(object sender, EventArgs e)
        {
            this.Question.Answers[0].AnswerValues.RemoveAt(this.answer2ListBox.SelectedIndex);
            this.UpdateAnswers2ListBox();
        }

        private void firstTypeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.Question.Type = this.DbContext.Types.First(t => t.Name == Constants.FIRST_TYPE_NAME);
            this.firstTypeGroupBox.Enabled = true;
            this.Question.Answers = new() { new Answer() };
        }

        private void secondTypeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.Question.Type = this.DbContext.Types.First(t => t.Name == Constants.SECOND_TYPE_NAME);
            this.firstTypeGroupBox.Enabled = false;
            this.fourthFifthTypeGroupBox.Enabled = false;

            this.secondThirdTypeGroupBox.Enabled = true;

            this.Question.Answers = new();
        }

        private void trirdTypeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.Question.Type = this.DbContext.Types.First(t => t.Name == Constants.THIRD_TYPE_NAME);
            this.firstTypeGroupBox.Enabled = false;
            this.fourthFifthTypeGroupBox.Enabled = false;

            this.secondThirdTypeGroupBox.Enabled = true;

            this.Question.Answers = new();
        }

        private void fourthTypeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.Question.Type = this.DbContext.Types.First(t => t.Name == Constants.FOURTH_TYPE_NAME);
            this.firstTypeGroupBox.Enabled = false;
            this.secondThirdTypeGroupBox.Enabled = false;

            this.fourthFifthTypeGroupBox.Enabled = true;

            this.Question.Answers = new() { new Answer() };
        }

        private void fifthTypeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.Question.Type = this.DbContext.Types.First(t => t.Name == Constants.FIFTH_TYPE_NAME);
            this.firstTypeGroupBox.Enabled = false;
            this.secondThirdTypeGroupBox.Enabled = false;

            this.fourthFifthTypeGroupBox.Enabled = true;

            this.Question.Answers = new() { new Answer() };
        }

        private void addQuestionButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.questionTextBox.Text))
            {
                MessageBox.Show(Constants.ERR_INPUT_IS_EMPTY);
                return;
            }

            if (this.SelectedCategoryIndexes.Count == 0)
            {
                MessageBox.Show(Constants.ERR_CATEGORY_IS_NOT_SELECTED);
                return;
            }

            if (this.Question.Answers.Count == 0)
            {
                MessageBox.Show(Constants.ERR_ANSWER_SETS_COUNT_0);
            }

            if (this.Question.Answers.Any(a => a.AnswerValues.Count == 0))
            {
                MessageBox.Show(Constants.ERR_ANSWER_SET_IS_EMPTY);
            }

            this.Question.Value = this.questionTextBox.Text;

            for (int i = 0; i < this.SelectedCategoryIndexes.Count; i++)
            {
                this.Question.Category_Question.Add(new Category_Question()
                {
                    Category = this.Categories[this.SelectedCategoryIndexes[i]],
                    CategoryId = this.Categories[this.SelectedCategoryIndexes[i]].Id,
                    Question = this.Question
                });
            }

            this.DbContext.Questions.Add(this.Question);
            try
            {
                this.DbContext.SaveChanges();
                MessageBox.Show(Constants.QUESTION_ADDED);
                this.UpdateForm();
            }
            catch (Exception)
            {
                MessageBox.Show(Constants.ERR_QUESTION_CANNOT_BE_ADDED);
            }
        }

        private void yesRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.Question.Answers[0].AnswerValues.Add(new AnswerValue()
            {
                Value = Constants.YES_ANSWER,
                IsCorrect = true
            });
        }

        private void noRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.Question.Answers[0].AnswerValues.Add(new AnswerValue()
            {
                Value = Constants.NO_ANSWER,
                IsCorrect = true
            });
        }

        private void isCaseSensitiveCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.Question.IsCaseSensitive = this.isCaseSensitiveCheckBox.Checked;
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            this.UpdateForm();
        }
    }
}
