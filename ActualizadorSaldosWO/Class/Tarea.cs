/*
 * Creado por SharpDevelop.
 * Usuario: jezafran
 * Fecha: 23/12/2017
 * Hora: 9:11 a. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;

namespace ActualizadorSaldosWO.Class
{
	/// <summary>
	/// Description of Tarea.
	/// </summary>
	public class Tarea
	{
		public Tarea()
		{
			Dias = new List<DiasSemana>();
		}
		public List<DiasSemana> Dias { set; get; }
		public DateTime Hora { set; get; }
	}
}
