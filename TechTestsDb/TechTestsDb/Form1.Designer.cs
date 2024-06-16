namespace TechTestsDb
{
    partial class Form1
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
            groupBox1 = new GroupBox();
            addCategoryButton = new Button();
            categoryNameTextBox = new TextBox();
            groupBox2 = new GroupBox();
            addDescriptionButton = new Button();
            descriptionNameTextBox = new TextBox();
            seedButton = new Button();
            addQuestionButton = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(addCategoryButton);
            groupBox1.Controls.Add(categoryNameTextBox);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(264, 98);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Add Category";
            // 
            // addCategoryButton
            // 
            addCategoryButton.Location = new Point(6, 59);
            addCategoryButton.Name = "addCategoryButton";
            addCategoryButton.Size = new Size(252, 29);
            addCategoryButton.TabIndex = 1;
            addCategoryButton.Text = "Add";
            addCategoryButton.UseVisualStyleBackColor = true;
            addCategoryButton.Click += addCategoryButton_Click;
            // 
            // categoryNameTextBox
            // 
            categoryNameTextBox.Location = new Point(6, 26);
            categoryNameTextBox.Name = "categoryNameTextBox";
            categoryNameTextBox.Size = new Size(252, 27);
            categoryNameTextBox.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(addDescriptionButton);
            groupBox2.Controls.Add(descriptionNameTextBox);
            groupBox2.Location = new Point(12, 116);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(264, 98);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Add Description";
            // 
            // addDescriptionButton
            // 
            addDescriptionButton.Location = new Point(6, 59);
            addDescriptionButton.Name = "addDescriptionButton";
            addDescriptionButton.Size = new Size(252, 29);
            addDescriptionButton.TabIndex = 4;
            addDescriptionButton.Text = "Add";
            addDescriptionButton.UseVisualStyleBackColor = true;
            addDescriptionButton.Click += addDescriptionButton_Click;
            // 
            // descriptionNameTextBox
            // 
            descriptionNameTextBox.Location = new Point(6, 26);
            descriptionNameTextBox.Name = "descriptionNameTextBox";
            descriptionNameTextBox.Size = new Size(252, 27);
            descriptionNameTextBox.TabIndex = 3;
            // 
            // seedButton
            // 
            seedButton.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            seedButton.Location = new Point(282, 12);
            seedButton.Name = "seedButton";
            seedButton.Size = new Size(75, 266);
            seedButton.TabIndex = 4;
            seedButton.Text = "SEED";
            seedButton.UseVisualStyleBackColor = true;
            seedButton.Click += seedButton_Click;
            // 
            // addQuestionButton
            // 
            addQuestionButton.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            addQuestionButton.Location = new Point(12, 220);
            addQuestionButton.Name = "addQuestionButton";
            addQuestionButton.Size = new Size(264, 56);
            addQuestionButton.TabIndex = 5;
            addQuestionButton.Text = "ADD NEW QUESTION";
            addQuestionButton.UseVisualStyleBackColor = true;
            addQuestionButton.Click += addQuestionButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(363, 288);
            Controls.Add(addQuestionButton);
            Controls.Add(seedButton);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button addCategoryButton;
        private TextBox categoryNameTextBox;
        private Button addDescriptionButton;
        private TextBox descriptionNameTextBox;
        private Button seedButton;
        private Button addQuestionButton;
    }
}