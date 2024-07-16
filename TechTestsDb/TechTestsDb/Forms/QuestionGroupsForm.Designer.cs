namespace TechTestsDb.Forms
{
    partial class QuestionGroupsForm
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
            questionGroupNameTextBox = new TextBox();
            addQuestionGroupButton = new Button();
            deleteQuestionGroupButton = new Button();
            label3 = new Label();
            questionGroupsComboBox = new ComboBox();
            freeQuestionsListBox = new ListBox();
            selectedQuestionsListBox = new ListBox();
            label1 = new Label();
            label2 = new Label();
            removeQuestionButton = new Button();
            addQuestionButton = new Button();
            saveChangesButton = new Button();
            SuspendLayout();
            // 
            // questionGroupNameTextBox
            // 
            questionGroupNameTextBox.Location = new Point(12, 32);
            questionGroupNameTextBox.Name = "questionGroupNameTextBox";
            questionGroupNameTextBox.Size = new Size(821, 27);
            questionGroupNameTextBox.TabIndex = 4;
            // 
            // addQuestionGroupButton
            // 
            addQuestionGroupButton.Location = new Point(839, 32);
            addQuestionGroupButton.Name = "addQuestionGroupButton";
            addQuestionGroupButton.Size = new Size(75, 27);
            addQuestionGroupButton.TabIndex = 5;
            addQuestionGroupButton.Text = "Add";
            addQuestionGroupButton.UseVisualStyleBackColor = true;
            addQuestionGroupButton.Click += addQuestionGroupButton_Click;
            // 
            // deleteQuestionGroupButton
            // 
            deleteQuestionGroupButton.Location = new Point(920, 32);
            deleteQuestionGroupButton.Name = "deleteQuestionGroupButton";
            deleteQuestionGroupButton.Size = new Size(75, 27);
            deleteQuestionGroupButton.TabIndex = 6;
            deleteQuestionGroupButton.Text = "Delete";
            deleteQuestionGroupButton.UseVisualStyleBackColor = true;
            deleteQuestionGroupButton.Click += deleteQuestionGroupButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 9);
            label3.Name = "label3";
            label3.Size = new Size(189, 20);
            label3.TabIndex = 7;
            label3.Text = "Enter question group name";
            // 
            // questionGroupsComboBox
            // 
            questionGroupsComboBox.FormattingEnabled = true;
            questionGroupsComboBox.Location = new Point(12, 65);
            questionGroupsComboBox.Name = "questionGroupsComboBox";
            questionGroupsComboBox.Size = new Size(983, 28);
            questionGroupsComboBox.TabIndex = 8;
            questionGroupsComboBox.SelectedIndexChanged += questionGroupsComboBox_SelectedIndexChanged;
            // 
            // freeQuestionsListBox
            // 
            freeQuestionsListBox.FormattingEnabled = true;
            freeQuestionsListBox.HorizontalScrollbar = true;
            freeQuestionsListBox.ItemHeight = 20;
            freeQuestionsListBox.Location = new Point(12, 119);
            freeQuestionsListBox.Name = "freeQuestionsListBox";
            freeQuestionsListBox.Size = new Size(467, 304);
            freeQuestionsListBox.TabIndex = 9;
            // 
            // selectedQuestionsListBox
            // 
            selectedQuestionsListBox.FormattingEnabled = true;
            selectedQuestionsListBox.HorizontalScrollbar = true;
            selectedQuestionsListBox.ItemHeight = 20;
            selectedQuestionsListBox.Location = new Point(526, 119);
            selectedQuestionsListBox.Name = "selectedQuestionsListBox";
            selectedQuestionsListBox.Size = new Size(469, 304);
            selectedQuestionsListBox.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 96);
            label1.Name = "label1";
            label1.Size = new Size(100, 20);
            label1.TabIndex = 11;
            label1.Text = "Questions List";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(526, 96);
            label2.Name = "label2";
            label2.Size = new Size(161, 20);
            label2.TabIndex = 12;
            label2.Text = "Selected Questions List";
            // 
            // removeQuestionButton
            // 
            removeQuestionButton.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            removeQuestionButton.Location = new Point(485, 273);
            removeQuestionButton.Name = "removeQuestionButton";
            removeQuestionButton.Size = new Size(35, 150);
            removeQuestionButton.TabIndex = 14;
            removeQuestionButton.Text = "<";
            removeQuestionButton.UseVisualStyleBackColor = true;
            removeQuestionButton.Click += removeQuestionButton_Click;
            // 
            // addQuestionButton
            // 
            addQuestionButton.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            addQuestionButton.Location = new Point(485, 119);
            addQuestionButton.Name = "addQuestionButton";
            addQuestionButton.Size = new Size(35, 150);
            addQuestionButton.TabIndex = 15;
            addQuestionButton.Text = ">";
            addQuestionButton.UseVisualStyleBackColor = true;
            addQuestionButton.Click += addQuestionButton_Click;
            // 
            // saveChangesButton
            // 
            saveChangesButton.Location = new Point(12, 429);
            saveChangesButton.Name = "saveChangesButton";
            saveChangesButton.Size = new Size(983, 42);
            saveChangesButton.TabIndex = 16;
            saveChangesButton.Text = "Save Changes";
            saveChangesButton.UseVisualStyleBackColor = true;
            saveChangesButton.Click += saveChangesButton_Click;
            // 
            // QuestionGroupsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1007, 481);
            Controls.Add(saveChangesButton);
            Controls.Add(addQuestionButton);
            Controls.Add(removeQuestionButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(selectedQuestionsListBox);
            Controls.Add(freeQuestionsListBox);
            Controls.Add(questionGroupsComboBox);
            Controls.Add(label3);
            Controls.Add(deleteQuestionGroupButton);
            Controls.Add(addQuestionGroupButton);
            Controls.Add(questionGroupNameTextBox);
            Name = "QuestionGroupsForm";
            Text = "Question Groups Form";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox questionGroupNameTextBox;
        private Button addQuestionGroupButton;
        private Button deleteQuestionGroupButton;
        private Label label3;
        private ComboBox questionGroupsComboBox;
        private ListBox freeQuestionsListBox;
        private ListBox selectedQuestionsListBox;
        private Label label1;
        private Label label2;
        private Button removeQuestionButton;
        private Button addQuestionButton;
        private Button saveChangesButton;
    }
}