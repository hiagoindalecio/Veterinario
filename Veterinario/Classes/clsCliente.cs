using System;
using MySql.Data.MySqlClient;
using System.Data;

namespace Veterinario
{
    class clsCliente
    {
        public string ds_msg;

        int mId_Cliente, mAtivo_Cliente;
        string mNome_Cliente, mEndereco_Cliente, mBairro_Cliente, mCidade_Estado, mCEP, mTelefone_Cliente, mCelular_Cliente;


        public int Id_Cliente
        {
            get { return mId_Cliente; }
            set { mId_Cliente = value; }
        }
        public int Ativo_Cliente
        {
            get { return mAtivo_Cliente; }
            set { mAtivo_Cliente = value; }
        }
        public string Nome_Cliente
        {
            get { return mNome_Cliente; }
            set { mNome_Cliente = value; }
        }
        public string Endereco_Cliente
        {
            get { return mEndereco_Cliente; }
            set { mEndereco_Cliente = value; }
        }
        public string Bairro_Cliente
        {
            get { return mBairro_Cliente; }
            set { mBairro_Cliente = value; }
        }
        public string Cidade_Estado
        {
            get { return mCidade_Estado; }
            set { mCidade_Estado = value; }
        }
        public string CEP
        {
            get { return mCEP; }
            set { mCEP = value; }
        }
        public string Telefone_Cliente
        {
            get { return mTelefone_Cliente; }
            set { mTelefone_Cliente = value; }
        }
        public string Celular_Cliente
        {
            get { return mCelular_Cliente; }
            set { mCelular_Cliente = value; }
        }

        public MySqlDataReader GetAllClientes()
        {
            clsConexao instancia_cnx = new clsConexao();
            MySqlCommand sql_cmd = new MySqlCommand("getAllClientes");
            sql_cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader sql_dr = instancia_cnx.selecionar(sql_cmd);
            return sql_dr;
        }

        public MySqlDataReader GetAllClientesAtivos()
        {
            clsConexao instancia_cnx = new clsConexao();
            MySqlCommand sql_cmd = new MySqlCommand("getAllClientesAtivos");
            sql_cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader sql_dr = instancia_cnx.selecionar(sql_cmd);
            return sql_dr;
        }

        public MySqlDataAdapter GetAllClientesAdapter()
        {
            clsConexao instancia_cnx = new clsConexao();
            MySqlCommand sql_cmd = new MySqlCommand("getAllClientes");
            sql_cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataAdapter sql_da = instancia_cnx.selecionarAdapter(sql_cmd);
            return sql_da;
        }

        public string VerificaAtivo()
        {
            string retorno = "";
            clsConexao instancia_cnx = new clsConexao();
            MySqlCommand sql_cmd = new MySqlCommand("verificaClienteAtivo");
            sql_cmd.CommandType = CommandType.StoredProcedure;
            sql_cmd.Parameters.AddWithValue("pId_Cliente", Id_Cliente).Direction = ParameterDirection.Input;
            MySqlDataReader sql_dr = instancia_cnx.selecionar(sql_cmd);
            if (sql_dr.Read())
            {
                int ehativo = Convert.ToInt32(sql_dr["@ehativo"]);
                if (Convert.ToInt32(ehativo) == 1)
                    retorno = "Ativo";
                else if (Convert.ToInt32(ehativo) == 0)
                    retorno = "Inativo";
                else if (Convert.ToInt32(ehativo) == -1)
                    retorno = "Cliente não encontrado no banco de dados.";
            }
            else
                retorno = "Erro ao executar procedimento 'verificaClienteAtivo'.";
            return(retorno);
        }

        public MySqlDataReader GetClientByID()
        {
            clsConexao instancia_cnx = new clsConexao();
            MySqlCommand sql_cmd = new MySqlCommand("getClienteById");
            sql_cmd.CommandType = CommandType.StoredProcedure;
            sql_cmd.Parameters.AddWithValue("pId_Cliente", Id_Cliente).Direction = ParameterDirection.Input;
            MySqlDataReader sql_dr = instancia_cnx.selecionar(sql_cmd);
            return sql_dr;
        }

        public MySqlDataReader GetClientByFilter(string filtro)
        {
            clsConexao instancia_cnx = new clsConexao();
            MySqlCommand sql_cmd = new MySqlCommand("getClienteByFilter");
            sql_cmd.CommandType = CommandType.StoredProcedure;
            sql_cmd.Parameters.AddWithValue("filtro", filtro).Direction = ParameterDirection.Input;
            MySqlDataReader sql_dr = instancia_cnx.selecionar(sql_cmd);
            return sql_dr;
        }

        public MySqlDataReader GetClientAtivoByFilter(string filtro)
        {
            clsConexao instancia_cnx = new clsConexao();
            MySqlCommand sql_cmd = new MySqlCommand("getClienteAtivoByFilter");
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
                MySqlCommand sql_cmd = new MySqlCommand("setCliente");
                sql_cmd.CommandType = CommandType.StoredProcedure;
                sql_cmd.Parameters.AddWithValue("pId_Cliente", 0).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pAtivo_cliente", 1).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pNome_Cliente", Nome_Cliente).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pEndereco_cliente", Endereco_Cliente).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pBairro_cliente", Bairro_Cliente).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pCidade_estado", Cidade_Estado).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pCep", CEP).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pTelefone_cliente", Telefone_Cliente).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pCelular_cliente", Celular_Cliente).Direction = ParameterDirection.Input;
                if (instancia_conexao.CRUD(sql_cmd))
                {
                    ds_msg = "Cliente inserido com sucesso!";
                }
                else
                {
                    ds_msg = "Erro ao inserir cliente! Erro na conexão com o banco.";
                }
            }
            catch (Exception ex)
            {
                ds_msg = "Erro ao inserir cliente! " + ex.Message;
            }
            return ds_msg;
        }

        public string update()
        {

            try
            {
                clsConexao instancia_conexao = new clsConexao();
                MySqlCommand sql_cmd = new MySqlCommand("updateCliente");
                sql_cmd.CommandType = CommandType.StoredProcedure;
                sql_cmd.Parameters.AddWithValue("pId_Cliente", Id_Cliente).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pAtivo_cliente", Ativo_Cliente).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pNome_Cliente", Nome_Cliente).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pEndereco_cliente", Endereco_Cliente).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pBairro_cliente", Bairro_Cliente).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pCidade_estado", Cidade_Estado).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pCep", CEP).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pTelefone_cliente", Telefone_Cliente).Direction = ParameterDirection.Input;
                sql_cmd.Parameters.AddWithValue("pCelular_cliente", Celular_Cliente).Direction = ParameterDirection.Input;
                if (instancia_conexao.CRUD(sql_cmd))
                {
                    ds_msg = "Cliente atualizado com sucesso!";
                }
                else
                {
                    ds_msg = "Erro ao atualizar cliente! Erro na conexão com o banco.";
                }
            }
            catch (Exception ex)
            {
                ds_msg = "Erro ao atualizar cliente! " + ex.Message;
            }
            return ds_msg;
        }
    }
}
