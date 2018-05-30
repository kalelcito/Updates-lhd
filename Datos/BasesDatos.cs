using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;
namespace Datos
{
    public class BasesDatos
    {
        private DbConnection conexion = null;
        public DbCommand comando = null;
        private DbTransaction transaccion = null;
        private string cadenaConexion;
        private static DbProviderFactory factory = null;
        
        /// <summary>
        /// Crea una instancia del acceso a la base de datos.
        /// </summary>
        public BasesDatos()
        {
            
            Configurar();
        }
        /// <summary>
        /// Configura el acceso a la base de datos para su utilización.
        /// </summary>
        /// <exception cref="BaseDatosException">Si existe un error al cargar la configuración.</exception>
        public void Configurar()
        {           
            try
            {
                string proveedor = ConfigurationManager.AppSettings.Get("PROVEEDOR_ADONET");
                this.cadenaConexion = ConfigurationManager.AppSettings.Get("CADENA_CONEXION");
                BasesDatos.factory = DbProviderFactories.GetFactory(proveedor);
            }
            catch (ConfigurationException ex)
            {
                throw new BaseDatosException("Error al cargar la configuración del acceso a datos.", ex);
            }
        }
        /// <summary>
        /// Permite desconectarse de la base de datos.
        /// </summary>

        public void Configurar2()
        {
            try
            {
                string proveedor = ConfigurationManager.AppSettings.Get("PROVEEDOR_ADONET");
                this.cadenaConexion = ConfigurationManager.AppSettings.Get("CADENA_CONEXION2");
                BasesDatos.factory = DbProviderFactories.GetFactory(proveedor);
            }
            catch (ConfigurationException ex)
            {
                throw new BaseDatosException("Error al cargar la configuración del acceso a datos.", ex);
            }
        }

        public void Configurar3()
        {
            try
            {
                string proveedor = ConfigurationManager.AppSettings.Get("PROVEEDOR_ADONET");
                this.cadenaConexion = ConfigurationManager.AppSettings.Get("CADENA_CONEXION3");
                BasesDatos.factory = DbProviderFactories.GetFactory(proveedor);
            }
            catch (ConfigurationException ex)
            {
                throw new BaseDatosException("Error al cargar la configuración del acceso a datos.", ex);
            }
        }

        public void Desconectar()
        {
            if (this.conexion.State.Equals(ConnectionState.Open))
            {
                this.conexion.Close();
            }
        }
        /// <summary>
        /// Se concecta con la base de datos.
        /// </summary>
        /// <exception cref="BaseDatosException">Si existe un error al conectarse.</exception>
        public void Conectar()
        {
            if (this.conexion != null && !this.conexion.State.Equals(ConnectionState.Closed))
            {
                throw new BaseDatosException("La conexión ya se encuentra abierta.");
            }
            try
            {
                if (this.conexion == null)
                {
                    this.conexion = factory.CreateConnection();
                    this.conexion.ConnectionString = cadenaConexion;
                }
                this.conexion.Open();
            }
            catch (DataException ex)
            {
                throw new BaseDatosException("Error al conectarse a la base de datos.", ex);
            }
        }
        /// <summary>
        /// Crea un comando en base a una sentencia SQL.
        /// Ejemplo:
        /// <code>SELECT * FROM Tabla WHERE campo1=@campo1, campo2=@campo2</code>
        /// Guarda el comando para el seteo de parámetros y la posterior ejecución.
        /// </summary>
        /// <param name="sentenciaSQL">La sentencia SQL con el formato: SENTENCIA [param = @param,]</param>
        public void CrearComando(string sentenciaSQL)
        {
            this.comando = factory.CreateCommand();
            this.comando.Connection = this.conexion;
            this.comando.CommandType = CommandType.Text;
            this.comando.CommandText = sentenciaSQL;
            this.comando.CommandTimeout = this.conexion.ConnectionTimeout;
            if (this.transaccion != null)
            {
                this.comando.Transaction = this.transaccion;
            }
        }

        public void CrearComandoProcedimiento(string sentenciaSQL)
        {
            this.comando = factory.CreateCommand();
            this.comando.Connection = this.conexion;
            this.comando.CommandType = System.Data.CommandType.StoredProcedure;
            this.comando.CommandText = sentenciaSQL;
            this.comando.CommandTimeout = this.conexion.ConnectionTimeout;
            if (this.transaccion != null)
            {
                this.comando.Transaction = this.transaccion;
            }
        }


        public void AsignarParametroProcedimiento(string nombre, DbType tipo, object valor)
        {
            DbParameter param = comando.CreateParameter();
            param.ParameterName = nombre;
            param.DbType = tipo;
            param.Value = valor;
            this.comando.Parameters.Add(param);


        }        /// <summary>
        public void AsignarParametroProcedimiento(string nombre, DbType tipo, int size, Boolean salida)
        {
            DbParameter param = comando.CreateParameter();
            param.ParameterName = nombre;
            param.DbType = tipo;
            //param.Value = valor;
            param.Size = size;
            if (salida) param.Direction = ParameterDirection.Output;
            else param.Direction = ParameterDirection.Input;
            this.comando.Parameters.Add(param);

        }        /// <summary>

        public object devolverParametroProcedimiento(string nombre)
        {
            Object value;
            value = this.comando.Parameters[nombre].Value;
            return value;
        }

        /// Asigna un parámetro de tipo entero al comando creado.
        /// </summary>
        /// <param name="nombre">El nombre del parámetro.</param>
        /// <param name="valor">El valor del parámetro.</param>
        public void AsignarParametroFlotante(string nombre, string valor)
        {
            if (valor == " ") { valor = "0"; }
            AsignarParametro(nombre, "", valor.ToString());
        }
        /// <summary>
        /// Asigna un parámetro de tipo entero al comando creado.
        /// </summary>
        /// <param name="nombre">El nombre del parámetro.</param>
        /// <param name="valor">El valor del parámetro.</param>
        public void AsignarParametroEntero(string nombre, int valor)
        {

            AsignarParametro(nombre, "", valor.ToString());
        }
        /// <summary>
        /// Asigna un parámetro de tipo cadena al comando creado.
        /// </summary>
        /// <param name="nombre">El nombre del parámetro.</param>
        /// <param name="valor">El valor del parámetro.</param>
        public void AsignarParametroCadena(string nombre, string valor="")
        {
            
            valor = valor.Replace("'","''");
            AsignarParametro(nombre, "'", valor);
        }
        /// <summary>
        /// Asigna un parámetro de tipo fecha al comando creado.
        /// </summary>
        /// <param name="nombre">El nombre del parámetro.</param>
        /// <param name="valor">El valor del parámetro.</param>
        public void AsignarParametroFecha(string nombre, string valor)
        {
            AsignarParametro(nombre, "'", valor.ToString());
        }
        /// <summary>
        /// Asigna un parámetro al comando creado.
        /// </summary>
        /// <param name="nombre">El nombre del parámetro.</param>
        /// <param name="separador">El separador que será agregado al valor del parámetro.</param>
        /// <param name="valor">El valor del parámetro.</param>
        private void AsignarParametro(string nombre, string separador, string valor)
        {
            int indice = this.comando.CommandText.IndexOf(nombre);
            string prefijo = this.comando.CommandText.Substring(0, indice);
            string sufijo = this.comando.CommandText.Substring(indice + nombre.Length);
            this.comando.CommandText = prefijo + separador + valor + separador + sufijo;
        }
        //        Dim da As New SqlDataAdapter("Select * From Compras ", cnMySql)
        //Dim ds As New DataSet
        //da.Fill(ds)
        //DataGridView1.DataSource = ds.Tables(0) DataTable4
        public DataSet DS()
        {
            DbCommand command = factory.CreateCommand();
            command.CommandText = "select * from ventatmp";
            Conectar();
            command.Connection = conexion;
            DbDataAdapter da = factory.CreateDataAdapter();
            da.SelectCommand = command;
            DataSet table = new DataSet();
            da.Fill(table, "ventatmp");
            return table;
        }
        /// <summary>
        /// Ejecuta el comando creado y retorna el resultado de la consulta.
        /// </summary>
        /// <returns>El resultado de la consulta.</returns>
        /// <exception cref="BaseDatosException">Si ocurre un error al ejecutar el comando.</exception>
        public DbDataReader EjecutarConsulta()
        {
            return this.comando.ExecuteReader();
        }

        /*  public DataTable EjecutarConsultaA()
          {
             return this.comando.ExecuteReader();
          }*/
        /// <summary>
        /// Ejecuta el comando creado .
        /// </summary>
        /// <exception cref="BaseDatosException">Si ocurre un error al ejecutar el comando.</exception>
        public void EjecutarConsulta1()
        {
            this.comando.ExecuteReader();
        }
        public void EjecutarConsulta2(ref string men)
        {
            try
            {
                this.comando.ExecuteReader();
                //this.comando.ExecuteNonQuery();
                men = "";
            }
            //catch (Exception)
            catch (SqlException ex)
            {
                SqlError err = ex.Errors[0];
                string mensaje = string.Empty;
                mensaje = err.ToString();
                men = mensaje;
            }
        }

        public DbDataReader EjecutarConsulta3(ref string men)
        {
            try
            {
                men = "";
                return this.comando.ExecuteReader();
               
            }
            //catch (Exception)
            catch (SqlException ex)
            {
                SqlError err = ex.Errors[0];
                string mensaje = string.Empty;
                mensaje = err.ToString();
                men = mensaje;

                return null;
            }
        }
 
    }
}