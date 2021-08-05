using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSV_Parser_ImagePreview_ADGV
{
    public partial class Form1 : Form
    {
        string csvPath = @"..\..\..\input.csv";

        public List<csvItem> loadCSV(string csvFile)
        {
            var query = from l in File.ReadAllLines(csvFile)
                        let data = l.Split(";")
                        select new csvItem
                        {
                            Id = data[0],
                            Name = data[1],
                            Color = data[2],
                            FotoPath = data[3],
                            FotoThumb = (Bitmap)Bitmap.FromFile(data[3]).GetThumbnailImage(50, 50, null, new IntPtr())
                        };
            return query.ToList();
        }

        public Form1()
        {
            InitializeComponent();

            //set DataSource
            advancedDataGridView1.RowTemplate.Height = 100;
            advancedDataGridView1.DataSource = loadCSV(csvPath);
            advancedDataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;


        }

        private void advancedDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

    public class csvItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public String FotoPath { get; set; }
        public Bitmap FotoThumb { get; set; }
    }
}
