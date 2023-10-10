using System.Xml.Linq;

namespace DBMS
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            tabControl = new TabControl();
            butOpen = new Button();
            butCreateNewDB = new Button();
            butAddColumn = new Button();
            butAddRow = new Button();
            tbCreateNewDB = new TextBox();
            butAddTable = new Button();
            tbAddTable = new TextBox();
            dataGridView = new DataGridView();
            comboBox = new ComboBox();
            tbAddColumn = new TextBox();
            ofdOpenImage = new OpenFileDialog();
            butDeleteColumn = new Button();
            butDeleteRow = new Button();
            butDeleteTable = new Button();
            sfdSaveDB = new SaveFileDialog();
            butSaveDB = new Button();
            ofdOpenDB = new OpenFileDialog();
            butRepeatedRows = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Location = new Point(16, 240);
            tabControl.Margin = new Padding(4, 5, 4, 5);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(873, 37);
            tabControl.TabIndex = 0;
            tabControl.SelectedIndexChanged += tabControl_SelectedIndexChanged;
            // 
            // butOpen
            // 
            butOpen.Location = new Point(17, 18);
            butOpen.Margin = new Padding(4, 5, 4, 5);
            butOpen.Name = "butOpen";
            butOpen.Size = new Size(161, 35);
            butOpen.TabIndex = 1;
            butOpen.Text = "Open";
            butOpen.UseVisualStyleBackColor = true;
            butOpen.Click += butOpen_Click;
            // 
            // butCreateNewDB
            // 
            butCreateNewDB.Location = new Point(195, 18);
            butCreateNewDB.Margin = new Padding(4, 5, 4, 5);
            butCreateNewDB.Name = "butCreateNewDB";
            butCreateNewDB.Size = new Size(161, 35);
            butCreateNewDB.TabIndex = 2;
            butCreateNewDB.Text = "Create New DB";
            butCreateNewDB.UseVisualStyleBackColor = true;
            butCreateNewDB.Click += butCreateNewDB_Click;
            // 
            // butAddColumn
            // 
            butAddColumn.Location = new Point(552, 18);
            butAddColumn.Margin = new Padding(4, 5, 4, 5);
            butAddColumn.Name = "butAddColumn";
            butAddColumn.Size = new Size(161, 35);
            butAddColumn.TabIndex = 3;
            butAddColumn.Text = "Add Column";
            butAddColumn.UseVisualStyleBackColor = true;
            butAddColumn.Click += butAddColumn_Click;
            // 
            // butAddRow
            // 
            butAddRow.Location = new Point(728, 18);
            butAddRow.Margin = new Padding(4, 5, 4, 5);
            butAddRow.Name = "butAddRow";
            butAddRow.Size = new Size(161, 35);
            butAddRow.TabIndex = 4;
            butAddRow.Text = "Add Row";
            butAddRow.UseVisualStyleBackColor = true;
            butAddRow.Click += butAddRow_Click;
            // 
            // tbCreateNewDB
            // 
            tbCreateNewDB.Location = new Point(195, 63);
            tbCreateNewDB.Margin = new Padding(4, 5, 4, 5);
            tbCreateNewDB.Name = "tbCreateNewDB";
            tbCreateNewDB.Size = new Size(160, 27);
            tbCreateNewDB.TabIndex = 5;
            // 
            // butAddTable
            // 
            butAddTable.Location = new Point(373, 18);
            butAddTable.Margin = new Padding(4, 5, 4, 5);
            butAddTable.Name = "butAddTable";
            butAddTable.Size = new Size(161, 35);
            butAddTable.TabIndex = 6;
            butAddTable.Text = "Add Table";
            butAddTable.UseVisualStyleBackColor = true;
            butAddTable.Click += butAddTable_Click;
            // 
            // tbAddTable
            // 
            tbAddTable.Location = new Point(373, 63);
            tbAddTable.Margin = new Padding(4, 5, 4, 5);
            tbAddTable.Name = "tbAddTable";
            tbAddTable.Size = new Size(160, 27);
            tbAddTable.TabIndex = 7;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(17, 286);
            dataGridView.Margin = new Padding(4, 5, 4, 5);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.RowTemplate.Height = 40;
            dataGridView.Size = new Size(872, 313);
            dataGridView.TabIndex = 8;
            dataGridView.CellBeginEdit += dataGridView_CellBeginEdit;
            dataGridView.CellEndEdit += dataGridView_CellEndEdit;
            dataGridView.CellMouseDoubleClick += dataGridView_CellMouseDoubleClick;
            // 
            // comboBox
            // 
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox.FormattingEnabled = true;
            comboBox.Items.AddRange(new object[] { "INT", "REAL", "CHAR", "STRING", "PICTURE FILE", "REAL INTERVAL" });
            comboBox.Location = new Point(552, 103);
            comboBox.Margin = new Padding(4, 5, 4, 5);
            comboBox.Name = "comboBox";
            comboBox.Size = new Size(160, 28);
            comboBox.TabIndex = 10;
            // 
            // tbAddColumn
            // 
            tbAddColumn.Location = new Point(552, 63);
            tbAddColumn.Margin = new Padding(4, 5, 4, 5);
            tbAddColumn.Name = "tbAddColumn";
            tbAddColumn.Size = new Size(160, 27);
            tbAddColumn.TabIndex = 11;
            // 
            // butDeleteColumn
            // 
            butDeleteColumn.Location = new Point(552, 145);
            butDeleteColumn.Margin = new Padding(4, 5, 4, 5);
            butDeleteColumn.Name = "butDeleteColumn";
            butDeleteColumn.Size = new Size(161, 35);
            butDeleteColumn.TabIndex = 14;
            butDeleteColumn.Text = "Delete Column";
            butDeleteColumn.UseVisualStyleBackColor = true;
            butDeleteColumn.Click += butDeleteColumn_Click;
            // 
            // butDeleteRow
            // 
            butDeleteRow.Location = new Point(728, 63);
            butDeleteRow.Margin = new Padding(4, 5, 4, 5);
            butDeleteRow.Name = "butDeleteRow";
            butDeleteRow.Size = new Size(161, 35);
            butDeleteRow.TabIndex = 15;
            butDeleteRow.Text = "Delete Row";
            butDeleteRow.UseVisualStyleBackColor = true;
            butDeleteRow.Click += butDeleteRow_Click;
            // 
            // butDeleteTable
            // 
            butDeleteTable.Location = new Point(373, 103);
            butDeleteTable.Margin = new Padding(4, 5, 4, 5);
            butDeleteTable.Name = "butDeleteTable";
            butDeleteTable.Size = new Size(161, 35);
            butDeleteTable.TabIndex = 16;
            butDeleteTable.Text = "Delete Table";
            butDeleteTable.UseVisualStyleBackColor = true;
            butDeleteTable.Click += butDeleteTable_Click;
            // 
            // butSaveDB
            // 
            butSaveDB.Location = new Point(16, 63);
            butSaveDB.Margin = new Padding(4, 5, 4, 5);
            butSaveDB.Name = "butSaveDB";
            butSaveDB.Size = new Size(161, 35);
            butSaveDB.TabIndex = 17;
            butSaveDB.Text = "Save";
            butSaveDB.UseVisualStyleBackColor = true;
            butSaveDB.Click += butSaveDB_Click;
            // 
            // butRepeatedRows
            // 
            butRepeatedRows.Location = new Point(17, 145);
            butRepeatedRows.Margin = new Padding(4, 5, 4, 5);
            butRepeatedRows.Name = "butRepeatedRows";
            butRepeatedRows.Size = new Size(161, 67);
            butRepeatedRows.TabIndex = 18;
            butRepeatedRows.Text = "Delete Repeated Rows";
            butRepeatedRows.UseVisualStyleBackColor = true;
            butRepeatedRows.Click += butRepeatedRows_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(917, 648);
            Controls.Add(butRepeatedRows);
            Controls.Add(butSaveDB);
            Controls.Add(butDeleteTable);
            Controls.Add(butDeleteRow);
            Controls.Add(butDeleteColumn);
            Controls.Add(tbAddColumn);
            Controls.Add(comboBox);
            Controls.Add(dataGridView);
            Controls.Add(tbAddTable);
            Controls.Add(butAddTable);
            Controls.Add(tbCreateNewDB);
            Controls.Add(butAddRow);
            Controls.Add(butAddColumn);
            Controls.Add(butCreateNewDB);
            Controls.Add(butOpen);
            Controls.Add(tabControl);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form1";
            Text = "DBMS Pidleteichuk TTP-42";
            FormClosing += Form1_FormClosing;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.Button butOpen;
        private System.Windows.Forms.Button butCreateNewDB;
        private System.Windows.Forms.Button butAddColumn;
        private System.Windows.Forms.Button butAddRow;
        private System.Windows.Forms.TextBox tbCreateNewDB;
        private System.Windows.Forms.Button butAddTable;
        private System.Windows.Forms.TextBox tbAddTable;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.TextBox tbAddColumn;
        private System.Windows.Forms.OpenFileDialog ofdOpenImage;
        private System.Windows.Forms.Button butDeleteColumn;
        private System.Windows.Forms.Button butDeleteRow;
        private System.Windows.Forms.Button butDeleteTable;
        private System.Windows.Forms.SaveFileDialog sfdSaveDB;
        private System.Windows.Forms.Button butSaveDB;
        private System.Windows.Forms.OpenFileDialog ofdOpenDB;
        private System.Windows.Forms.Button butRepeatedRows;
    }
}