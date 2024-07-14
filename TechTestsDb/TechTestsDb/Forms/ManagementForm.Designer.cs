namespace TechTestsDb.Forms
{
    partial class ManagementForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManagementForm));
            tableDataListBox = new ListBox();
            label1 = new Label();
            tableNamesComboBox = new ComboBox();
            addButton = new Button();
            updateButton = new Button();
            deleteButton = new Button();
            refreshButton = new Button();
            SuspendLayout();
            // 
            // tableDataListBox
            // 
            tableDataListBox.FormattingEnabled = true;
            tableDataListBox.HorizontalScrollbar = true;
            tableDataListBox.ItemHeight = 20;
            tableDataListBox.Location = new Point(12, 76);
            tableDataListBox.Name = "tableDataListBox";
            tableDataListBox.Size = new Size(582, 364);
            tableDataListBox.TabIndex = 0;
            tableDataListBox.SelectedIndexChanged += tableDataListBox_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(98, 23);
            label1.TabIndex = 0;
            label1.Text = "Select table";
            // 
            // tableNamesComboBox
            // 
            tableNamesComboBox.FormattingEnabled = true;
            tableNamesComboBox.Location = new Point(12, 40);
            tableNamesComboBox.Name = "tableNamesComboBox";
            tableNamesComboBox.Size = new Size(548, 28);
            tableNamesComboBox.TabIndex = 1;
            tableNamesComboBox.SelectedIndexChanged += tableNamesComboBox_SelectedIndexChanged;
            // 
            // addButton
            // 
            addButton.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            addButton.Location = new Point(600, 37);
            addButton.Name = "addButton";
            addButton.Size = new Size(188, 46);
            addButton.TabIndex = 2;
            addButton.Text = "Add";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // updateButton
            // 
            updateButton.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            updateButton.Location = new Point(600, 89);
            updateButton.Name = "updateButton";
            updateButton.Size = new Size(188, 46);
            updateButton.TabIndex = 3;
            updateButton.Text = "Update";
            updateButton.UseVisualStyleBackColor = true;
            updateButton.Click += updateButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            deleteButton.Location = new Point(600, 141);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(188, 46);
            deleteButton.TabIndex = 4;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // refreshButton
            // 
            refreshButton.BackgroundImage = (Image)resources.GetObject("refreshButton.BackgroundImage");
            refreshButton.BackgroundImageLayout = ImageLayout.Center;
            refreshButton.Location = new Point(562, 37);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(32, 32);
            refreshButton.TabIndex = 5;
            refreshButton.UseVisualStyleBackColor = true;
            refreshButton.Click += refreshButton_Click;
            // 
            // ManagementForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(refreshButton);
            Controls.Add(deleteButton);
            Controls.Add(updateButton);
            Controls.Add(addButton);
            Controls.Add(tableNamesComboBox);
            Controls.Add(tableDataListBox);
            Controls.Add(label1);
            Name = "ManagementForm";
            Text = "Management Form";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox tableDataListBox;
        private ComboBox tableNamesComboBox;
        private Label label1;
        private Button addButton;
        private Button updateButton;
        private Button deleteButton;
        private Button refreshButton;
    }
}