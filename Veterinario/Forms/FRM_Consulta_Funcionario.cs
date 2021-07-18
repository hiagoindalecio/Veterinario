using System;
using System.Windows.Forms;
using System.Text;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace Veterinario.Forms
{
    public partial class FRM_Consulta_Funcionario : Form
    {
        public FRM_Consulta_Funcionario()
        {
            InitializeComponent();
            Parametros();
        }

        private static FRM_Consulta_Funcionario instance;

        public static FRM_Consulta_Funcionario Instance()
        {
            if (instance == null)
            {
                instance = new FRM_Consulta_Funcionario();
            }
            return instance;
        }

        private void Close(object sender, FormClosedEventArgs e)
        {
            instance = null;
        }

        private void Parametros()
        {
            txtNome.MaxLength = 150;
            txtSenha1.MaxLength = 15;
            txtSenha2.MaxLength = 15;
            txtSenha1.UseSystemPasswordChar = true;
            txtSenha2.UseSystemPasswordChar = true;
            txtLogin.MaxLength = 50;
        }

        private void LoadAll(object sender, EventArgs e)
        {
            lstFuncionarios.Items.Clear();
            clsFuncionario objFuncionario = new clsFuncionario();
            MySqlDataReader sql_dr = objFuncionario.GetAllFuncionarios();
            while (sql_dr.Read())
            {
                ListViewItem item = new ListViewItem(sql_dr["id_funcionario"].ToString());
                item.SubItems.Add(sql_dr["nome_funcionario"].ToString());
                item.SubItems.Add(Convert.ToInt32(sql_dr["master_id"]) == 1 ? "Sim" : "Não");
                item.SubItems.Add(Convert.ToInt32(sql_dr["ativo_funcionario"]) == 1 ? "Sim" : "Não");
                lstFuncionarios.Items.Add(item);
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
            lstFuncionarios.Items.Clear();
            clsFuncionario objFuncionario = new clsFuncionario();
            MySqlDataReader sql_dr = objFuncionario.GetFuncionariosByFilter(txtFiltro.Text);
            while (sql_dr.Read())
            {
                ListViewItem item = new ListViewItem(sql_dr["id_funcionario"].ToString());
                item.SubItems.Add(sql_dr["nome_funcionario"].ToString());
                item.SubItems.Add(Convert.ToInt32(sql_dr["master_id"]) == 1 ? "Sim" : "Não");
                item.SubItems.Add(Convert.ToInt32(sql_dr["ativo_funcionario"]) == 1 ? "Sim" : "Não");
                lstFuncionarios.Items.Add(item);
            }
            sql_dr.Close();
        }

        private void FiltrarAtivos()
        {
            lstFuncionarios.Items.Clear();
            clsFuncionario objFuncionario = new clsFuncionario();
            MySqlDataReader sql_dr = objFuncionario.GetFuncionariosAtivosByFilter(txtFiltro.Text);
            while (sql_dr.Read())
            {
                ListViewItem item = new ListViewItem(sql_dr["id_funcionario"].ToString());
                item.SubItems.Add(sql_dr["nome_funcionario"].ToString());
                item.SubItems.Add(Convert.ToInt32(sql_dr["master_id"]) == 1 ? "Sim" : "Não");
                item.SubItems.Add(Convert.ToInt32(sql_dr["ativo_funcionario"]) == 1 ? "Sim" : "Não");
                lstFuncionarios.Items.Add(item);
            }
            sql_dr.Close();
        }

        private void EditarFuncionario(object sender, EventArgs e)
        {
            int nr_FuncionarioSelecionado;
            string nome_Funcionario = "Name";
            try
            {
                string vl_select = lstFuncionarios.SelectedItems[0].Text;
                nome_Funcionario = lstFuncionarios.SelectedItems[0].SubItems[1].Text;
                nr_FuncionarioSelecionado = Convert.ToInt32(vl_select);
            }
            catch
            {
                nr_FuncionarioSelecionado = -1;
            }
            if(nr_FuncionarioSelecionado != -1)
            {
                gbDados.Visible = true;
                gbFuncionarios.Enabled = false;
                txtNome.Text = nome_Funcionario;
                clsFuncionario objFuncionario = new clsFuncionario();
                objFuncionario.Id_Funcionario = nr_FuncionarioSelecionado;
                objFuncionario.GetFuncionarioByID();
                txtLogin.Text = objFuncionario.Login;
                cmbMaster.SelectedIndex = objFuncionario.Master_Id == true ? cmbMaster.FindString("Sim") : cmbMaster.FindString("Não");
                cmbAtivo.SelectedIndex = objFuncionario.Ativo_Funcionario == true ? cmbAtivo.FindString("Sim") : cmbAtivo.FindString("Não");

            }
        }

        private void LoadAtivos()
        {
            lstFuncionarios.Items.Clear();
            clsFuncionario objFuncionario = new clsFuncionario();
            MySqlDataReader sql_dr = objFuncionario.GetAllFuncionarioAtivos();
            while (sql_dr.Read())
            {
                ListViewItem item = new ListViewItem(sql_dr["id_funcionario"].ToString());
                item.SubItems.Add(sql_dr["nome_funcionario"].ToString());
                item.SubItems.Add(Convert.ToInt32(sql_dr["master_id"]) == 1 ? "Sim" : "Não");
                item.SubItems.Add(Convert.ToInt32(sql_dr["ativo_funcionario"]) == 1 ? "Sim" : "Não");
                lstFuncionarios.Items.Add(item);
            }
            sql_dr.Close();
        }

        private void AlteraFiltro(object sender, EventArgs e)
        {
            if (ckbAtivos.Checked)
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

        private void SenhaPadrao(object sender, EventArgs e)
        {
            if (cbxSenha.Checked)
            {
                txtSenha1.Text = "102030";
                txtSenha2.Text = "102030";
                txtSenha1.UseSystemPasswordChar = true;
                txtSenha2.UseSystemPasswordChar = true;
                txtSenha1.Enabled = false;
                txtSenha2.Enabled = false;
            }
            else
            {
                txtSenha1.Enabled = true;
                txtSenha2.Enabled = true;
                txtSenha1.Text = "";
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

        private void AtualizarFuncionario(object sender, EventArgs e)
        {
            int nr_FuncionarioSelecionado;
            try
            {
                string vl_select = lstFuncionarios.SelectedItems[0].Text;
                nr_FuncionarioSelecionado = Convert.ToInt32(vl_select);
            }
            catch
            {
                nr_FuncionarioSelecionado = -1;
            }
            if (txtNome.Text != "" && txtLogin.Text != "" && txtSenha1.Text != "" && txtSenha2.Text != "" && cmbMaster.Text != "" && nr_FuncionarioSelecionado != -1)
            {
                if (txtSenha1.Text.Equals(txtSenha2.Text))
                {
                    clsFuncionario objFunc = new clsFuncionario();
                    objFunc.Id_Funcionario = nr_FuncionarioSelecionado;
                    objFunc.Nome_Funcionario = txtNome.Text;
                    objFunc.Login = txtLogin.Text;
                    if (!ckbAtivos.Checked)
                        objFunc.Senha_funcionario = CriptografarSenha(txtSenha1.Text);
                    else
                        objFunc.Senha_funcionario = CriptografarSenha("102030");
                    if (cmbMaster.Text == "Sim")
                        objFunc.Master_Id = true;
                    else
                        objFunc.Master_Id = false;
                    if (cmbAtivo.Text == "Sim")
                        objFunc.Ativo_Funcionario = true;
                    else
                        objFunc.Ativo_Funcionario = false;
                    objFunc.update();
                    MessageBox.Show(objFunc.ds_msg);
                    if (objFunc.ds_msg == "Funcionário atualizado com sucesso!")
                    {
                        txtNome.Text = "";
                        txtLogin.Text = "";
                        txtSenha1.Text = "";
                        txtSenha2.Text = "";
                        cmbMaster.SelectedItem = cmbMaster.Items[1];
                        gbDados.Visible = false;
                        LoadAll(null, null);
                        ckbAtivos.Checked = false;
                        gbFuncionarios.Enabled = true;
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
            if (txtSenha1.UseSystemPasswordChar)
                txtSenha1.UseSystemPasswordChar = false;
            else
                txtSenha1.UseSystemPasswordChar = true;
        }

        private void VisualizarSenha2(object sender, EventArgs e)
        {
            if (txtSenha2.UseSystemPasswordChar)
                txtSenha2.UseSystemPasswordChar = false;
            else
                txtSenha2.UseSystemPasswordChar = true;
        }

        private void CancelarEdicao(object sender, EventArgs e)
        {
            gbDados.Visible = false;
            gbFuncionarios.Enabled = true;
        }
    }
}
