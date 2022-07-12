using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace JapaneseText
{
    public partial class frm_pesquisar : Form
    {
        SqlConnection conexao;
        SqlCommand cmd;
        SqlDataReader reader;

        string sql;
        public frm_pesquisar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new SqlConnection(@"Server=DESKTOP-3O6SOMD\SQLEXPRESS;Database=Anki;User Id=sa;Password=qwe123;");
                sql = "select JapaneseText, Romanji, Traducao from teste where JapaneseText = @JapaneseText";
                cmd = new SqlCommand(sql, conexao);
                cmd.Parameters.AddWithValue("@JapaneseText", textBox1.Text);

                conexao.Open();

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    label7.Text = (string)reader["JapaneseText"];
                    label4.Text = (string)reader["Romanji"];
                    label5.Text = (string)reader["Traducao"];
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conexao.Close();

            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
