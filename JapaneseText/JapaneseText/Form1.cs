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
    public partial class Form1 : Form
    {
        SqlConnection conexao;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        SqlDataReader reader;

        string sql;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" & textBox2.Text != "" & textBox3.Text != "")
            {
                try
                {
                    conexao = new SqlConnection(@"Server=DESKTOP-3O6SOMD\SQLEXPRESS;Database=Anki;User Id=sa;Password=qwe123;");
                    sql = "insert into teste (JapaneseText, Romanji, Traducao) values (@JapaneseText, @Romanji, @Traducao)";
                    cmd = new SqlCommand(sql, conexao);
                    cmd.Parameters.AddWithValue("@JapaneseText", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Romanji", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Traducao", textBox2.Text);
                    conexao.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cadastro Efetuado com sucesso!", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            else
            {
                MessageBox.Show("Por favor digite todos os dados obrigatórios", "Japanese Text", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new SqlConnection(@"Server=DESKTOP-3O6SOMD\SQLEXPRESS;Database=Anki;User Id=sa;Password=qwe123;");
                sql = "select * from teste";
                DataSet ds = new DataSet();
                adapter = new SqlDataAdapter(sql, conexao);
                conexao.Open();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                
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

        private void btn_consultar_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new SqlConnection(@"Server=DESKTOP-3O6SOMD\SQLEXPRESS;Database=Anki;User Id=sa;Password=qwe123;");
                sql = "select * from caracter";
                cmd = new SqlCommand(sql, conexao);
                cmd.Parameters.AddWithValue("@JapaneseText", textBox1.Text);

                conexao.Open();

                reader = cmd.ExecuteReader();

               
                while (reader.Read())
                {
                    textBox1.Text = Convert.ToString(reader["JapaneseText"]);
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

        private void button3_Click(object sender, EventArgs e)
        {         
           try
            {
                conexao = new SqlConnection(@"Server=DESKTOP-3O6SOMD\SQLEXPRESS;Database=Anki;User Id=sa;Password=qwe123;");
                sql = "delete teste where  id = @id";
                cmd = new SqlCommand(sql, conexao);
                              
                cmd.Parameters.AddWithValue("@id", textBox4.Text);

                conexao.Open();

                
                cmd.ExecuteNonQuery();
                MessageBox.Show("Dado excluído com sucesso!", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void button4_Click(object sender, EventArgs e)
        {
            pesquisa pe = new pesquisa();   
            pe.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new SqlConnection(@"Server=DESKTOP-3O6SOMD\SQLEXPRESS;Database=Anki;User Id=sa;Password=qwe123;");
                sql = "update teste set JapaneseText = @JapaneseText, Romanji = @Romanji, Traducao = @Traducao where id = @id";
                cmd = new SqlCommand(sql, conexao);
                cmd.Parameters.AddWithValue("@id", textBox4.Text);
                cmd.Parameters.AddWithValue("@JapaneseText", textBox1.Text);
                cmd.Parameters.AddWithValue("@Romanji", textBox3.Text);
                cmd.Parameters.AddWithValue("@Traducao", textBox2.Text);
                
                conexao.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Dado Editado com sucesso!", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*this.textBox4.Text = Convert.ToString(this.dataGridView1.CurrentRow.Cells["id"].Value);
            this.textBox1.Text = Convert.ToString(this.dataGridView1.CurrentRow.Cells["JapaneseText"].Value);
            this.textBox3.Text = Convert.ToString(this.dataGridView1.CurrentRow.Cells["Romanji"].Value);
            this.textBox2.Text = Convert.ToString(this.dataGridView1.CurrentRow.Cells["Traducao"].Value);*/
            textBox4.Text = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells["JapaneseText"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["Romanji"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["Traducao"].Value.ToString();

        }

       
    }
}

