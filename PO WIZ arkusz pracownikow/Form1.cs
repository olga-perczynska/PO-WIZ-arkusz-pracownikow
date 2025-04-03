using System.ComponentModel;
using System.Data;
using System.Xml.Serialization;

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
            dataGridView1.DataSource = new BindingList<Global>(StaticData.ListaOsob); // Dynamiczna lista
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


        public void LoadCSVToDataGridView(string filePath)
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

            string[] headers = lines[0].Split(',');

            if (headers.Length < 5)
            {
                MessageBox.Show("Plik CSV ma nieprawidłową strukturę!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (StaticData.ListaOsob == null)
            {
                StaticData.ListaOsob = new List<Global>();
            }

            HashSet<int> existingIds = new HashSet<int>(StaticData.ListaOsob.Select(o => o.Id));

            int addedCount = 0;
            for (int i = 1; i < lines.Length; i++)
            {
                string[] values = lines[i].Split(',');

                if (values.Length == 5)
                {
                    if (int.TryParse(values[0].Trim(), out int id) && !existingIds.Contains(id))
                    {
                        Global nowaOsoba = new Global
                        {
                            Id = id,
                            Imie = values[1].Trim(),
                            Nazwisko = values[2].Trim(),
                            Etat = values[3].Trim(),
                            Wiek = int.TryParse(values[4].Trim(), out int wiek) ? wiek : 0
                        };

                        StaticData.ListaOsob.Add(nowaOsoba);
                        existingIds.Add(id);
                        addedCount++;
                    }
                }
            }

            OdswiezGridView();

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

        private void button5_Click(object sender, EventArgs e)
        {
            ExportToXML();
        }

        private string xmlFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "dane.xml");

        private void ExportToXML()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Global>));
                using (TextWriter writer = new StreamWriter(xmlFilePath))
                {
                    serializer.Serialize(writer, StaticData.ListaOsob);
                }
                MessageBox.Show("Dane zapisano do pliku XML", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd zapisu do XML: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadXMLToDataGridView()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Pliki XML (*.xml)|*.xml";
                openFileDialog.Title = "Wybierz plik XML";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(List<Global>));
                        using (TextReader reader = new StreamReader(openFileDialog.FileName))
                        {
                            StaticData.ListaOsob = (List<Global>)serializer.Deserialize(reader);
                        }
                        OdswiezGridView();
                        MessageBox.Show("Dane wczytano z wybranego pliku XML!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Błąd odczytu XML: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            LoadXMLToDataGridView();
        }
    }


}
