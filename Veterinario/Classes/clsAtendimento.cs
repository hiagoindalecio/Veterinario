using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Globalization;

namespace Veterinario
{
    class clsAtendimento
    {
        public string ds_msg;

        int mId_Atendimento, mFk_Funcionario, mFk_animal;
        string mDescricao_atendimento;
        DateTime mData_Atendimento;

        public int Id_Atendimento
        {
            get { return mId_Atendimento; }
            set { mId_Atendimento = value; }
        }
        public int Fk_Funcionario
        {
            get { return mFk_Funcionario; }
            set { mFk_Funcionario = value; }
        }
        public int Fk_animal
        {
            get { return mFk_animal; }
            set { mFk_animal = value; }
        }
        public string Descricao_atendimento
        {
            get { return mDescricao_atendimento; }
            set { mDescricao_atendimento = value; }
        }
        public DateTime Data_Atendimento
        {
            get { return mData_Atendimento; }
            set { mData_Atendimento = value; }
        }

        public MySqlDataReader GetAllAtendimentos()
        {
            clsConexao instancia_cnx = new clsConexao();
            MySqlCommand sql_cmd = new MySqlCommand("getAllAtendimentos");
            sql_cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader sql_dr = instancia_cnx.selecionar(sql_cmd);
            return sql_dr;
        }
        public MySqlDataReader GetAtendimentoByID()
        {
            clsConexao instancia_cnx = new clsConexao();
            MySqlCommand sql_cmd = new MySqlCommand("getAtendimentoById");
            sql_cmd.CommandType = CommandType.StoredProcedure;
            sql_cmd.Parameters.AddWithValue("pId_Atendimento", Id_Atendimento).Direction = ParameterDirection.Input;
            MySqlDataReader sql_dr = instancia_cnx.selecionar(sql_cmd);
            return sql_dr;
        }
        public MySqlDataReader GetAtendimentosByFilter(string filtro)
        {
            clsConexao instancia_cnx = new clsConexao();
            MySqlCommand sql_cmd = new MySqlCommand("getAtendimentosByFilter");
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
                MySqlCommand sql_cmd = new MySqlCommand("setAtendimento");
                sql_cmd.CommandType = CommandType.StoredProcedure;
                sql_cmd.Parameters.AddWithValue("pId_Atendimento", 0).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pDescricao_Atendimento", Descricao_atendimento).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pData_Atendimento", Data_Atendimento.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pFk_Funcionario", Fk_Funcionario).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pFk_animal", Fk_animal).Direction = ParameterDirection.Input;
                if (instancia_conexao.CRUD(sql_cmd))
                {
                    ds_msg = "Atendimento registrado com sucesso!";
                }
                else
                {
                    ds_msg = "Erro ao registrar atendimento! Erro na conexão com o banco.";
                }
            }
            catch (Exception ex)
            {
                ds_msg = "Erro ao registrar atendimento! " + ex.Message;
            }
            return ds_msg;
        }
    }
}
