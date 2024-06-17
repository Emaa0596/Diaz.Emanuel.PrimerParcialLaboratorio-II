namespace WinFormCrud
{
    partial class FrmTiendas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblProducto = new Label();
            lblPrecio = new Label();
            lblCantidad = new Label();
            btnAgregar = new Button();
            btnEliminar = new Button();
            menuStrip1 = new MenuStrip();
            OrdenarMenuStrip = new ToolStripMenuItem();
            menorPrecioAMayorToolStripMenuItem = new ToolStripMenuItem();
            mayorPrecioAMenorToolStripMenuItem = new ToolStripMenuItem();
            menorCantidadAMayorToolStripMenuItem = new ToolStripMenuItem();
            mayorCantidadAMenorToolStripMenuItem = new ToolStripMenuItem();
            menuStrip2 = new MenuStrip();
            AdministradorMenuStrip = new ToolStripMenuItem();
            crearProductoToolStripMenuItem = new ToolStripMenuItem();
            actualizarProductoToolStripMenuItem = new ToolStripMenuItem();
            eliminarProductoToolStripMenuItem = new ToolStripMenuItem();
            SupervisorMenuStrip = new ToolStripMenuItem();
            crearProductoToolStripMenuItem1 = new ToolStripMenuItem();
            actualizarProductoToolStripMenuItem1 = new ToolStripMenuItem();
            lstViewProductos = new ListView();
            clmProductos = new ColumnHeader();
            clmPrecio = new ColumnHeader();
            clmCantidad = new ColumnHeader();
            menuStrip1.SuspendLayout();
            menuStrip2.SuspendLayout();
            SuspendLayout();
            // 
            // lblProducto
            // 
            lblProducto.AutoSize = true;
            lblProducto.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblProducto.Location = new Point(54, 48);
            lblProducto.Name = "lblProducto";
            lblProducto.Size = new Size(80, 20);
            lblProducto.TabIndex = 1;
            lblProducto.Text = "Productos";
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblPrecio.Location = new Point(265, 48);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(52, 20);
            lblPrecio.TabIndex = 2;
            lblPrecio.Text = "Precio";
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblCantidad.Location = new Point(456, 48);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(71, 20);
            lblCantidad.TabIndex = 3;
            lblCantidad.Text = "Cantidad";
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.Transparent;
            btnAgregar.Location = new Point(112, 280);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(100, 41);
            btnAgregar.TabIndex = 5;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.Transparent;
            btnEliminar.Location = new Point(354, 280);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(100, 41);
            btnEliminar.TabIndex = 6;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Dock = DockStyle.None;
            menuStrip1.Items.AddRange(new ToolStripItem[] { OrdenarMenuStrip });
            menuStrip1.Location = new Point(54, 9);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(94, 24);
            menuStrip1.TabIndex = 7;
            menuStrip1.Text = "menuStrip1";
            // 
            // OrdenarMenuStrip
            // 
            OrdenarMenuStrip.DropDownItems.AddRange(new ToolStripItem[] { menorPrecioAMayorToolStripMenuItem, mayorPrecioAMenorToolStripMenuItem, menorCantidadAMayorToolStripMenuItem, mayorCantidadAMenorToolStripMenuItem });
            OrdenarMenuStrip.Name = "OrdenarMenuStrip";
            OrdenarMenuStrip.Size = new Size(86, 20);
            OrdenarMenuStrip.Text = "Ordenar por:";
            // 
            // menorPrecioAMayorToolStripMenuItem
            // 
            menorPrecioAMayorToolStripMenuItem.Name = "menorPrecioAMayorToolStripMenuItem";
            menorPrecioAMayorToolStripMenuItem.Size = new Size(206, 22);
            menorPrecioAMayorToolStripMenuItem.Text = "Menor precio a Mayor";
            menorPrecioAMayorToolStripMenuItem.Click += MenorPrecioAMayorStripMenu_Click;
            // 
            // mayorPrecioAMenorToolStripMenuItem
            // 
            mayorPrecioAMenorToolStripMenuItem.Name = "mayorPrecioAMenorToolStripMenuItem";
            mayorPrecioAMenorToolStripMenuItem.Size = new Size(206, 22);
            mayorPrecioAMenorToolStripMenuItem.Text = "Mayor precio a Menor";
            mayorPrecioAMenorToolStripMenuItem.Click += MayorPrecioAMenorStripMenuItem_Click;
            // 
            // menorCantidadAMayorToolStripMenuItem
            // 
            menorCantidadAMayorToolStripMenuItem.Name = "menorCantidadAMayorToolStripMenuItem";
            menorCantidadAMayorToolStripMenuItem.Size = new Size(206, 22);
            menorCantidadAMayorToolStripMenuItem.Text = "Menor Cantidad a Mayor";
            menorCantidadAMayorToolStripMenuItem.Click += MenorCantidadAMayorMenuItem_Click;
            // 
            // mayorCantidadAMenorToolStripMenuItem
            // 
            mayorCantidadAMenorToolStripMenuItem.Name = "mayorCantidadAMenorToolStripMenuItem";
            mayorCantidadAMenorToolStripMenuItem.Size = new Size(206, 22);
            mayorCantidadAMenorToolStripMenuItem.Text = "Mayor cantidad a Menor";
            mayorCantidadAMenorToolStripMenuItem.Click += MayorCantidadAMenorMenuItem_Click;
            // 
            // menuStrip2
            // 
            menuStrip2.Dock = DockStyle.None;
            menuStrip2.Items.AddRange(new ToolStripItem[] { AdministradorMenuStrip, SupervisorMenuStrip });
            menuStrip2.Location = new Point(294, 9);
            menuStrip2.Name = "menuStrip2";
            menuStrip2.Size = new Size(177, 24);
            menuStrip2.TabIndex = 8;
            menuStrip2.Text = "menuStrip2";
            // 
            // AdministradorMenuStrip
            // 
            AdministradorMenuStrip.DropDownItems.AddRange(new ToolStripItem[] { crearProductoToolStripMenuItem, actualizarProductoToolStripMenuItem, eliminarProductoToolStripMenuItem });
            AdministradorMenuStrip.Name = "AdministradorMenuStrip";
            AdministradorMenuStrip.Size = new Size(95, 20);
            AdministradorMenuStrip.Text = "Administrador";
            // 
            // crearProductoToolStripMenuItem
            // 
            crearProductoToolStripMenuItem.Name = "crearProductoToolStripMenuItem";
            crearProductoToolStripMenuItem.Size = new Size(178, 22);
            crearProductoToolStripMenuItem.Text = "Crear Producto";
            crearProductoToolStripMenuItem.Click += CrearProductoStripMenu_Click;
            // 
            // actualizarProductoToolStripMenuItem
            // 
            actualizarProductoToolStripMenuItem.Name = "actualizarProductoToolStripMenuItem";
            actualizarProductoToolStripMenuItem.Size = new Size(178, 22);
            actualizarProductoToolStripMenuItem.Text = "Actualizar Producto";
            // 
            // eliminarProductoToolStripMenuItem
            // 
            eliminarProductoToolStripMenuItem.Name = "eliminarProductoToolStripMenuItem";
            eliminarProductoToolStripMenuItem.Size = new Size(178, 22);
            eliminarProductoToolStripMenuItem.Text = "Eliminar Producto";
            // 
            // SupervisorMenuStrip
            // 
            SupervisorMenuStrip.DropDownItems.AddRange(new ToolStripItem[] { crearProductoToolStripMenuItem1, actualizarProductoToolStripMenuItem1 });
            SupervisorMenuStrip.Name = "SupervisorMenuStrip";
            SupervisorMenuStrip.Size = new Size(74, 20);
            SupervisorMenuStrip.Text = "Supervisor";
            // 
            // crearProductoToolStripMenuItem1
            // 
            crearProductoToolStripMenuItem1.Name = "crearProductoToolStripMenuItem1";
            crearProductoToolStripMenuItem1.Size = new Size(178, 22);
            crearProductoToolStripMenuItem1.Text = "Crear Producto";
            // 
            // actualizarProductoToolStripMenuItem1
            // 
            actualizarProductoToolStripMenuItem1.Name = "actualizarProductoToolStripMenuItem1";
            actualizarProductoToolStripMenuItem1.Size = new Size(178, 22);
            actualizarProductoToolStripMenuItem1.Text = "Actualizar Producto";
            // 
            // lstViewProductos
            // 
            lstViewProductos.Columns.AddRange(new ColumnHeader[] { clmProductos, clmPrecio, clmCantidad });
            lstViewProductos.Location = new Point(54, 84);
            lstViewProductos.Name = "lstViewProductos";
            lstViewProductos.Size = new Size(473, 174);
            lstViewProductos.TabIndex = 9;
            lstViewProductos.UseCompatibleStateImageBehavior = false;
            lstViewProductos.View = View.Details;
            // 
            // clmProductos
            // 
            clmProductos.Text = "Productos";
            clmProductos.Width = 200;
            // 
            // clmPrecio
            // 
            clmPrecio.Text = "Precio";
            clmPrecio.TextAlign = HorizontalAlignment.Center;
            clmPrecio.Width = 100;
            // 
            // clmCantidad
            // 
            clmCantidad.Text = "Cantidad";
            clmCantidad.TextAlign = HorizontalAlignment.Right;
            clmCantidad.Width = 150;
            // 
            // FrmTiendas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(573, 349);
            Controls.Add(lstViewProductos);
            Controls.Add(btnEliminar);
            Controls.Add(btnAgregar);
            Controls.Add(lblCantidad);
            Controls.Add(lblPrecio);
            Controls.Add(lblProducto);
            Controls.Add(menuStrip1);
            Controls.Add(menuStrip2);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "FrmTiendas";
            Text = "FrmProducto";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            menuStrip2.ResumeLayout(false);
            menuStrip2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblProducto;
        private Label lblCantidad;
        private Button btnAgregar;
        private Button btnEliminar;
        protected Label lblPrecio;
        private MenuStrip menuStrip1;
        protected ToolStripMenuItem OrdenarMenuStrip;
        protected ToolStripMenuItem menorPrecioAMayorToolStripMenuItem;
        protected ToolStripMenuItem mayorPrecioAMenorToolStripMenuItem;
        protected ToolStripMenuItem menorCantidadAMayorToolStripMenuItem;
        protected ToolStripMenuItem mayorCantidadAMenorToolStripMenuItem;
        private MenuStrip menuStrip2;
        private ToolStripMenuItem crearProductoToolStripMenuItem;
        private ToolStripMenuItem actualizarProductoToolStripMenuItem;
        private ToolStripMenuItem eliminarProductoToolStripMenuItem;
        private ToolStripMenuItem crearProductoToolStripMenuItem1;
        private ToolStripMenuItem actualizarProductoToolStripMenuItem1;
        protected ToolStripMenuItem AdministradorMenuStrip;
        protected ToolStripMenuItem SupervisorMenuStrip;
        protected ListView lstViewProductos;
        protected ColumnHeader clmProductos;
        protected ColumnHeader clmPrecio;
        protected ColumnHeader clmCantidad;
    }
}