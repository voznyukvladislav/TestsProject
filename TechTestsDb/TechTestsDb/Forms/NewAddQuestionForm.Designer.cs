namespace TechTestsDb.Forms
{
    partial class NewAddQuestionForm
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
            groupBox1 = new GroupBox();
            fifthTypeRadioButton = new RadioButton();
            fourthTypeRadioButton = new RadioButton();
            thirdTypeRadioButton = new RadioButton();
            secondTypeRadioButton = new RadioButton();
            firstTypeRadioButton = new RadioButton();
            descriptionsListBox = new ListBox();
            label1 = new Label();
            label2 = new Label();
            categoriesListBox = new ListBox();
            firstTypeGroupBox = new GroupBox();
            noRadioButton = new RadioButton();
            yesRadioButton = new RadioButton();
            secondThirdTypeGroupBox = new GroupBox();
            addAnswerSetButton = new Button();
            add1Button = new Button();
            deleteSetButton = new Button();
            delete1Button = new Button();
            answer1ListBox = new ListBox();
            answer1TextBox = new TextBox();
            answerSetsComboBox = new ComboBox();
            fourthFifthTypeGroupBox = new GroupBox();
            add2Button = new Button();
            answer2ListBox = new ListBox();
            delete2Button = new Button();
            isCorrectAnswerCheckBox = new CheckBox();
            answer2TextBox = new TextBox();
            addQuestionButton = new Button();
            refreshButton = new Button();
            questionTextBox = new TextBox();
            label3 = new Label();
            isCaseSensitiveCheckBox = new CheckBox();
            groupBox1.SuspendLayout();
            firstTypeGroupBox.SuspendLayout();
            secondThirdTypeGroupBox.SuspendLayout();
            fourthFifthTypeGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(fifthTypeRadioButton);
            groupBox1.Controls.Add(fourthTypeRadioButton);
            groupBox1.Controls.Add(thirdTypeRadioButton);
            groupBox1.Controls.Add(secondTypeRadioButton);
            groupBox1.Controls.Add(firstTypeRadioButton);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(121, 190);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Question Type";
            // 
            // fifthTypeRadioButton
            // 
            fifthTypeRadioButton.AutoSize = true;
            fifthTypeRadioButton.Location = new Point(6, 142);
            fifthTypeRadioButton.Name = "fifthTypeRadioButton";
            fifthTypeRadioButton.Size = new Size(39, 24);
            fifthTypeRadioButton.TabIndex = 4;
            fifthTypeRadioButton.TabStop = true;
            fifthTypeRadioButton.Text = "V";
            fifthTypeRadioButton.UseVisualStyleBackColor = true;
            fifthTypeRadioButton.CheckedChanged += fifthTypeRadioButton_CheckedChanged;
            // 
            // fourthTypeRadioButton
            // 
            fourthTypeRadioButton.AutoSize = true;
            fourthTypeRadioButton.Location = new Point(6, 112);
            fourthTypeRadioButton.Name = "fourthTypeRadioButton";
            fourthTypeRadioButton.Size = new Size(43, 24);
            fourthTypeRadioButton.TabIndex = 3;
            fourthTypeRadioButton.TabStop = true;
            fourthTypeRadioButton.Text = "IV";
            fourthTypeRadioButton.UseVisualStyleBackColor = true;
            fourthTypeRadioButton.CheckedChanged += fourthTypeRadioButton_CheckedChanged;
            // 
            // thirdTypeRadioButton
            // 
            thirdTypeRadioButton.AutoSize = true;
            thirdTypeRadioButton.Location = new Point(6, 82);
            thirdTypeRadioButton.Name = "thirdTypeRadioButton";
            thirdTypeRadioButton.Size = new Size(42, 24);
            thirdTypeRadioButton.TabIndex = 2;
            thirdTypeRadioButton.TabStop = true;
            thirdTypeRadioButton.Text = "III";
            thirdTypeRadioButton.UseVisualStyleBackColor = true;
            thirdTypeRadioButton.CheckedChanged += trirdTypeRadioButton_CheckedChanged;
            // 
            // secondTypeRadioButton
            // 
            secondTypeRadioButton.AutoSize = true;
            secondTypeRadioButton.Location = new Point(6, 52);
            secondTypeRadioButton.Name = "secondTypeRadioButton";
            secondTypeRadioButton.Size = new Size(38, 24);
            secondTypeRadioButton.TabIndex = 1;
            secondTypeRadioButton.TabStop = true;
            secondTypeRadioButton.Text = "II";
            secondTypeRadioButton.UseVisualStyleBackColor = true;
            secondTypeRadioButton.CheckedChanged += secondTypeRadioButton_CheckedChanged;
            // 
            // firstTypeRadioButton
            // 
            firstTypeRadioButton.AutoSize = true;
            firstTypeRadioButton.Location = new Point(6, 22);
            firstTypeRadioButton.Name = "firstTypeRadioButton";
            firstTypeRadioButton.Size = new Size(34, 24);
            firstTypeRadioButton.TabIndex = 0;
            firstTypeRadioButton.TabStop = true;
            firstTypeRadioButton.Text = "I";
            firstTypeRadioButton.UseVisualStyleBackColor = true;
            firstTypeRadioButton.CheckedChanged += firstTypeRadioButton_CheckedChanged;
            // 
            // descriptionsListBox
            // 
            descriptionsListBox.FormattingEnabled = true;
            descriptionsListBox.HorizontalScrollbar = true;
            descriptionsListBox.ItemHeight = 20;
            descriptionsListBox.Location = new Point(139, 38);
            descriptionsListBox.Name = "descriptionsListBox";
            descriptionsListBox.Size = new Size(314, 164);
            descriptionsListBox.TabIndex = 2;
            descriptionsListBox.SelectedIndexChanged += descriptionsListBox_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(139, 15);
            label1.Name = "label1";
            label1.Size = new Size(127, 20);
            label1.TabIndex = 3;
            label1.Text = "Select description";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(459, 15);
            label2.Name = "label2";
            label2.Size = new Size(122, 20);
            label2.TabIndex = 5;
            label2.Text = "Select categories";
            // 
            // categoriesListBox
            // 
            categoriesListBox.FormattingEnabled = true;
            categoriesListBox.HorizontalScrollbar = true;
            categoriesListBox.ItemHeight = 20;
            categoriesListBox.Location = new Point(459, 38);
            categoriesListBox.Name = "categoriesListBox";
            categoriesListBox.SelectionMode = SelectionMode.MultiSimple;
            categoriesListBox.Size = new Size(314, 164);
            categoriesListBox.TabIndex = 4;
            categoriesListBox.SelectedIndexChanged += categoriesListBox_SelectedIndexChanged;
            // 
            // firstTypeGroupBox
            // 
            firstTypeGroupBox.Controls.Add(noRadioButton);
            firstTypeGroupBox.Controls.Add(yesRadioButton);
            firstTypeGroupBox.Location = new Point(12, 208);
            firstTypeGroupBox.Name = "firstTypeGroupBox";
            firstTypeGroupBox.Size = new Size(121, 237);
            firstTypeGroupBox.TabIndex = 6;
            firstTypeGroupBox.TabStop = false;
            firstTypeGroupBox.Text = "For 1st type";
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
            // secondThirdTypeGroupBox
            // 
            secondThirdTypeGroupBox.Controls.Add(addAnswerSetButton);
            secondThirdTypeGroupBox.Controls.Add(add1Button);
            secondThirdTypeGroupBox.Controls.Add(deleteSetButton);
            secondThirdTypeGroupBox.Controls.Add(delete1Button);
            secondThirdTypeGroupBox.Controls.Add(answer1ListBox);
            secondThirdTypeGroupBox.Controls.Add(answer1TextBox);
            secondThirdTypeGroupBox.Controls.Add(answerSetsComboBox);
            secondThirdTypeGroupBox.Location = new Point(139, 208);
            secondThirdTypeGroupBox.Name = "secondThirdTypeGroupBox";
            secondThirdTypeGroupBox.Size = new Size(314, 240);
            secondThirdTypeGroupBox.TabIndex = 7;
            secondThirdTypeGroupBox.TabStop = false;
            secondThirdTypeGroupBox.Text = "For 2nd, 3rd types";
            // 
            // addAnswerSetButton
            // 
            addAnswerSetButton.Location = new Point(132, 26);
            addAnswerSetButton.Name = "addAnswerSetButton";
            addAnswerSetButton.Size = new Size(85, 29);
            addAnswerSetButton.TabIndex = 7;
            addAnswerSetButton.Text = "Add Set";
            addAnswerSetButton.UseVisualStyleBackColor = true;
            addAnswerSetButton.Click += addAnswerSetButton_Click;
            // 
            // add1Button
            // 
            add1Button.Location = new Point(178, 60);
            add1Button.Name = "add1Button";
            add1Button.Size = new Size(62, 29);
            add1Button.TabIndex = 6;
            add1Button.Text = "Add";
            add1Button.UseVisualStyleBackColor = true;
            add1Button.Click += add1Button_Click;
            // 
            // deleteSetButton
            // 
            deleteSetButton.Location = new Point(223, 26);
            deleteSetButton.Name = "deleteSetButton";
            deleteSetButton.Size = new Size(85, 29);
            deleteSetButton.TabIndex = 5;
            deleteSetButton.Text = "Del Set";
            deleteSetButton.UseVisualStyleBackColor = true;
            deleteSetButton.Click += deleteSetButton_Click;
            // 
            // delete1Button
            // 
            delete1Button.Location = new Point(246, 59);
            delete1Button.Name = "delete1Button";
            delete1Button.Size = new Size(62, 29);
            delete1Button.TabIndex = 4;
            delete1Button.Text = "Del";
            delete1Button.UseVisualStyleBackColor = true;
            delete1Button.Click += delete1Button_Click;
            // 
            // answer1ListBox
            // 
            answer1ListBox.FormattingEnabled = true;
            answer1ListBox.HorizontalScrollbar = true;
            answer1ListBox.ItemHeight = 20;
            answer1ListBox.Location = new Point(6, 93);
            answer1ListBox.Name = "answer1ListBox";
            answer1ListBox.Size = new Size(302, 144);
            answer1ListBox.TabIndex = 3;
            // 
            // answer1TextBox
            // 
            answer1TextBox.Location = new Point(6, 60);
            answer1TextBox.Name = "answer1TextBox";
            answer1TextBox.PlaceholderText = "Enter answer";
            answer1TextBox.Size = new Size(166, 27);
            answer1TextBox.TabIndex = 2;
            // 
            // answerSetsComboBox
            // 
            answerSetsComboBox.FormattingEnabled = true;
            answerSetsComboBox.Location = new Point(6, 26);
            answerSetsComboBox.Name = "answerSetsComboBox";
            answerSetsComboBox.Size = new Size(121, 28);
            answerSetsComboBox.TabIndex = 0;
            answerSetsComboBox.SelectedIndexChanged += answerSetsComboBox_SelectedIndexChanged;
            // 
            // fourthFifthTypeGroupBox
            // 
            fourthFifthTypeGroupBox.Controls.Add(add2Button);
            fourthFifthTypeGroupBox.Controls.Add(answer2ListBox);
            fourthFifthTypeGroupBox.Controls.Add(delete2Button);
            fourthFifthTypeGroupBox.Controls.Add(isCorrectAnswerCheckBox);
            fourthFifthTypeGroupBox.Controls.Add(answer2TextBox);
            fourthFifthTypeGroupBox.Location = new Point(459, 208);
            fourthFifthTypeGroupBox.Name = "fourthFifthTypeGroupBox";
            fourthFifthTypeGroupBox.Size = new Size(314, 240);
            fourthFifthTypeGroupBox.TabIndex = 8;
            fourthFifthTypeGroupBox.TabStop = false;
            fourthFifthTypeGroupBox.Text = "For 4th, 5th types";
            // 
            // add2Button
            // 
            add2Button.Location = new Point(178, 56);
            add2Button.Name = "add2Button";
            add2Button.Size = new Size(62, 29);
            add2Button.TabIndex = 7;
            add2Button.Text = "Add";
            add2Button.UseVisualStyleBackColor = true;
            add2Button.Click += add2Button_Click;
            // 
            // answer2ListBox
            // 
            answer2ListBox.FormattingEnabled = true;
            answer2ListBox.HorizontalScrollbar = true;
            answer2ListBox.ItemHeight = 20;
            answer2ListBox.Location = new Point(6, 93);
            answer2ListBox.Name = "answer2ListBox";
            answer2ListBox.Size = new Size(302, 144);
            answer2ListBox.TabIndex = 6;
            // 
            // delete2Button
            // 
            delete2Button.Location = new Point(246, 56);
            delete2Button.Name = "delete2Button";
            delete2Button.Size = new Size(62, 29);
            delete2Button.TabIndex = 5;
            delete2Button.Text = "Del";
            delete2Button.UseVisualStyleBackColor = true;
            delete2Button.Click += delete2Button_Click;
            // 
            // isCorrectAnswerCheckBox
            // 
            isCorrectAnswerCheckBox.AutoSize = true;
            isCorrectAnswerCheckBox.Location = new Point(6, 60);
            isCorrectAnswerCheckBox.Name = "isCorrectAnswerCheckBox";
            isCorrectAnswerCheckBox.Size = new Size(137, 24);
            isCorrectAnswerCheckBox.TabIndex = 1;
            isCorrectAnswerCheckBox.Text = "IsCorrectAnswer";
            isCorrectAnswerCheckBox.UseVisualStyleBackColor = true;
            // 
            // answer2TextBox
            // 
            answer2TextBox.Location = new Point(6, 23);
            answer2TextBox.Name = "answer2TextBox";
            answer2TextBox.PlaceholderText = "Enter answer";
            answer2TextBox.Size = new Size(302, 27);
            answer2TextBox.TabIndex = 0;
            // 
            // addQuestionButton
            // 
            addQuestionButton.Location = new Point(779, 336);
            addQuestionButton.Name = "addQuestionButton";
            addQuestionButton.Size = new Size(267, 51);
            addQuestionButton.TabIndex = 9;
            addQuestionButton.Text = "Add Question";
            addQuestionButton.UseVisualStyleBackColor = true;
            addQuestionButton.Click += addQuestionButton_Click;
            // 
            // refreshButton
            // 
            refreshButton.Location = new Point(779, 393);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(267, 51);
            refreshButton.TabIndex = 10;
            refreshButton.Text = "Refresh";
            refreshButton.UseVisualStyleBackColor = true;
            refreshButton.Click += refreshButton_Click;
            // 
            // questionTextBox
            // 
            questionTextBox.Location = new Point(779, 38);
            questionTextBox.Multiline = true;
            questionTextBox.Name = "questionTextBox";
            questionTextBox.ScrollBars = ScrollBars.Vertical;
            questionTextBox.Size = new Size(267, 263);
            questionTextBox.TabIndex = 11;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(779, 15);
            label3.Name = "label3";
            label3.Size = new Size(133, 20);
            label3.TabIndex = 12;
            label3.Text = "Enter question text";
            // 
            // isCaseSensitiveCheckBox
            // 
            isCaseSensitiveCheckBox.AutoSize = true;
            isCaseSensitiveCheckBox.Location = new Point(779, 307);
            isCaseSensitiveCheckBox.Name = "isCaseSensitiveCheckBox";
            isCaseSensitiveCheckBox.Size = new Size(130, 24);
            isCaseSensitiveCheckBox.TabIndex = 13;
            isCaseSensitiveCheckBox.Text = "IsCaseSensitive";
            isCaseSensitiveCheckBox.UseVisualStyleBackColor = true;
            isCaseSensitiveCheckBox.CheckedChanged += isCaseSensitiveCheckBox_CheckedChanged;
            // 
            // NewAddQuestionForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1050, 453);
            Controls.Add(isCaseSensitiveCheckBox);
            Controls.Add(label3);
            Controls.Add(questionTextBox);
            Controls.Add(refreshButton);
            Controls.Add(addQuestionButton);
            Controls.Add(fourthFifthTypeGroupBox);
            Controls.Add(secondThirdTypeGroupBox);
            Controls.Add(firstTypeGroupBox);
            Controls.Add(label2);
            Controls.Add(categoriesListBox);
            Controls.Add(label1);
            Controls.Add(descriptionsListBox);
            Controls.Add(groupBox1);
            Name = "NewAddQuestionForm";
            Text = "Create Question Form";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            firstTypeGroupBox.ResumeLayout(false);
            firstTypeGroupBox.PerformLayout();
            secondThirdTypeGroupBox.ResumeLayout(false);
            secondThirdTypeGroupBox.PerformLayout();
            fourthFifthTypeGroupBox.ResumeLayout(false);
            fourthFifthTypeGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private RadioButton fifthTypeRadioButton;
        private RadioButton fourthTypeRadioButton;
        private RadioButton thirdTypeRadioButton;
        private RadioButton secondTypeRadioButton;
        private RadioButton firstTypeRadioButton;
        private ListBox descriptionsListBox;
        private Label label1;
        private Label label2;
        private ListBox categoriesListBox;
        private GroupBox firstTypeGroupBox;
        private RadioButton noRadioButton;
        private RadioButton yesRadioButton;
        private GroupBox secondThirdTypeGroupBox;
        private Button delete1Button;
        private ListBox answer1ListBox;
        private TextBox answer1TextBox;
        private ComboBox answerSetsComboBox;
        private GroupBox fourthFifthTypeGroupBox;
        private CheckBox isCorrectAnswerCheckBox;
        private TextBox answer2TextBox;
        private ListBox answer2ListBox;
        private Button delete2Button;
        private Button addQuestionButton;
        private Button refreshButton;
        private TextBox questionTextBox;
        private Label label3;
        private CheckBox isCaseSensitiveCheckBox;
        private Button deleteSetButton;
        private Button addAnswerSetButton;
        private Button add1Button;
        private Button add2Button;
    }
}