namespace Lab_ShellExecute
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
            this.FilePathBox = new System.Windows.Forms.TextBox();
            this.OpenExplorerButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.HandleBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.VerbBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.DirectoryBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ParametersBox = new System.Windows.Forms.TextBox();
            this.LaunchButton = new System.Windows.Forms.Button();
            this.NShowBox = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ErrorLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.ClassBox = new System.Windows.Forms.TextBox();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FilePathBox
            // 
            this.FilePathBox.Location = new System.Drawing.Point(136, 210);
            this.FilePathBox.Name = "FilePathBox";
            this.FilePathBox.Size = new System.Drawing.Size(437, 30);
            this.FilePathBox.TabIndex = 1;
            // 
            // OpenExplorerButton
            // 
            this.OpenExplorerButton.Location = new System.Drawing.Point(639, 206);
            this.OpenExplorerButton.Name = "OpenExplorerButton";
            this.OpenExplorerButton.Size = new System.Drawing.Size(157, 34);
            this.OpenExplorerButton.TabIndex = 2;
            this.OpenExplorerButton.Text = "Проводник";
            this.OpenExplorerButton.UseVisualStyleBackColor = true;
            this.OpenExplorerButton.Click += new System.EventHandler(this.OpenExplorerButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(430, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Параметры структуры SHELLEXECUTEINFOA";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "hWnd";
            // 
            // HandleBox
            // 
            this.HandleBox.Location = new System.Drawing.Point(150, 154);
            this.HandleBox.Name = "HandleBox";
            this.HandleBox.ReadOnly = true;
            this.HandleBox.Size = new System.Drawing.Size(302, 30);
            this.HandleBox.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 272);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "lpVerb";
            // 
            // VerbBox
            // 
            this.VerbBox.FormattingEnabled = true;
            this.VerbBox.Items.AddRange(new object[] {
            "edit",
            "explore",
            "find",
            "open",
            "openas",
            "print",
            "properties",
            "runas"});
            this.VerbBox.Location = new System.Drawing.Point(136, 269);
            this.VerbBox.Name = "VerbBox";
            this.VerbBox.Size = new System.Drawing.Size(302, 31);
            this.VerbBox.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 213);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 23);
            this.label5.TabIndex = 8;
            this.label5.Text = "lpFile";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 382);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 23);
            this.label6.TabIndex = 10;
            this.label6.Text = "lpDirectory";
            // 
            // DirectoryBox
            // 
            this.DirectoryBox.Location = new System.Drawing.Point(136, 379);
            this.DirectoryBox.Name = "DirectoryBox";
            this.DirectoryBox.ReadOnly = true;
            this.DirectoryBox.Size = new System.Drawing.Size(437, 30);
            this.DirectoryBox.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 440);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 23);
            this.label7.TabIndex = 12;
            this.label7.Text = "parameters";
            // 
            // ParametersBox
            // 
            this.ParametersBox.Location = new System.Drawing.Point(136, 440);
            this.ParametersBox.Name = "ParametersBox";
            this.ParametersBox.Size = new System.Drawing.Size(440, 30);
            this.ParametersBox.TabIndex = 13;
            // 
            // LaunchButton
            // 
            this.LaunchButton.Location = new System.Drawing.Point(26, 21);
            this.LaunchButton.Name = "LaunchButton";
            this.LaunchButton.Size = new System.Drawing.Size(121, 43);
            this.LaunchButton.TabIndex = 14;
            this.LaunchButton.Text = "Запуск";
            this.LaunchButton.UseVisualStyleBackColor = true;
            this.LaunchButton.Click += new System.EventHandler(this.LaunchButton_Click);
            // 
            // NShowBox
            // 
            this.NShowBox.AutoSize = true;
            this.NShowBox.Location = new System.Drawing.Point(12, 505);
            this.NShowBox.Name = "NShowBox";
            this.NShowBox.Size = new System.Drawing.Size(91, 27);
            this.NShowBox.TabIndex = 15;
            this.NShowBox.Text = "nShow";
            this.NShowBox.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ErrorLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 609);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(870, 26);
            this.statusStrip1.TabIndex = 16;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(18, 20);
            this.ErrorLabel.Text = "...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 319);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 23);
            this.label1.TabIndex = 17;
            this.label1.Text = "lpClass";
            // 
            // ClassBox
            // 
            this.ClassBox.Location = new System.Drawing.Point(136, 319);
            this.ClassBox.Name = "ClassBox";
            this.ClassBox.Size = new System.Drawing.Size(184, 30);
            this.ClassBox.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 635);
            this.Controls.Add(this.ClassBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.NShowBox);
            this.Controls.Add(this.LaunchButton);
            this.Controls.Add(this.ParametersBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.DirectoryBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.VerbBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.HandleBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.OpenExplorerButton);
            this.Controls.Add(this.FilePathBox);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Lab_ShellExecute";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox FilePathBox;
        private System.Windows.Forms.Button OpenExplorerButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox HandleBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox VerbBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox DirectoryBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox ParametersBox;
        private System.Windows.Forms.Button LaunchButton;
        private System.Windows.Forms.CheckBox NShowBox;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel ErrorLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ClassBox;
    }
}

