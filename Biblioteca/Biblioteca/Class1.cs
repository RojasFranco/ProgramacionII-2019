﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Biblioteca
{
    public static class DAO
    {
        private static SqlConnection connection;
        private static SqlCommand command;

        static DAO()
        {
            string connectionString = @"Data Source= ./SQLEXPRESS ; Initial Catalog = BDVet; Integrated Security = true;"; //@para no poner '//' y saltear
            //El integrated es para la seguridad de windows
            connection = new SqlConnection(connectionString);
            command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = System.Data.CommandType.Text;

        }

        public static void InsertarCliente(string nombre, string apellido, string dni, DateTime fechaNacimiento)
        {
            try
            {
                connection.Open();
                string comando = string.Format("INSERT INTO CLIENTE (Nombre, Apellido, Dni) VALUES ('{0}', '{1}', '{2}')", nombre, apellido, dni);
                command.CommandText = comando;
                command.ExecuteNonQuery();
            }
            /*catch (Exception)
            {

                throw;
            }*/
            finally
            {
                if(connection!=null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
    }
}