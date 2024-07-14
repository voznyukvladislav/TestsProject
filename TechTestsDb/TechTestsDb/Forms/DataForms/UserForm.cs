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
    public partial class UserForm : Form
    {
        private ManagementForm ManagementForm { get; set; }
        private TechTestsDbContext DbContext { get; set; }
        private string Action { get; set; } = string.Empty;
        private User User { get; set; } = new();

        internal UserForm(TechTestsDbContext dbContext, string action, ManagementForm managementForm)
        {
            InitializeComponent();
            this.DbContext = dbContext;
            this.Action = action;
            ManagementForm = managementForm;
        }
        internal UserForm(TechTestsDbContext dbContext, string action, User user, ManagementForm managementForm)
        {
            InitializeComponent();
            this.DbContext = dbContext;
            this.Action = action;
            this.User = user;
            this.ManagementForm = managementForm;

            this.idTextBox.Text = $"{this.User.Id}";
            this.loginTextBox.Text = this.User.Login;

            this.passwordTextBox.Text = this.User.PasswordHash;
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.User.Login = this.loginTextBox.Text;
                if (this.changePasswordCheckBox.Checked)
                {
                    string hash = PasswordHashing.GetHash(this.passwordTextBox.Text);
                    this.User.PasswordHash = hash;
                }
                else if (!this.changePasswordCheckBox.Checked)
                {
                    this.User.PasswordHash = this.passwordTextBox.Text;
                }

                if (this.Action == Constants.ACTION_ADD)
                {
                    this.DbContext.Users.Add(this.User);
                }
                else if (this.Action == Constants.ACTION_UPDATE)
                {
                    this.DbContext.Users.Update(this.User);
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

        private void changePasswordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.changePasswordCheckBox.Checked)
            {
                this.passwordLabel.Text = "Password";
            }
            else if (!this.changePasswordCheckBox.Checked)
            {
                this.passwordLabel.Text = "PasswordHash";
            }
        }

        private void UserForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.applyButton_Click(sender, e);
                this.ManagementForm.UpdateTableDataListBox();
            }
        }
    }
}
