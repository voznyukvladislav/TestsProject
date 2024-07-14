namespace TechTestsDb.Forms.DataForms
{
    partial class DescriptionForm
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
            valueTextBox = new TextBox();
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
            cancelButton.TabIndex = 23;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // applyButton
            // 
            applyButton.Location = new Point(12, 118);
            applyButton.Name = "applyButton";
            applyButton.Size = new Size(215, 42);
            applyButton.TabIndex = 22;
            applyButton.Text = "Apply";
            applyButton.UseVisualStyleBackColor = true;
            applyButton.Click += applyButton_Click;
            // 
            // valueTextBox
            // 
            valueTextBox.Location = new Point(12, 85);
            valueTextBox.Name = "valueTextBox";
            valueTextBox.Size = new Size(440, 27);
            valueTextBox.TabIndex = 21;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 62);
            label2.Name = "label2";
            label2.Size = new Size(45, 20);
            label2.TabIndex = 20;
            label2.Text = "Value";
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
            // DescriptionForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(464, 173);
            Controls.Add(cancelButton);
            Controls.Add(applyButton);
            Controls.Add(valueTextBox);
            Controls.Add(label2);
            Controls.Add(idTextBox);
            Controls.Add(label1);
            KeyPreview = true;
            Name = "DescriptionForm";
            Text = "DescriptionForm";
            KeyUp += DescriptionForm_KeyUp;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button cancelButton;
        private Button applyButton;
        private TextBox valueTextBox;
        private Label label2;
        private TextBox idTextBox;
        private Label label1;
    }
}