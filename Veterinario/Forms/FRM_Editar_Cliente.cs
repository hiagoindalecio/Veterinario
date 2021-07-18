using Refit;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

namespace Veterinario.Forms
{
    public partial class FRM_Editar_Cliente : Form
    {
        int id_Cliente;
        public FRM_Editar_Cliente(int id)
        {
            InitializeComponent();
            id_Cliente = id;
            ObterDados();
            Parametros();
        }

        private void Parametros()
        {
            txtTelefone.MaxLength = 13;
            txtCelular.MaxLength = 14;
            txtNome.MaxLength = 150;
            txtEndereco.MaxLength = 200;
            txtBairro.MaxLength = 50;
            txtCEP.MaxLength = 9;
        }

        private void ValidarTelefone(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)(Keys.Back))
            {
                e.Handled = false;
                if (e.KeyChar == (char)(Keys.Back))
                {
                    txtTelefone.Text = "";
                }
                else
                {
                    if (txtTelefone.Text.Length == 0)
                    {
                        txtTelefone.Text += "(";
                    }
                    else if (txtTelefone.Text.Length == 3)
                    {
                        txtTelefone.Text += ")";
                    }
                    else if (txtTelefone.Text.Length == 8)
                    {
                        txtTelefone.Text += "-";
                    }
                    txtTelefone.SelectionStart = txtTelefone.Text.Length + 1;
                }
            }
            else
                e.Handled = true;
        }

        private void ValidarCelular(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)(Keys.Back))
            {
                e.Handled = false;
                if (e.KeyChar == (char)(Keys.Back))
                {
                    txtCelular.Text = "";
                }
                else
                {
                    if (txtCelular.Text.Length == 0)
                    {
                        txtCelular.Text += "(";
                    }
                    else if (txtCelular.Text.Length == 3)
                    {
                        txtCelular.Text += ")";
                    }
                    else if (txtCelular.Text.Length == 8)
                    {
                        txtCelular.Text += "-";
                    }
                    else if (txtCelular.Text.Length == 13)
                    {
                        string string_alterada = txtCelular.Text.Replace("-", string.Empty);
                        txtCelular.Text = string_alterada;
                        txtCelular.SelectionStart = 0;
                        txtCelular.Text = txtCelular.Text.Insert(9, "-");
                    }
                    txtCelular.SelectionStart = txtCelular.Text.Length + 1;
                }
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

        private void ValidarCEP(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == (char)(Keys.Back))
            {
                e.Handled = false;
                if (e.KeyChar == (char)(Keys.Back))
                {
                    txtCEP.Text = "";
                }
                else if (txtCEP.Text.Length == 5)
                {
                    txtCEP.Text += "-";
                    txtCEP.SelectionStart = txtCEP.TextLength + 1;
                }
            }
            else
            {
                e.Handled = true;
            }
        }

        private void Cancel(object sender, EventArgs e)
        {
            this.Close();
        }

        async Task BuscaAPI()
        {
            try
            {
                cmbCidade.Items.Clear();
                var cityClient = RestService.For<iApiService>("http://educacao.dadosabertosbr.com");
                var cities = await cityClient.GetCitiesAsync(cmbEstado.Text);
                var wrong = cities.Split(',');
                for (int i = 0; i < wrong.Length; i++)
                {
                    var city = wrong[i].Split(':');
                    cmbCidade.Items.Add(city[1].ToString().Replace("\"", "").Replace("]", ""));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao utilizar a API, por favor contate o suporte.\n{ex} ERRO :(");
            }
        }

        private async void ObterDados()
        {
            try
            {
                clsCliente objCliente = new clsCliente();
                objCliente.Id_Cliente = id_Cliente;
                MySqlDataReader dr_Cliente = objCliente.GetClientByID();
                if(dr_Cliente.Read())
                {
                    txtNome.Text = dr_Cliente["nome_cliente"].ToString();
                    txtEndereco.Text = dr_Cliente["endereco_cliente"].ToString();
                    txtBairro.Text = dr_Cliente["bairro_cliente"].ToString();
                    string cidade_estado = dr_Cliente["cidade_estado"].ToString();
                    var cidade_est = cidade_estado.Split('-');
                    cmbEstado.SelectedIndex = cmbEstado.FindString(Regex.Replace(cidade_est[1], @"\s+", ""));
                    await BuscaAPI();
                    cmbCidade.SelectedIndex = cmbCidade.FindString(cidade_est[0].Remove(cidade_est[0].Length -1));
                    txtCEP.Text = dr_Cliente["cep"].ToString();
                    txtTelefone.Text = dr_Cliente["telefone_cliente"].ToString();
                    txtCelular.Text = dr_Cliente["celular_cliente"].ToString();
                    int ativo = Convert.ToInt32(dr_Cliente["ativo_cliente"]);
                    if(ativo == 1)
                    {
                        cmbAtivo.SelectedIndex = cmbAtivo.FindString("Sim");
                    }
                    else
                    {
                        cmbAtivo.SelectedIndex = cmbAtivo.FindString("Não");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Erro ao obter dados!", "Erro");
            }
            

        }

        private async void BuscarCidades(object sender, EventArgs e)
        {
            await BuscaAPI();
        }

        private void AtualizarCliente(object sender, EventArgs e)
        {
            if (txtNome.Text != "" && txtTelefone.Text != "" && txtCelular.Text != "" && txtBairro.Text != "" && txtCEP.Text != "" && txtEndereco.Text != "" && cmbCidade.Text != "" && cmbEstado.Text != "" && cmbAtivo.Text != "")
            {
                clsCliente objCliente = new clsCliente();
                objCliente.Id_Cliente = id_Cliente;
                objCliente.Nome_Cliente = txtNome.Text;
                objCliente.Telefone_Cliente = txtTelefone.Text;
                objCliente.Celular_Cliente = txtCelular.Text;
                objCliente.Bairro_Cliente = txtBairro.Text;
                objCliente.CEP = txtCEP.Text;
                objCliente.Endereco_Cliente = txtEndereco.Text;
                objCliente.Cidade_Estado = $"{ cmbCidade.Text } - { cmbEstado.Text }";
                objCliente.Ativo_Cliente = cmbAtivo.Text == "Sim" ? 1 : 0;
                objCliente.update();
                MessageBox.Show(objCliente.ds_msg);
                if (objCliente.ds_msg == "Cliente atualizado com sucesso!")
                {
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Por favor preencha todos os campos para prosseguir!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
