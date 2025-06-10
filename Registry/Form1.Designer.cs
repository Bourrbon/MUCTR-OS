using System.Diagnostics;

namespace RegistryApp
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
            RegistryTreeView = new TreeView();
            CreateButton = new Button();
            ParametersBox = new ComboBox();
            DeleteButton = new Button();
            statusStrip1 = new StatusStrip();
            ErrorLabel = new ToolStripStatusLabel();
            label1 = new Label();
            ParameterEditBox = new RichTextBox();
            listBoxChanges = new ListBox();
            listViewValues = new ListView();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // RegistryTreeView
            // 
            RegistryTreeView.Location = new Point(12, 12);
            RegistryTreeView.Name = "RegistryTreeView";
            RegistryTreeView.Size = new Size(340, 426);
            RegistryTreeView.TabIndex = 0;
            // 
            // CreateButton
            // 
            CreateButton.Location = new Point(358, 409);
            CreateButton.Name = "CreateButton";
            CreateButton.Size = new Size(206, 29);
            CreateButton.TabIndex = 1;
            CreateButton.Text = "Создать";
            CreateButton.UseVisualStyleBackColor = true;
            CreateButton.Click += btnCreate_Click;
            // 
            // ParametersBox
            // 
            ParametersBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ParametersBox.FormattingEnabled = true;
            ParametersBox.Items.AddRange(new object[] { "Раздел", "Строковый параметр", "Число (QWORD)" });
            ParametersBox.Location = new Point(394, 16);
            ParametersBox.Name = "ParametersBox";
            ParametersBox.Size = new Size(379, 28);
            ParametersBox.TabIndex = 2;
            // 
            // DeleteButton
            // 
            DeleteButton.Location = new Point(582, 409);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(206, 29);
            DeleteButton.TabIndex = 3;
            DeleteButton.Text = "Удалить";
            DeleteButton.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { ErrorLabel });
            statusStrip1.Location = new Point(0, 445);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 26);
            statusStrip1.TabIndex = 4;
            statusStrip1.Text = "statusStrip1";
            // 
            // ErrorLabel
            // 
            ErrorLabel.Name = "ErrorLabel";
            ErrorLabel.Size = new Size(18, 20);
            ErrorLabel.Text = "...";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(397, 68);
            label1.Name = "label1";
            label1.Size = new Size(285, 20);
            label1.TabIndex = 6;
            label1.Text = "Введите название раздела / параметра";
            // 
            // ParameterEditBox
            // 
            ParameterEditBox.Location = new Point(394, 113);
            ParameterEditBox.Multiline = false;
            ParameterEditBox.Name = "ParameterEditBox";
            ParameterEditBox.Size = new Size(379, 52);
            ParameterEditBox.TabIndex = 7;
            ParameterEditBox.Text = "";
            // 
            // listBoxChanges
            // 
            listBoxChanges.FormattingEnabled = true;
            listBoxChanges.Location = new Point(435, 218);
            listBoxChanges.Name = "listBoxChanges";
            listBoxChanges.Size = new Size(150, 104);
            listBoxChanges.TabIndex = 8;
            // 
            // listViewValues
            // 
            listViewValues.Location = new Point(620, 222);
            listViewValues.Name = "listViewValues";
            listViewValues.Size = new Size(151, 121);
            listViewValues.TabIndex = 9;
            listViewValues.UseCompatibleStateImageBehavior = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 471);
            Controls.Add(listViewValues);
            Controls.Add(listBoxChanges);
            Controls.Add(ParameterEditBox);
            Controls.Add(label1);
            Controls.Add(statusStrip1);
            Controls.Add(DeleteButton);
            Controls.Add(ParametersBox);
            Controls.Add(CreateButton);
            Controls.Add(RegistryTreeView);
            Name = "Form1";
            Text = "Form1";
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TreeView RegistryTreeView;
        private Button CreateButton;
        private ComboBox ParametersBox;
        private Button DeleteButton;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel ErrorLabel;
        private Label label1;
        private RichTextBox ParameterEditBox;


        private ListBox listBoxChanges;
        private ListView listViewValues;
    }
}
