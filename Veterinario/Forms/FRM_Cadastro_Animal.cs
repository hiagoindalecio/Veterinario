using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;

namespace Veterinario.Forms
{
    public partial class FRM_Cadastro_Animal : Form
    {
        //MemoryStream ms;

        public FRM_Cadastro_Animal()
        {
            InitializeComponent();
        }

        private static FRM_Cadastro_Animal instance;

        public static FRM_Cadastro_Animal Instance()
        {
            if (instance == null)
            {
                instance = new FRM_Cadastro_Animal();
            }
            return instance;
        }

        public MySqlDataReader sql_donoSelecionado;
        private int id_dono = -1;
        public MySqlDataReader sql_tipoSelecionado;
        private int id_tipo = -1;
        public MySqlDataReader sql_racaSelecionada;
        private int id_raca = -1;

        private void Parametros()
        {
            txtNome.MaxLength = 100;
        }

        private void Close(object sender, FormClosingEventArgs e)
        {
            instance = null;
        }

        private byte[] ConvertImageToByte(System.Drawing.Image foto)
        {
            if (foto != null)
            {
                byte[] foto_array;
                using (MemoryStream stream = new MemoryStream())
                {
                    Bitmap bmp = new Bitmap(foto);
                    bmp.Save(stream, ImageFormat.Jpeg);
                    foto_array = stream.ToArray();
                }
                /*MemoryStream ms = new MemoryStream();
                picFoto.Image.Save(ms, picFoto.Image.RawFormat);
                byte[] foto_array = ms.ToArray();*/
                return (foto_array);
            } 
            else
            {
                return (null);
            }
        }

        private void ProcurarFoto(object sender, EventArgs e)
        {
            oFd1.Filter = "jpeg|*.jpg|bmp|*.bmp|all files|*.*";
            DialogResult res = oFd1.ShowDialog();
            if (res == DialogResult.OK)
            {
                picFoto.Image = Image.FromFile(oFd1.FileName);
            }
        }

        private void BuscarCliente(object sender, EventArgs e)
        {
            txtDono.Text = "";
            id_dono = -1;
            FRM_Selecionar_Cliente form_Cliente = new FRM_Selecionar_Cliente(this);
            form_Cliente.ShowDialog();
            if (sql_donoSelecionado != null)
            {
                sql_donoSelecionado.Read();
                txtDono.Text = sql_donoSelecionado["nome_cliente"].ToString();
                id_dono = Convert.ToInt32(sql_donoSelecionado["id_cliente"]);
            }
        }

        private void BuscarTipo(object sender, EventArgs e)
        {
            txtTipo.Text = "";
            id_tipo = -1;
            txtRaca.Text = "";
            id_raca = -1;
            FRM_SelecionarTipo form_Tipo = new FRM_SelecionarTipo(this, null);
            form_Tipo.ShowDialog();
            if (sql_tipoSelecionado != null)
            {
                sql_tipoSelecionado.Read();
                txtTipo.Text = sql_tipoSelecionado["nome_tipo"].ToString();
                id_tipo = Convert.ToInt32(sql_tipoSelecionado["id_tipo"]);
                btnAddRaca.Enabled = true;
            }
        }

        private void BuscarRaca(object sender, EventArgs e)
        {
            txtRaca.Text = "";
            id_raca = -1;
            FRM_SelecionarRaca form_Raca = new FRM_SelecionarRaca(this, id_tipo);
            form_Raca.ShowDialog();
            if (sql_racaSelecionada != null)
            {
                sql_racaSelecionada.Read();
                txtRaca.Text = sql_racaSelecionada["nome_raca"].ToString();
                id_raca = Convert.ToInt32(sql_racaSelecionada["id_raca"]);
            }
        }

        private void RegistrarAnimal(object sender, EventArgs e)
        {
            if(txtNome.Text != "" && txtDono.Text != "" && txtRaca.Text != "" && txtTipo.Text != "" && id_dono != -1 && id_raca != -1 && id_tipo != -1)
            {
                clsAnimal objAnimal = new clsAnimal();
                objAnimal.Nome_animal = txtNome.Text;
                if (picFoto.Image.Width != Veterinario.Properties.Resources.upload2.Width && picFoto.Image.Height != Veterinario.Properties.Resources.upload2.Height)
                {
                    objAnimal.Foto_array = ConvertImageToByte(picFoto.Image);
                    objAnimal.Nascimento = Convert.ToDateTime(dtpNascimento.Text);
                    objAnimal.Fk_dono = id_dono;
                    objAnimal.Fk_tipo = id_tipo;
                    objAnimal.Fk_raca = id_raca;
                    objAnimal.insert();
                    MessageBox.Show(objAnimal.ds_msg);
                    if (objAnimal.ds_msg == "Animal inserido com sucesso!")
                    {
                        txtNome.Text = "";
                        txtDono.Text = "";
                        id_dono = -1;
                        txtRaca.Text = "";
                        id_raca = -1;
                        txtTipo.Text = "";
                        id_tipo = -1;
                        picFoto.Image = Veterinario.Properties.Resources.upload2;
                    }
                }
                else
                {
                    if (MessageBox.Show("Tem certeza que deseja adicionar o animal sem foto?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        objAnimal.Foto_array = ConvertImageToByte(Veterinario.Properties.Resources.Vazio);
                        objAnimal.Nascimento = Convert.ToDateTime(dtpNascimento.Text);
                        objAnimal.Fk_dono = id_dono;
                        objAnimal.Fk_tipo = id_tipo;
                        objAnimal.Fk_raca = id_raca;
                        objAnimal.insert();
                        MessageBox.Show(objAnimal.ds_msg);
                        if (objAnimal.ds_msg == "Animal inserido com sucesso!")
                        {
                            txtNome.Text = "";
                            txtDono.Text = "";
                            id_dono = -1;
                            txtRaca.Text = "";
                            id_raca = -1;
                            txtTipo.Text = "";
                            id_tipo = -1;
                            picFoto.Image = Veterinario.Properties.Resources.upload2;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor preencha todos os dados para finalizar o cadastro.", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
