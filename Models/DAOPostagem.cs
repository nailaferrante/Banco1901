using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System;

namespace projetoBanco1901.Models
{
    public class DAOPostagem
    {
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataReader rd = null;

        string conexao = @"Data Source=.\SqlExpress;Initial Catalog=Banco1901;user id=sa;password=senai@123";
        public List<Postagem> Listar()
        {
            List<Postagem> postagem = new List<Postagem>();
            try
            {
                con = new SqlConnection();
                con.ConnectionString = conexao;
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from postagem";
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    postagem.Add(new Postagem()
                    {
                        Idpostagem = rd.GetInt32(0),
                        Idtopico = rd.GetInt32(1),
                        Idusuario = rd.GetInt32(2),
                        Mensagem = rd.GetString(3),
                        Datapublicacao = rd.GetDateTime(4),
                    });
                }
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return postagem;
        }
        public bool Cadastrar(Postagem postagem){
            bool resultado = false;
            try {
                con = new SqlConnection(conexao);
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into postagem(Idtopico,Idusuario,Mensagem) values(@n,@e,@h)"; // cidades é o nome da tabela
                cmd.Parameters.AddWithValue("@n",postagem.Idtopico);
                cmd.Parameters.AddWithValue("@e",postagem.Idusuario);
                cmd.Parameters.AddWithValue("@h",postagem.Mensagem);

                int r = cmd.ExecuteNonQuery();
                if(r > 0)
                resultado = true;

                cmd.Parameters.Clear();
            }
            catch(SqlException se){
                throw new Exception(se.Message);
            }
            catch(Exception ex){
                throw new Exception(ex.Message);
            }
            finally{
                con.Close();
            }
            return resultado;
        }

    }
}