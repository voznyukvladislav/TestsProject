using Microsoft.EntityFrameworkCore;
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
    public partial class QuestionGroupsForm : Form
    {
        private TechTestsDbContext DbContext { get; set; }
        private QuestionGroup QuestionGroup { get; set; } = new();

        private List<Question> Questions { get; set; } = new();
        private List<QuestionGroup> QuestionGroups { get; set; } = new();

        private List<Question> FreeQuestions { get; set; } = new();
        private List<Question> SelectedQuestions { get; set; } = new();

        internal QuestionGroupsForm(TechTestsDbContext dbContext)
        {
            InitializeComponent();

            this.DbContext = dbContext;

            this.QuestionGroups = this.DbContext.QuestionGroups
                .Include(qg => qg.Question_QuestionGroup)
                .ThenInclude(qqg => qqg.Question)
                .ThenInclude(q => q.Category_Question)
                .ThenInclude(cq => cq.Category)
                .ToList();
            this.Questions = this.DbContext.Questions
                .Include(q => q.Category_Question)
                .ThenInclude(cq => cq.Category)
                .ToList();

            this.UpdateQuestionGroupsComboBox();
            this.UpdateLists();
        }

        private void UpdateQuestionGroupsComboBox()
        {
            List<string> questionGroupsComboBoxDataSource = this.QuestionGroups
                .Select(qg => $"Id: {qg.Id}, Name: {qg.Name}")
                .ToList();
            this.questionGroupsComboBox.DataSource = questionGroupsComboBoxDataSource;
        }

        private void UpdateQuestionsListBox(ListBox listBox, List<Question> questions)
        {
            List<string> listBoxDataSource = new List<string>();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < questions.Count; i++)
            {
                sb.Append($"Id: {questions[i].Id}, Value: {questions[i].Value}, Categories: ");
                for (int j = 0; j < questions[i].Category_Question.Count; j++)
                {
                    sb.Append($"{questions[i].Category_Question[j].Category.Name}");
                    if (j < questions[i].Category_Question.Count - 1)
                    {
                        sb.Append(", ");
                    }
                }

                listBoxDataSource.Add(sb.ToString());
                sb.Clear();
            }

            listBox.DataSource = listBoxDataSource;
        }

        private void UpdateLists()
        {
            this.UpdateQuestionsListBox(this.freeQuestionsListBox, this.FreeQuestions);
            this.UpdateQuestionsListBox(this.selectedQuestionsListBox, this.SelectedQuestions);
        }

        private void UpdateForm()
        {
            this.questionGroupNameTextBox.Text = string.Empty;
            this.questionGroupsComboBox.DataSource = new List<string>();
            this.questionGroupsComboBox.Text = string.Empty;
            this.freeQuestionsListBox.DataSource = new List<string>();
            this.selectedQuestionsListBox.DataSource = new List<string>();
        }

        private void addQuestionGroupButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.questionGroupNameTextBox.Text))
            {
                MessageBox.Show(Constants.ERR_QUESTION_GROUP_NAME_EMPTY);
                return;
            }

            this.QuestionGroup = new();
            this.QuestionGroup.Name = this.questionGroupNameTextBox.Text;

            this.QuestionGroups.Add(this.QuestionGroup);

            this.DbContext.QuestionGroups.Add(this.QuestionGroup);
            this.DbContext.SaveChanges();

            this.UpdateQuestionGroupsComboBox();

            this.questionGroupsComboBox.SelectedIndex = this.QuestionGroups.Count - 1;
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            this.DbContext.QuestionGroups.Update(this.QuestionGroup);
            this.DbContext.SaveChanges();
        }

        private void questionGroupsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.questionGroupsComboBox.SelectedIndex == -1)
            {
                this.QuestionGroup = new();
                this.questionGroupNameTextBox.Text = string.Empty;
                this.freeQuestionsListBox.DataSource = new List<string>();
                this.selectedQuestionsListBox.DataSource = new List<string>();

                return;
            }

            this.QuestionGroup = this.QuestionGroups[this.questionGroupsComboBox.SelectedIndex];
            this.questionGroupNameTextBox.Text = this.QuestionGroup.Name;
            this.SelectedQuestions = this.QuestionGroup.Question_QuestionGroup
                .Select(qqg => qqg.Question)
                .ToList();

            this.FreeQuestions = this.Questions
                .Except(this.SelectedQuestions)
                .ToList();

            this.UpdateLists();
        }

        private void addQuestionButton_Click(object sender, EventArgs e)
        {
            if (this.freeQuestionsListBox.SelectedIndex == -1) return;

            this.SelectedQuestions.Add(this.FreeQuestions[this.freeQuestionsListBox.SelectedIndex]);
            this.FreeQuestions.RemoveAt(this.freeQuestionsListBox.SelectedIndex);

            this.FreeQuestions = this.FreeQuestions
                .OrderBy(fq => fq.Id)
                .ToList();
            this.SelectedQuestions = this.SelectedQuestions
                .OrderBy(sq => sq.Id)
                .ToList();

            this.UpdateLists();
        }

        private void removeQuestionButton_Click(object sender, EventArgs e)
        {
            if (this.selectedQuestionsListBox.SelectedIndex == -1) return;

            this.FreeQuestions.Add(this.SelectedQuestions[this.selectedQuestionsListBox.SelectedIndex]);
            this.SelectedQuestions.RemoveAt(this.selectedQuestionsListBox.SelectedIndex);

            this.FreeQuestions = this.FreeQuestions
                .OrderBy(fq => fq.Id)
                .ToList();
            this.SelectedQuestions = this.SelectedQuestions
                .OrderBy(sq => sq.Id)
                .ToList();

            this.UpdateLists();
        }

        private void saveChangesButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.QuestionGroup.Name))
            {
                MessageBox.Show(Constants.ERR_INPUT_IS_EMPTY);
                return;
            }

            this.QuestionGroup.Name = this.questionGroupNameTextBox.Text;
            this.QuestionGroup.Question_QuestionGroup = new();
            for (int i = 0; i < this.SelectedQuestions.Count; i++)
            {
                this.QuestionGroup.Question_QuestionGroup.Add(new Question_QuestionGroup()
                {
                    Question = this.SelectedQuestions[i],
                    QuestionId = this.SelectedQuestions[i].Id,
                    QuestionGroup = this.QuestionGroup
                });
            }

            this.DbContext.QuestionGroups.Update(this.QuestionGroup);
            this.DbContext.SaveChanges();
        }

        private void deleteQuestionGroupButton_Click(object sender, EventArgs e)
        {
            if (this.questionGroupsComboBox.SelectedIndex == -1) return;

            this.QuestionGroups.RemoveAt(this.questionGroupsComboBox.SelectedIndex);
            
            this.DbContext.QuestionGroups.Remove(this.QuestionGroup);
            this.DbContext.SaveChanges();

            this.UpdateQuestionGroupsComboBox();

            if (this.QuestionGroups.Count > 0)
                this.questionGroupsComboBox.SelectedIndex = 0;
            else
            {
                this.UpdateForm();
            }
        }
    }
}
