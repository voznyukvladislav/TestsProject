using Microsoft.IdentityModel.Tokens;
using TechTestsDb.Data;
using TechTestsDb.Models;

namespace TechTestsDb
{
    public partial class Form1 : Form
    {
        internal TechTestsDbContext DbContext { get; set; } = new();
        public Form1()
        {
            InitializeComponent();

        }

        private void seedButton_Click(object sender, EventArgs e)
        {
            this.DbContext.Types.RemoveRange(this.DbContext.Types.ToList());
            this.DbContext.SaveChanges();

            this.DbContext.Types.AddRange(new List<Models.Type>() {
                new Models.Type { Name = "I" }, new Models.Type { Name = "II" }, new Models.Type { Name = "III" }
            });
            this.DbContext.SaveChanges();
        }

        private void addQuestionButton_Click(object sender, EventArgs e)
        {
            AddQuestionForm addQuestionForm = new AddQuestionForm();
            addQuestionForm.ShowDialog();
        }

        private void addCategoryButton_Click(object sender, EventArgs e)
        {
            if (!this.categoryNameTextBox.Text.IsNullOrEmpty())
            {
                Category category = new Category() { Name = this.categoryNameTextBox.Text };
                this.DbContext.Categories.Add(category);
                this.DbContext.SaveChanges();

                this.categoryNameTextBox.Text = string.Empty;
            }
        }

        private void addDescriptionButton_Click(object sender, EventArgs e)
        {
            if (!this.descriptionNameTextBox.Text.IsNullOrEmpty())
            {
                Description description = new Description() { Value = this.descriptionNameTextBox.Text };
                this.DbContext.Descriptions.Add(description);
                this.DbContext.SaveChanges();

                this.descriptionNameTextBox.Text = string.Empty;
            }
        }

        private void clearDbButton_Click(object sender, EventArgs e)
        {
            this.DbContext.Categories.RemoveRange(this.DbContext.Categories.ToList());
            this.DbContext.Descriptions.RemoveRange(this.DbContext.Descriptions.ToList());
            this.DbContext.Types.RemoveRange(this.DbContext.Types.ToList());
            this.DbContext.Answers.RemoveRange(this.DbContext.Answers.ToList());
            this.DbContext.AnswerValues.RemoveRange(this.DbContext.AnswerValues.ToList());
            this.DbContext.Questions.RemoveRange(this.DbContext.Questions.ToList());

            this.DbContext.SaveChanges();
        }
    }
}