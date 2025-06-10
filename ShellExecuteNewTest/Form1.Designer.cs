namespace ShellExecuteNewTest
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
            FilePathBox = new TextBox();
            LPFileButton = new Button();
            openFileDialog1 = new OpenFileDialog();
            label2 = new Label();
            label3 = new Label();
            HandleBox = new TextBox();
            label4 = new Label();
            VerbBox = new ComboBox();
            label5 = new Label();
            label7 = new Label();
            ParametersBox = new TextBox();
            LaunchButton = new Button();
            statusStrip1 = new StatusStrip();
            ErrorLabel = new ToolStripStatusLabel();
            ParametersButton = new Button();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // FilePathBox
            // 
            FilePathBox.Location = new Point(136, 284);
            FilePathBox.Name = "FilePathBox";
            FilePathBox.Size = new Size(437, 30);
            FilePathBox.TabIndex = 1;
            // 
            // LPFileButton
            // 
            LPFileButton.Location = new Point(639, 280);
            LPFileButton.Name = "LPFileButton";
            LPFileButton.Size = new Size(157, 34);
            LPFileButton.TabIndex = 2;
            LPFileButton.Text = "Проводник";
            LPFileButton.UseVisualStyleBackColor = true;
            LPFileButton.Click += OpenExplorerButton_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 100);
            label2.Name = "label2";
            label2.Size = new Size(554, 23);
            label2.TabIndex = 3;
            label2.Text = "Обязательные параметры структуры SHELLEXECUTEINFO";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 171);
            label3.Name = "label3";
            label3.Size = new Size(60, 23);
            label3.TabIndex = 4;
            label3.Text = "hWnd";
            // 
            // HandleBox
            // 
            HandleBox.Location = new Point(136, 164);
            HandleBox.Name = "HandleBox";
            HandleBox.ReadOnly = true;
            HandleBox.Size = new Size(302, 30);
            HandleBox.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 224);
            label4.Name = "label4";
            label4.Size = new Size(66, 23);
            label4.TabIndex = 6;
            label4.Text = "lpVerb";
            // 
            // VerbBox
            // 
            VerbBox.DropDownStyle = ComboBoxStyle.DropDownList;
            VerbBox.FormattingEnabled = true;
            VerbBox.Items.AddRange(new object[] { "edit", "explore", "find", "open", "openas", "print", "properties", "runas" });
            VerbBox.Location = new Point(137, 221);
            VerbBox.Name = "VerbBox";
            VerbBox.Size = new Size(302, 31);
            VerbBox.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 287);
            label5.Name = "label5";
            label5.Size = new Size(56, 23);
            label5.TabIndex = 8;
            label5.Text = "lpFile";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 333);
            label7.Name = "label7";
            label7.Size = new Size(111, 23);
            label7.TabIndex = 12;
            label7.Text = "parameters";
            // 
            // ParametersBox
            // 
            ParametersBox.Location = new Point(137, 333);
            ParametersBox.Name = "ParametersBox";
            ParametersBox.Size = new Size(440, 30);
            ParametersBox.TabIndex = 13;
            // 
            // LaunchButton
            // 
            LaunchButton.Location = new Point(26, 21);
            LaunchButton.Name = "LaunchButton";
            LaunchButton.Size = new Size(121, 43);
            LaunchButton.TabIndex = 14;
            LaunchButton.Text = "Запуск";
            LaunchButton.UseVisualStyleBackColor = true;
            LaunchButton.Click += LaunchButton_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { ErrorLabel });
            statusStrip1.Location = new Point(0, 609);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(870, 26);
            statusStrip1.TabIndex = 16;
            statusStrip1.Text = "statusStrip1";
            // 
            // ErrorLabel
            // 
            ErrorLabel.Name = "ErrorLabel";
            ErrorLabel.Size = new Size(18, 20);
            ErrorLabel.Text = "...";
            // 
            // ParametersButton
            // 
            ParametersButton.Location = new Point(640, 329);
            ParametersButton.Name = "ParametersButton";
            ParametersButton.Size = new Size(157, 34);
            ParametersButton.TabIndex = 19;
            ParametersButton.Text = "Проводник";
            ParametersButton.UseVisualStyleBackColor = true;
            ParametersButton.Click += ParametersButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(870, 635);
            Controls.Add(ParametersButton);
            Controls.Add(statusStrip1);
            Controls.Add(LaunchButton);
            Controls.Add(ParametersBox);
            Controls.Add(label7);
            Controls.Add(label5);
            Controls.Add(VerbBox);
            Controls.Add(label4);
            Controls.Add(HandleBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(LPFileButton);
            Controls.Add(FilePathBox);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(4);
            Name = "Form1";
            Text = "Lab_ShellExecute";
            Load += Form1_Load;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.TextBox FilePathBox;
        private System.Windows.Forms.Button LPFileButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox HandleBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox VerbBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox ParametersBox;
        private System.Windows.Forms.Button LaunchButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel ErrorLabel;
        private Button ParametersButton;
    }
}

