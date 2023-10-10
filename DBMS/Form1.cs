using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;

namespace DBMS
{
    public partial class Form1 : Form
    {
        Manager manager = new Manager();
        string filePath = "";
        object oldValue;
        object cellNewValue;
        public Form1()
        {
            InitializeComponent();
        }

        private void butCreateNewDB_Click(object sender, EventArgs e)
        {
            if (tbCreateNewDB.Text!=""&& !filePath.Equals(""))
            {
                DialogResult dialogResult = MessageBox.Show("«·ÂÂ„ÚË ÁÏ≥ÌË?", "œŒœ≈–≈ƒ∆≈ÕÕﬂ", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    manager.SaveDB(filePath);
                }
            }

            if (manager.CreateNewDB(tbCreateNewDB.Text))
            {
                tabControl.TabPages.Clear();
                dataGridView.Rows.Clear();
                dataGridView.Columns.Clear();
                filePath = "";
            }
        }

        private void butAddTable_Click(object sender, EventArgs e)
        {
            if (manager.AddTable(tbAddTable.Text))
            {
                tabControl.TabPages.Add(tbAddTable.Text);
            }
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ind = tabControl.SelectedIndex;
            if (ind != -1) ShowTable(manager.GetTable(ind));
        }

        void ShowTable(Table t)
        {
            try
            {
                dataGridView.Rows.Clear();
                dataGridView.Columns.Clear();

                foreach (Column c in t.Columns)
                {
                    if (c.Type != "PICTURE FILE")
                    {
                        DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                        column.Name = c.Name + " {" + c.Type + "}";
                        column.Width = 200;
                        dataGridView.Columns.Add(column);
                    }
                    else
                    {
                        DataGridViewImageColumn column = new DataGridViewImageColumn();
                        column.Width = 200;
                        dataGridView.Columns.Add(column);
                        column.Name = c.Name + " {" + c.Type + "}";
                    }

                }

                foreach (Row r in t.Rows)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.Height = 60;
                    foreach (var s in r.Values)
                    {
                        if (!(s is (List<byte>)))
                        {
                            DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
                            cell.Value = s;
                            row.Cells.Add(cell);
                        }
                        else
                        {
                            DataGridViewImageCell cell = new DataGridViewImageCell();
                            var img = Manager.ByteArrayToImage((List<byte>)s);
                            cell.Value = img;
                            cell.ImageLayout = DataGridViewImageCellLayout.Stretch;
                            row.Cells.Add(cell);

                        }
                    }
                    try
                    {
                        dataGridView.Rows.Add(row);
                    }
                    catch { }
                }
            }
            catch { }
        }

        private void butAddColumn_Click(object sender, EventArgs e)
        {
            if (manager.AddColumn(tabControl.SelectedIndex, tbAddColumn.Text, comboBox.Text))
            {
                int ind = tabControl.SelectedIndex;
                if (ind != -1) ShowTable(manager.GetTable(ind));
            }
        }

        private void butAddRow_Click(object sender, EventArgs e)
        {
            if (manager.AddRow(tabControl.SelectedIndex))
            {

                int ind = tabControl.SelectedIndex;
                if (ind != -1) ShowTable(manager.GetTable(ind));
            }
        }

        private void butRepeatedRows_Click(object sender, EventArgs e)
        {
            if (dataGridView.Rows.Count == 0) return;
            try
            {
                manager.RepeatedRows(tabControl.SelectedIndex);
            }
            catch { }

            int ind = tabControl.SelectedIndex;
            if (ind != -1) ShowTable(manager.GetTable(ind));
        }

        private void dataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            oldValue = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
        }

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            cellNewValue = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            if (!manager.ChangeValue(cellNewValue, tabControl.SelectedIndex, e.ColumnIndex, e.RowIndex))
            {
                dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = oldValue;
                MessageBox.Show("ÕÂ ‚≥ÌËÈ ÙÓÏ‡Ú ‚‚Ó‰Û", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void butDeleteRow_Click(object sender, EventArgs e)
        {
            if (dataGridView.Rows.Count == 0) return;
            try
            {
                manager.DeleteRow(tabControl.SelectedIndex, dataGridView.CurrentCell.RowIndex);
            }
            catch { }

            int ind = tabControl.SelectedIndex;
            if (ind != -1) ShowTable(manager.GetTable(ind));
        }

        private void butDeleteColumn_Click(object sender, EventArgs e)
        {
            if (dataGridView.Columns.Count == 0) return;
            try
            {
                manager.DeleteColumn(tabControl.SelectedIndex, dataGridView.CurrentCell.ColumnIndex);
            }
            catch { }

            int ind = tabControl.SelectedIndex;
            if (ind != -1) ShowTable(manager.GetTable(ind));
        }

        private void butDeleteTable_Click(object sender, EventArgs e)
        {
            if (tabControl.TabCount == 0) return;
            try
            {
                manager.DeleteTable(tabControl.SelectedIndex);
                tabControl.TabPages.RemoveAt(tabControl.SelectedIndex);
            }
            catch { }
            if (tabControl.TabCount == 0) return;

            int ind = tabControl.SelectedIndex;
            if (ind != -1) ShowTable(manager.GetTable(ind));
        }

        private void butSaveDB_Click(object sender, EventArgs e)
        {
            if (!filePath.Equals(""))
            {
                manager.SaveDB(filePath);
            }
            else
            {
                Stream stream;

                sfdSaveDB.Filter = "tdb files (*.tdb)|*.tdb";
                sfdSaveDB.FilterIndex = 1;
                sfdSaveDB.RestoreDirectory = true;

                if (sfdSaveDB.ShowDialog() == DialogResult.OK)
                {
                    if ((stream = sfdSaveDB.OpenFile()) != null)
                    {
                        stream.Close();
                        manager.SaveDB(sfdSaveDB.FileName);
                    }
                }
            }
        }

        private void butOpen_Click(object sender, EventArgs e)
        {
            if (!filePath.Equals(""))
            {
                DialogResult dialogResult = MessageBox.Show("«·ÂÂ„ÚË ÁÏ≥ÌË?", "œŒœ≈–≈ƒ∆≈ÕÕﬂ", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    manager.SaveDB(filePath);
                }
            }

            ofdOpenDB.Filter = "tdb files (*.tdb)|*.tdb";
            ofdOpenDB.FilterIndex = 1;
            ofdOpenDB.RestoreDirectory = true;

            if (ofdOpenDB.ShowDialog() == DialogResult.OK)
            {
                filePath = ofdOpenDB.FileName;
                if (filePath == null) return;
                manager.OpenDB(ofdOpenDB.FileName);
            }
            else { return; }
            tabControl.TabPages.Clear();
            List<string> buf = manager.GetTableNameList();
            foreach (string s in buf)
                tabControl.TabPages.Add(s);

            int ind = tabControl.SelectedIndex;
            if (ind != -1) ShowTable(manager.GetTable(ind));

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!filePath.Equals(""))
            {
                DialogResult dialogResult = MessageBox.Show("«·ÂÂ„ÚË ÁÏ≥ÌË?", "œŒœ≈–≈ƒ∆≈ÕÕﬂ", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    manager.SaveDB(filePath);
                }
            }
        }

        private void dataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (ofdOpenImage.ShowDialog() == DialogResult.OK && dataGridView.Columns[e.ColumnIndex].CellType == typeof(DataGridViewImageCell))
            {
                manager.OpenPicture(ofdOpenImage.FileName, ofdOpenImage.FileName, tabControl.SelectedIndex, dataGridView.CurrentCell.RowIndex, dataGridView.CurrentCell.ColumnIndex);
                int ind = tabControl.SelectedIndex;
                if (ind != -1) ShowTable(manager.GetTable(ind));
            }

        }

    }
}