using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using NetAppAdoNet.Helpers;
using NetAppAdoNet.Models;
using PracticaFinal.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace PracticaFinal.Repositories
{
    
    public class RepositoryDepartamentos
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;

        public RepositoryDepartamentos()
        {
            IConfigurationRoot configuration = HelperConfiguration.GetConfiguration();

            string connectionString = configuration.GetConnectionString("SqlLocalTajamar");
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
        }
        public async Task<List<string>> GetDepartamentosAsync()
        {
            string sql = "SP_ALL_DEPARTAMENTOS";
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            List<string> departamentos = new List<string>();
            while (await this.reader.ReadAsync())
            {
                string nombre = this.reader["DNOMBRE"].ToString();
                departamentos.Add(nombre);
            }
            await this.reader.CloseAsync();
            await this.cn.CloseAsync();
            return departamentos;
        }
        public async Task<Departamentos> GetEmpleadosDepartamentoAsync(string nombredepartamento)
        {
            string sql = "SP_DEPARTAMENTOS_EMPLEADOS";
            this.com.Parameters.AddWithValue("@nombre", nombredepartamento);
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            Departamentos model = new Departamentos();
            //model.Apellidos = new List<string>();
            while (await reader.ReadAsync())
            {

             
                    model.IdDepartamento = int.Parse(reader["DEPT_NO"].ToString());
                    model.Nombre = reader["DNOMBRE"].ToString();
                    model.Localidad = reader["LOC"].ToString();              
                    model.Apellidos.Add(reader["APELLIDO"].ToString());
            }
            await this.reader.CloseAsync();
            await this.cn.CloseAsync();
            this.com.Parameters.Clear();
            return model;
        }
        public async Task<int> CreateDepartamentoAsync(int id,string nombredepartamento,string localidad)
        {
            string sql = "SP_INSERT_DEPT";
            this.com.Parameters.AddWithValue("@id", id);
            this.com.Parameters.AddWithValue("@nombre", nombredepartamento);
            this.com.Parameters.AddWithValue("@localidad", localidad);
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            int registros = await this.com.ExecuteNonQueryAsync();
            await this.cn.CloseAsync();
            this.com.Parameters.Clear();
            MessageBox.Show("departamento insertado" + registros);
            return registros;

        }
        public async Task<int> UpdateEmpleadoAsync(string apellido,string oficio, int salario)
        {
            string sql = "SP_UPDATE_EMP";
            this.com.Parameters.AddWithValue("@apellido", apellido);
            this.com.Parameters.AddWithValue("@oficio", oficio);
            this.com.Parameters.AddWithValue("@salario", salario);
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            int registros = await this.com.ExecuteNonQueryAsync();
            await this.cn.CloseAsync();
            this.com.Parameters.Clear();
            MessageBox.Show("Empleado actualizado" + registros);
            return registros;
        }
        public async Task<Empleado> GetDatosEmpleadosAsync(string apellido)
        {
            string sql = "SP_DATOS_EMPLEADOS";
            this.com.Parameters.AddWithValue("@apellido", apellido);
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            Empleado model = new Empleado();
           
            while (await reader.ReadAsync())
            {
                model.Apellido = reader["APELLIDO"].ToString();
                model.Oficio = reader["OFICIO"].ToString();
                model.Salario = int.Parse(reader["SALARIO"].ToString());
               
            }
            await this.reader.CloseAsync();
            await this.cn.CloseAsync();
            this.com.Parameters.Clear();
            return model;
        }
    }
}
