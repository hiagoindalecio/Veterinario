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
using Veterinario.Forms;

namespace Veterinario
{
    public partial class FRM_Selecionar_Cliente : Form
    {
        FRM_Cadastro_Animal frm_AnimalAtual;
        public FRM_Selecionar_Cliente(FRM_Cadastro_Animal form_Animal)
        {
            InitializeComponent();
            frm_AnimalAtual = form_Animal;
        }
        private void LoadAll(object sender, EventArgs e)
        {
            lstClientes.Items.Clear();
            clsCliente obj_cliente = new clsCliente();
            MySqlDataReader sql_dr = obj_cliente.GetAllClientesAtivos();
            while (sql_dr.Read())
            {
                ListViewItem item = new ListViewItem(sql_dr["id_cliente"].ToString());
                item.SubItems.Add(sql_dr["nome_cliente"].ToString());
                lstClientes.Items.Add(item);
            }
            sql_dr.Close();
        }

        private void SalvarCliente(object sender, EventArgs e)
        {
            clsCliente objCliente = new clsCliente();
            objCliente.Id_Cliente = Convert.ToInt32(lstClientes.SelectedItems[0].Text);
            frm_AnimalAtual.sql_donoSelecionado = objCliente.GetClientByID();
            this.Close();
        }

        private void LiberarSelecionar(object sender, EventArgs e)
        {
            btnSelecionar.Enabled = true;
        }

        private void Cancel(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Filtrar(object sender, EventArgs e)
        {
            lstClientes.Items.Clear();
            clsCliente objCliente = new clsCliente();
            MySqlDataReader sql_dr = objCliente.GetClientAtivoByFilter(txtFiltro.Text);
            while (sql_dr.Read())
            {
                ListViewItem item = new ListViewItem(sql_dr["id_cliente"].ToString());
                item.SubItems.Add(sql_dr["nome_cliente"].ToString());
                lstClientes.Items.Add(item);
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
