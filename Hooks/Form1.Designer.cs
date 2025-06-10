namespace Hooks
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
            DLLPathBox = new RichTextBox();
            label1 = new Label();
            ExplorerButton = new Button();
            OutputBox = new RichTextBox();
            label2 = new Label();
            LinkButton = new Button();
            HookButton = new Button();
            UnhookButton = new Button();
            openFileDialog1 = new OpenFileDialog();
            statusStrip1 = new StatusStrip();
            ErrorLabel = new ToolStripStatusLabel();
            ClearTextButton = new Button();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // DLLPathBox
            // 
            DLLPathBox.Location = new Point(38, 89);
            DLLPathBox.Margin = new Padding(4, 3, 4, 3);
            DLLPathBox.Multiline = false;
            DLLPathBox.Name = "DLLPathBox";
            DLLPathBox.Size = new Size(671, 38);
            DLLPathBox.TabIndex = 0;
            DLLPathBox.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(38, 46);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(262, 23);
            label1.TabIndex = 1;
            label1.Text = "DLL с системной ловушкой:";
            // 
            // ExplorerButton
            // 
            ExplorerButton.Location = new Point(761, 89);
            ExplorerButton.Margin = new Padding(4, 3, 4, 3);
            ExplorerButton.Name = "ExplorerButton";
            ExplorerButton.Size = new Size(208, 33);
            ExplorerButton.TabIndex = 2;
            ExplorerButton.Text = "Проводник";
            ExplorerButton.UseVisualStyleBackColor = true;
            ExplorerButton.Click += ExplorerButton_Click;
            // 
            // OutputBox
            // 
            OutputBox.Location = new Point(38, 342);
            OutputBox.Name = "OutputBox";
            OutputBox.ReadOnly = true;
            OutputBox.Size = new Size(671, 135);
            OutputBox.TabIndex = 3;
            OutputBox.Text = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(38, 300);
            label2.Name = "label2";
            label2.Size = new Size(168, 23);
            label2.TabIndex = 4;
            label2.Text = "Системный ввод:";
            // 
            // LinkButton
            // 
            LinkButton.Location = new Point(38, 196);
            LinkButton.Name = "LinkButton";
            LinkButton.Size = new Size(208, 29);
            LinkButton.TabIndex = 5;
            LinkButton.Text = "Подключить DLL";
            LinkButton.UseVisualStyleBackColor = true;
            LinkButton.Click += LinkButton_Click;
            // 
            // HookButton
            // 
            HookButton.Location = new Point(311, 196);
            HookButton.Name = "HookButton";
            HookButton.Size = new Size(168, 29);
            HookButton.TabIndex = 6;
            HookButton.Text = "Привязать хук";
            HookButton.UseVisualStyleBackColor = true;
            HookButton.Click += HookButton_Click;
            // 
            // UnhookButton
            // 
            UnhookButton.Location = new Point(524, 196);
            UnhookButton.Name = "UnhookButton";
            UnhookButton.Size = new Size(185, 29);
            UnhookButton.TabIndex = 7;
            UnhookButton.Text = "Отвязать хук";
            UnhookButton.UseVisualStyleBackColor = true;
            UnhookButton.Click += UnhookButton_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { ErrorLabel });
            statusStrip1.Location = new Point(0, 499);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1100, 26);
            statusStrip1.TabIndex = 8;
            statusStrip1.Text = "statusStrip1";
            // 
            // ErrorLabel
            // 
            ErrorLabel.Name = "ErrorLabel";
            ErrorLabel.Size = new Size(18, 20);
            ErrorLabel.Text = "...";
            // 
            // ClearTextButton
            // 
            ClearTextButton.Location = new Point(743, 342);
            ClearTextButton.Name = "ClearTextButton";
            ClearTextButton.Size = new Size(114, 29);
            ClearTextButton.TabIndex = 9;
            ClearTextButton.Text = "Очистить";
            ClearTextButton.UseVisualStyleBackColor = true;
            ClearTextButton.Click += ClearTextButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 525);
            Controls.Add(ClearTextButton);
            Controls.Add(statusStrip1);
            Controls.Add(UnhookButton);
            Controls.Add(HookButton);
            Controls.Add(LinkButton);
            Controls.Add(label2);
            Controls.Add(OutputBox);
            Controls.Add(ExplorerButton);
            Controls.Add(label1);
            Controls.Add(DLLPathBox);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "Form1";
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox DLLPathBox;
        private Label label1;
        private Button ExplorerButton;
        private RichTextBox OutputBox;
        private Label label2;
        private Button LinkButton;
        private Button HookButton;
        private Button UnhookButton;
        private OpenFileDialog openFileDialog1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel ErrorLabel;
        private Button ClearTextButton;
    }
}
