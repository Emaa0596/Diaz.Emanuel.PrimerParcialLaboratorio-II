using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Productos;

namespace WinFormCrud
{
    public partial class FrmProducto : Form
    {
        private Producto? Producto;
        public FrmProducto()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public Producto? Productos
        {
            get { return this.Producto; }
        }

        public FrmProducto(Producto producto)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Producto = producto;
            this.Codigo.Text = this.Producto.Codigo.ToString();
            this.Nombre.Text = this.Producto.Nombre;
            this.Precio.Text = this.Producto.Precio.ToString();
            this.Cantidad.Text = this.Producto.Cantidad.ToString();
            this.Codigo.Enabled = false;
            //this.Cantidad.Enabled = false;
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void Aceptar_Click(object sender, EventArgs e)
        {

            if (int.TryParse(Codigo.Text, out int codigo) && double.TryParse(Precio.Text,out double precio) && int.TryParse(Cantidad.Text, out int cantidad))
            {
                int codigoTextbox = codigo;
                string nombre = Nombre.Text.Trim();
                double precioTxtbox = precio;
                int unidad = cantidad;
                try
                {
                    if (unidad < 0) 
                    { 
                        throw new ErrorEnCantidadIngresadaException();
                    }
                }
                catch (ErrorEnCantidadIngresadaException ex)
                {
                    unidad = 0;
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    this.Producto = new Producto(codigoTextbox, nombre, precioTxtbox, unidad);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Ingrese datos validos", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
