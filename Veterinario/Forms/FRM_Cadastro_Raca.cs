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
    public partial class FRM_Cadastro_Raca : Form
    {
        public FRM_Cadastro_Raca()
        {
            InitializeComponent();
        }

        private static FRM_Cadastro_Raca instance;

        public static FRM_Cadastro_Raca Instance()
        {
            if (instance == null)
            {
                instance = new FRM_Cadastro_Raca();
            }
            return instance;
        }

        private void Close(object sender, FormClosedEventArgs e)
        {
            instance = null;
        }

        public MySqlDataReader sql_tipoSelecionado;
        private int id_tipo = -1;

        private void BuscarTipo(object sender, EventArgs e)
        {
            FRM_SelecionarTipo form_Tipo = new FRM_SelecionarTipo(null, this);
            form_Tipo.ShowDialog();
            if (sql_tipoSelecionado != null)
            {
                sql_tipoSelecionado.Read();
                txtTipo.Text = sql_tipoSelecionado["nome_tipo"].ToString();
                id_tipo = Convert.ToInt32(sql_tipoSelecionado["id_tipo"]);
            }
        }
        
        private void Registrar(object sender, EventArgs e)
        {
            if(txtNome.Text != "" && txtTipo.Text != "" && id_tipo != -1)
            {
                clsRaca obj_raca = new clsRaca();
                obj_raca.Nome_Raca = txtNome.Text;
                obj_raca.Fk_Tipo = id_tipo;
                obj_raca.insert();
                MessageBox.Show(obj_raca.ds_msg);
                txtNome.Text = "";
                txtTipo.Text = "";
                id_tipo = -1;
            }
            else
            {
                MessageBox.Show("Preencha todos os campos para prosseguir!", "ERRO");
            }

        }

        private void ValidarTexto(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar)
                || e.KeyChar == (char)(Keys.Back))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
