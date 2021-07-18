using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Data;
using System.Drawing;

namespace Veterinario.Forms
{
    public partial class FRM_Consulta_atendimento : Form
    {
        public FRM_Consulta_atendimento()
        {
            InitializeComponent();
        }

        private static FRM_Consulta_atendimento instance;

        public static FRM_Consulta_atendimento Instance()
        {
            if (instance == null)
            {
                instance = new FRM_Consulta_atendimento();
            }
            return instance;
        }

        private void Close(object sender, FormClosedEventArgs e)
        {
            instance = null;
        }

        private void ObterDados(object sender, EventArgs e)
        {
            gbDescricao.Visible = true;
            gbDados.Visible = true;
            int nr_Atendimento_Selecionado;
            try
            {
                string vl_select = lstAtendimento.SelectedItems[0].Text;
                nr_Atendimento_Selecionado = Convert.ToInt32(vl_select);
            }
            catch
            {
                nr_Atendimento_Selecionado = -1;
            }
            if (nr_Atendimento_Selecionado != -1)
            {
                try
                {
                    clsAtendimento objAtend = new clsAtendimento();
                    objAtend.Id_Atendimento = nr_Atendimento_Selecionado;
                    MySqlDataReader dr_atend = objAtend.GetAtendimentoByID();
                    if (dr_atend.Read())
                    {
                        clsAnimal objAnimal = new clsAnimal();
                        objAnimal.Id_animal = Convert.ToInt32(dr_atend["fk_animal"]);
                        MySqlDataReader dr_animal = objAnimal.GetAnimalByID();
                        if(dr_animal.Read())
                        {
                            lblNome.Text = dr_animal["nome_animal"].ToString();
                            MySqlDataAdapter sql_da = objAnimal.GetAnimalByIDAdapter();
                            sql_da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                            DataSet ds = new DataSet();
                            sql_da.Fill(ds, "tb_animal");
                            DataTable table = new DataTable();
                            sql_da.Fill(table);
                            picFoto.Image = null;
                            if (ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                            {
                                byte[] foto_array = (byte[])ds.Tables[0].Rows[0][2];
                                MemoryStream ms = new MemoryStream(foto_array);
                                try
                                {
                                    picFoto.Image = Image.FromStream(ms);
                                }
                                catch
                                {
                                    MessageBox.Show("Erro ao carregar imagem", "ERRO");
                                }
                            }
                            sql_da.Dispose();
                            clsRaca objRaca = new clsRaca();
                            objRaca.Id_Raca = Convert.ToInt32(dr_animal["fk_raca"]);
                            MySqlDataReader dr_raca = objRaca.GetRacaByID();
                            if(dr_raca.Read())
                            {
                                lblRaca.Text = dr_raca["nome_raca"].ToString();
                            }
                            dr_raca.Close();
                            clsTipo objTipo = new clsTipo();
                            objTipo.Id_tipo = Convert.ToInt32(dr_animal["fk_tipo"]);
                            MySqlDataReader dr_tipo = objTipo.GetTipoByID();
                            if (dr_tipo.Read())
                            {
                                lblTipo.Text = dr_tipo["nome_tipo"].ToString();
                            }
                            dr_tipo.Close();
                        }
                        dr_animal.Close();
                        txtDescricao.Text = dr_atend["descricao_atendimento"].ToString();
                    }
                    dr_atend.Close();
                }
                catch
                {
                    MessageBox.Show("Erro ao buscar dados do atendimento, contacte o suporte!", "Erro");
                }

            }
        }

        private void LoadAll(object sender, EventArgs e)
        {
            lstAtendimento.Items.Clear();
            clsAtendimento obj_atendimento = new clsAtendimento();
            MySqlDataReader sql_dr = obj_atendimento.GetAllAtendimentos();
            while (sql_dr.Read())
            {
                ListViewItem item = new ListViewItem(sql_dr["id_atendimento"].ToString());
                clsAnimal objAnimal = new clsAnimal();
                objAnimal.Id_animal = Convert.ToInt32(sql_dr["fk_animal"]);
                MySqlDataReader dr_animal = objAnimal.GetAnimalByID();
                if(dr_animal.Read())
                {
                    item.SubItems.Add(sql_dr["nome_animal"].ToString());
                }
                dr_animal.Close();
                item.SubItems.Add(Convert.ToDateTime(sql_dr["data_atendimento"]).Date.ToString("dd/MM/yyyy"));
                clsFuncionario objFuncionario = new clsFuncionario();
                objFuncionario.Id_Funcionario = Convert.ToInt32(sql_dr["fk_funcionario"]);
                objFuncionario.GetFuncionarioByID();
                item.SubItems.Add(objFuncionario.Nome_Funcionario);
                lstAtendimento.Items.Add(item);
            }
            sql_dr.Close();
        }

        private void Filtrar(object sender, EventArgs e)
        {
            if(txtFiltro.Text != "")
            {
                lstAtendimento.Items.Clear();
                clsAtendimento obj_atendimento = new clsAtendimento();
                MySqlDataReader sql_dr = obj_atendimento.GetAtendimentosByFilter(txtFiltro.Text);
                while (sql_dr.Read())
                {
                    ListViewItem item = new ListViewItem(sql_dr["id_atendimento"].ToString());
                    item.SubItems.Add(sql_dr["nome_animal"].ToString());
                    item.SubItems.Add(Convert.ToDateTime(sql_dr["data_atendimento"]).Date.ToString("dd/MM/yyyy"));
                    item.SubItems.Add(sql_dr["nome_funcionario"].ToString());
                    lstAtendimento.Items.Add(item);
                }
                sql_dr.Close();
            }
        }

        private void RemoverFiltro(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Back) && txtFiltro.TextLength == 1)
            {
                LoadAll(null, null);
            }
        }
    }
}
