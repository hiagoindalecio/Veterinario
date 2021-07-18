using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Data;

namespace Veterinario.Forms
{
    public partial class FRM_Editar_Animal : Form
    {
        private int id_animal = -1;
        public FRM_Editar_Animal(int id)
        {
            InitializeComponent();
            Parametros(id);
        }

        private void Parametros(int id)
        {
            clsAnimal objAnimal = new clsAnimal();
            objAnimal.Id_animal = id;
            MySqlDataReader dr_animal = objAnimal.GetAnimalByID();
            if (dr_animal.Read())
            {
                txtNome.Text = dr_animal["nome_animal"].ToString();
                picFoto.Image = null;
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
            }
            id_animal = id;
        }

        private void Close(object sender, EventArgs e)
        {
            this.Close();
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

        private void AtualizarAnimal(object sender, EventArgs e)
        {
            if (txtNome.Text != "" && id_animal != -1)
            {
                clsAnimal objAnimal = new clsAnimal();
                objAnimal.Id_animal = id_animal;
                if (picFoto.Image.Width != 0 && picFoto.Image.Height != 0)
                {
                    objAnimal.Foto_array = ConvertImageToByte(picFoto.Image);
                    objAnimal.updatePicture();
                    MessageBox.Show(objAnimal.ds_msg);
                    if (objAnimal.ds_msg == "Foto atualizada com sucesso!")
                    {
                        this.Close();
                    }
                }
                else
                {
                    if (MessageBox.Show("Tem certeza que deseja adicionar o animal sem foto?", "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        objAnimal.Foto_array = ConvertImageToByte(Veterinario.Properties.Resources.Vazio);
                        objAnimal.updatePicture();
                        MessageBox.Show(objAnimal.ds_msg);
                        if (objAnimal.ds_msg == "Foto atualizada com sucesso!")
                        {
                            this.Close();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Erro de obtenção de dados, contate o suporte.", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
