using System;
using System.Collections.Generic;
using System.Text;

namespace NetAppAdoNet.Models
{
    public class Departamentos
    {
        public List<string> Apellidos { get; set; }
        public int IdDepartamento { get; set; }
        public string Nombre { get; set; }
        public string Localidad { get; set; }
        public Departamentos()
        {
            this.Apellidos = new List<string>();
        }

    }
}
