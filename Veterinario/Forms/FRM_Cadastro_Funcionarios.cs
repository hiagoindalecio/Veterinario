using System;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Veterinario.Forms
{
    public partial class FRM_Cadastro_Funcionarios : Form
    {
        public FRM_Cadastro_Funcionarios()
        {
            InitializeComponent();
            Parametros();
        }

        private void Parametros()
        {
            txtNome.MaxLength = 150;
            txtSenha.MaxLength = 15;
            txtSenha2.MaxLength = 15;
            txtSenha.UseSystemPasswordChar = true;
            txtSenha2.UseSystemPasswordChar = true;
            txtLogin.MaxLength = 50;
        }

        private static FRM_Cadastro_Funcionarios instance;

        public static FRM_Cadastro_Funcionarios Instance()
        {
            if (instance == null)
            {
                instance = new FRM_Cadastro_Funcionarios();
            }
            return instance;
        }

        private void Close(object sender, FormClosedEventArgs e)
        {
            instance = null;
        }

        private void SenhaPadrao(object sender, EventArgs e)
        {
            if (chbxSenha.Checked)
            {
                txtSenha.Text = "102030";
                txtSenha2.Text = "102030";
                txtSenha.UseSystemPasswordChar = true;
                txtSenha2.UseSystemPasswordChar = true;
                txtSenha.Enabled = false;
                txtSenha2.Enabled = false;
            }
            else
            {
                txtSenha.Enabled = true;
                txtSenha2.Enabled = true;
                txtSenha.Text = "";
                txtSenha2.Text = "";
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

        public String CriptografarSenha(string senha)
        {
            var stringHash = "";
            try
            {
                UnicodeEncoding objUE = new UnicodeEncoding();
                byte[] hashBytes, messageBytes = objUE.GetBytes(senha);

                SHA512Managed objSM = new SHA512Managed();


                hashBytes = objSM.ComputeHash(messageBytes);

                foreach (byte b in hashBytes)
                {
                    stringHash += String.Format("{0:x2}", b);
                }
            }
            catch (Exception e)
            {
                stringHash = e.Message;
            }
            return stringHash;
        }

        private void CadastrarFuncionario(object sender, EventArgs e)
        {
            if (txtNome.Text != "" && txtLogin.Text != "" && txtSenha.Text != "" && txtSenha2.Text != "" && cmbMaster.Text != "")
            {
                if (txtSenha.Text.Equals(txtSenha2.Text))
                {
                    clsFuncionario objFunc = new clsFuncionario();
                    objFunc.Nome_Funcionario = txtNome.Text;
                    objFunc.Login = txtLogin.Text;
                    if (!chbxSenha.Checked)
                        objFunc.Senha_funcionario = CriptografarSenha(txtSenha.Text);
                    else
                        objFunc.Senha_funcionario = CriptografarSenha("102030");
                    if (cmbMaster.Text == "Sim")
                        objFunc.Master_Id = true;
                    else
                        objFunc.Master_Id = false;
                    objFunc.Ativo_Funcionario = true;
                    objFunc.insert();
                    MessageBox.Show(objFunc.ds_msg);
                    if (objFunc.ds_msg == "Funcionário inserido com sucesso!")
                    {
                        txtNome.Text = "";
                        txtLogin.Text = "";
                        txtSenha.Text = "";
                        txtSenha2.Text = "";
                        cmbMaster.SelectedItem = cmbMaster.Items[1];
                    }
                }
                else
                {
                    MessageBox.Show("As senhas não são iguais.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Preencha todos os campos para prosseguir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void VisualizarSenha(object sender, EventArgs e)
        {
            if (txtSenha.UseSystemPasswordChar)
                txtSenha.UseSystemPasswordChar = false;
            else
                txtSenha.UseSystemPasswordChar = true;
        }

        private void VisualizarSenha2(object sender, EventArgs e)
        {
            if (txtSenha2.UseSystemPasswordChar)
                txtSenha2.UseSystemPasswordChar = false;
            else
                txtSenha2.UseSystemPasswordChar = true;
        }
    }
}
