using Microsoft.IdentityModel.Tokens;
using TechTestsDb.Data;
using TechTestsDb.Forms;
using TechTestsDb.Models;

namespace TechTestsDb
{
    public partial class InitialForm : Form
    {
        internal TechTestsDbContext DbContext { get; set; } = new();
        public InitialForm()
        {
            InitializeComponent();
        }

        private void dataManagementButton_Click(object sender, EventArgs e)
        {
            ManagementForm managementForm = new ManagementForm(this.DbContext);
            managementForm.Show();
        }

        private void clearDbButton_Click(object sender, EventArgs e)
        {
            this.DbContext.Answers.RemoveRange(this.DbContext.Answers.ToList());
            this.DbContext.AnswerValues.RemoveRange(this.DbContext.AnswerValues.ToList());
            this.DbContext.Categories.RemoveRange(this.DbContext.Categories.ToList());
            this.DbContext.Category_Questions.RemoveRange(this.DbContext.Category_Questions.ToList());
            this.DbContext.Descriptions.RemoveRange(this.DbContext.Descriptions.ToList());
            this.DbContext.Questions.RemoveRange(this.DbContext.Questions.ToList());
            this.DbContext.Question_QuestionGroup.RemoveRange(this.DbContext.Question_QuestionGroup.ToList());
            this.DbContext.QuestionGroups.RemoveRange(this.DbContext.QuestionGroups.ToList());
            this.DbContext.Results.RemoveRange(this.DbContext.Results.ToList());
            this.DbContext.Types.RemoveRange(this.DbContext.Types.ToList());
            this.DbContext.Users.RemoveRange(this.DbContext.Users.ToList());

            this.DbContext.SaveChanges();
        }

        private void seedButton_Click(object sender, EventArgs e)
        {
            List<Models.Type> types = new List<Models.Type>()
            {
                new Models.Type { Name = Constants.FIRST_TYPE_NAME },
                new Models.Type { Name = Constants.SECOND_TYPE_NAME },
                new Models.Type { Name = Constants.THIRD_TYPE_NAME },
                new Models.Type { Name = Constants.FOURTH_TYPE_NAME },
                new Models.Type { Name = Constants.FIFTH_TYPE_NAME }
            };

            this.DbContext.Types.AddRange(types);
            this.DbContext.SaveChanges();
        }

        private void addQuestionButton_Click(object sender, EventArgs e)
        {
            NewAddQuestionForm newAddQuestionForm = new NewAddQuestionForm(this.DbContext);
            newAddQuestionForm.Show();
        }

        private void questionGroups_Click(object sender, EventArgs e)
        {
            QuestionGroupsForm questionGroupsForm = new QuestionGroupsForm(this.DbContext);
            questionGroupsForm.Show();
        }
    }
}