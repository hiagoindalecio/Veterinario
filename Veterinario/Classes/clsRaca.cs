using System;
using MySql.Data.MySqlClient;
using System.Data;

namespace Veterinario
{
    class clsRaca
    {
        public string ds_msg;
        int mId_raca, mFk_tipo;
        string mNome_raca;

        public int Id_Raca
        {
            get { return mId_raca; }
            set { mId_raca = value; }
        }
        public int Fk_Tipo
        {
            get { return mFk_tipo; }
            set { mFk_tipo = value; }
        }
        public string Nome_Raca
        {
            get { return mNome_raca; }
            set { mNome_raca = value; }
        }

        public MySqlDataReader GetAllRacas()
        {
            clsConexao instancia_cnx = new clsConexao();
            MySqlCommand sql_cmd = new MySqlCommand("getAllRacas");
            sql_cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader sql_dr = instancia_cnx.selecionar(sql_cmd);
            return sql_dr;
        }

        public MySqlDataReader GetRacaByID()
        {
            clsConexao instancia_cnx = new clsConexao();
            MySqlCommand sql_cmd = new MySqlCommand("getRacaById");
            sql_cmd.CommandType = CommandType.StoredProcedure;
            sql_cmd.Parameters.AddWithValue("pId_Raca", Id_Raca).Direction = ParameterDirection.Input;
            MySqlDataReader sql_dr = instancia_cnx.selecionar(sql_cmd);
            return sql_dr;
        }

        public MySqlDataReader GetRacasByTipo()
        {
            clsConexao instancia_cnx = new clsConexao();
            MySqlCommand sql_cmd = new MySqlCommand("getRacasByTipo");
            sql_cmd.CommandType = CommandType.StoredProcedure;
            sql_cmd.Parameters.AddWithValue("pFk_Tipo", Fk_Tipo).Direction = ParameterDirection.Input;
            MySqlDataReader sql_dr = instancia_cnx.selecionar(sql_cmd);
            return sql_dr;
        }

        public MySqlDataReader GetRacaByFilter(string filtro)
        {
            clsConexao instancia_cnx = new clsConexao();
            MySqlCommand sql_cmd = new MySqlCommand("getRacaByFilter");
            sql_cmd.CommandType = CommandType.StoredProcedure;
            sql_cmd.Parameters.AddWithValue("pFk_Tipo", Fk_Tipo).Direction = ParameterDirection.Input;
            sql_cmd.Parameters.AddWithValue("filtro", filtro).Direction = ParameterDirection.Input;
            MySqlDataReader sql_dr = instancia_cnx.selecionar(sql_cmd);
            return sql_dr;
        }

        public string insert()
        {
            try
            {
                clsConexao instancia_conexao = new clsConexao();
                MySqlCommand sql_cmd = new MySqlCommand("setRaca");
                sql_cmd.CommandType = CommandType.StoredProcedure;
                sql_cmd.Parameters.AddWithValue("pId_Raca", 0).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pNome_Raca", Nome_Raca).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pFk_Tipo", Fk_Tipo).Direction = ParameterDirection.Input;
                if (instancia_conexao.CRUD(sql_cmd))
                {
                    ds_msg = "Raça inserida com sucesso!";
                }
                else
                {
                    ds_msg = "Erro ao inserir raça! Erro na conexão com o banco.";
                }
            }
            catch (Exception ex)
            {
                ds_msg = "Erro ao inserir raça!" + ex.Message;
            }
            return ds_msg;
        }
    }
}
