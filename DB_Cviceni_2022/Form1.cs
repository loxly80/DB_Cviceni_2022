using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_Cviceni_2022
{
    public partial class Form1 : Form
    {
        private SqlRepository sqlRepository;
        public Form1()
        {
            InitializeComponent();
            sqlRepository = new SqlRepository();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            listView1.Items.Clear();
            var lidi = sqlRepository.GetLidi();
            foreach (var clovek in lidi)
            {
                listView1.Items.Add(clovek.ToListViewItem());
            }
        }

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
            {
                if(listView1.SelectedIndices.Count > 0)
                {
                    sqlRepository.DeleteClovek(listView1.SelectedItems[0].SubItems[0].Text);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Musíte vybrat položku ke smazání");
                }
            }
        }
    }
}
