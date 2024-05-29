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
using Tiendas;

namespace WinFormCrud
{
    public partial class FrmAlmacen : FrmProducto
    {
        public FrmAlmacen(Canasta carrito)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            base.carrito = carrito;
        }
        private void FrmAlmacen_Load(object sender, EventArgs e)
        {
            this.ActualizarVisor();
        }

        /// <summary>
        /// Agrega al carrito el producto seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void btnAgregar_Click(object sender, EventArgs e)
        {
            int indice = base.lstProductos.SelectedIndex;
            if (indice != -1)
            {
                ProductosAlmacen prod = base.listaAlmacen[indice];
                this.carrito += prod;
                this.ActualizarVisor();
                lstProductos.SelectedIndex = indice;
            }
            else
            {
                MessageBox.Show("Seleccione el producto que desea agregar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Baja la cantidad del producto seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void btnEliminar_Click(object sender, EventArgs e)
        {
            int indice = base.lstProductos.SelectedIndex;
            if (indice != -1)
            {
                ProductosAlmacen prod = base.listaAlmacen[indice];
                base.carrito -= prod;
                this.ActualizarVisor();
                lstProductos.SelectedIndex = indice;
            }
            else
            {
                MessageBox.Show("Seleccione el producto que desea eliminar", "Error", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Actualiza los productos en el listbox de panaderia
        /// </summary>
        protected override void ActualizarVisor()
        {
            lstProductos.Items.Clear();
            foreach (ProductosAlmacen productos in base.listaAlmacen)
            {
                string item = productos.Mostrar();
                lstProductos.Items.Add(item);
            }
        }

        public  List<ProductosAlmacen> CrearProductos()
        {
            ProductosAlmacen leche = new ProductosAlmacen(0001, "Leche", 1100);
            ProductosAlmacen jugoEnSobre = new ProductosAlmacen(0002, "Jugo clight", 350);
            ProductosAlmacen arroz = new ProductosAlmacen(0003, "Arroz largo", 1200);
            ProductosAlmacen aceite = new ProductosAlmacen(0004, "Aceite", 1700);
            ProductosAlmacen azucar = new ProductosAlmacen(0005, "Azucar", 1000);
            ProductosAlmacen harina = new ProductosAlmacen(0006, "Harina", 900);
            ProductosAlmacen cafe = new ProductosAlmacen(0007, "Cafe molido", 3900);
            ProductosAlmacen arvejas = new ProductosAlmacen(0008, "Arvejas", 800);
            List<ProductosAlmacen> lista = new List<ProductosAlmacen> { leche, jugoEnSobre, arroz, aceite, azucar, harina, cafe, arvejas };
            //List<Producto> retorno = ConvertirProductos(lista);
            return lista;
        }

        //private List<Producto> ConvertirProductos(List<ProductosAlmacen> lista)
        //{
        //    List<Productos.Producto> productosCasteados = new List<Productos.Producto>();
        //    foreach (ProductosAlmacen productos in lista)
        //    {
        //        Producto prod = (Producto)productos;
        //        productosCasteados.Add(prod);
        //    }
        //    return productosCasteados;
        //}

        /// <summary>
        /// Guarda los productos ordenados que se encuentran en la lista de la clase padre
        /// </summary>
        /// <param name="lista"></param>
        private void ObtenerListaOrdenada(List<Producto> lista)
        {
            List<ProductosAlmacen> listaOrdenada = new List<ProductosAlmacen>();
            foreach (Producto productos in lista)
            {
                ProductosAlmacen prod = (ProductosAlmacen)productos;
                listaOrdenada.Add(prod);
            }
            base.listaAlmacen = listaOrdenada;
        }

        /// <summary>
        /// Invoca al metodo de la clase padre, obtiene la lista ordenada (Segun criterio Clickeado) y actualiza el visor de productos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void MenorPrecioAMayorStripMenu_Click(object sender, EventArgs e)
        {
            base.MenorPrecioAMayorStripMenu_Click(sender, e);
            ObtenerListaOrdenada(base.productos);
            this.ActualizarVisor();
        }

        protected override void MayorPrecioAMenorStripMenuItem_Click(object sender, EventArgs e)
        {
            base.MayorPrecioAMenorStripMenuItem_Click(sender, e);
            ObtenerListaOrdenada(base.productos);
            this.ActualizarVisor();
        }

        protected override void MenorCantidadAMayorMenuItem_Click(object sender, EventArgs e)
        {
            base.MenorCantidadAMayorMenuItem_Click(sender, e);
            ObtenerListaOrdenada(base.productos);
            this.ActualizarVisor();
        }

        protected override void MayorCantidadAMenorMenuItem_Click(object sender, EventArgs e)
        {
            base.MayorCantidadAMenorMenuItem_Click(sender, e);
            ObtenerListaOrdenada(base.productos);
            this.ActualizarVisor();
        }
    }
}
