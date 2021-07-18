using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Veterinario.Forms
{
    public partial class FRM_Consulta_Cliente : Form
    {
        public FRM_Consulta_Cliente()
        {
            InitializeComponent();
        }

        private static FRM_Consulta_Cliente instance;

        public static FRM_Consulta_Cliente Instance()
        {
            if (instance == null)
            {
                instance = new FRM_Consulta_Cliente();
            }
            return instance;
        }

        private void Close(object sender, FormClosedEventArgs e)
        {
            instance = null;
        }

        private void LoadAll(object sender, EventArgs e)
        {
            lstClientes.Items.Clear();
            clsCliente obj_cliente = new clsCliente();
            MySqlDataReader sql_dr = obj_cliente.GetAllClientes();
            /*MySqlDataAdapter sql_da = obj_cliente.GetAllClientesAdapter();
            sql_da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            DataTable dt = new DataTable();
            sql_da.Fill(dt);
            //DataSet ds = new DataSet();
            var rds = new Microsoft.Reporting.WinForms.ReportDataSource("Message", dt);
            rvClientes.LocalReport.DataSources.Clear();
            rvClientes.LocalReport.DataSources.Add(rds);
            rvClientes.LocalReport.Refresh();
            sql_da.Dispose();*/
            /*MySqlDataAdapter sql_da = obj_cliente.GetAllClientesAdapter();
            sql_da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            DataSet ds = new DataSet();
            sql_da.Fill(ds, "tb_cliente");
            DataTable table = new DataTable();
            sql_da.Fill(table);
            var rds = new Microsoft.Reporting.WinForms.ReportDataSource("Clientes", table);
            rvClientes.LocalReport.DataSources.Clear();
            rvClientes.LocalReport.DataSources.Add(rds);
            rvClientes.LocalReport.Refresh();
            sql_da.Dispose();*/ //ENFIM, DESISTO DE USAR REPORTVIEWER COM DATABASE EXTERNO.
            while (sql_dr.Read())
            {
                ListViewItem item = new ListViewItem(sql_dr["id_cliente"].ToString());
                item.SubItems.Add(sql_dr["nome_cliente"].ToString());
                item.SubItems.Add(sql_dr["celular_cliente"].ToString());
                item.SubItems.Add(sql_dr["cidade_estado"].ToString());
                lstClientes.Items.Add(item);
            }
            sql_dr.Close();
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
            lstClientes.Items.Clear();
            clsCliente objCliente = new clsCliente();
            MySqlDataReader sql_dr = objCliente.GetClientByFilter(txtFiltro.Text);
            while (sql_dr.Read())
            {
                ListViewItem item = new ListViewItem(sql_dr["id_cliente"].ToString());
                item.SubItems.Add(sql_dr["nome_cliente"].ToString());
                item.SubItems.Add(sql_dr["celular_cliente"].ToString());
                item.SubItems.Add(sql_dr["cidade_estado"].ToString());
                lstClientes.Items.Add(item);
            }
            sql_dr.Close();
        }

        private void FiltrarAtivos()
        {
            lstClientes.Items.Clear();
            clsCliente objCliente = new clsCliente();
            MySqlDataReader sql_dr = objCliente.GetClientAtivoByFilter(txtFiltro.Text);
            while (sql_dr.Read())
            {
                ListViewItem item = new ListViewItem(sql_dr["id_cliente"].ToString());
                item.SubItems.Add(sql_dr["nome_cliente"].ToString());
                item.SubItems.Add(sql_dr["celular_cliente"].ToString());
                item.SubItems.Add(sql_dr["cidade_estado"].ToString());
                lstClientes.Items.Add(item);
            }
            sql_dr.Close();
        }

        private void CarregarDados(object sender, EventArgs e)
        {
            gbDados.Visible = true;
            lstAnimais.Items.Clear();
            int nr_ClienteSelecionado;
            string nome_cliente = "Name";
            try
            {
                string vl_select = lstClientes.SelectedItems[0].Text;
                nome_cliente = lstClientes.SelectedItems[0].SubItems[1].Text;
                nr_ClienteSelecionado = Convert.ToInt32(vl_select);
            }
            catch
            {
                nr_ClienteSelecionado = -1;
            }
            lblNome.Text = nome_cliente;
            lblID.Text = $"ID - {nr_ClienteSelecionado.ToString()}";
            clsCliente objCliente = new clsCliente();
            objCliente.Id_Cliente = nr_ClienteSelecionado;
            MySqlDataReader sql_dr = objCliente.GetClientByID();
            if(sql_dr.Read())
            {
                lblEndereco.Text = sql_dr["endereco_cliente"].ToString();
                lblCidade.Text = sql_dr["cidade_estado"].ToString();
                lblAtivo.Text = Convert.ToInt32(sql_dr["ativo_cliente"]) == 1 ? "Ativo - Sim" : "Ativo - Não";
            }
            sql_dr.Close();
            if (nr_ClienteSelecionado != -1)
            {
                int quantos = 0;
                
                clsAnimal objAnimal = new clsAnimal();
                MySqlDataReader sql_dr2 = objAnimal.GetAnimaisByIDDono(nr_ClienteSelecionado);
                while (sql_dr2.Read())
                {
                    ListViewItem item = new ListViewItem(sql_dr2["id_animal"].ToString());
                    item.SubItems.Add(sql_dr2["nome_animal"].ToString());
                    clsTipo objTipo = new clsTipo();
                    objTipo.Id_tipo = Convert.ToInt32(sql_dr2["fk_tipo"]);
                    MySqlDataReader dr = objTipo.GetTipoByID();
                    if (dr.Read())
                    {
                        item.SubItems.Add(dr["nome_tipo"].ToString());
                    }
                    dr.Close();
                    lstAnimais.Items.Add(item);
                    quantos++;
                }
                sql_dr2.Close();
            }
        }

        private void LoadAtivos()
        {
            lstClientes.Items.Clear();
            clsCliente obj_cliente = new clsCliente();
            MySqlDataReader sql_dr = obj_cliente.GetAllClientesAtivos();
            while (sql_dr.Read())
            {
                ListViewItem item = new ListViewItem(sql_dr["id_cliente"].ToString());
                item.SubItems.Add(sql_dr["nome_cliente"].ToString());
                item.SubItems.Add(sql_dr["celular_cliente"].ToString());
                item.SubItems.Add(sql_dr["cidade_estado"].ToString());
                lstClientes.Items.Add(item);
            }
            sql_dr.Close();
        }

        private void AlteraFiltro(object sender, EventArgs e)
        {
            if(ckbAtivos.Checked)
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

        private void EditarCliente(object sender, EventArgs e)
        {
            int nr_ClienteSelecionado;
            try
            {
                string vl_select = lstClientes.SelectedItems[0].Text;
                nr_ClienteSelecionado = Convert.ToInt32(vl_select);
            }
            catch
            {
                nr_ClienteSelecionado = -1;
            }
            FRM_Editar_Cliente frm_Edit = new FRM_Editar_Cliente(nr_ClienteSelecionado);
            frm_Edit.ShowDialog();
            CarregarDados(null, null);
            LoadAll(null, null);
            gbDados.Visible = false;
        }
    }
}
