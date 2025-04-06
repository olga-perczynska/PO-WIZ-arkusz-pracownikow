namespace PO_WIZ_arkusz_pracownikow
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
            button1 = new Button();
            dataGridView1 = new DataGridView();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(1708, 550);
            button1.Name = "button1";
            button1.Size = new Size(188, 58);
            button1.TabIndex = 1;
            button1.Text = "Dodaj";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(-9, 30);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 102;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1621, 586);
            dataGridView1.TabIndex = 2;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.RowEnter += dataGridView1_RowEnter;
            dataGridView1.RowHeaderMouseClick += dataGridView1_RowHeaderMouseClick;
            // 
            // button2
            // 
            button2.Location = new Point(45, 709);
            button2.Name = "button2";
            button2.Size = new Size(293, 58);
            button2.TabIndex = 3;
            button2.Text = "Zapis do .csv";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(459, 709);
            button3.Name = "button3";
            button3.Size = new Size(293, 58);
            button3.TabIndex = 4;
            button3.Text = "Odczyt z .csv";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(1708, 438);
            button4.Name = "button4";
            button4.Size = new Size(188, 58);
            button4.TabIndex = 5;
            button4.Text = "Usuń";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(1319, 709);
            button5.Name = "button5";
            button5.Size = new Size(293, 58);
            button5.TabIndex = 7;
            button5.Text = "Odczyt z .json";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(888, 709);
            button6.Name = "button6";
            button6.Size = new Size(293, 58);
            button6.TabIndex = 6;
            button6.Text = "Zapis do .json";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1955, 871);
            Controls.Add(button5);
            Controls.Add(button6);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button button1;
        private DataGridView dataGridView1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
    }
}
