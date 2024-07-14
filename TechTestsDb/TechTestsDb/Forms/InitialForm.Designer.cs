namespace TechTestsDb
{
    partial class InitialForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataManagementButton = new Button();
            seedButton = new Button();
            addQuestionButton = new Button();
            clearDbButton = new Button();
            questionGroups = new Button();
            SuspendLayout();
            // 
            // dataManagementButton
            // 
            dataManagementButton.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            dataManagementButton.Location = new Point(12, 12);
            dataManagementButton.Name = "dataManagementButton";
            dataManagementButton.Size = new Size(339, 47);
            dataManagementButton.TabIndex = 0;
            dataManagementButton.Text = "Data Management";
            dataManagementButton.UseVisualStyleBackColor = true;
            dataManagementButton.Click += dataManagementButton_Click;
            // 
            // seedButton
            // 
            seedButton.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            seedButton.Location = new Point(12, 171);
            seedButton.Name = "seedButton";
            seedButton.Size = new Size(339, 47);
            seedButton.TabIndex = 1;
            seedButton.Text = "Seed Data";
            seedButton.UseVisualStyleBackColor = true;
            seedButton.Click += seedButton_Click;
            // 
            // addQuestionButton
            // 
            addQuestionButton.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            addQuestionButton.Location = new Point(12, 65);
            addQuestionButton.Name = "addQuestionButton";
            addQuestionButton.Size = new Size(339, 47);
            addQuestionButton.TabIndex = 2;
            addQuestionButton.Text = "Add Question";
            addQuestionButton.UseVisualStyleBackColor = true;
            addQuestionButton.Click += addQuestionButton_Click;
            // 
            // clearDbButton
            // 
            clearDbButton.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            clearDbButton.Location = new Point(12, 224);
            clearDbButton.Name = "clearDbButton";
            clearDbButton.Size = new Size(339, 47);
            clearDbButton.TabIndex = 3;
            clearDbButton.Text = "Clear DB";
            clearDbButton.UseVisualStyleBackColor = true;
            clearDbButton.Click += clearDbButton_Click;
            // 
            // questionGroups
            // 
            questionGroups.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            questionGroups.Location = new Point(12, 118);
            questionGroups.Name = "questionGroups";
            questionGroups.Size = new Size(339, 47);
            questionGroups.TabIndex = 4;
            questionGroups.Text = "Question Groups";
            questionGroups.UseVisualStyleBackColor = true;
            questionGroups.Click += questionGroups_Click;
            // 
            // InitialForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(363, 285);
            Controls.Add(questionGroups);
            Controls.Add(clearDbButton);
            Controls.Add(addQuestionButton);
            Controls.Add(seedButton);
            Controls.Add(dataManagementButton);
            Name = "InitialForm";
            Text = "TechTests-DB";
            ResumeLayout(false);
        }

        #endregion

        private Button dataManagementButton;
        private Button seedButton;
        private Button addQuestionButton;
        private Button clearDbButton;
        private Button questionGroups;
    }
}