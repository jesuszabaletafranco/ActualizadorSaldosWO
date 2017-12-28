/*
 * Creado por SharpDevelop.
 * Usuario: jezafran
 * Fecha: 25/09/2017
 * Hora: 3:04 p. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Globalization;
using System.Threading;
using System.Resources;
using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;
using Microsoft.Win32;
using Newtonsoft.Json;

using System.Windows.Forms;



using System.ComponentModel;
using System.Configuration.Install;


namespace ActualizadorSaldosWO.Class
{
	/// <summary>
	/// Description of Util.
	/// </summary>
	[RunInstaller(true)]
	
	public class Util
	{
		public Util()
		{
		}
		
		public static List<Conexion> Conexiones = new List<Conexion>();
		
		public static string ElapsedTime(Stopwatch watch)
        {
            TimeSpan ts = watch.Elapsed;

            // Format and display the TimeSpan value. 
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            return elapsedTime;
        }
		
		public static void SetLookupBinding( ListControl toBind,  object dataSource, string displayMember,  string valueMember )
		{
		  toBind.DisplayMember = displayMember;
		  toBind.ValueMember = valueMember;
		
		  // Only after the following line will the listbox 
		  // receive events due to binding.
		  toBind.DataSource = dataSource;
		}
		
		public static List<Conexion> GetAllConecctionStrings()
		{
			List<Conexion> lista = new List<Conexion>();
			
			ConfigurationManager.RefreshSection("connectionStrings");

				
			// Get the configuration file.
    		Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
    		// Add the connection string.
    		ConnectionStringsSection csSection = config.ConnectionStrings;
    		
    		
			//System.Windows.Forms.MessageBox.Show(ConfigurationManager.ConnectionStrings[0].ConnectionString.ToString());
			for ( int i = 0; i< ConfigurationManager.ConnectionStrings.Count; i++) {
				if(!csSection.ConnectionStrings[i].Name.Equals("LocalSqlServer")){
					var tmp = new Conexion();
					tmp.Nombre = csSection.ConnectionStrings[i].Name;
					lista.Add(tmp);
				}
			}
			return lista;
		}
		
		public static string GetConecctionString(string sCadenaConexion)
		{
			return ConfigurationManager.ConnectionStrings[sCadenaConexion].ConnectionString.Replace("Data Source=", "").Replace("Initial Catalog=", "").Replace("User ID=", "").Replace("User ID=", "").Replace("Password=", "").Trim();
		}
		
		public static void SaveConnectionString(string nombreConexion, string servidor, string baseDatos, string usuario, string clave)
		{			
    		// Get the configuration file.
    		Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
    		config.AppSettings.SectionInformation.ForceSave = true;
    		// Add the connection string.
    		ConnectionStringsSection csSection = config.ConnectionStrings;
    		csSection.ConnectionStrings.Add( new ConnectionStringSettings(nombreConexion, string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};Connection Timeout=30000", servidor, baseDatos, usuario, clave), "System.Data.SqlClient"));

    		// Save the configuration file.
    		config.Save(ConfigurationSaveMode.Modified);
    		//Debug.WriteLine("Connection string added.");
		}
		public static void UpdateConnectionString(string nombreAnterior, string nombreConexion, string servidor, string baseDatos, string usuario, string clave)
		{			
    		// Get the configuration file.
    		Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
    		config.AppSettings.SectionInformation.ForceSave = true;
    		// Add the connection string.
    		ConnectionStringsSection csSection = config.ConnectionStrings;
    		//csSection.ConnectionStrings.Add( new ConnectionStringSettings(nombreConexion, string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};", servidor, baseDatos, usuario, clave), "System.Data.SqlClient"));
    		
    		csSection.ConnectionStrings[nombreAnterior].ConnectionString = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};", servidor, baseDatos, usuario, clave);
			csSection.ConnectionStrings[nombreAnterior].Name = nombreConexion;
    		// Save the configuration file.
    		config.Save(ConfigurationSaveMode.Modified);
    		
    		//Debug.WriteLine("Connection string added.");
		}
		
		public static void EliminarCadenaConexion(string nombreConexion)
		{			
    		// Get the configuration file.
    		Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
    		config.AppSettings.SectionInformation.ForceSave = true;
    		// Add the connection string.
    		ConnectionStringsSection csSection = config.ConnectionStrings;
    		//csSection.ConnectionStrings.Add( new ConnectionStringSettings(nombreConexion, string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};", servidor, baseDatos, usuario, clave), "System.Data.SqlClient"));
    		csSection.ConnectionStrings.Remove(nombreConexion);

    		// Save the configuration file.
    		config.Save(ConfigurationSaveMode.Modified);
    		
    		//Debug.WriteLine("Connection string added.");
		}
		
		public static void CrearEstructura(Conexion conexion)
		{

			ResourceManager rm = new ResourceManager("ActualizadorSaldosWO.ResourceQuerys", Assembly.GetExecutingAssembly());
			String sql = rm.GetString("Funciones");
			
			using (SqlConnection sqlConn = new SqlConnection(conexion.ToString())) {
				sqlConn.Open();
				using (SqlCommand cm = sqlConn.CreateCommand()) {
					string pattern="[\\s](?i)GO(?-i)";
		            Regex matcher = new Regex(pattern, RegexOptions.Compiled);
		            int start = 0;
		            int end = 0;
		            Match batch=matcher.Match(sql);
		            while (batch.Success) {
		            	
		                end = batch.Index;
		                string batchQuery = sql.Substring(start, end - start).Trim();
		                MessageBox.Show(batchQuery);
		                //execute the batch
		                cm.CommandText = batchQuery;
		                cm.ExecuteNonQuery();
		                start = end + batch.Length;
		                batch = matcher.Match(sql,start);                
		            }
				}
				sqlConn.Close();
			}
		}
		
		public static void AddApplicationToStartup(string path)
		{
		    using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
		    {
		        key.SetValue("CAUpdateSaldosWO", "\"" + path + "\"");
		    }
		}
		
		public static void RemoveApplicationFromStartup()
		{
		    using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
		    {
		        key.DeleteValue("CAUpdateSaldosWO", false);
		    }
		}
		
		public static List<DiasSemana> Dias()
		{
			List<DiasSemana> lista = new List<DiasSemana>();
			lista.Add(new DiasSemana{ Codigo = 0, Nombre="Domingo"});
			lista.Add(new DiasSemana{ Codigo = 1, Nombre="Lunes"});
			lista.Add(new DiasSemana{ Codigo = 2, Nombre="Martes"});
			lista.Add(new DiasSemana{ Codigo = 3, Nombre="Miercoles"});
			lista.Add(new DiasSemana{ Codigo = 4, Nombre="Jueves"});
			lista.Add(new DiasSemana{ Codigo = 5, Nombre="Viernes"});
			lista.Add(new DiasSemana{ Codigo = 6, Nombre="Sabado"});
			return lista;
		}
		
		public static bool CheckAutoRunStatus()
		{
		    RegistryKey winLogonKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
		    string currentKey = winLogonKey.GetValue("CAUpdateSaldosWO").ToString();
		    System.Windows.Forms.MessageBox.Show(currentKey);
		    if (currentKey == "0")
		        return (false);
		    return (true);
		}
		
		public static void AddConexion(Conexion conexion){
			Util.Conexiones.Add(conexion);
			Util.SerializeConexiones(Util.Conexiones);
			Util.Conexiones = Util.DeserializeConexiones();
		}
		public static void DelConexion(Conexion conexion){
			Util.Conexiones.Remove(conexion);
			Util.SerializeConexiones(Util.Conexiones);
			Util.Conexiones = Util.DeserializeConexiones();
		}
		
		public static void SerializeConexiones(List<Conexion> conexiones)
		{
			string json = JsonConvert.SerializeObject(conexiones, Formatting.Indented);
			File.WriteAllText("tareas.dat", json);
		}
		
		public static List<Conexion> DeserializeConexiones()
		{
			List<Conexion> conexiones = new List<Conexion>();
			if(File.Exists("tareas.dat"))
			{
				string json = File.ReadAllText("tareas.dat");
				conexiones = JsonConvert.DeserializeObject<List<Conexion>>(json);
			}
			return conexiones;
		}
		
		public static bool EsCuentaTemporal(string cuenta){
			
			int digito = int.Parse(cuenta.Substring(0,1));
			return digito >= 4 && digito <= 7;
		}
	}
}
