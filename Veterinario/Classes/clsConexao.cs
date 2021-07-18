using System;
using MySql.Data.MySqlClient;
using System.Data;

namespace Veterinario
{
    class clsConexao
    {
        string ds_erro;

        public MySqlConnection instancia_conexao = new MySqlConnection();

        public MySqlConnection conectar()
        {
            try
            {
                //instancia_conexao.ConnectionString = "Server=" + ipServer + "; Port=" + portServer + "; Database='" + nameDb + "'; Uid='" + loginServer + "'; Pwd='" + senhaServer + "';";
                instancia_conexao.ConnectionString = "Server=127.0.0.1; Port=3306; Database='db_vet'; Uid='root'; Pwd='';";
                instancia_conexao.Open();
            }
            catch (Exception ex)
            {
                ds_erro = ex.Message;
            }

            return instancia_conexao;
        }
        public void desconectar()
        {
            instancia_conexao.Close();
        }
        //INSERT, UPDADE, DELETE
        public bool CRUD(MySqlCommand sql_cmd)
        {
            try
            {
                conectar();
                sql_cmd.Connection = instancia_conexao;
                sql_cmd.ExecuteReader(CommandBehavior.SingleRow);
                desconectar();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        //SELECT
        public MySqlDataReader selecionar(MySqlCommand sql_cmd)
        {
            conectar();
            sql_cmd.Connection = instancia_conexao;
            MySqlDataReader sql_dr = sql_cmd.ExecuteReader(CommandBehavior.Default);
            return sql_dr;
        }

        public MySqlDataAdapter selecionarAdapter(MySqlCommand sql_cmd)
        {
            conectar();
            sql_cmd.Connection = instancia_conexao;
            MySqlDataAdapter sql_da = new MySqlDataAdapter(sql_cmd);
            return sql_da;
        }
    }
}
