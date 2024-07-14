namespace TechTestsDb.Forms.DataForms
{
    partial class QuestionForm
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
            typeIdTextBox = new TextBox();
            label2 = new Label();
            idTextBox = new TextBox();
            label1 = new Label();
            descriptionIdTextBox = new TextBox();
            label3 = new Label();
            valueTextBox = new TextBox();
            label5 = new Label();
            isCaseSensitiveCheckBox = new CheckBox();
            SuspendLayout();
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(237, 261);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(215, 42);
            cancelButton.TabIndex = 23;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // applyButton
            // 
            applyButton.Location = new Point(12, 261);
            applyButton.Name = "applyButton";
            applyButton.Size = new Size(215, 42);
            applyButton.TabIndex = 22;
            applyButton.Text = "Apply";
            applyButton.UseVisualStyleBackColor = true;
            applyButton.Click += applyButton_Click;
            // 
            // typeIdTextBox
            // 
            typeIdTextBox.Location = new Point(12, 85);
            typeIdTextBox.Name = "typeIdTextBox";
            typeIdTextBox.Size = new Size(440, 27);
            typeIdTextBox.TabIndex = 21;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 62);
            label2.Name = "label2";
            label2.Size = new Size(53, 20);
            label2.TabIndex = 20;
            label2.Text = "TypeId";
            // 
            // idTextBox
            // 
            idTextBox.Location = new Point(12, 32);
            idTextBox.Name = "idTextBox";
            idTextBox.ReadOnly = true;
            idTextBox.Size = new Size(440, 27);
            idTextBox.TabIndex = 19;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(22, 20);
            label1.TabIndex = 18;
            label1.Text = "Id";
            // 
            // descriptionIdTextBox
            // 
            descriptionIdTextBox.Location = new Point(12, 138);
            descriptionIdTextBox.Name = "descriptionIdTextBox";
            descriptionIdTextBox.Size = new Size(440, 27);
            descriptionIdTextBox.TabIndex = 25;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 115);
            label3.Name = "label3";
            label3.Size = new Size(98, 20);
            label3.TabIndex = 24;
            label3.Text = "DescriptionId";
            // 
            // valueTextBox
            // 
            valueTextBox.Location = new Point(12, 194);
            valueTextBox.Name = "valueTextBox";
            valueTextBox.Size = new Size(440, 27);
            valueTextBox.TabIndex = 29;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 171);
            label5.Name = "label5";
            label5.Size = new Size(45, 20);
            label5.TabIndex = 28;
            label5.Text = "Value";
            // 
            // isCaseSensitiveCheckBox
            // 
            isCaseSensitiveCheckBox.AutoSize = true;
            isCaseSensitiveCheckBox.Location = new Point(12, 231);
            isCaseSensitiveCheckBox.Name = "isCaseSensitiveCheckBox";
            isCaseSensitiveCheckBox.Size = new Size(130, 24);
            isCaseSensitiveCheckBox.TabIndex = 30;
            isCaseSensitiveCheckBox.Text = "IsCaseSensitive";
            isCaseSensitiveCheckBox.UseVisualStyleBackColor = true;
            // 
            // QuestionForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(464, 316);
            Controls.Add(isCaseSensitiveCheckBox);
            Controls.Add(valueTextBox);
            Controls.Add(label5);
            Controls.Add(descriptionIdTextBox);
            Controls.Add(label3);
            Controls.Add(cancelButton);
            Controls.Add(applyButton);
            Controls.Add(typeIdTextBox);
            Controls.Add(label2);
            Controls.Add(idTextBox);
            Controls.Add(label1);
            KeyPreview = true;
            Name = "QuestionForm";
            Text = "QuestionForm";
            KeyUp += QuestionForm_KeyUp;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button cancelButton;
        private Button applyButton;
        private TextBox typeIdTextBox;
        private Label label2;
        private TextBox idTextBox;
        private Label label1;
        private TextBox descriptionIdTextBox;
        private Label label3;
        private TextBox valueTextBox;
        private Label label5;
        private CheckBox isCaseSensitiveCheckBox;
    }
}