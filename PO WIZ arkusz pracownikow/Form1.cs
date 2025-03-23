﻿using System.Data;

namespace PO_WIZ_arkusz_pracownikow
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            OdswiezGridView();
        }

        public void OdswiezGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = StaticData.ListaOsob;
            dataGridView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.ShowDialog();
        }


        private void ExportToCSV(DataGridView dataGridView, string filePath)
        {
            
            string csvContent = "Id,Imie,Nazwisko,Etat,Wiek" + Environment.NewLine;
          
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
              
                if (!row.IsNewRow)
                {
                    
                    csvContent += string.Join(",", Array.ConvertAll(row.Cells.Cast<DataGridViewCell>()
                    .ToArray(), c => c.Value)) + Environment.NewLine;
                }
            }
           
            File.WriteAllText(filePath, csvContent);
        }

        private void LoadCSVToDataGridView(string filePath)
        {
            
            if (!File.Exists(filePath))
            {
                MessageBox.Show("Plik CSV nie istnieje.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

          
            string[] lines = File.ReadAllLines(filePath);

           
            if (lines.Length == 0)
            {
                MessageBox.Show("Plik CSV jest pusty.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            DataTable dataTable = new DataTable();


          
            string[] headers = lines[0].Split(','); 

            foreach (string header in headers)
            {
                dataTable.Columns.Add(header.Trim()); 
            }

            
            for (int i = 1; i < lines.Length; i++)
            {
                string[] values = lines[i].Split(',');

               
                if (values.Length == headers.Length)
                {
                    dataTable.Rows.Add(values);
                }
            }

            
            dataGridView1.DataSource = dataTable;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
                saveFileDialog.Title = "Zapisz jako CSV";
                saveFileDialog.FileName = "dane.csv";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ExportToCSV(dataGridView1, saveFileDialog.FileName);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "CSV files (*.csv)|*.csv";
                openFileDialog.Title = "Wybierz plik CSV";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    LoadCSVToDataGridView(openFileDialog.FileName);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridView1.SelectedRows[0].Index;

                if (rowIndex >= 0 && rowIndex < StaticData.ListaOsob.Count)
                {
                    StaticData.ListaOsob.RemoveAt(rowIndex); 
                    OdswiezGridView(); 
                }
            }
            else
            {
                MessageBox.Show("Wybierz wiersz do usunięcia.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                dataGridView1.ClearSelection();
                dataGridView1.Rows[e.RowIndex].Selected = true;
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dataGridView1.Rows.Count)
            {
                return;
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
  
            if (e.RowIndex >= 0)
            {
          
                dataGridView1.ClearSelection(); 
                dataGridView1.Rows[e.RowIndex].Selected = true; 
            }
        }
    }
}
