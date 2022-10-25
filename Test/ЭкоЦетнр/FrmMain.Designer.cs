namespace project
{
    partial class FrmMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button_open = new System.Windows.Forms.Button();
            this.button_save = new System.Windows.Forms.Button();
            this.button_report = new System.Windows.Forms.Button();
            this.button_delete_node = new System.Windows.Forms.Button();
            this.button_add_node = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Colomn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_open
            // 
            this.button_open.BackColor = System.Drawing.Color.Orange;
            this.button_open.FlatAppearance.BorderSize = 0;
            this.button_open.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_open.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_open.ForeColor = System.Drawing.Color.White;
            this.button_open.Location = new System.Drawing.Point(12, 12);
            this.button_open.Name = "button_open";
            this.button_open.Size = new System.Drawing.Size(161, 30);
            this.button_open.TabIndex = 0;
            this.button_open.Text = "Открыть XML";
            this.button_open.UseVisualStyleBackColor = false;
            this.button_open.Click += new System.EventHandler(this.button_open_Click);
            // 
            // button_save
            // 
            this.button_save.BackColor = System.Drawing.Color.IndianRed;
            this.button_save.FlatAppearance.BorderSize = 0;
            this.button_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_save.ForeColor = System.Drawing.Color.White;
            this.button_save.Location = new System.Drawing.Point(189, 12);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(161, 30);
            this.button_save.TabIndex = 1;
            this.button_save.Text = "Сохранить XML";
            this.button_save.UseVisualStyleBackColor = false;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // button_report
            // 
            this.button_report.BackColor = System.Drawing.Color.SeaGreen;
            this.button_report.FlatAppearance.BorderSize = 0;
            this.button_report.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_report.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_report.ForeColor = System.Drawing.Color.White;
            this.button_report.Location = new System.Drawing.Point(556, 12);
            this.button_report.Name = "button_report";
            this.button_report.Size = new System.Drawing.Size(161, 30);
            this.button_report.TabIndex = 2;
            this.button_report.Text = "Отчет в HTML";
            this.button_report.UseVisualStyleBackColor = false;
            this.button_report.Click += new System.EventHandler(this.button_report_Click);
            // 
            // button_delete_node
            // 
            this.button_delete_node.BackColor = System.Drawing.Color.Black;
            this.button_delete_node.FlatAppearance.BorderSize = 0;
            this.button_delete_node.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_delete_node.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_delete_node.ForeColor = System.Drawing.Color.White;
            this.button_delete_node.Location = new System.Drawing.Point(12, 238);
            this.button_delete_node.Name = "button_delete_node";
            this.button_delete_node.Size = new System.Drawing.Size(161, 30);
            this.button_delete_node.TabIndex = 3;
            this.button_delete_node.Text = "Удалить запись";
            this.button_delete_node.UseVisualStyleBackColor = false;
            this.button_delete_node.Click += new System.EventHandler(this.button_delete_node_Click);
            // 
            // button_add_node
            // 
            this.button_add_node.BackColor = System.Drawing.Color.LightSeaGreen;
            this.button_add_node.FlatAppearance.BorderSize = 0;
            this.button_add_node.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_add_node.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_add_node.ForeColor = System.Drawing.Color.White;
            this.button_add_node.Location = new System.Drawing.Point(189, 238);
            this.button_add_node.Name = "button_add_node";
            this.button_add_node.Size = new System.Drawing.Size(161, 30);
            this.button_add_node.TabIndex = 4;
            this.button_add_node.Text = "Добавить запись";
            this.button_add_node.UseVisualStyleBackColor = false;
            this.button_add_node.Click += new System.EventHandler(this.button_add_node_Click);
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Silver;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.column2,
            this.column3,
            this.Colomn5,
            this.column4});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.PowderBlue;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView1.Location = new System.Drawing.Point(12, 65);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView1.Size = new System.Drawing.Size(705, 150);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.HeaderText = "Книга";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 62;
            // 
            // column2
            // 
            this.column2.HeaderText = "Автор";
            this.column2.Name = "column2";
            this.column2.ReadOnly = true;
            this.column2.Width = 150;
            // 
            // column3
            // 
            this.column3.HeaderText = "Категория";
            this.column3.Name = "column3";
            this.column3.ReadOnly = true;
            this.column3.Width = 150;
            // 
            // Colomn5
            // 
            this.Colomn5.HeaderText = "Год";
            this.Colomn5.Name = "Colomn5";
            this.Colomn5.ReadOnly = true;
            this.Colomn5.Width = 150;
            // 
            // column4
            // 
            this.column4.HeaderText = "Цена";
            this.column4.Name = "column4";
            this.column4.ReadOnly = true;
            this.column4.Width = 150;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 293);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button_add_node);
            this.Controls.Add(this.button_delete_node);
            this.Controls.Add(this.button_report);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.button_open);
            this.Name = "FrmMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_open;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Button button_report;
        private System.Windows.Forms.Button button_delete_node;
        private System.Windows.Forms.Button button_add_node;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Colomn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn column4;
    }
}

