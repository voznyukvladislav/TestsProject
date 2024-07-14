namespace TechTestsDb.Forms.DataForms
{
    partial class QuestionGroupForm
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
            nameTextBox = new TextBox();
            label2 = new Label();
            idTextBox = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(237, 118);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(215, 42);
            cancelButton.TabIndex = 11;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // applyButton
            // 
            applyButton.Location = new Point(12, 118);
            applyButton.Name = "applyButton";
            applyButton.Size = new Size(215, 42);
            applyButton.TabIndex = 10;
            applyButton.Text = "Apply";
            applyButton.UseVisualStyleBackColor = true;
            applyButton.Click += applyButton_Click;
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(12, 85);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(440, 27);
            nameTextBox.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 62);
            label2.Name = "label2";
            label2.Size = new Size(49, 20);
            label2.TabIndex = 8;
            label2.Text = "Name";
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
            // QuestionGroupForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(464, 173);
            Controls.Add(cancelButton);
            Controls.Add(applyButton);
            Controls.Add(nameTextBox);
            Controls.Add(label2);
            Controls.Add(idTextBox);
            Controls.Add(label1);
            KeyPreview = true;
            Name = "QuestionGroupForm";
            Text = "QuestionGroupForm";
            KeyUp += QuestionGroupForm_KeyUp;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button cancelButton;
        private Button applyButton;
        private TextBox nameTextBox;
        private Label label2;
        private TextBox idTextBox;
        private Label label1;
    }
}