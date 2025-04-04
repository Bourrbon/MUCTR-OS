namespace Lab2
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.FileTree = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.CreateFileButton = new System.Windows.Forms.Button();
            this.EditFileButton = new System.Windows.Forms.Button();
            this.DeleteFIleButton = new System.Windows.Forms.Button();
            this.FileEditBox = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.FileInfoBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ErrorLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.SaveFileButton = new System.Windows.Forms.Button();
            this.CancelFileButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ParentFolderButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.RenameFileButton = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // FileTree
            // 
            this.FileTree.Location = new System.Drawing.Point(12, 63);
            this.FileTree.Name = "FileTree";
            this.FileTree.Size = new System.Drawing.Size(248, 271);
            this.FileTree.TabIndex = 0;
            this.FileTree.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.FileTree_NodeMouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Текущая папка";
            // 
            // CreateFileButton
            // 
            this.CreateFileButton.Location = new System.Drawing.Point(12, 395);
            this.CreateFileButton.Name = "CreateFileButton";
            this.CreateFileButton.Size = new System.Drawing.Size(248, 34);
            this.CreateFileButton.TabIndex = 2;
            this.CreateFileButton.Text = "Создать файл";
            this.CreateFileButton.UseVisualStyleBackColor = true;
            // 
            // EditFileButton
            // 
            this.EditFileButton.Location = new System.Drawing.Point(12, 501);
            this.EditFileButton.Name = "EditFileButton";
            this.EditFileButton.Size = new System.Drawing.Size(248, 34);
            this.EditFileButton.TabIndex = 3;
            this.EditFileButton.Text = "Изменить файл";
            this.EditFileButton.UseVisualStyleBackColor = true;
            // 
            // DeleteFIleButton
            // 
            this.DeleteFIleButton.Location = new System.Drawing.Point(12, 546);
            this.DeleteFIleButton.Name = "DeleteFIleButton";
            this.DeleteFIleButton.Size = new System.Drawing.Size(248, 34);
            this.DeleteFIleButton.TabIndex = 4;
            this.DeleteFIleButton.Text = "Удалить файл";
            this.DeleteFIleButton.UseVisualStyleBackColor = true;
            // 
            // FileEditBox
            // 
            this.FileEditBox.Enabled = false;
            this.FileEditBox.Location = new System.Drawing.Point(3, 59);
            this.FileEditBox.Name = "FileEditBox";
            this.FileEditBox.Size = new System.Drawing.Size(317, 424);
            this.FileEditBox.TabIndex = 5;
            this.FileEditBox.Text = "";
            this.FileEditBox.WordWrap = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(224, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Редактирование файла";
            // 
            // FileInfoBox
            // 
            this.FileInfoBox.Enabled = false;
            this.FileInfoBox.Location = new System.Drawing.Point(6, 63);
            this.FileInfoBox.Multiline = true;
            this.FileInfoBox.Name = "FileInfoBox";
            this.FileInfoBox.ReadOnly = true;
            this.FileInfoBox.Size = new System.Drawing.Size(340, 271);
            this.FileInfoBox.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(76, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(210, 23);
            this.label3.TabIndex = 8;
            this.label3.Text = "Информация о файле";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel,
            this.toolStripStatusLabel1,
            this.ErrorLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 592);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1001, 26);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(59, 20);
            this.StatusLabel.Text = "Статус: ";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(897, 20);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "⠀";
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(30, 20);
            this.ErrorLabel.Text = "✅";
            // 
            // SaveFileButton
            // 
            this.SaveFileButton.Location = new System.Drawing.Point(3, 501);
            this.SaveFileButton.Name = "SaveFileButton";
            this.SaveFileButton.Size = new System.Drawing.Size(145, 34);
            this.SaveFileButton.TabIndex = 10;
            this.SaveFileButton.Text = "Сохранить";
            this.SaveFileButton.UseVisualStyleBackColor = true;
            // 
            // CancelFileButton
            // 
            this.CancelFileButton.Location = new System.Drawing.Point(194, 501);
            this.CancelFileButton.Name = "CancelFileButton";
            this.CancelFileButton.Size = new System.Drawing.Size(126, 34);
            this.CancelFileButton.TabIndex = 11;
            this.CancelFileButton.Text = "Отмена";
            this.CancelFileButton.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.RenameFileButton);
            this.panel1.Controls.Add(this.ParentFolderButton);
            this.panel1.Controls.Add(this.FileTree);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.CreateFileButton);
            this.panel1.Controls.Add(this.EditFileButton);
            this.panel1.Controls.Add(this.DeleteFIleButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(263, 592);
            this.panel1.TabIndex = 12;
            // 
            // ParentFolderButton
            // 
            this.ParentFolderButton.AutoSize = true;
            this.ParentFolderButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ParentFolderButton.Location = new System.Drawing.Point(13, 341);
            this.ParentFolderButton.Name = "ParentFolderButton";
            this.ParentFolderButton.Size = new System.Drawing.Size(30, 33);
            this.ParentFolderButton.TabIndex = 5;
            this.ParentFolderButton.Text = "↑";
            this.ParentFolderButton.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.FileInfoBox);
            this.panel2.Location = new System.Drawing.Point(288, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(349, 337);
            this.panel2.TabIndex = 13;
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.Controls.Add(this.CancelFileButton);
            this.panel3.Controls.Add(this.FileEditBox);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.SaveFileButton);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(678, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(323, 592);
            this.panel3.TabIndex = 14;
            // 
            // RenameFileButton
            // 
            this.RenameFileButton.Location = new System.Drawing.Point(12, 449);
            this.RenameFileButton.Name = "RenameFileButton";
            this.RenameFileButton.Size = new System.Drawing.Size(248, 34);
            this.RenameFileButton.TabIndex = 6;
            this.RenameFileButton.Text = "Переименовать файл";
            this.RenameFileButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1001, 618);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lab2";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView FileTree;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CreateFileButton;
        private System.Windows.Forms.Button EditFileButton;
        private System.Windows.Forms.Button DeleteFIleButton;
        private System.Windows.Forms.RichTextBox FileEditBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox FileInfoBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.Button SaveFileButton;
        private System.Windows.Forms.Button CancelFileButton;
        private System.Windows.Forms.ToolStripStatusLabel ErrorLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button ParentFolderButton;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button RenameFileButton;
    }
}

