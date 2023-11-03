using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Modelo
{
    public class VehiculoModelo
    {
        public int ind { get; set; }
        public int IdVehiculo { get; set; }
        public string descripcion { get; set; }
        public int idmarcar { get; set; }
        public int idmodelo { get; set; }
        public int idcolor { get; set; }
        public decimal precio { get; set; }
        public int anio { get; set; }
        public string motor { get; set; }
        public string ruedas { get; set; }
        public bool Estatus { get; set; }

    }
}
