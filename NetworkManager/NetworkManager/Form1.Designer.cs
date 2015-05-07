namespace NetworkManager
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
            this.Start = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SendToAll = new System.Windows.Forms.Button();
            this.Logs = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.LoadConfigurationButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.Stop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Start
            // 
<<<<<<< HEAD
            this.Start.Location = new System.Drawing.Point(129, 268);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(88, 23);
=======
            this.Start.Location = new System.Drawing.Point(172, 330);
            this.Start.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(117, 28);
>>>>>>> fc415feb0377697a027edd30326f6d52ce5cc06e
            this.Start.TabIndex = 0;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
<<<<<<< HEAD
            this.textBox1.Location = new System.Drawing.Point(12, 297);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(205, 20);
=======
            this.textBox1.Location = new System.Drawing.Point(16, 366);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(272, 22);
>>>>>>> fc415feb0377697a027edd30326f6d52ce5cc06e
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // SendToAll
            // 
<<<<<<< HEAD
            this.SendToAll.Location = new System.Drawing.Point(223, 297);
            this.SendToAll.Name = "SendToAll";
            this.SendToAll.Size = new System.Drawing.Size(75, 20);
=======
            this.SendToAll.Location = new System.Drawing.Point(297, 366);
            this.SendToAll.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SendToAll.Name = "SendToAll";
            this.SendToAll.Size = new System.Drawing.Size(100, 25);
>>>>>>> fc415feb0377697a027edd30326f6d52ce5cc06e
            this.SendToAll.TabIndex = 2;
            this.SendToAll.Text = "Send to all";
            this.SendToAll.UseVisualStyleBackColor = true;
            this.SendToAll.Click += new System.EventHandler(this.button2_Click);
            // 
            // Logs
            // 
            this.Logs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.Logs.FullRowSelect = true;
<<<<<<< HEAD
            this.Logs.Location = new System.Drawing.Point(12, 12);
            this.Logs.Name = "Logs";
            this.Logs.Size = new System.Drawing.Size(506, 250);
=======
            this.Logs.Location = new System.Drawing.Point(16, 15);
            this.Logs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Logs.Name = "Logs";
            this.Logs.Size = new System.Drawing.Size(673, 307);
>>>>>>> fc415feb0377697a027edd30326f6d52ce5cc06e
            this.Logs.TabIndex = 8;
            this.Logs.Tag = "Logs";
            this.Logs.UseCompatibleStateImageBehavior = false;
            this.Logs.View = System.Windows.Forms.View.Details;
            this.Logs.SelectedIndexChanged += new System.EventHandler(this.Logs_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Logs";
            this.columnHeader1.Width = 664;
            // 
            // contextMenuStrip1
            // 
<<<<<<< HEAD
=======
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
>>>>>>> fc415feb0377697a027edd30326f6d52ce5cc06e
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // LoadConfigurationButton
            // 
<<<<<<< HEAD
            this.LoadConfigurationButton.Location = new System.Drawing.Point(12, 268);
            this.LoadConfigurationButton.Name = "LoadConfigurationButton";
            this.LoadConfigurationButton.Size = new System.Drawing.Size(111, 23);
=======
            this.LoadConfigurationButton.Location = new System.Drawing.Point(16, 330);
            this.LoadConfigurationButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LoadConfigurationButton.Name = "LoadConfigurationButton";
            this.LoadConfigurationButton.Size = new System.Drawing.Size(148, 28);
>>>>>>> fc415feb0377697a027edd30326f6d52ce5cc06e
            this.LoadConfigurationButton.TabIndex = 9;
            this.LoadConfigurationButton.Text = "Load Configuration";
            this.LoadConfigurationButton.UseVisualStyleBackColor = true;
            this.LoadConfigurationButton.Click += new System.EventHandler(this.LoadConfigurationButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk_1);
            // 
            // Stop
            // 
<<<<<<< HEAD
            this.Stop.Location = new System.Drawing.Point(223, 268);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(75, 23);
=======
            this.Stop.Location = new System.Drawing.Point(297, 330);
            this.Stop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(100, 28);
>>>>>>> fc415feb0377697a027edd30326f6d52ce5cc06e
            this.Stop.TabIndex = 10;
            this.Stop.Text = "Stop";
            this.Stop.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
<<<<<<< HEAD
            this.ClientSize = new System.Drawing.Size(530, 323);
=======
            this.ClientSize = new System.Drawing.Size(707, 398);
>>>>>>> fc415feb0377697a027edd30326f6d52ce5cc06e
            this.Controls.Add(this.Stop);
            this.Controls.Add(this.LoadConfigurationButton);
            this.Controls.Add(this.Logs);
            this.Controls.Add(this.SendToAll);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Start);
<<<<<<< HEAD
=======
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
>>>>>>> fc415feb0377697a027edd30326f6d52ce5cc06e
            this.Name = "Form1";
            this.Text = "NetworkManager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button SendToAll;
        private System.Windows.Forms.ListView Logs;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button LoadConfigurationButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button Stop;

    }
}

