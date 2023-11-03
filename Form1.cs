using Examen.Controlador;
using Examen.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen
{
    public partial class Form1 : Form
    {
        VehiculoController vehcon = new VehiculoController();
        VehiculoModelo vehmod = new VehiculoModelo();



        public Form1()
        {
            InitializeComponent();
        }

        private void refrescar()
        {
            
            dgvroles.DataSource = vehcon.GetVehiculo();
        }


        private void btnagregar_Click(object sender, EventArgs e)
        {
            this.refrescar();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
