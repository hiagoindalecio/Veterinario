using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Veterinario.Forms
{
    public partial class FRM_SelcionarAnimal : Form
    {
        Atendimento fRM_Atendimento = new Atendimento(-1);
        public FRM_SelcionarAnimal(Atendimento FRM_Atendimento)
        {
            InitializeComponent();
            fRM_Atendimento = FRM_Atendimento;
        }

        private void LoadAll(object sender, EventArgs e)
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
                    lstAnimais.Items.Add(item);
                }
            }
        }

        private void SalvarAnimal(object sender, EventArgs e)
        {
            clsAnimal objAnimal = new clsAnimal();
            objAnimal.Id_animal = Convert.ToInt32(lstAnimais.SelectedItems[0].Text);
            fRM_Atendimento.sql_AnimalSelecionado = objAnimal.GetAnimalByID();
            this.Close();
        }

        private void LiberarSelecionar(object sender, EventArgs e)
        {
            btnSelecionar.Enabled = true;
        }

        private void Close(object sender, EventArgs e)
        {
            fRM_Atendimento.sql_AnimalSelecionado = null;
            this.Close();
        }

        private void Filtrar(object sender, EventArgs e)
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
                    lstAnimais.Items.Add(item);
                }
            }
            sql_dr.Close();
        }

        private void RemoveFiltro(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Back) && txtFiltro.TextLength == 1)
            {
                LoadAll(null, null);
            }
        }
    }
}
