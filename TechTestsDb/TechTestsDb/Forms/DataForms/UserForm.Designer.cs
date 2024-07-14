namespace TechTestsDb.Forms.DataForms
{
    partial class UserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cancelButton = new Button();
            applyButton = new Button();
            loginTextBox = new TextBox();
            label2 = new Label();
            idTextBox = new TextBox();
            label1 = new Label();
            passwordTextBox = new TextBox();
            passwordLabel = new Label();
            changePasswordCheckBox = new CheckBox();
            SuspendLayout();
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(237, 205);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(215, 42);
            cancelButton.TabIndex = 17;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // applyButton
            // 
            applyButton.Location = new Point(12, 205);
            applyButton.Name = "applyButton";
            applyButton.Size = new Size(215, 42);
            applyButton.TabIndex = 16;
            applyButton.Text = "Apply";
            applyButton.UseVisualStyleBackColor = true;
            applyButton.Click += applyButton_Click;
            // 
            // loginTextBox
            // 
            loginTextBox.Location = new Point(12, 85);
            loginTextBox.Name = "loginTextBox";
            loginTextBox.Size = new Size(440, 27);
            loginTextBox.TabIndex = 15;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 62);
            label2.Name = "label2";
            label2.Size = new Size(46, 20);
            label2.TabIndex = 14;
            label2.Text = "Login";
            // 
            // idTextBox
            // 
            idTextBox.Location = new Point(12, 32);
            idTextBox.Name = "idTextBox";
            idTextBox.ReadOnly = true;
            idTextBox.Size = new Size(440, 27);
            idTextBox.TabIndex = 13;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(22, 20);
            label1.TabIndex = 12;
            label1.Text = "Id";
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(12, 140);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(440, 27);
            passwordTextBox.TabIndex = 19;
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(12, 117);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(70, 20);
            passwordLabel.TabIndex = 18;
            passwordLabel.Text = "Password";
            // 
            // changePasswordCheckBox
            // 
            changePasswordCheckBox.AutoSize = true;
            changePasswordCheckBox.Location = new Point(12, 173);
            changePasswordCheckBox.Name = "changePasswordCheckBox";
            changePasswordCheckBox.Size = new Size(442, 24);
            changePasswordCheckBox.TabIndex = 20;
            changePasswordCheckBox.Text = "Checked will change password, unchecked will change its hash";
            changePasswordCheckBox.UseVisualStyleBackColor = true;
            changePasswordCheckBox.CheckedChanged += changePasswordCheckBox_CheckedChanged;
            // 
            // UserForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(464, 260);
            Controls.Add(changePasswordCheckBox);
            Controls.Add(passwordTextBox);
            Controls.Add(passwordLabel);
            Controls.Add(cancelButton);
            Controls.Add(applyButton);
            Controls.Add(loginTextBox);
            Controls.Add(label2);
            Controls.Add(idTextBox);
            Controls.Add(label1);
            KeyPreview = true;
            Name = "UserForm";
            Text = "UserForm";
            KeyUp += UserForm_KeyUp;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button cancelButton;
        private Button applyButton;
        private TextBox loginTextBox;
        private Label label2;
        private TextBox idTextBox;
        private Label label1;
        private TextBox passwordTextBox;
        private Label passwordLabel;
        private CheckBox changePasswordCheckBox;
    }
}