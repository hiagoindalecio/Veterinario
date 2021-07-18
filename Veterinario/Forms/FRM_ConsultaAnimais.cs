using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace Veterinario.Forms
{
    public partial class FRM_ConsultaAnimais : Form
    {
        public FRM_ConsultaAnimais()
        {
            InitializeComponent();
        }

        private static FRM_ConsultaAnimais instance;

        public static FRM_ConsultaAnimais Instance()
        {
            if (instance == null)
            {
                instance = new FRM_ConsultaAnimais();
            }
            return instance;
        }

        private void Close(object sender, FormClosedEventArgs e)
        {
            instance = null;
        }

        private void LoadAll(object sender, EventArgs e)
        {
            lstAnimais.Items.Clear();
            clsAnimal obj_animal = new clsAnimal();
            MySqlDataReader sql_dr = obj_animal.GetAllAnimais();
            while (sql_dr.Read())
            {
                ListViewItem item = new ListViewItem(sql_dr["id_animal"].ToString());
                item.SubItems.Add(sql_dr["nome_animal"].ToString());
                clsCliente objCliente = new clsCliente();
                objCliente.Id_Cliente = Convert.ToInt32(sql_dr["fk_dono"]);
                MySqlDataReader sql_dr2 = objCliente.GetClientByID();
                if(sql_dr2.Read())
                {
                    item.SubItems.Add(sql_dr2["id_cliente"].ToString());
                    item.SubItems.Add(sql_dr2["nome_cliente"].ToString());
                }
                else
                {
                    item.SubItems.Add("ERRO");
                }
                sql_dr2.Close();
                lstAnimais.Items.Add(item);
            }
        }

        private void RemoverFiltro(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Back) && txtFiltro.TextLength == 1)
            {
                if (ckbAtivos.Checked)
                    LoadAtivos();
                else
                    LoadAll(null, null);
            }
        }

        private void Filtrar()
        {
            lstAnimais.Items.Clear();
            clsAnimal objAnimal = new clsAnimal();
            MySqlDataReader sql_dr = objAnimal.GetAnimaisByFilter(txtFiltro.Text);
            clsCliente objCliente = new clsCliente();
            while (sql_dr.Read())
            {
                objCliente.Id_Cliente = Convert.ToInt32(sql_dr["fk_dono"]);
                ListViewItem item = new ListViewItem(sql_dr["id_animal"].ToString());
                item.SubItems.Add(sql_dr["nome_animal"].ToString());
                item.SubItems.Add(sql_dr["fk_dono"].ToString());
                MySqlDataReader dr_dono = objCliente.GetClientByID();
                if (dr_dono.Read())
                    item.SubItems.Add(dr_dono["nome_cliente"].ToString());
                else
                    item.SubItems.Add("ERRO");
                lstAnimais.Items.Add(item);
                dr_dono.Close();
            }
        }

        private void FiltrarAtivos()
        {
            lstAnimais.Items.Clear();
            clsAnimal objAnimal = new clsAnimal();
            MySqlDataReader sql_dr = objAnimal.GetAnimaisByFilter(txtFiltro.Text);
            clsCliente objCliente = new clsCliente();
            while (sql_dr.Read())
            {
                objCliente.Id_Cliente = Convert.ToInt32(sql_dr["fk_dono"]);
                if (objCliente.VerificaAtivo() == "Ativo")
                {
                    ListViewItem item = new ListViewItem(sql_dr["id_animal"].ToString());
                    item.SubItems.Add(sql_dr["nome_animal"].ToString());
                    item.SubItems.Add(sql_dr["fk_dono"].ToString());
                    MySqlDataReader dr_dono = objCliente.GetClientByID();
                    if (dr_dono.Read())
                        item.SubItems.Add(dr_dono["nome_cliente"].ToString());
                    else
                        item.SubItems.Add("ERRO");
                    lstAnimais.Items.Add(item);
                    dr_dono.Close();
                }
            }
            sql_dr.Close();
        }

        private void CarregarDados(object sender, EventArgs e)
        {
            gbDados.Visible = true;
            int nr_AnimalSelecionado;
            try
            {
                string vl_select = lstAnimais.SelectedItems[0].Text;
                nr_AnimalSelecionado = Convert.ToInt32(vl_select);
            }
            catch
            {
                nr_AnimalSelecionado = -1;
            }
            if(nr_AnimalSelecionado != -1)
            {
                picFoto.Image = null;
                clsAnimal objAnimal = new clsAnimal();
                objAnimal.Id_animal = nr_AnimalSelecionado;
                MySqlDataReader sql_dr = objAnimal.GetAnimalByID();
                if (sql_dr.Read())
                {
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
                    clsTipo objTipo = new clsTipo();
                    objTipo.Id_tipo = Convert.ToInt32(sql_dr["fk_tipo"]);
                    MySqlDataReader sql_dr_caracteristica = objTipo.GetTipoByID();
                    if (sql_dr_caracteristica.Read())
                    {
                        lblTipo.Text = sql_dr_caracteristica["nome_tipo"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível encontrar o tipo do animal.", "ERRO");
                    }
                    sql_dr_caracteristica.Close();
                    clsRaca objRaca = new clsRaca();
                    objRaca.Id_Raca = Convert.ToInt32(sql_dr["fk_raca"]);
                    sql_dr_caracteristica = objRaca.GetRacaByID();
                    if (sql_dr_caracteristica.Read())
                    {
                        lblRaca.Text = sql_dr_caracteristica["nome_raca"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível encontrar a raça do animal.", "ERRO");
                    }
                    sql_dr_caracteristica.Close();
                    clsCliente objCliente = new clsCliente();
                    objCliente.Id_Cliente = Convert.ToInt32(sql_dr["fk_dono"]);
                    sql_dr_caracteristica = objCliente.GetClientByID();
                    if (sql_dr_caracteristica.Read())
                    {
                        lblDono.Text = sql_dr_caracteristica["nome_cliente"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível encontrar o dono do animal.", "ERRO");
                    }
                    sql_dr_caracteristica.Close();
                    DateTime now = DateTime.Now;
                    int idade = now.Year - Convert.ToDateTime(sql_dr["nascimento"]).Year;
                    if (now.DayOfYear < Convert.ToDateTime(sql_dr["nascimento"]).DayOfYear)
                        idade--;
                    lblIdade.Text = idade.ToString();
                }
                else
                {
                    MessageBox.Show("Erro ao tentar acessar informações dobre o animal!", "ERRO!");
                }
                lblNome.Text = sql_dr["nome_animal"].ToString();
            }
        }

        private void LoadAtivos()
        {
            lstAnimais.Items.Clear();
            clsAnimal objAnimal = new clsAnimal();
            MySqlDataReader sql_dr = objAnimal.GetAllAnimais();
            clsCliente objCliente = new clsCliente();
            while (sql_dr.Read())
            {
                objCliente.Id_Cliente = Convert.ToInt32(sql_dr["fk_dono"]);
                if (objCliente.VerificaAtivo() == "Ativo")
                {
                    ListViewItem item = new ListViewItem(sql_dr["id_animal"].ToString());
                    item.SubItems.Add(sql_dr["nome_animal"].ToString());
                    item.SubItems.Add(sql_dr["fk_dono"].ToString());
                    MySqlDataReader dr_dono = objCliente.GetClientByID();
                    if (dr_dono.Read())
                        item.SubItems.Add(dr_dono["nome_cliente"].ToString());
                    else
                        item.SubItems.Add("ERRO");
                    lstAnimais.Items.Add(item);
                    dr_dono.Close();
                }
            }
        }

        private void AlteraFiltro(object sender, EventArgs e)
        {
            if (ckbAtivos.Checked)
            {
                LoadAtivos();
            }
            else
            {
                LoadAll(null, null);
            }
        }

        private void Filtro(object sender, EventArgs e)
        {
            if (ckbAtivos.Checked && txtFiltro.Text != "")
            {
                FiltrarAtivos();
            }
            else if (txtFiltro.Text != "")
            {
                Filtrar();
            }
        }

        private void AtualizarFoto(object sender, EventArgs e)
        {
            FRM_Editar_Animal frm_edit = new FRM_Editar_Animal(Convert.ToInt32(lstAnimais.SelectedItems[0].Text));
            frm_edit.ShowDialog();
            CarregarDados(null, null);
        }
    }
}
