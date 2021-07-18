using System;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Veterinario.Forms
{
    public partial class FRM_Login : Form
    {
        public FRM_Login()
        {
            InitializeComponent();
            Parametros();
        }

        private void Parametros()
        {
            txtUser.CharacterCasing = CharacterCasing.Lower;
            txtSenha.UseSystemPasswordChar = true;
            txtUser.Focus();
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

        private void Logar()
        {
            try
            {
                clsFuncionario obj_usuario = new clsFuncionario();
                obj_usuario.Login = txtUser.Text;
                obj_usuario.Senha_funcionario = CriptografarSenha(txtSenha.Text);
                obj_usuario.AutenticarFuncionario();
                if (Equals(obj_usuario.ds_msg, ""))
                {
                    Principal formP = new Principal(obj_usuario.Id_Funcionario, obj_usuario.Master_Id, this);
                    formP.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(obj_usuario.ds_msg);
                    txtSenha.Clear();
                    txtSenha.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Não foi possível se conectar ao banco!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Visualizar(object sender, EventArgs e)
        {
            if (txtSenha.UseSystemPasswordChar == false)
            {
                txtSenha.UseSystemPasswordChar = true;
            }
            else
            {
                txtSenha.UseSystemPasswordChar = false;
            } 
        }

        private void LoginEnter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Logar();
            }
        }

        private void LoginButton(object sender, EventArgs e)
        {
            Logar();
        }
    }
}
