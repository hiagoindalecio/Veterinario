using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Veterinario.Forms
{
    public partial class FRM_Cadastro_Tipo : Form
    {
        public FRM_Cadastro_Tipo()
        {
            InitializeComponent();
        }
        private static FRM_Cadastro_Tipo instance;
        public static FRM_Cadastro_Tipo Instance()
        {
            if (instance == null)
            {
                instance = new FRM_Cadastro_Tipo();
            }
            return instance;
        }

        private void Close(object sender, FormClosedEventArgs e)
        {
            instance = null;
        }

        private void Registrar(object sender, EventArgs e)
        {
            if(txtNome.Text != "")
            {
                clsTipo objTipo = new clsTipo();
                objTipo.Nome_tipo = txtNome.Text;
                objTipo.insert();
                MessageBox.Show(objTipo.ds_msg);
                txtNome.Text = "";
            }
            else
            {
                MessageBox.Show("Preencha todos os campos para prosseguir!", "ERRO");
            }
        }

        private void FRM_Cadastro_Tipo_FormClosed(object sender, FormClosedEventArgs e)
        {
            instance = null;
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
