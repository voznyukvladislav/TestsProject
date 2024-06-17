namespace TechTestsDb
{
    partial class AddQuestionForm
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
            label2 = new Label();
            questionTextBox = new TextBox();
            descriptionIdsComboBox = new ComboBox();
            descriptionTextBox = new TextBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            noRadioButton = new RadioButton();
            yesRadioButton = new RadioButton();
            addQuestionButton = new Button();
            categoriesComboBox = new ComboBox();
            label3 = new Label();
            groupBox1 = new GroupBox();
            isCaseSensitive = new CheckBox();
            addAnswersButton = new Button();
            resetButton = new Button();
            answearTextBox = new TextBox();
            addAnswerButton = new Button();
            label4 = new Label();
            answersComboBox = new ComboBox();
            groupBox3 = new GroupBox();
            type3RadioButton = new RadioButton();
            type2RadioButton = new RadioButton();
            type1RadioButton = new RadioButton();
            categoriesTextBox = new TextBox();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 178);
            label2.Name = "label2";
            label2.Size = new Size(133, 20);
            label2.TabIndex = 5;
            label2.Text = "Enter question text";
            // 
            // questionTextBox
            // 
            questionTextBox.Location = new Point(6, 201);
            questionTextBox.Multiline = true;
            questionTextBox.Name = "questionTextBox";
            questionTextBox.ScrollBars = ScrollBars.Vertical;
            questionTextBox.Size = new Size(388, 287);
            questionTextBox.TabIndex = 4;
            // 
            // descriptionIdsComboBox
            // 
            descriptionIdsComboBox.FormattingEnabled = true;
            descriptionIdsComboBox.Location = new Point(6, 48);
            descriptionIdsComboBox.Name = "descriptionIdsComboBox";
            descriptionIdsComboBox.Size = new Size(388, 28);
            descriptionIdsComboBox.TabIndex = 1;
            descriptionIdsComboBox.SelectedIndexChanged += descriptionIdsComboBox_SelectedIndexChanged;
            // 
            // descriptionTextBox
            // 
            descriptionTextBox.Location = new Point(6, 82);
            descriptionTextBox.Multiline = true;
            descriptionTextBox.Name = "descriptionTextBox";
            descriptionTextBox.ReadOnly = true;
            descriptionTextBox.ScrollBars = ScrollBars.Vertical;
            descriptionTextBox.Size = new Size(388, 84);
            descriptionTextBox.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 25);
            label1.Name = "label1";
            label1.Size = new Size(144, 20);
            label1.TabIndex = 3;
            label1.Text = "Select description id";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(noRadioButton);
            groupBox2.Controls.Add(yesRadioButton);
            groupBox2.Location = new Point(400, 153);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(225, 91);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Select answer";
            // 
            // noRadioButton
            // 
            noRadioButton.AutoSize = true;
            noRadioButton.Location = new Point(6, 56);
            noRadioButton.Name = "noRadioButton";
            noRadioButton.Size = new Size(50, 24);
            noRadioButton.TabIndex = 1;
            noRadioButton.TabStop = true;
            noRadioButton.Text = "No";
            noRadioButton.UseVisualStyleBackColor = true;
            noRadioButton.CheckedChanged += noRadioButton_CheckedChanged;
            // 
            // yesRadioButton
            // 
            yesRadioButton.AutoSize = true;
            yesRadioButton.Location = new Point(6, 26);
            yesRadioButton.Name = "yesRadioButton";
            yesRadioButton.Size = new Size(51, 24);
            yesRadioButton.TabIndex = 0;
            yesRadioButton.TabStop = true;
            yesRadioButton.Text = "Yes";
            yesRadioButton.UseVisualStyleBackColor = true;
            yesRadioButton.CheckedChanged += yesRadioButton_CheckedChanged;
            // 
            // addQuestionButton
            // 
            addQuestionButton.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            addQuestionButton.Location = new Point(400, 366);
            addQuestionButton.Name = "addQuestionButton";
            addQuestionButton.Size = new Size(225, 122);
            addQuestionButton.TabIndex = 7;
            addQuestionButton.Text = "ADD QUESTION";
            addQuestionButton.UseVisualStyleBackColor = true;
            addQuestionButton.Click += addQuestionButton_Click;
            // 
            // categoriesComboBox
            // 
            categoriesComboBox.FormattingEnabled = true;
            categoriesComboBox.Location = new Point(631, 46);
            categoriesComboBox.Name = "categoriesComboBox";
            categoriesComboBox.Size = new Size(378, 28);
            categoriesComboBox.TabIndex = 8;
            categoriesComboBox.SelectedIndexChanged += categoriesComboBox_SelectedIndexChanged_1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(631, 23);
            label3.Name = "label3";
            label3.Size = new Size(111, 20);
            label3.TabIndex = 9;
            label3.Text = "Select category";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(isCaseSensitive);
            groupBox1.Controls.Add(addAnswersButton);
            groupBox1.Controls.Add(resetButton);
            groupBox1.Controls.Add(answearTextBox);
            groupBox1.Controls.Add(addAnswerButton);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(answersComboBox);
            groupBox1.Controls.Add(groupBox3);
            groupBox1.Controls.Add(categoriesTextBox);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(categoriesComboBox);
            groupBox1.Controls.Add(questionTextBox);
            groupBox1.Controls.Add(addQuestionButton);
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(descriptionTextBox);
            groupBox1.Controls.Add(descriptionIdsComboBox);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1015, 494);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Create New Question";
            // 
            // isCaseSensitive
            // 
            isCaseSensitive.AutoSize = true;
            isCaseSensitive.Location = new Point(400, 249);
            isCaseSensitive.Name = "isCaseSensitive";
            isCaseSensitive.Size = new Size(134, 24);
            isCaseSensitive.TabIndex = 18;
            isCaseSensitive.Text = "Is case sensitive";
            isCaseSensitive.UseVisualStyleBackColor = true;
            isCaseSensitive.CheckedChanged += isCaseSensitive_CheckedChanged;
            // 
            // addAnswersButton
            // 
            addAnswersButton.Location = new Point(631, 459);
            addAnswersButton.Name = "addAnswersButton";
            addAnswersButton.Size = new Size(378, 29);
            addAnswersButton.TabIndex = 17;
            addAnswersButton.Text = "Add answers";
            addAnswersButton.UseVisualStyleBackColor = true;
            addAnswersButton.Click += addAnswearsButton_Click;
            // 
            // resetButton
            // 
            resetButton.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            resetButton.Location = new Point(400, 279);
            resetButton.Name = "resetButton";
            resetButton.Size = new Size(225, 81);
            resetButton.TabIndex = 16;
            resetButton.Text = "RESET";
            resetButton.UseVisualStyleBackColor = true;
            resetButton.Click += resetButton_Click;
            // 
            // answearTextBox
            // 
            answearTextBox.Location = new Point(631, 310);
            answearTextBox.Multiline = true;
            answearTextBox.Name = "answearTextBox";
            answearTextBox.ScrollBars = ScrollBars.Vertical;
            answearTextBox.Size = new Size(378, 143);
            answearTextBox.TabIndex = 15;
            // 
            // addAnswerButton
            // 
            addAnswerButton.Location = new Point(902, 275);
            addAnswerButton.Name = "addAnswerButton";
            addAnswerButton.Size = new Size(107, 29);
            addAnswerButton.TabIndex = 14;
            addAnswerButton.Text = "Add";
            addAnswerButton.UseVisualStyleBackColor = true;
            addAnswerButton.Click += addAnswearButton_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(631, 253);
            label4.Name = "label4";
            label4.Size = new Size(116, 20);
            label4.TabIndex = 13;
            label4.Text = "Select answer id";
            // 
            // answersComboBox
            // 
            answersComboBox.FormattingEnabled = true;
            answersComboBox.Location = new Point(631, 276);
            answersComboBox.Name = "answersComboBox";
            answersComboBox.Size = new Size(265, 28);
            answersComboBox.TabIndex = 12;
            answersComboBox.SelectedIndexChanged += answearsComboBox_SelectedIndexChanged;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(type3RadioButton);
            groupBox3.Controls.Add(type2RadioButton);
            groupBox3.Controls.Add(type1RadioButton);
            groupBox3.Location = new Point(400, 23);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(225, 124);
            groupBox3.TabIndex = 11;
            groupBox3.TabStop = false;
            groupBox3.Text = "Select Type";
            // 
            // type3RadioButton
            // 
            type3RadioButton.AutoSize = true;
            type3RadioButton.Location = new Point(6, 83);
            type3RadioButton.Name = "type3RadioButton";
            type3RadioButton.Size = new Size(42, 24);
            type3RadioButton.TabIndex = 2;
            type3RadioButton.TabStop = true;
            type3RadioButton.Text = "III";
            type3RadioButton.UseVisualStyleBackColor = true;
            type3RadioButton.CheckedChanged += type3RadioButton_CheckedChanged;
            // 
            // type2RadioButton
            // 
            type2RadioButton.AutoSize = true;
            type2RadioButton.Location = new Point(6, 53);
            type2RadioButton.Name = "type2RadioButton";
            type2RadioButton.Size = new Size(38, 24);
            type2RadioButton.TabIndex = 1;
            type2RadioButton.TabStop = true;
            type2RadioButton.Text = "II";
            type2RadioButton.UseVisualStyleBackColor = true;
            type2RadioButton.CheckedChanged += type2RadioButton_CheckedChanged;
            // 
            // type1RadioButton
            // 
            type1RadioButton.AutoSize = true;
            type1RadioButton.Location = new Point(6, 23);
            type1RadioButton.Name = "type1RadioButton";
            type1RadioButton.Size = new Size(34, 24);
            type1RadioButton.TabIndex = 0;
            type1RadioButton.TabStop = true;
            type1RadioButton.Text = "I";
            type1RadioButton.UseVisualStyleBackColor = true;
            type1RadioButton.CheckedChanged += type1RadioButton_CheckedChanged;
            // 
            // categoriesTextBox
            // 
            categoriesTextBox.Location = new Point(631, 82);
            categoriesTextBox.Multiline = true;
            categoriesTextBox.Name = "categoriesTextBox";
            categoriesTextBox.ScrollBars = ScrollBars.Vertical;
            categoriesTextBox.Size = new Size(378, 155);
            categoriesTextBox.TabIndex = 10;
            // 
            // AddQuestionForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1039, 518);
            Controls.Add(groupBox1);
            Name = "AddQuestionForm";
            Text = "Add Question Form";
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label label2;
        private TextBox questionTextBox;
        private ComboBox descriptionIdsComboBox;
        private TextBox descriptionTextBox;
        private Label label1;
        private GroupBox groupBox2;
        private RadioButton noRadioButton;
        private RadioButton yesRadioButton;
        private Button addQuestionButton;
        private ComboBox categoriesComboBox;
        private Label label3;
        private GroupBox groupBox1;
        private TextBox categoriesTextBox;
        private TextBox answearTextBox;
        private Button addAnswerButton;
        private Label label4;
        private ComboBox answersComboBox;
        private GroupBox groupBox3;
        private RadioButton type3RadioButton;
        private RadioButton type2RadioButton;
        private RadioButton type1RadioButton;
        private Button resetButton;
        private Button addAnswersButton;
        private CheckBox isCaseSensitive;
    }
}