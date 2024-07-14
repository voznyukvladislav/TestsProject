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
            questionsListBox = new ListBox();
            questionGroupNameTextBox = new TextBox();
            addQuestionGroupButton = new Button();
            deleteQuestionGroupButton = new Button();
            label3 = new Label();
            questionGroupsComboBox = new ComboBox();
            applyButton = new Button();
            SuspendLayout();
            // 
            // questionsListBox
            // 
            questionsListBox.FormattingEnabled = true;
            questionsListBox.HorizontalScrollbar = true;
            questionsListBox.ItemHeight = 20;
            questionsListBox.Location = new Point(12, 99);
            questionsListBox.Name = "questionsListBox";
            questionsListBox.SelectionMode = SelectionMode.MultiSimple;
            questionsListBox.Size = new Size(624, 284);
            questionsListBox.TabIndex = 3;
            questionsListBox.SelectedIndexChanged += questionsListBox_SelectedIndexChanged;
            // 
            // questionGroupNameTextBox
            // 
            questionGroupNameTextBox.Location = new Point(12, 32);
            questionGroupNameTextBox.Name = "questionGroupNameTextBox";
            questionGroupNameTextBox.Size = new Size(462, 27);
            questionGroupNameTextBox.TabIndex = 4;
            // 
            // addQuestionGroupButton
            // 
            addQuestionGroupButton.Location = new Point(480, 32);
            addQuestionGroupButton.Name = "addQuestionGroupButton";
            addQuestionGroupButton.Size = new Size(75, 27);
            addQuestionGroupButton.TabIndex = 5;
            addQuestionGroupButton.Text = "Add";
            addQuestionGroupButton.UseVisualStyleBackColor = true;
            addQuestionGroupButton.Click += addQuestionGroupButton_Click;
            // 
            // deleteQuestionGroupButton
            // 
            deleteQuestionGroupButton.Location = new Point(561, 32);
            deleteQuestionGroupButton.Name = "deleteQuestionGroupButton";
            deleteQuestionGroupButton.Size = new Size(75, 27);
            deleteQuestionGroupButton.TabIndex = 6;
            deleteQuestionGroupButton.Text = "Delete";
            deleteQuestionGroupButton.UseVisualStyleBackColor = true;
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
            questionGroupsComboBox.Size = new Size(624, 28);
            questionGroupsComboBox.TabIndex = 8;
            questionGroupsComboBox.SelectedIndexChanged += questionGroupsComboBox_SelectedIndexChanged;
            // 
            // applyButton
            // 
            applyButton.Location = new Point(12, 389);
            applyButton.Name = "applyButton";
            applyButton.Size = new Size(624, 36);
            applyButton.TabIndex = 9;
            applyButton.Text = "Save changes";
            applyButton.UseVisualStyleBackColor = true;
            applyButton.Click += applyButton_Click;
            // 
            // QuestionGroupsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(648, 431);
            Controls.Add(applyButton);
            Controls.Add(questionGroupsComboBox);
            Controls.Add(label3);
            Controls.Add(deleteQuestionGroupButton);
            Controls.Add(addQuestionGroupButton);
            Controls.Add(questionGroupNameTextBox);
            Controls.Add(questionsListBox);
            Name = "QuestionGroupsForm";
            Text = "Question Groups Form";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ListBox questionsListBox;
        private TextBox questionGroupNameTextBox;
        private Button addQuestionGroupButton;
        private Button deleteQuestionGroupButton;
        private Label label3;
        private ComboBox questionGroupsComboBox;
        private Button applyButton;
    }
}