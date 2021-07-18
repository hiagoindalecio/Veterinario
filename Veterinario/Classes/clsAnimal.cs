using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Globalization;

namespace Veterinario
{
    class clsAnimal
    {
        public string ds_msg;
        int mId_animal, mFk_dono, mFk_tipo, mFk_raca;
        DateTime mNascimento;
        string mNome_animal;
        byte[] mFoto_array;

        public int Id_animal
        {
            get { return mId_animal; }
            set { mId_animal = value; }
        }
        public int Fk_dono
        {
            get { return mFk_dono; }
            set { mFk_dono = value; }
        }
        public int Fk_tipo
        {
            get { return mFk_tipo; }
            set { mFk_tipo = value; }
        }
        public int Fk_raca
        {
            get { return mFk_raca; }
            set { mFk_raca = value; }
        }
        public string Nome_animal
        {
            get { return mNome_animal; }
            set { mNome_animal = value; }
        }
        public byte[] Foto_array
        {
            get { return mFoto_array; }
            set { mFoto_array = value; }
        }
        public DateTime Nascimento
        {
            get { return mNascimento; }
            set { mNascimento = value; }
        }

        public MySqlDataReader GetAllAnimais()
        {
            clsConexao instancia_cnx = new clsConexao();
            MySqlCommand sql_cmd = new MySqlCommand("getAllAnimals");
            sql_cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader sql_dr = instancia_cnx.selecionar(sql_cmd);
            return sql_dr;
        }

        public MySqlDataReader GetAnimalByID()
        {
            clsConexao instancia_cnx = new clsConexao();
            MySqlCommand sql_cmd = new MySqlCommand("getAnimalById");
            sql_cmd.CommandType = CommandType.StoredProcedure;
            sql_cmd.Parameters.AddWithValue("pId_Animal", Id_animal).Direction = ParameterDirection.Input;
            MySqlDataReader sql_dr = instancia_cnx.selecionar(sql_cmd);
            return sql_dr;
        }

        public MySqlDataReader GetAnimaisByIDDono(int id_dono)
        {
            clsConexao instancia_cnx = new clsConexao();
            MySqlCommand sql_cmd = new MySqlCommand("getAnimaisByIdDono");
            sql_cmd.CommandType = CommandType.StoredProcedure;
            sql_cmd.Parameters.AddWithValue("pId_Dono", id_dono).Direction = ParameterDirection.Input;
            MySqlDataReader sql_dr = instancia_cnx.selecionar(sql_cmd);
            return sql_dr;
        }

        public MySqlDataAdapter GetAnimalByIDAdapter()
        {
            clsConexao instancia_cnx = new clsConexao();
            MySqlCommand sql_cmd = new MySqlCommand("getAnimalById");
            sql_cmd.CommandType = CommandType.StoredProcedure;
            sql_cmd.Parameters.AddWithValue("pId_Animal", Id_animal).Direction = ParameterDirection.Input;
            MySqlDataAdapter sql_dr = instancia_cnx.selecionarAdapter(sql_cmd);
            return sql_dr;
        }

        public MySqlDataReader GetAnimaisByFilter(string filtro)
        {
            clsConexao instancia_cnx = new clsConexao();
            MySqlCommand sql_cmd = new MySqlCommand("getAnimalByFilter");
            sql_cmd.CommandType = CommandType.StoredProcedure;
            sql_cmd.Parameters.AddWithValue("filtro", filtro).Direction = ParameterDirection.Input;
            MySqlDataReader sql_dr = instancia_cnx.selecionar(sql_cmd);
            return sql_dr;
        }

        public void updatePicture()
        {
            try
            {
                clsConexao instancia_cnx = new clsConexao();
                MySqlCommand sql_cmd = new MySqlCommand("updatePictureAnimal");
                sql_cmd.CommandType = CommandType.StoredProcedure;
                sql_cmd.Parameters.AddWithValue("pId_Animal", Id_animal).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.Add("pImage", MySqlDbType.TinyBlob);
                sql_cmd.Parameters["pImage"].Value = Foto_array;
                MySqlDataReader sql_dr = instancia_cnx.selecionar(sql_cmd);
                ds_msg = "Foto atualizada com sucesso!";
            }
            catch (Exception ex)
            {
                ds_msg = "Erro ao atualizar foto! " + ex.Message;
            }
        }

        public void insert()
        {
            try
            {
                clsConexao instancia_conexao = new clsConexao();
                MySqlCommand sql_cmd = new MySqlCommand("setAnimal");
                sql_cmd.CommandType = CommandType.StoredProcedure;
                sql_cmd.Parameters.AddWithValue("pId_Animal", 0).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pNome_Animal", Nome_animal).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.Add("@pImage", MySqlDbType.TinyBlob);
                sql_cmd.Parameters["@pImage"].Value = Foto_array;
                sql_cmd.Parameters.AddWithValue("pNascimento", Nascimento.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pFk_dono", Fk_dono).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pFk_tipo", Fk_tipo).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pFk_raca", Fk_raca).Direction = ParameterDirection.Input;
                if (instancia_conexao.CRUD(sql_cmd))
                {
                    ds_msg = "Animal inserido com sucesso!";
                }
                else
                {
                    ds_msg = "Erro ao inserir animal! Erro na conexão com o banco, talvez o formato da imagem não é suportado.";
                }
            }
            catch (Exception ex)
            {
                ds_msg = "Erro ao inserir animal! " + ex.Message;
            }
        }
    }
}
