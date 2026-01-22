using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using NetAppAdoNet.Helpers;
using NetAppAdoNet.Models;
using PracticaFinal.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PracticaFinal.Repositories
{
    #region procedures
    //    CREATE PROCEDURE SP_ALL_DEPARTAMENTOS
    //AS
    //BEGIN
    //    SET NOCOUNT ON;
    //    SELECT DNOMBRE
    //    FROM DEPT;
    //    END
    //    CREATE PROCEDURE SP_GET_DEPARTAMENTO
    //        @nombre NVARCHAR(50)
    //AS
    //BEGIN
    //    SET NOCOUNT ON;

    //    SELECT DEPT_NO, DNOMBRE, LOC
    //    FROM DEPT
    //    WHERE DNOMBRE = @nombre;
    //    END
//    CREATE PROCEDURE SP_GET_EMPLEADOS_DEPARTAMENTO
//        @idDepartamento INT
//    AS
//BEGIN
//    SET NOCOUNT ON;

//    SELECT APELLIDO
//    FROM EMP
//    WHERE DEPT_NO = @idDepartamento;
//    END

//CREATE PROCEDURE SP_INSERT_DEPT
//    @id INT,
//    @nombre NVARCHAR(50),
//    @localidad NVARCHAR(50)
//AS
//BEGIN
//    SET NOCOUNT ON;

//    INSERT INTO DEPT(DEPT_NO, DNOMBRE, LOC)
//    VALUES(@id, @nombre, @localidad);
//    END

//CREATE PROCEDURE SP_UPDATE_EMP
//    @apellido NVARCHAR(50),
//    @oficio NVARCHAR(50),
//    @salario INT
//AS
//BEGIN
//    SET NOCOUNT ON;

//    UPDATE EMP
//    SET OFICIO = @oficio,
//        SALARIO = @salario
//    WHERE APELLIDO = @apellido;
//    END

//CREATE PROCEDURE SP_DATOS_EMPLEADOS
//    @apellido NVARCHAR(50)
//AS
//BEGIN
//    SET NOCOUNT ON;

//    SELECT APELLIDO, OFICIO, SALARIO
//    FROM EMP
//    WHERE APELLIDO = @apellido;
//    END


    #endregion
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
        //public async Task<Departamentos> GetEmpleadosDepartamentoAsync(string nombredepartamento)
        //{
        //    // 1️⃣ Obtener datos del departamento
        //    string sqlDept = "SP_GET_DEPARTAMENTO";
        //    this.com.CommandType = CommandType.StoredProcedure;
        //    this.com.CommandText = sqlDept;
        //    this.com.Parameters.AddWithValue("@nombre", nombredepartamento);

        //    await this.cn.OpenAsync();
        //    this.reader = await this.com.ExecuteReaderAsync();

        //    Departamentos model = new Departamentos
        //    {
        //        Apellidos = new List<string>()
        //    };

        //    if (await reader.ReadAsync())
        //    {
        //        model.IdDepartamento = int.Parse(reader["DEPT_NO"].ToString());
        //        model.Nombre = reader["DNOMBRE"].ToString();
        //        model.Localidad = reader["LOC"].ToString();
        //    }

        //    await this.reader.CloseAsync();
        //    this.com.Parameters.Clear();

        //    // 2️⃣ Obtener empleados del departamento
        //    string sqlEmp = "SP_GET_EMPLEADOS_DEPARTAMENTO";
        //    this.com.CommandType = CommandType.StoredProcedure;
        //    this.com.CommandText = sqlEmp;
        //    this.com.Parameters.AddWithValue("@idDepartamento", model.IdDepartamento);

        //    this.reader = await this.com.ExecuteReaderAsync();

        //    while (await reader.ReadAsync())
        //    {
        //        model.Apellidos.Add(reader["APELLIDO"].ToString());
        //    }

        //    await this.reader.CloseAsync();
        //    await this.cn.CloseAsync();
        //    this.com.Parameters.Clear();

        //    return model;
        //}

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
