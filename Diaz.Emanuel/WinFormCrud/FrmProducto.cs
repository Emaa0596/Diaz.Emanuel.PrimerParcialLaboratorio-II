using Productos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormCrud
{
    public partial class FrmProducto : Form
    {
        public List<Productos.Producto> productos;
        public FrmProducto()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.productos = new List<Productos.Producto>();
        }

        public FrmProducto(List<Productos.Producto> productos)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.productos = productos;
        }

        public List<Productos.Producto> ListaProductos
        {
            get { return this.productos; }
            set { this.productos = value; }
        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {
            ActualizarVisor();
        }

        public virtual List<Producto> CrearProductos()
        {
            List<Producto> lista = new List<Producto>();
            return lista;        
        }


        private void ActualizarVisor()
        {
            lstProductos.Items.Clear();
            foreach (Productos.Producto productos in this.productos)
            {
                string item = productos.Mostrar();
                lstProductos.Items.Add(item);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int indice = lstProductos.SelectedIndex;
            if (indice != -1)
            {
                this.productos[indice].Cantidad += 1;
                ActualizarVisor();
                lstProductos.SelectedIndex = indice;
            }
            else
            {
                MessageBox.Show("Seleccione el producto que desea agregar", "Error", MessageBoxButtons.OK);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int indice = lstProductos.SelectedIndex;
            if (indice != -1)
            {
                if (this.productos[indice].Cantidad > 0)
                {
                    this.productos[indice].Cantidad -= 1;
                    ActualizarVisor();
                }
                else
                {
                    MessageBox.Show("No hay ningun producto de este tipo agregado a la canasta", "Error", MessageBoxButtons.OK);
                }

            }
            else
            {
                MessageBox.Show("Seleccione el producto que desea eliminar", "Error", MessageBoxButtons.OK);
            }

        }

        
    }
}
