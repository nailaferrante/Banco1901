using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System;

namespace projetoBanco1901.Models
{
    public class DAOUsuario
    {
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataReader rd = null;

        string conexao = @"Data Source=.\SqlExpress;Initial Catalog=Banco1901;user id=sa;password=senai@123";
        public List<Usuario> Listar()
        {
            List<Usuario> usuario = new List<Usuario>();
            try
            {
                con = new SqlConnection();
                con.ConnectionString = conexao;
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from usuario";
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    usuario.Add(new Usuario()
                    {
                        Idusuario = rd.GetInt32(0),
                        Nome = rd.GetString(1),
                        Login = rd.GetString(2),
                        Senha = rd.GetString(3),
                        Datacadastro = rd.GetDateTime(4),
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
            return usuario;
        }

    }
}