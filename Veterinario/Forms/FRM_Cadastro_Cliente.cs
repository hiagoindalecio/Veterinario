using Refit;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Veterinario.Forms
{
    public partial class FRM_Cadastro_Cliente : Form
    {
        public FRM_Cadastro_Cliente()
        {
            InitializeComponent();
            Parametros();
        }

        private static FRM_Cadastro_Cliente instance;

        public static FRM_Cadastro_Cliente Instance()
        {
            if (instance == null)
            {
                instance = new FRM_Cadastro_Cliente();
            }
            return instance;
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

        private void Close(object sender, FormClosingEventArgs e)
        {
            instance = null;
        }

        private async void BuscarCidades(object sender, EventArgs e)
        {
            await BuscaAPI();
        }

        private void CadastrarCliente(object sender, EventArgs e)
        {
            if(txtNome.Text != "" && txtTelefone.Text != "" && txtCelular.Text != "" && txtBairro.Text != "" && txtCEP.Text != "" && txtEndereco.Text != "" && cmbCidade.Text != "" && cmbEstado.Text != "")
            {
                clsCliente objCliente = new clsCliente();
                objCliente.Nome_Cliente = txtNome.Text;
                objCliente.Telefone_Cliente = txtTelefone.Text;
                objCliente.Celular_Cliente = txtCelular.Text;
                objCliente.Bairro_Cliente = txtBairro.Text;
                objCliente.CEP = txtCEP.Text;
                objCliente.Endereco_Cliente = txtEndereco.Text;
                objCliente.Cidade_Estado = $"{ cmbCidade.Text } - { cmbEstado.Text }";
                objCliente.insert();
                MessageBox.Show(objCliente.ds_msg);
                if(objCliente.ds_msg == "Cliente inserido com sucesso!")
                {
                    txtNome.Text = "";
                    txtTelefone.Text = "";
                    txtCelular.Text = "";
                    txtBairro.Text = "";
                    txtCEP.Text = "";
                    txtEndereco.Text = "";
                    cmbCidade.Text = "";
                    cmbEstado.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Por favor preencha todos os campos para prosseguir!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
    }
}
