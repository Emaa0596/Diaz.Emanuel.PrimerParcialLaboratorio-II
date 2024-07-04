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
    public partial class FrmCarniceria : FrmTiendas
    {
        /// <summary>
        /// Inicializa el formulario y configura su posicion
        /// </summary>
        /// <param name="carrito">Canasta que se envia a la clase padre</param>
        public FrmCarniceria(Canasta carrito)
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
        private void FrmCarniceria_Load(object sender, EventArgs e)
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
                ProductosCarniceria prod = base.listaCarniceria[indice];
                if (prod.Cantidad >= 5)
                {
                    base.DispararEventoCantidadMaximaPermitida();
                }
                else
                {
                    base.carrito += prod;
                    Datos.basesql.ModificarProductoCarniceriaOPanaderia(prod);
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
                ProductosCarniceria prod = base.listaCarniceria[indice];
                if (prod.Cantidad == 0)
                {
                    base.DispararEventoCantidadMaximaPermitida();
                }
                else
                {
                    base.carrito -= prod;
                    Datos.basesql.ModificarProductoCarniceriaOPanaderia(prod);
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
            foreach (ProductosCarniceria productos in base.listaCarniceria)
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
            List<ProductosCarniceria> listaOrdenada = new List<ProductosCarniceria>();
            foreach (Producto productos in lista)
            {
                ProductosCarniceria prod = (ProductosCarniceria)productos;
                listaOrdenada.Add(prod);
            }
            base.listaCarniceria = listaOrdenada;
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
                ProductosCarniceria productoCarniceria = new ProductosCarniceria(productoAgregado.Codigo, productoAgregado.Nombre, productoAgregado.Precio, productoAgregado.Cantidad, 1);
                foreach (Producto prod in this.listaCarniceria)
                {
                    if (prod == productoCarniceria)
                    {
                        coincidenciaPanaderia = true;
                    }
                }
                if (!coincidenciaPanaderia)
                {
                    base.AgregarProducto(productoCarniceria);
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
                ProductosCarniceria productoAModificar = this.listaCarniceria[indice];
                FrmProducto prod = new FrmProducto(productoAModificar);
                DialogResult resultado = prod.ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    ProductosCarniceria productoModificado = new ProductosCarniceria(prod.Productos.Codigo, prod.Productos.Nombre, prod.Productos.Precio, prod.Productos.Cantidad, 1);
                    base.delegadoModificar = () => Datos.basesql.ModificarProductoCarniceriaOPanaderia(productoModificado);
                    Task subProceso = Task.Run(base.delegadoModificar);
                    subProceso.Wait();
                    this.listaCarniceria = Datos.basesql.ObtenerListaCarniceria();
                    Datos.SerializarDatos(this.listaCarniceria, @"./productosCarniceria.json");
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
                ProductosCarniceria productoAModificar = this.listaCarniceria[indice];
                FrmProducto prod = new FrmProducto(productoAModificar);
                DialogResult resultado = prod.ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    Datos.basesql.EliminarProducto(productoAModificar.Codigo, "productosCarniceria");
                    this.listaCarniceria = Datos.basesql.ObtenerListaCarniceria();
                    Datos.SerializarDatos(this.listaCarniceria, @"./productosCarniceria.json");
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
            if (base.carrito.listaCarniceria.Count > 0)
            {
                for (int i = 0; i < this.carrito.listaCarniceria.Count; i++)
                {
                    if (base.carrito.listaCarniceria[i] == prod)
                    {
                        base.carrito.listaCarniceria.Remove(base.carrito.listaCarniceria[i]);
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
                ProductosCarniceria prod = this.listaCarniceria[indice];
                MessageBox.Show(prod.Mostrar(),$"{prod.Nombre}",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                base.BtnInfoProducto_Click(sender, e);
            }
        }
    }
}
