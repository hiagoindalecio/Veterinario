using System;
using MySql.Data.MySqlClient;
using System.Data;

namespace Veterinario
{
    class clsFuncionario
    {
        public string ds_msg;

        int mId_Fucionario;
        string mNome_Funcionario, mSenha_funcionario, mLogin;
        bool mMaster_Id, mAtivo_Funcionario;

        public int Id_Funcionario
        {
            get { return mId_Fucionario; }
            set { mId_Fucionario = value; }
        }
        public bool Master_Id
        {
            get { return mMaster_Id; }
            set { mMaster_Id = value; }
        }
        public bool Ativo_Funcionario
        {
            get { return mAtivo_Funcionario; }
            set { mAtivo_Funcionario = value; }
        }
        public string Nome_Funcionario
        {
            get { return mNome_Funcionario; }
            set { mNome_Funcionario = value; }
        }
        public string Senha_funcionario
        {
            get { return mSenha_funcionario; }
            set { mSenha_funcionario = value; }
        }
        public string Login
        {
            get { return mLogin; }
            set { mLogin = value; }
        }

        public MySqlDataReader GetAllFuncionarios()
        {
            clsConexao instancia_cnx = new clsConexao();
            MySqlCommand sql_cmd = new MySqlCommand("getAllFuncionarios");
            sql_cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader sql_dr = instancia_cnx.selecionar(sql_cmd);
            return sql_dr;
        }

        public void GetFuncionarioByID()
        {
            clsConexao instancia_conexao = new clsConexao();
            MySqlCommand sql_cmd = new MySqlCommand("getFuncionarioById");
            sql_cmd.CommandType = CommandType.StoredProcedure;
            sql_cmd.Parameters.AddWithValue("pId_Funcionario", Id_Funcionario).Direction = ParameterDirection.Input;
            MySqlDataReader sql_dr = instancia_conexao.selecionar(sql_cmd);
            if (sql_dr.Read())
            {
                Nome_Funcionario = sql_dr["nome_funcionario"].ToString();
                Senha_funcionario = sql_dr["senha_funcionario"].ToString();
                Login = sql_dr["login"].ToString();
                Master_Id = Convert.ToBoolean(sql_dr["master_id"]);
                Ativo_Funcionario = Convert.ToBoolean(sql_dr["ativo_funcionario"]);
            }
        }

        public MySqlDataReader GetAllFuncionarioAtivos()
        {
            clsConexao instancia_cnx = new clsConexao();
            MySqlCommand sql_cmd = new MySqlCommand("getAllFuncionariosAtivos");
            sql_cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader sql_dr = instancia_cnx.selecionar(sql_cmd);
            return sql_dr;
        }

        public MySqlDataReader GetFuncionariosByFilter(string filtro)
        {
            clsConexao instancia_cnx = new clsConexao();
            MySqlCommand sql_cmd = new MySqlCommand("getFuncionarioByFilter");
            sql_cmd.CommandType = CommandType.StoredProcedure;
            sql_cmd.Parameters.AddWithValue("filtro", filtro).Direction = ParameterDirection.Input;
            MySqlDataReader sql_dr = instancia_cnx.selecionar(sql_cmd);
            return sql_dr;
        }

        public MySqlDataReader GetFuncionariosAtivosByFilter(string filtro)
        {
            clsConexao instancia_cnx = new clsConexao();
            MySqlCommand sql_cmd = new MySqlCommand("getFuncionarioAtivoByFilter");
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
                MySqlCommand sql_cmd = new MySqlCommand("setFuncionario");
                sql_cmd.CommandType = CommandType.StoredProcedure;
                sql_cmd.Parameters.AddWithValue("pId_Funcionario", 0).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pMaster_Id", Master_Id).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pAtivo_Funcionario", Ativo_Funcionario).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pLogin", Login).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pNome_Funcionario", Nome_Funcionario).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pSenha_Funcionario", Senha_funcionario).Direction = ParameterDirection.Input;
                if (instancia_conexao.CRUD(sql_cmd))
                {
                    ds_msg = "Funcionário inserido com sucesso!";
                }
                else
                {
                    ds_msg = "Erro ao inserir funcionário! Erro na conexão com o banco.";
                }
            }
            catch (Exception ex)
            {
                ds_msg = "Erro ao inserir funcionário! " + ex.Message;
            }
            return ds_msg;
        }

        public string update()
        {
            try
            {
                clsConexao instancia_conexao = new clsConexao();
                MySqlCommand sql_cmd = new MySqlCommand("updateFuncionario");
                sql_cmd.CommandType = CommandType.StoredProcedure;
                sql_cmd.Parameters.AddWithValue("pId_Funcionario", Id_Funcionario).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pMaster_Id", Master_Id).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pAtivo_Funcionario", Ativo_Funcionario).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pLogin", Login).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pNome_Funcionario", Nome_Funcionario).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pSenha_Funcionario", Senha_funcionario).Direction = ParameterDirection.Input;
                if (instancia_conexao.CRUD(sql_cmd))
                {
                    ds_msg = "Funcionário atualizado com sucesso!";
                }
                else
                {
                    ds_msg = "Erro ao atualizar funcionário! Erro na conexão com o banco.";
                }
            }
            catch (Exception ex)
            {
                ds_msg = "Erro ao atualizar funcionário! " + ex.Message;
            }
            return ds_msg;
        }

        public void AutenticarFuncionario()
        {
            clsConexao instancia_conexao = new clsConexao();
            MySqlCommand sql_cmd = new MySqlCommand("autenticarFuncionario");
            sql_cmd.CommandType = CommandType.StoredProcedure;
            sql_cmd.Parameters.AddWithValue("pLogin_Funcionario", Login).Direction = ParameterDirection.Input;
            sql_cmd.Parameters.AddWithValue("pSenha_Funcionario", Senha_funcionario).Direction = ParameterDirection.Input;
            MySqlDataReader sql_dr = instancia_conexao.selecionar(sql_cmd);
            if (sql_dr.Read())
            {
                if (Convert.ToInt32(sql_dr["ativo_funcionario"]) == 0)
                {
                    ds_msg = "Funcionário inativo!";
                }
                else
                {
                    Id_Funcionario = Convert.ToInt32(sql_dr["id_funcionario"].ToString());
                    Nome_Funcionario = sql_dr["nome_funcionario"].ToString();
                    Master_Id = Convert.ToBoolean(sql_dr["master_id"]);
                    ds_msg = "";
                }
            }
            else
            {
                ds_msg = "Usuario/senha inválidos";
            }
        }
    }
}