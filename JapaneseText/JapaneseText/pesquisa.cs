using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JapaneseText
{
    public partial class pesquisa : Form
    {
        public pesquisa()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_pesquisar pes = new frm_pesquisar();
            pes.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm_pesquisaPT ps = new frm_pesquisaPT();
            ps.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frm_pesquisaRM p = new frm_pesquisaRM();
            p.Show();
        }
    }
}
