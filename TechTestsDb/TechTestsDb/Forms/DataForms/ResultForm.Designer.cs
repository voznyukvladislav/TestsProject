namespace TechTestsDb.Forms.DataForms
{
    partial class ResultForm
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
            userIdTextBox = new TextBox();
            label2 = new Label();
            idTextBox = new TextBox();
            label1 = new Label();
            questionGroupIdTextBox = new TextBox();
            label3 = new Label();
            dateTimeTextBox = new TextBox();
            label4 = new Label();
            resultTextBox = new TextBox();
            label5 = new Label();
            SuspendLayout();
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(237, 277);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(215, 42);
            cancelButton.TabIndex = 11;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // applyButton
            // 
            applyButton.Location = new Point(12, 277);
            applyButton.Name = "applyButton";
            applyButton.Size = new Size(215, 42);
            applyButton.TabIndex = 10;
            applyButton.Text = "Apply";
            applyButton.UseVisualStyleBackColor = true;
            applyButton.Click += applyButton_Click;
            // 
            // userIdTextBox
            // 
            userIdTextBox.Location = new Point(12, 85);
            userIdTextBox.Name = "userIdTextBox";
            userIdTextBox.Size = new Size(440, 27);
            userIdTextBox.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 62);
            label2.Name = "label2";
            label2.Size = new Size(51, 20);
            label2.TabIndex = 8;
            label2.Text = "UserId";
            // 
            // idTextBox
            // 
            idTextBox.Location = new Point(12, 32);
            idTextBox.Name = "idTextBox";
            idTextBox.ReadOnly = true;
            idTextBox.Size = new Size(440, 27);
            idTextBox.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(22, 20);
            label1.TabIndex = 6;
            label1.Text = "Id";
            // 
            // questionGroupIdTextBox
            // 
            questionGroupIdTextBox.Location = new Point(12, 138);
            questionGroupIdTextBox.Name = "questionGroupIdTextBox";
            questionGroupIdTextBox.Size = new Size(440, 27);
            questionGroupIdTextBox.TabIndex = 13;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 115);
            label3.Name = "label3";
            label3.Size = new Size(122, 20);
            label3.TabIndex = 12;
            label3.Text = "QuestionGroupId";
            // 
            // dateTimeTextBox
            // 
            dateTimeTextBox.Location = new Point(12, 191);
            dateTimeTextBox.Name = "dateTimeTextBox";
            dateTimeTextBox.Size = new Size(440, 27);
            dateTimeTextBox.TabIndex = 15;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 168);
            label4.Name = "label4";
            label4.Size = new Size(74, 20);
            label4.TabIndex = 14;
            label4.Text = "DateTime";
            // 
            // resultTextBox
            // 
            resultTextBox.Location = new Point(12, 244);
            resultTextBox.Name = "resultTextBox";
            resultTextBox.Size = new Size(440, 27);
            resultTextBox.TabIndex = 17;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 221);
            label5.Name = "label5";
            label5.Size = new Size(49, 20);
            label5.TabIndex = 16;
            label5.Text = "Result";
            // 
            // ResultForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(464, 333);
            Controls.Add(resultTextBox);
            Controls.Add(label5);
            Controls.Add(dateTimeTextBox);
            Controls.Add(label4);
            Controls.Add(questionGroupIdTextBox);
            Controls.Add(label3);
            Controls.Add(cancelButton);
            Controls.Add(applyButton);
            Controls.Add(userIdTextBox);
            Controls.Add(label2);
            Controls.Add(idTextBox);
            Controls.Add(label1);
            KeyPreview = true;
            Name = "ResultForm";
            Text = "ResultForm";
            KeyUp += ResultForm_KeyUp;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button cancelButton;
        private Button applyButton;
        private TextBox userIdTextBox;
        private Label label2;
        private TextBox idTextBox;
        private Label label1;
        private TextBox questionGroupIdTextBox;
        private Label label3;
        private TextBox dateTimeTextBox;
        private Label label4;
        private TextBox resultTextBox;
        private Label label5;
    }
}