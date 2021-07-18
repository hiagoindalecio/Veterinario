using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Veterinario.Forms
{
    public partial class FRM_SelecionarTipo : Form
    {
        FRM_Cadastro_Animal frm_AnimalAtual;
        FRM_Cadastro_Raca frm_RacaAtual;
        public FRM_SelecionarTipo(FRM_Cadastro_Animal form_Animal, FRM_Cadastro_Raca form_raca)
        {
            InitializeComponent();
            frm_AnimalAtual = form_Animal;
            frm_RacaAtual = form_raca;
        }

        private void LoadAll(object sender, EventArgs e)
        {
            clsTipo objTipo = new clsTipo();
            MySqlDataReader sql_dr = objTipo.GetAllTipos();
            while (sql_dr.Read())
            {
                ListViewItem item = new ListViewItem(sql_dr["id_tipo"].ToString());
                item.SubItems.Add(sql_dr["nome_tipo"].ToString());
                lstTipo.Items.Add(item);
            }
        }

        private void SalvarTipo(object sender, EventArgs e)
        {
            clsTipo objTipo = new clsTipo();
            if(lstTipo.SelectedItems[0] != null)
            {
                objTipo.Id_tipo = Convert.ToInt32(lstTipo.SelectedItems[0].Text);
                if (frm_RacaAtual == null)
                {
                    frm_AnimalAtual.sql_tipoSelecionado = objTipo.GetTipoByID();
                }
                else
                {
                    frm_RacaAtual.sql_tipoSelecionado = objTipo.GetTipoByID();
                }
                this.Close();
            }
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
            lstTipo.Items.Clear();
            clsTipo objTipo = new clsTipo();
            MySqlDataReader sql_dr = objTipo.GetTiposByFilter(txtFiltro.Text);
            while (sql_dr.Read())
            {
                ListViewItem item = new ListViewItem(sql_dr["id_tipo"].ToString());
                item.SubItems.Add(sql_dr["nome_tipo"].ToString());
                lstTipo.Items.Add(item);
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
