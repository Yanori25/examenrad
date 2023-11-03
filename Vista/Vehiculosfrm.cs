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

namespace Examen.Vista
{
    public partial class Vehiculosfrm : Form
    {
        VehiculoController vehcon = new VehiculoController();
        VehiculoModelo vehmod = new VehiculoModelo();
        string id = "";


        public Vehiculosfrm()
        {
            InitializeComponent();
        }

        private void refrescarcmbs()
        {

            cmbmodelo.DataSource = vehcon.Getmodelo();
            cmbmodelo.DisplayMember = "NombreModelo";
            cmbmodelo.ValueMember = "IdModelo";


            cmbmarca.DataSource = vehcon.Getmarca();
            cmbmarca.DisplayMember = "NombreMarca";
            cmbmarca.ValueMember = "IdMarca";

            cmbcolor.DataSource = vehcon.Getcolor();
            cmbcolor.DisplayMember = "NombreColor";
            cmbcolor.ValueMember = "IdColor";

        }


        private void refrescar()
        {

            dgvroles.DataSource = vehcon.GetVehiculo();
        }

        private void Vehiculosfrm_Load(object sender, EventArgs e)
        {
            this.refrescar();
            this.refrescarcmbs();
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {

        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro de eliminar este registro ?", "Eliminar registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                vehmod.ind = 3;
                vehmod.IdVehiculo = Convert.ToInt32(this.id);
                vehmod.descripcion = "3";
                vehmod.idmarcar = 0;
                vehmod.idmodelo = 0;
                vehmod.idcolor = 0;
                vehmod.precio = 100;
                vehmod.anio = 0;
                vehmod.motor = "0";
                vehmod.ruedas = "0";
                vehcon.Crear(vehmod);
                this.refrescar();

            }
        }

        private void dgvroles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.id = dgvroles.Rows[e.RowIndex].Cells[0].Value.ToString();

        }

        private void txtfiltro_TextChanged(object sender, EventArgs e)
        {
            string filtername = "Descripcion";
            ((DataTable)dgvroles.DataSource).DefaultView.RowFilter = string.Format("[{0}] like '%{1}%'", filtername,
                txtfiltro.Text);
        }
    }
}
