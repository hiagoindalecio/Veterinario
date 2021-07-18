using System;
using MySql.Data.MySqlClient;
using System.Data;

namespace Veterinario
{
    class clsTipo
    {
        public string ds_msg;
        int mId_tipo;
        string mNome_tipo;
        public int Id_tipo
        {
            get { return mId_tipo; }
            set { mId_tipo = value; }
        }
        public string Nome_tipo
        {
            get { return mNome_tipo; }
            set { mNome_tipo = value; }
        }

        public MySqlDataReader GetAllTipos()
        {
            clsConexao instancia_cnx = new clsConexao();
            MySqlCommand sql_cmd = new MySqlCommand("getAllTipos");
            sql_cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader sql_dr = instancia_cnx.selecionar(sql_cmd);
            return sql_dr;
        }
        public MySqlDataReader GetTipoByID()
        {
            clsConexao instancia_cnx = new clsConexao();
            MySqlCommand sql_cmd = new MySqlCommand("getTipoById");
            sql_cmd.CommandType = CommandType.StoredProcedure;
            sql_cmd.Parameters.AddWithValue("pId_Tipo", Id_tipo).Direction = ParameterDirection.Input;
            MySqlDataReader sql_dr = instancia_cnx.selecionar(sql_cmd);
            return sql_dr;
        }
        public MySqlDataReader GetTiposByFilter(string filtro)
        {
            clsConexao instancia_cnx = new clsConexao();
            MySqlCommand sql_cmd = new MySqlCommand("getTipoByFilter");
            sql_cmd.CommandType = CommandType.StoredProcedure;
            sql_cmd.Parameters.AddWithValue("filtro", filtro).Direction = ParameterDirection.Input;
            MySqlDataReader sql_dr = instancia_cnx.selecionar(sql_cmd);
            return sql_dr;
        }

        public string insert()
        {
            try
            {
                clsConexao instancia_conexao = new clsConexao();
                MySqlCommand sql_cmd = new MySqlCommand("setTipo");
                sql_cmd.CommandType = CommandType.StoredProcedure;
                sql_cmd.Parameters.AddWithValue("pId_Tipo", 0).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pNome_Tipo", Nome_tipo).Direction = ParameterDirection.Input;
                if (instancia_conexao.CRUD(sql_cmd))
                {
                    ds_msg = "Tipo inserido com sucesso!";
                }
                else
                {
                    ds_msg = "Erro ao inserir tipo! Erro na conexão com o banco.";
                }
            }
            catch (Exception ex)
            {
                ds_msg = "Erro ao inserir tipo! " + ex.Message;
            }
            return ds_msg;
        }
    }
}
