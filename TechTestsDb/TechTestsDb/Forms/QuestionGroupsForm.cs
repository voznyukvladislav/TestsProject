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
        private List<Question> Questions { get; set; } = new();
        private List<QuestionGroup> QuestionGroups { get; set; } = new();
        private QuestionGroup QuestionGroup { get; set; } = new();

        private List<int> SelectedQuestionIndexes { get; set; } = new();
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

            this.questionGroupsComboBox.DataSource = this.QuestionGroups
                .Select(qg => $"Id: {qg.Id}, Name: {qg.Name}")
                .ToList();

            this.UpdateQuestionsListBox();
        }

        private void UpdateQuestionsListBox()
        {
            List<string> questionsListBoxDataSource = new();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.Questions.Count; i++)
            {
                sb.Append($"Id: {this.Questions[i].Id}, Value: {this.Questions[i].Value}, ");
                for (int j = 0; j < this.Questions[i].Category_Question.Count; j++)
                {
                    sb.Append($"{this.Questions[i].Category_Question[j].Category.Name}");
                    if (j < this.Questions[i].Category_Question.Count - 1)
                    {
                        sb.Append(", ");
                    }
                }
                questionsListBoxDataSource.Add(sb.ToString());
                sb.Clear();
            }

            this.questionsListBox.DataSource = questionsListBoxDataSource;

            this.SelectedQuestionIndexes = new();

            QuestionGroup selectedQuestionGroup = this.QuestionGroups[this.questionGroupsComboBox.SelectedIndex];
            for (int i = 0; i < selectedQuestionGroup.Question_QuestionGroup.Count; i++)
            {
                Question question = selectedQuestionGroup.Question_QuestionGroup[i].Question;
                int questionIndex = this.Questions.FindIndex(q => q.Id == question.Id);
                this.questionsListBox.SelectedIndex = questionIndex;
                this.SelectedQuestionIndexes.Add(questionIndex);
            }
        }

        private void UpdateQuestionGroupsComboBox()
        {
            this.QuestionGroups = this.DbContext.QuestionGroups
                .Include(qg => qg.Question_QuestionGroup)
                .ThenInclude(qqg => qqg.Question)
                .ThenInclude(q => q.Category_Question)
                .ThenInclude(cq => cq.Category)
                .ToList();
            this.questionGroupsComboBox.DataSource = this.QuestionGroups
                .Select(qg => $"Id: {qg.Id}, Name: {qg.Name}")
                .ToList();
        }

        private void addQuestionGroupButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.questionGroupNameTextBox.Text))
            {
                MessageBox.Show(Constants.ERR_QUESTION_GROUP_NAME_EMPTY);
                return;
            }

            this.QuestionGroup.Name = this.questionGroupNameTextBox.Text;
            this.DbContext.QuestionGroups.Add(this.QuestionGroup);
            this.DbContext.SaveChanges();

            this.UpdateQuestionGroupsComboBox();
            this.questionGroupNameTextBox.Text = string.Empty;
        }

        private void questionsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.QuestionGroup.Question_QuestionGroup = new();
            this.SelectedQuestionIndexes = this.questionsListBox.SelectedIndices.Cast<int>().ToList();
            for (int i = 0; i < this.SelectedQuestionIndexes.Count; i++)
            {
                this.QuestionGroup.Question_QuestionGroup.Add(new Question_QuestionGroup()
                {
                    QuestionGroup = this.QuestionGroup,
                    Question = this.Questions[this.SelectedQuestionIndexes[i]],
                    QuestionId = this.Questions[this.SelectedQuestionIndexes[i]].Id
                });
            }
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            this.DbContext.QuestionGroups.Update(this.QuestionGroup);
            this.DbContext.SaveChanges();
        }

        private void questionGroupsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.QuestionGroup = this.QuestionGroups[this.questionGroupsComboBox.SelectedIndex];
        }
    }
}
