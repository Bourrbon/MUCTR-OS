namespace Lab5
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
            this.label1 = new System.Windows.Forms.Label();
            this.StatusBox = new System.Windows.Forms.TextBox();
            this.PriorityBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.StartThreadButton = new System.Windows.Forms.Button();
            this.PauseThreadButton = new System.Windows.Forms.Button();
            this.ResumeThreadButton = new System.Windows.Forms.Button();
            this.StopThreadButton = new System.Windows.Forms.Button();
            this.ChildThreadView = new System.Windows.Forms.TreeView();
            this.label4 = new System.Windows.Forms.Label();
            this.OutputBox = new System.Windows.Forms.TextBox();
            this.ThreadPrioritySlider = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.ThreadPrioritySlider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(318, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Управление дочерними потоками:";
            // 
            // StatusBox
            // 
            this.StatusBox.Location = new System.Drawing.Point(49, 143);
            this.StatusBox.Name = "StatusBox";
            this.StatusBox.ReadOnly = true;
            this.StatusBox.Size = new System.Drawing.Size(149, 30);
            this.StatusBox.TabIndex = 1;
            // 
            // PriorityBox
            // 
            this.PriorityBox.Location = new System.Drawing.Point(276, 143);
            this.PriorityBox.Name = "PriorityBox";
            this.PriorityBox.ReadOnly = true;
            this.PriorityBox.Size = new System.Drawing.Size(100, 30);
            this.PriorityBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Статус:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(272, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Приоритет:";
            // 
            // StartThreadButton
            // 
            this.StartThreadButton.Location = new System.Drawing.Point(49, 226);
            this.StartThreadButton.Name = "StartThreadButton";
            this.StartThreadButton.Size = new System.Drawing.Size(96, 45);
            this.StartThreadButton.TabIndex = 5;
            this.StartThreadButton.Text = "Запуск";
            this.StartThreadButton.UseVisualStyleBackColor = true;
            this.StartThreadButton.Click += new System.EventHandler(this.StartThreadButton_Click);
            // 
            // PauseThreadButton
            // 
            this.PauseThreadButton.Location = new System.Drawing.Point(49, 304);
            this.PauseThreadButton.Name = "PauseThreadButton";
            this.PauseThreadButton.Size = new System.Drawing.Size(96, 45);
            this.PauseThreadButton.TabIndex = 6;
            this.PauseThreadButton.Text = "Пауза";
            this.PauseThreadButton.UseVisualStyleBackColor = true;
            // 
            // ResumeThreadButton
            // 
            this.ResumeThreadButton.Location = new System.Drawing.Point(236, 304);
            this.ResumeThreadButton.Name = "ResumeThreadButton";
            this.ResumeThreadButton.Size = new System.Drawing.Size(140, 45);
            this.ResumeThreadButton.TabIndex = 7;
            this.ResumeThreadButton.Text = "Возобновить";
            this.ResumeThreadButton.UseVisualStyleBackColor = true;
            // 
            // StopThreadButton
            // 
            this.StopThreadButton.Location = new System.Drawing.Point(256, 227);
            this.StopThreadButton.Name = "StopThreadButton";
            this.StopThreadButton.Size = new System.Drawing.Size(120, 44);
            this.StopThreadButton.TabIndex = 9;
            this.StopThreadButton.Text = "Остановка";
            this.StopThreadButton.UseVisualStyleBackColor = true;
            this.StopThreadButton.Click += new System.EventHandler(this.StopThreadButton_Click);
            // 
            // ChildThreadView
            // 
            this.ChildThreadView.Location = new System.Drawing.Point(489, 99);
            this.ChildThreadView.Name = "ChildThreadView";
            this.ChildThreadView.Size = new System.Drawing.Size(478, 329);
            this.ChildThreadView.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(485, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(170, 23);
            this.label4.TabIndex = 11;
            this.label4.Text = "Дочерние потоки:";
            // 
            // OutputBox
            // 
            this.OutputBox.Location = new System.Drawing.Point(49, 452);
            this.OutputBox.Multiline = true;
            this.OutputBox.Name = "OutputBox";
            this.OutputBox.ReadOnly = true;
            this.OutputBox.Size = new System.Drawing.Size(918, 296);
            this.OutputBox.TabIndex = 14;
            // 
            // ThreadPrioritySlider
            // 
            this.ThreadPrioritySlider.LargeChange = 1;
            this.ThreadPrioritySlider.Location = new System.Drawing.Point(49, 390);
            this.ThreadPrioritySlider.Maximum = 4;
            this.ThreadPrioritySlider.Name = "ThreadPrioritySlider";
            this.ThreadPrioritySlider.Size = new System.Drawing.Size(333, 56);
            this.ThreadPrioritySlider.TabIndex = 15;
            this.ThreadPrioritySlider.Value = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 760);
            this.Controls.Add(this.ThreadPrioritySlider);
            this.Controls.Add(this.OutputBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ChildThreadView);
            this.Controls.Add(this.StopThreadButton);
            this.Controls.Add(this.ResumeThreadButton);
            this.Controls.Add(this.PauseThreadButton);
            this.Controls.Add(this.StartThreadButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PriorityBox);
            this.Controls.Add(this.StatusBox);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Lab4";
            ((System.ComponentModel.ISupportInitialize)(this.ThreadPrioritySlider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox StatusBox;
        private System.Windows.Forms.TextBox PriorityBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button StartThreadButton;
        private System.Windows.Forms.Button PauseThreadButton;
        private System.Windows.Forms.Button ResumeThreadButton;
        private System.Windows.Forms.Button StopThreadButton;
        private System.Windows.Forms.TreeView ChildThreadView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox OutputBox;
        private System.Windows.Forms.TrackBar ThreadPrioritySlider;
    }
}

