using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
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
using TechTestsDb.DTOs;
using TechTestsDb.Forms.DataForms;
using TechTestsDb.Models;

namespace TechTestsDb.Forms
{
    public partial class ManagementForm : Form
    {
        // Main data
        internal TechTestsDbContext DbContext { get; set; }
        public List<string> TableNames { get; set; } = new List<string>()
        {
            "Categories",
            "Types",
            "Descriptions",
            "Questions",
            "Answers",
            "AnswerValues",
            "QuestionGroups",
            "Users",
            "Results",
            "Category_Question",
            "Question_QuestionGroup"
        };

        // Values from DB
        internal List<Answer> Answers { get; set; } = new();
        internal List<AnswerValue> AnswerValues { get; set; } = new();
        internal List<Category_Question> Category_Question { get; set; } = new();
        internal List<Category> Categories { get; set; } = new();
        internal List<Description> Descriptions { get; set; } = new();
        internal List<Question_QuestionGroup> Question_QuestionGroup { get; set; } = new();
        internal List<Question> Questions { get; set; } = new();
        internal List<QuestionGroup> QuestionGroups { get; set; } = new();
        internal List<Result> Results { get; set; } = new();
        internal List<Models.Type> Types { get; set; } = new();
        internal List<User> Users { get; set; } = new();

        // User interactions values
        public string SelectedTableName { get; set; } = string.Empty;
        public int SelectedIndex { get; set; } = -1;

        internal ManagementForm(TechTestsDbContext dbContext)
        {
            InitializeComponent();
            this.DbContext = dbContext;
            this.TableNames = this.TableNames.Order().ToList();
            this.tableNamesComboBox.DataSource = this.TableNames;
        }

        internal void UpdateTableDataListBox()
        {
            switch (this.SelectedTableName)
            {
                case "Answers":
                    this.Answers = this.DbContext.Answers.ToList();
                    List<AnswerDTO> answers = this.Answers
                        .Select(a => DTO_Factory.GetAnswerDTO(a))
                        .ToList();
                    List<string> answersJson = answers
                        .Select(a => JsonConvert.SerializeObject(a))
                        .ToList();
                    answersJson = answersJson.Select(a => a.TrimStart('{')).ToList();
                    answersJson = answersJson.Select(a => a.TrimEnd('}')).ToList();

                    this.tableDataListBox.DataSource = answersJson;
                    break;

                case "AnswerValues":
                    this.AnswerValues = this.DbContext.AnswerValues.ToList();
                    List<AnswerValueDTO> answerValues = this.AnswerValues
                        .Select(a => DTO_Factory.GetAnswerValueDTO(a))
                        .ToList();
                    List<string> answerValuesJson = answerValues
                        .Select(a => JsonConvert.SerializeObject(a))
                        .ToList();
                    answerValuesJson = answerValuesJson.Select(a => a.TrimStart('{')).ToList();
                    answerValuesJson = answerValuesJson.Select(a => a.TrimEnd('}')).ToList();

                    this.tableDataListBox.DataSource = answerValuesJson;
                    break;

                case "Categories":
                    this.Categories = this.DbContext.Categories.ToList();
                    List<CategoryDTO> categories = this.Categories
                        .Select(c => DTO_Factory.GetCategoryDTO(c))
                        .ToList();
                    List<string> categoriesJson = categories
                        .Select(c => JsonConvert.SerializeObject(c))
                        .ToList();
                    categoriesJson = categoriesJson.Select(c => c.TrimStart('{')).ToList();
                    categoriesJson = categoriesJson.Select(c => c.TrimEnd('}')).ToList();

                    this.tableDataListBox.DataSource = categoriesJson;
                    break;

                case "Category_Question":
                    this.Category_Question = this.DbContext.Category_Questions.ToList();
                    List<Category_QuestionDTO> categoryQuestion = this.Category_Question
                        .Select(cq => DTO_Factory.GetCategoryQuestionDTO(cq))
                        .ToList();
                    List<string> categoryQuestionJson = categoryQuestion
                        .Select(cq => JsonConvert.SerializeObject(cq))
                        .ToList();
                    categoryQuestionJson = categoryQuestionJson.Select(cq => cq.TrimStart('{')).ToList();
                    categoryQuestionJson = categoryQuestionJson.Select(cq => cq.TrimEnd('}')).ToList();

                    this.tableDataListBox.DataSource = categoryQuestionJson;

                    break;

                case "Descriptions":
                    this.Descriptions = this.DbContext.Descriptions.ToList();
                    List<DescriptionDTO> descriptions = this.Descriptions
                        .Select(d => DTO_Factory.GetDescriptionDTO(d))
                        .ToList();
                    List<string> descriptionsJson = descriptions
                        .Select(d => JsonConvert.SerializeObject(d))
                        .ToList();
                    descriptionsJson = descriptionsJson.Select(d => d.TrimStart('{')).ToList();
                    descriptionsJson = descriptionsJson.Select(d => d.TrimEnd('}')).ToList();

                    this.tableDataListBox.DataSource = descriptionsJson;

                    break;

                case "Questions":
                    this.Questions = this.DbContext.Questions.ToList();
                    List<QuestionDTO> questions = this.Questions
                        .Select(q => DTO_Factory.GetQuestionDTO(q))
                        .ToList();
                    List<string> questionsJson = questions
                        .Select(q => JsonConvert.SerializeObject(q))
                        .ToList();
                    questionsJson = questionsJson.Select(q => q.TrimStart('{')).ToList();
                    questionsJson = questionsJson.Select(q => q.TrimEnd('}')).ToList();

                    this.tableDataListBox.DataSource = questionsJson;

                    break;

                case "Question_QuestionGroup":
                    this.Question_QuestionGroup = this.DbContext.Question_QuestionGroup.ToList();
                    List<Question_QuestionGroupDTO> questionQuestionGroup = this.Question_QuestionGroup
                        .Select(q => DTO_Factory.GetQuestionQuestionGroupDTO(q))
                        .ToList();
                    List<string> questionQuestionGroupJson = questionQuestionGroup
                        .Select(q => JsonConvert.SerializeObject(q))
                        .ToList();
                    questionQuestionGroupJson = questionQuestionGroupJson.Select(q => q.TrimStart('{')).ToList();
                    questionQuestionGroupJson = questionQuestionGroupJson.Select(q => q.TrimEnd('}')).ToList();

                    this.tableDataListBox.DataSource = questionQuestionGroupJson;

                    break;

                case "QuestionGroups":
                    this.QuestionGroups = this.DbContext.QuestionGroups.ToList();
                    List<QuestionGroupDTO> questionGroups = this.QuestionGroups
                        .Select(q => DTO_Factory.GetQuestionGroupDTO(q))
                        .ToList();
                    List<string> questionGroupsJson = questionGroups
                        .Select(q => JsonConvert.SerializeObject(q))
                        .ToList();
                    questionGroupsJson = questionGroupsJson.Select(q => q.TrimStart('{')).ToList();
                    questionGroupsJson = questionGroupsJson.Select(q => q.TrimEnd('}')).ToList();

                    this.tableDataListBox.DataSource = questionGroupsJson;

                    break;

                case "Results":
                    this.Results = this.DbContext.Results.ToList();
                    List<ResultDTO> results = this.Results
                        .Select(r => DTO_Factory.GetResultDTO(r))
                        .ToList();
                    List<string> resultsJson = results
                        .Select(r => JsonConvert.SerializeObject(r))
                        .ToList();
                    resultsJson = resultsJson.Select(r => r.TrimStart('{')).ToList();
                    resultsJson = resultsJson.Select(r => r.TrimEnd('}')).ToList();

                    this.tableDataListBox.DataSource = resultsJson;

                    break;

                case "Types":
                    this.Types = this.DbContext.Types.ToList();
                    List<TypeDTO> types = this.Types
                        .Select(t => DTO_Factory.GetTypeDTO(t))
                        .ToList();
                    List<string> typesJson = types
                        .Select(t => JsonConvert.SerializeObject(t))
                        .ToList();
                    typesJson = typesJson.Select(t => t.TrimStart('{')).ToList();
                    typesJson = typesJson.Select(t => t.TrimEnd('}')).ToList();

                    this.tableDataListBox.DataSource = typesJson;

                    break;

                case "Users":
                    this.Users = this.DbContext.Users.ToList();
                    List<UserDTO> users = this.Users
                        .Select(u => DTO_Factory.GetUserDTO(u))
                        .ToList();
                    List<string> usersJson = users
                        .Select(u => JsonConvert.SerializeObject(u))
                        .ToList();
                    usersJson = usersJson.Select(u => u.TrimStart('{')).ToList();
                    usersJson = usersJson.Select(u => u.TrimEnd('}')).ToList();

                    this.tableDataListBox.DataSource = usersJson;

                    break;
            }
        }

        private void tableNamesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedTableName = this.tableNamesComboBox.SelectedValue.ToString();
            this.UpdateTableDataListBox();
            this.SelectedIndex = -1;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            switch (this.SelectedTableName)
            {
                case "Answers":
                    AnswerForm answerForm = new AnswerForm(this.DbContext, Constants.ACTION_ADD, this);
                    answerForm.Show();

                    break;

                case "AnswerValues":
                    AnswerValueForm answerValueForm = new AnswerValueForm(this.DbContext, Constants.ACTION_ADD, this);
                    answerValueForm.Show();

                    break;

                case "Categories":
                    CategoryForm categoryForm = new CategoryForm(this.DbContext, Constants.ACTION_ADD, this);
                    categoryForm.Show();

                    break;

                case "Category_Question":
                    Category_QuestionForm category_QuestionForm = new Category_QuestionForm(this.DbContext, Constants.ACTION_ADD, this);
                    category_QuestionForm.Show();

                    break;

                case "Descriptions":
                    DescriptionForm descriptionForm = new DescriptionForm(this.DbContext, Constants.ACTION_ADD, this);
                    descriptionForm.Show();

                    break;

                case "Questions":
                    QuestionForm questionForm = new QuestionForm(this.DbContext, Constants.ACTION_ADD, this);
                    questionForm.Show();

                    break;

                case "Question_QuestionGroup":
                    Question_QuestionGroupForm question_QuestionGroupForm = new Question_QuestionGroupForm(this.DbContext, Constants.ACTION_ADD, this);
                    question_QuestionGroupForm.Show();

                    break;

                case "QuestionGroups":
                    QuestionGroupForm questionGroupForm = new QuestionGroupForm(this.DbContext, Constants.ACTION_ADD, this);
                    questionGroupForm.Show();

                    break;

                case "Results":
                    ResultForm resultForm = new ResultForm(this.DbContext, Constants.ACTION_ADD, this);
                    resultForm.Show();

                    break;

                case "Types":
                    TypeForm typeForm = new TypeForm(this.DbContext, Constants.ACTION_ADD, this);
                    typeForm.Show();

                    break;

                case "Users":
                    UserForm userForm = new UserForm(this.DbContext, Constants.ACTION_ADD, this);
                    userForm.Show();

                    break;
            }
        }

        private void tableDataListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedIndex = this.tableDataListBox.SelectedIndex;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (this.SelectedIndex == -1) return;
            int index = this.SelectedIndex;
            switch (this.SelectedTableName)
            {
                case "Answers":
                    this.DbContext.Answers.Remove(this.DbContext.Answers.First(a => a.Id == this.Answers[index].Id));
                    this.DbContext.SaveChanges();
                    this.UpdateTableDataListBox();
                    break;

                case "AnswerValues":
                    this.DbContext.AnswerValues.Remove(this.DbContext.AnswerValues.First(av => av.Id == this.AnswerValues[index].Id));
                    this.DbContext.SaveChanges();
                    this.UpdateTableDataListBox();
                    break;

                case "Categories":
                    this.DbContext.Categories.Remove(this.DbContext.Categories.First(c => c.Id == this.Categories[index].Id));
                    this.DbContext.SaveChanges();
                    this.UpdateTableDataListBox();

                    break;
                case "Category_Question":
                    this.DbContext.Category_Questions.Remove(this.DbContext.Category_Questions.First(cq => cq.CategoryId == this.Category_Question[index].CategoryId && cq.QuestionId == this.Category_Question[index].QuestionId));
                    this.DbContext.SaveChanges();
                    this.UpdateTableDataListBox();
                    break;

                case "Descriptions":
                    this.DbContext.Descriptions.Remove(this.DbContext.Descriptions.First(d => d.Id == this.Descriptions[index].Id));
                    this.DbContext.SaveChanges();
                    this.UpdateTableDataListBox();
                    break;

                case "Questions":
                    this.DbContext.Questions.Remove(this.DbContext.Questions.First(q => q.Id == this.Questions[index].Id));
                    this.DbContext.SaveChanges();
                    this.UpdateTableDataListBox();

                    break;
                case "Question_QuestionGroup":
                    this.DbContext.Question_QuestionGroup.Remove(this.DbContext.Question_QuestionGroup.First(q => q.QuestionId == this.Question_QuestionGroup[index].QuestionId && q.QuestionGroupId == this.Question_QuestionGroup[index].QuestionGroupId));
                    this.DbContext.SaveChanges();
                    this.UpdateTableDataListBox();
                    break;

                case "QuestionGroups":
                    this.DbContext.QuestionGroups.Remove(this.DbContext.QuestionGroups.First(qg => qg.Id == this.QuestionGroups[index].Id));
                    this.DbContext.SaveChanges();
                    this.UpdateTableDataListBox();

                    break;

                case "Results":
                    this.DbContext.Results.Remove(this.DbContext.Results.First(r => r.Id == this.Results[index].Id));
                    this.DbContext.SaveChanges();
                    this.UpdateTableDataListBox();
                    break;

                case "Types":
                    this.DbContext.Types.Remove(this.DbContext.Types.First(t => t.Id == this.Types[index].Id));
                    this.DbContext.SaveChanges();
                    this.UpdateTableDataListBox();

                    break;

                case "Users":
                    this.DbContext.Users.Remove(this.Users.First(u => u.Id == this.Users[index].Id));
                    this.DbContext.SaveChanges();
                    this.UpdateTableDataListBox();

                    break;
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (this.SelectedIndex == -1) return;
            switch (this.SelectedTableName)
            {
                case "Answers":
                    AnswerForm answerForm = new AnswerForm(this.DbContext, Constants.ACTION_UPDATE, this.Answers[this.SelectedIndex], this);
                    answerForm.Show();

                    break;

                case "AnswerValues":
                    AnswerValueForm answerValueForm = new AnswerValueForm(this.DbContext, Constants.ACTION_UPDATE, this.AnswerValues[this.SelectedIndex], this);
                    answerValueForm.Show();

                    break;

                case "Categories":
                    CategoryForm categoryForm = new CategoryForm(this.DbContext, Constants.ACTION_UPDATE, this.Categories[this.SelectedIndex], this);
                    categoryForm.Show();

                    break;

                case "Category_Question":
                    Category_QuestionForm category_QuestionForm = new Category_QuestionForm(this.DbContext, Constants.ACTION_UPDATE, this.Category_Question[this.SelectedIndex], this);
                    category_QuestionForm.Show();

                    break;

                case "Descriptions":
                    DescriptionForm descriptionForm = new DescriptionForm(this.DbContext, Constants.ACTION_UPDATE, this.Descriptions[this.SelectedIndex], this);
                    descriptionForm.Show();

                    break;

                case "Questions":
                    QuestionForm questionForm = new QuestionForm(this.DbContext, Constants.ACTION_UPDATE, this.Questions[this.SelectedIndex], this);
                    questionForm.Show();

                    break;

                case "Question_QuestionGroup":
                    Question_QuestionGroupForm question_QuestionGroupForm = new Question_QuestionGroupForm(this.DbContext, Constants.ACTION_UPDATE, this.Question_QuestionGroup[this.SelectedIndex], this);
                    question_QuestionGroupForm.Show();

                    break;

                case "QuestionGroups":
                    QuestionGroupForm questionGroupForm = new QuestionGroupForm(this.DbContext, Constants.ACTION_UPDATE, this.QuestionGroups[this.SelectedIndex], this);
                    questionGroupForm.Show();

                    break;

                case "Results":
                    ResultForm resultForm = new ResultForm(this.DbContext, Constants.ACTION_UPDATE, this.Results[this.SelectedIndex], this);
                    resultForm.Show();

                    break;

                case "Types":
                    TypeForm typeForm = new TypeForm(this.DbContext, Constants.ACTION_UPDATE, this.Types[this.SelectedIndex], this);
                    typeForm.Show();

                    break;

                case "Users":
                    UserForm userForm = new UserForm(this.DbContext, Constants.ACTION_UPDATE, this.Users[this.SelectedIndex], this);
                    userForm.Show();

                    break;
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            this.UpdateTableDataListBox();
        }
    }
}
