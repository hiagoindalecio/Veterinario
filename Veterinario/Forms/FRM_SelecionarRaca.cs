using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Veterinario.Forms;

namespace Veterinario
{
    public partial class FRM_SelecionarRaca : Form
    {
        FRM_Cadastro_Animal frm_AnimalAtual;
        int id_tipo;
        public FRM_SelecionarRaca(FRM_Cadastro_Animal form_Animal, int id_tipoAtual)
        {
            InitializeComponent();
            frm_AnimalAtual = form_Animal;
            id_tipo = id_tipoAtual;
        }

        private void LoadAll(object sender, EventArgs e)
        {
            clsRaca obj_raca = new clsRaca();
            obj_raca.Fk_Tipo = id_tipo;
            MySqlDataReader sql_dr = obj_raca.GetRacasByTipo();
            while (sql_dr.Read())
            {
                ListViewItem item = new ListViewItem(sql_dr["id_raca"].ToString());
                item.SubItems.Add(sql_dr["nome_raca"].ToString());
                lstRacas.Items.Add(item);
            }
        }

        private void SalvarRaca(object sender, EventArgs e)
        {
            clsRaca objRaca = new clsRaca();
            objRaca.Id_Raca = Convert.ToInt32(lstRacas.SelectedItems[0].Text);
            frm_AnimalAtual.sql_racaSelecionada = objRaca.GetRacaByID();
            this.Close();
        }

        private void LiberarSelecionar(object sender, EventArgs e)
        {
            btnSelecionar.Enabled = true;
        }

        private void Close(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Filtrar(object sender, EventArgs e)
        {
            lstRacas.Items.Clear();
            clsRaca objRaca = new clsRaca();
            objRaca.Fk_Tipo = id_tipo;
            MySqlDataReader sql_dr = objRaca.GetRacaByFilter(txtFiltro.Text);
            while (sql_dr.Read())
            {
                ListViewItem item = new ListViewItem(sql_dr["id_raca"].ToString());
                item.SubItems.Add(sql_dr["nome_raca"].ToString());
                lstRacas.Items.Add(item);
            }
            sql_dr.Close();
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
