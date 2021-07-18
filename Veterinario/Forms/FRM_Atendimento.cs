using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Veterinario.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace Veterinario
{
    public partial class Atendimento : Form
    {
        public Atendimento(int idUsuario)
        {
            InitializeComponent();
            id_user = idUsuario;
            Parametros();
        }

        private static Atendimento instance;

        public MySqlDataReader sql_AnimalSelecionado;
        public int id_animal;
        public int id_dono;
        public int id_user;

        public void Parametros()
        {
            txtDescricao.MaxLength = 250;
        }

        public static Atendimento Instance(int idUsuario)
        {
            if (instance == null)
            {
                instance = new Atendimento(idUsuario);
            }
            return instance;
        }

        private void Close(object sender, FormClosedEventArgs e)
        {
            instance = null;
        }

        private void BuscarAnimal(object sender, EventArgs e)
        {
            txtAnimal.Text = "";
            txtDono.Text = "";
            id_animal = -1;
            id_dono = -1;
            picFoto.Image = Veterinario.Properties.Resources.Vazio;
            FRM_SelcionarAnimal frm_selectAnimal = new FRM_SelcionarAnimal(this);
            frm_selectAnimal.ShowDialog();
            if(sql_AnimalSelecionado != null)
            {
                sql_AnimalSelecionado.Read();
                txtAnimal.Text = sql_AnimalSelecionado["nome_animal"].ToString();
                id_animal = Convert.ToInt32(sql_AnimalSelecionado["id_animal"]);
                id_dono = Convert.ToInt32(sql_AnimalSelecionado["fk_dono"]);
                clsAnimal objAnimal = new clsAnimal();
                objAnimal.Id_animal = id_animal;
                MySqlDataAdapter sql_da = objAnimal.GetAnimalByIDAdapter();
                sql_da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                DataSet ds = new DataSet();
                sql_da.Fill(ds, "tb_animal");
                DataTable table = new DataTable();
                sql_da.Fill(table);
                picFoto.Image = null;
                if (ds.Tables[0].Rows[0][0] != System.DBNull.Value)
                {
                    byte[] foto_array = (byte[])ds.Tables[0].Rows[0][2];
                    MemoryStream ms = new MemoryStream(foto_array);
                    try
                    {
                        picFoto.Image = Image.FromStream(ms);
                    }
                    catch
                    {
                        MessageBox.Show("Erro ao carregar imagem", "ERRO");
                    }
                }
                sql_da.Dispose();
                clsCliente objCliente = new clsCliente();
                objCliente.Id_Cliente = id_dono;
                MySqlDataReader sql_dr = objCliente.GetClientByID();
                if (sql_dr.Read())
                {
                    txtDono.Text = sql_dr["nome_cliente"].ToString();
                }
            }
        }

        private void RegistrarAtendimento(object sender, EventArgs e)
        {
            if(id_animal != -1 && id_user != -1 && txtDescricao.Text != "")
            {
                clsAtendimento objAtendimento = new clsAtendimento();
                objAtendimento.Fk_animal = id_animal;
                objAtendimento.Fk_Funcionario = id_user;
                objAtendimento.Descricao_atendimento = txtDescricao.Text;
                DateTime dt = DateTime.Now;
                objAtendimento.Data_Atendimento = dt.Date;
                objAtendimento.insert();
                MessageBox.Show(objAtendimento.ds_msg);
                id_animal = -1;
                id_dono = -1;
                txtAnimal.Text = "";
                txtDono.Text = "";
                txtDescricao.Text = "";
                picFoto.Image = Veterinario.Properties.Resources.Vazio;
            }
            else
            {
                MessageBox.Show("Preencha todos os campos para registrar um novo atendimento.", "Atenção");
            }
        }

        private void ValidacaoDescricao(object sender, KeyPressEventArgs e)
        {

        }
    }
}
