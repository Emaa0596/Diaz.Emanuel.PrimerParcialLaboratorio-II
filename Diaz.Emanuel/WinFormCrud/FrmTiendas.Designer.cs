﻿namespace WinFormCrud
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
            BtnInfoProducto = new Button();
            menuStrip1.SuspendLayout();
            menuStrip2.SuspendLayout();
            SuspendLayout();
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
            actualizarProductoToolStripMenuItem.Click += ActualizarProductoMenuItem_Click;
            // 
            // eliminarProductoToolStripMenuItem
            // 
            eliminarProductoToolStripMenuItem.Name = "eliminarProductoToolStripMenuItem";
            eliminarProductoToolStripMenuItem.Size = new Size(178, 22);
            eliminarProductoToolStripMenuItem.Text = "Eliminar Producto";
            eliminarProductoToolStripMenuItem.Click += EliminarProductoMenuItem_Click;
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
            crearProductoToolStripMenuItem1.Click += CrearProductoSupervisorMenuItem_Click;
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
            lstViewProductos.MultiSelect = false;
            lstViewProductos.Name = "lstViewProductos";
            lstViewProductos.Size = new Size(473, 174);
            lstViewProductos.TabIndex = 9;
            lstViewProductos.UseCompatibleStateImageBehavior = false;
            lstViewProductos.View = View.Details;
            // 
            // clmProductos
            // 
            clmProductos.Text = "PRODUCTOS";
            clmProductos.Width = 200;
            // 
            // clmPrecio
            // 
            clmPrecio.Text = "PRECIO";
            clmPrecio.TextAlign = HorizontalAlignment.Center;
            clmPrecio.Width = 100;
            // 
            // clmCantidad
            // 
            clmCantidad.Text = "CANTIDAD";
            clmCantidad.TextAlign = HorizontalAlignment.Right;
            clmCantidad.Width = 150;
            // 
            // BtnInfoProducto
            // 
            BtnInfoProducto.BackColor = Color.Transparent;
            BtnInfoProducto.Location = new Point(54, 54);
            BtnInfoProducto.Name = "BtnInfoProducto";
            BtnInfoProducto.Size = new Size(173, 24);
            BtnInfoProducto.TabIndex = 10;
            BtnInfoProducto.Text = "Informacion del producto";
            BtnInfoProducto.UseVisualStyleBackColor = false;
            BtnInfoProducto.Click += BtnInfoProducto_Click;
            // 
            // FrmTiendas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(573, 349);
            Controls.Add(BtnInfoProducto);
            Controls.Add(lstViewProductos);
            Controls.Add(btnEliminar);
            Controls.Add(btnAgregar);
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
        private Button btnAgregar;
        private Button btnEliminar;
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
        private Button BtnInfoProducto;
    }
}