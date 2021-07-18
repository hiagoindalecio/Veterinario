using System;
using System.Windows.Forms;
using Veterinario.Forms;

namespace Veterinario
{
    public partial class Principal : Form
    {
        public static int id_userLogado;
        public static bool master_id;
        FRM_Login frm_loginLocal;
        public Principal(int id_funcionario, bool master, FRM_Login form_login)
        {
            InitializeComponent();
            frm_loginLocal = form_login;
            Parametros(id_funcionario, form_login, master);
            ValidarUser();
        }

        private void Parametros(int id_user, FRM_Login form_login, bool master)
        {
            id_userLogado = id_user;
            master_id = master;
            clsFuncionario obj_funcionario = new clsFuncionario();
            obj_funcionario.Id_Funcionario = id_user;
            obj_funcionario.GetFuncionarioByID();
            txtUserLogado.Text = obj_funcionario.Nome_Funcionario;
        }

        private void ValidarUser()
        {
            if(master_id == false)
            {
                funcionariosItem.Visible = false;
            }
        }

        private void CadastroCliente(object sender, EventArgs e)
        {
            for (int intIndex = Application.OpenForms.Count - 1; intIndex > 0; intIndex--)
            {
                if (Application.OpenForms[intIndex] != this)
                    Application.OpenForms[intIndex].Close();
            }
            FRM_Cadastro_Cliente form_atendimento = FRM_Cadastro_Cliente.Instance();
            form_atendimento.MdiParent = this;
            form_atendimento.Show();
        }

        private void ConsultaCliente(object sender, EventArgs e)
        {
            for (int intIndex = Application.OpenForms.Count - 1; intIndex > 0; intIndex--)
            {
                if (Application.OpenForms[intIndex] != this)
                    Application.OpenForms[intIndex].Close();
            }
            FRM_Consulta_Cliente form_consulta_cliente = FRM_Consulta_Cliente.Instance();
            form_consulta_cliente.MdiParent = this;
            form_consulta_cliente.Show();
        }

        private void CadastroAnimal(object sender, EventArgs e)
        {
            for (int intIndex = Application.OpenForms.Count - 1; intIndex > 0; intIndex--)
            {
                if (Application.OpenForms[intIndex] != this)
                    Application.OpenForms[intIndex].Close();
            }
            FRM_Cadastro_Animal form_cadastro_animal = FRM_Cadastro_Animal.Instance();
            form_cadastro_animal.MdiParent = this;
            form_cadastro_animal.Show();
        }

        private void BackToLogin(object sender, FormClosedEventArgs e)
        {
            frm_loginLocal.txtUser.Text = "";
            frm_loginLocal.txtSenha.Text = "";
            frm_loginLocal.txtUser.Focus();
            frm_loginLocal.Show();
        }

        private void Logoff(object sender, EventArgs e)
        {
            this.Close();
            frm_loginLocal.txtUser.Text = "";
            frm_loginLocal.txtSenha.Text = "";
            frm_loginLocal.txtUser.Focus();
            frm_loginLocal.Show();
        }

        private void ConsultaAnimal(object sender, EventArgs e)
        {
            for (int intIndex = Application.OpenForms.Count - 1; intIndex > 0; intIndex--)
            {
                if (Application.OpenForms[intIndex] != this)
                    Application.OpenForms[intIndex].Close();
            }
            FRM_ConsultaAnimais form_consultaAnimal = FRM_ConsultaAnimais.Instance();
            form_consultaAnimal.MdiParent = this;
            form_consultaAnimal.Show();
        }

        private void CadastroRaca(object sender, EventArgs e)
        {
            for (int intIndex = Application.OpenForms.Count - 1; intIndex > 0; intIndex--)
            {
                if (Application.OpenForms[intIndex] != this)
                    Application.OpenForms[intIndex].Close();
            }
            FRM_Cadastro_Raca form_cadastroRaca = FRM_Cadastro_Raca.Instance();
            form_cadastroRaca.MdiParent = this;
            form_cadastroRaca.Show();
        }

        private void CadastroTipo(object sender, EventArgs e)
        {
            for (int intIndex = Application.OpenForms.Count - 1; intIndex > 0; intIndex--)
            {
                if (Application.OpenForms[intIndex] != this)
                    Application.OpenForms[intIndex].Close();
            }
            FRM_Cadastro_Tipo form_cadastroTipo = FRM_Cadastro_Tipo.Instance();
            form_cadastroTipo.MdiParent = this;
            form_cadastroTipo.Show();
        }

        private void OpenCadastroFuncionario(object sender, EventArgs e)
        {
            for (int intIndex = Application.OpenForms.Count - 1; intIndex > 0; intIndex--)
            {
                if (Application.OpenForms[intIndex] != this)
                    Application.OpenForms[intIndex].Close();
            }
            FRM_Cadastro_Funcionarios form_cadastroFuncionarios = FRM_Cadastro_Funcionarios.Instance();
            form_cadastroFuncionarios.MdiParent = this;
            form_cadastroFuncionarios.Show();
        }

        private void Openatendimento(object sender, EventArgs e)
        {
            for (int intIndex = Application.OpenForms.Count - 1; intIndex > 0; intIndex--)
            {
                if (Application.OpenForms[intIndex] != this)
                    Application.OpenForms[intIndex].Close();
            }
            Atendimento form_atendimento = Atendimento.Instance(id_userLogado);
            form_atendimento.MdiParent = this;
            form_atendimento.Show();
        }

        private void OpenGestaoAtendimentos(object sender, EventArgs e)
        {
            for (int intIndex = Application.OpenForms.Count - 1; intIndex > 0; intIndex--)
            {
                if (Application.OpenForms[intIndex] != this)
                    Application.OpenForms[intIndex].Close();
            }
            FRM_Consulta_atendimento form_consulta_atendimento = FRM_Consulta_atendimento.Instance();
            form_consulta_atendimento.MdiParent = this;
            form_consulta_atendimento.Show();
        }

        private void OpenConsultaFuncionario(object sender, EventArgs e)
        {
            for (int intIndex = Application.OpenForms.Count - 1; intIndex > 0; intIndex--)
            {
                if (Application.OpenForms[intIndex] != this)
                    Application.OpenForms[intIndex].Close();
            }
            FRM_Consulta_Funcionario form_consulta_funcionario = FRM_Consulta_Funcionario.Instance();
            form_consulta_funcionario.MdiParent = this;
            form_consulta_funcionario.Show();
        }
    }
}
