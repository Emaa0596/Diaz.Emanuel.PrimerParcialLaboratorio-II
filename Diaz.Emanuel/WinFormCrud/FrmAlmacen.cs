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
using Usuarios;

namespace WinFormCrud
{
    public partial class FrmAlmacen : FrmTiendas
    {
        /// <summary>
        /// Inicializa el formulario y configura su posicion
        /// </summary>
        /// <param name="carrito">Canasta que se envia a la clase base</param>
        public FrmAlmacen(Canasta carrito)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            base.carrito = carrito;
        }

        /// <summary>
        /// Configura los permisos segun perfil de usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmAlmacen_Load(object sender, EventArgs e)
        {
            base.ConfigurarPermisos();
            this.ActualizarVisor();
        }

        /// <summary>
        /// Agrega al carrito el producto seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void btnAgregar_Click(object sender, EventArgs e)
        {
            if (base.lstViewProductos.SelectedIndices.Count > 0)
            {
                int indice = lstViewProductos.SelectedIndices[0];
                ProductosAlmacen prod = base.listaAlmacen[indice];
                if (prod.Cantidad >= 5)
                {
                    base.DispararEventoCantidadMaximaPermitida();
                }
                else
                {
                    base.carrito += prod;
                    Datos.basesql.ModificarProductoAlmacen(prod);
                    this.ActualizarVisor();
                    lstViewProductos.Items[indice].Selected = true;
                }
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
            if (base.lstViewProductos.SelectedIndices.Count > 0)
            {
                int indice = lstViewProductos.SelectedIndices[0];
                ProductosAlmacen prod = base.listaAlmacen[indice];
                if (prod.Cantidad == 0)
                {
                    base.DispararEventoCantidadMaximaPermitida();
                }
                else
                {
                    base.carrito -= prod;
                    Datos.basesql.ModificarProductoAlmacen(prod);
                    this.ActualizarVisor();
                    lstViewProductos.Items[indice].Selected = true;
                }
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
            lstViewProductos.Items.Clear();
            foreach (ProductosAlmacen productos in base.listaAlmacen)
            {
                ListViewItem item = new ListViewItem(productos.Nombre);
                item.SubItems.Add(productos.Precio.ToString());
                item.SubItems.Add(productos.Cantidad.ToString());
                lstViewProductos.Items.Add(item);
            }
        }

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

        /// <summary>
        /// Crea un producto siempre y cuando no exista en la lista
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void CrearProductoStripMenu_Click(object sender, EventArgs e)
        {
            FrmProducto nuevoProducto = new FrmProducto();
            DialogResult dialogo = nuevoProducto.ShowDialog();
            if (dialogo == DialogResult.OK)
            {
                Producto productoAgregado = nuevoProducto.Productos;
                bool coincidenciaPanaderia = false;
                ProductosAlmacen productoAlmacen = new ProductosAlmacen(productoAgregado.Codigo, productoAgregado.Nombre, productoAgregado.Precio, productoAgregado.Cantidad);
                foreach (Producto prod in this.listaAlmacen)
                {
                    if (prod == productoAlmacen)
                    {
                        coincidenciaPanaderia = true;
                    }
                }
                if (!coincidenciaPanaderia)
                {
                    base.AgregarProducto(productoAlmacen);
                }
                else
                {
                    MessageBox.Show("Ya existe ese producto", "Coincidencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                base.CrearProductoStripMenu_Click(sender, e);
            }
        }

        /// <summary>
        /// Actualiza el producto seleccionado en un subproceso (en archivos y base sql)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void ActualizarProductoMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lstViewProductos.SelectedItems.Count > 0)
            {
                int indice = lstViewProductos.SelectedIndices[0];
                ProductosAlmacen productoAModificar = this.listaAlmacen[indice];
                FrmProducto prod = new FrmProducto(productoAModificar);
                DialogResult resultado = prod.ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    ProductosAlmacen productoModificado = new ProductosAlmacen(prod.Productos.Codigo, prod.Productos.Nombre, prod.Productos.Precio, prod.Productos.Cantidad);
                    base.delegadoModificar = () => Datos.basesql.ModificarProductoAlmacen(productoModificado);
                    Task subProceso = Task.Run(base.delegadoModificar);
                    subProceso.Wait();
                    this.listaAlmacen = Datos.basesql.ObtenerListaAlmacen();
                    Datos.SerializarDatos(this.listaAlmacen, @"./productosAlmacen.json");

                    base.ActualizarCarrito(productoModificado);
                    this.ActualizarVisor();
                }
            }
            else
            {
                base.ActualizarProductoMenuItem_Click(sender, e);
            }
        }

        /// <summary>
        /// Elimina el producto seleccionado en archivos y base sql
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void EliminarProductoMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lstViewProductos.SelectedItems.Count > 0)
            {
                int indice = lstViewProductos.SelectedIndices[0];
                ProductosAlmacen productoAModificar = this.listaAlmacen[indice];
                FrmProducto prod = new FrmProducto(productoAModificar);
                DialogResult resultado = prod.ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    Datos.basesql.EliminarProducto(productoAModificar.Codigo, "productosAlmacen");
                    this.listaAlmacen = Datos.basesql.ObtenerListaAlmacen();
                    Datos.SerializarDatos(this.listaAlmacen, @"./productosAlmacen.json");
                    this.EliminarProductoDelCarrito(productoAModificar);
                    this.ActualizarVisor();
                }
            }
            else
            {
                base.EliminarProductoMenuItem_Click(sender, e);
            } 
        }

        protected override void EliminarProductoDelCarrito(Producto prod)
        {
            if (base.carrito.listaAlmacen.Count > 0)
            {
                for (int i = 0; i < this.carrito.listaAlmacen.Count; i++)
                {
                    if (base.carrito.listaAlmacen[i] == prod)
                    {
                        base.carrito.listaAlmacen.Remove(base.carrito.listaAlmacen[i]);
                    }
                }
            }
        }

        /// <summary>
        /// Muestra la informacion del producto seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void BtnInfoProducto_Click(object sender, EventArgs e)
        {
            if (lstViewProductos.SelectedItems.Count > 0)
            {
                int indice = this.lstViewProductos.SelectedIndices[0];
                Producto prod = this.listaAlmacen[indice];
                MessageBox.Show(prod.Mostrar(), $"{prod.Nombre}", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                base.BtnInfoProducto_Click(sender,e);
            }
        }
    }
}
