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
        string idmodelo = "";
        string idmarca = "";
        string idcolor = "";



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
            vehmod.ind = 1;
            vehmod.IdVehiculo = 0;
            vehmod.descripcion =  txtdescripcion.Text;
            vehmod.idmarcar = Convert.ToInt32(cmbmarca.SelectedValue.ToString()) ;
            vehmod.idmodelo = Convert.ToInt32(cmbmodelo.SelectedValue.ToString()) ;
            vehmod.idcolor = Convert.ToInt32( cmbcolor.SelectedValue.ToString());
            vehmod.precio =  Convert.ToDecimal(txtprecio.Text.Replace(",", "."));
            vehmod.anio = Convert.ToInt32(txtanio.Text);
            vehmod.motor = txtmotor.Text;
            vehmod.ruedas =  txtrueda.Text;
            vehmod.precioint = 0;
            vehcon.Crear(vehmod);

            txtdescripcion.Text = "";
            txtanio.Text = "";
            txtprecio.Text = "";
            txtrueda.Text = "";

            this.refrescar();

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
                vehmod.precioint = 0;
                vehcon.Crear(vehmod);
                this.refrescar();

            }
        }

        private void dgvroles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.id = dgvroles.Rows[e.RowIndex].Cells[0].Value.ToString();

            txtdescripcion.Text = dgvroles.Rows[e.RowIndex].Cells[1].Value.ToString();
            cmbmarca.Text = dgvroles.Rows[e.RowIndex].Cells[2].Value.ToString();
            cmbmodelo.Text = dgvroles.Rows[e.RowIndex].Cells[3].Value.ToString();
            cmbcolor.Text = dgvroles.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtprecio.Text = dgvroles.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtprecio.Text = txtprecio.Text.Replace(",", ".");

            txtanio.Text = dgvroles.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtmotor.Text = dgvroles.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtrueda.Text = dgvroles.Rows[e.RowIndex].Cells[8].Value.ToString();
            this.idmarca = dgvroles.Rows[e.RowIndex].Cells[9].Value.ToString();
            this.idcolor = dgvroles.Rows[e.RowIndex].Cells[10].Value.ToString();
            this.idmodelo = dgvroles.Rows[e.RowIndex].Cells[11].Value.ToString();



        }

        private void txtfiltro_TextChanged(object sender, EventArgs e)
        {
            string filtername = "Descripcion";
            ((DataTable)dgvroles.DataSource).DefaultView.RowFilter = string.Format("[{0}] like '%{1}%'", filtername,
                txtfiltro.Text);
        }

        private void txtanio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // solo 1 punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

        }

        private void txtprecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // solo 1 punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            int preciod = 0;
            if (MessageBox.Show("Estas seguro de actualizar este registro ?", "Eliminar registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                this.idmarca = cmbmarca.SelectedValue.ToString();
                this.idmodelo = cmbmodelo.SelectedValue.ToString();
                this.idcolor = cmbcolor.SelectedValue.ToString();



                vehmod.ind = 2;
                vehmod.IdVehiculo = Convert.ToInt32(this.id);
                vehmod.descripcion = txtdescripcion.Text;
                vehmod.idmarcar = Convert.ToInt32(this.idmarca);
                vehmod.idmodelo = Convert.ToInt32(this.idmodelo);
                vehmod.idcolor = Convert.ToInt32(this.idcolor);
              //  preciod =  decimal.Parse(txtprecio.Text);
               
                vehmod.precio = 0; // decimal.Parse(txtprecio.Text);
             //   vehmod.precio = Convert.ToDecimal(vehmod.precio);
                vehmod.anio = Convert.ToInt32(txtanio.Text);
                vehmod.motor = txtmotor.Text;
                vehmod.ruedas = txtrueda.Text;
                decimal valorDecimal = Convert.ToDecimal(txtprecio.Text);
                int valorEntero = (int)Math.Round(valorDecimal);
                vehmod.precioint = valorEntero ;
                vehcon.Crear(vehmod);

                txtdescripcion.Text = "";
                txtanio.Text = "";
                txtprecio.Text = "";
                txtrueda.Text = "";

                this.refrescar();
            }
            }
    }
}
