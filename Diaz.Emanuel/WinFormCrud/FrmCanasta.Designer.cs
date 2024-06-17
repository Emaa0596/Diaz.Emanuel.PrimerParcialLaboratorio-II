namespace WinFormCrud
{
    partial class FrmCanasta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCanasta));
            lblTxtAPagar = new Label();
            lblTotalAPagarDouble = new Label();
            menuStrip1 = new MenuStrip();
            ordenarPorToolStripMenuItem = new ToolStripMenuItem();
            menorPrecioAMayorToolStripMenuItem = new ToolStripMenuItem();
            mayorPrecioAMenorToolStripMenuItem = new ToolStripMenuItem();
            mayorCantidadAMenorToolStripMenuItem = new ToolStripMenuItem();
            mayorCantidadAMenorToolStripMenuItem1 = new ToolStripMenuItem();
            lblPrecio = new Label();
            lblCantidad = new Label();
            lstViewCanasta = new ListView();
            clmProductos = new ColumnHeader();
            clmPrecio = new ColumnHeader();
            clmCantidad = new ColumnHeader();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // lblTxtAPagar
            // 
            lblTxtAPagar.AutoSize = true;
            lblTxtAPagar.Font = new Font("Swis721 Blk BT", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblTxtAPagar.Location = new Point(40, 301);
            lblTxtAPagar.Name = "lblTxtAPagar";
            lblTxtAPagar.Size = new Size(156, 22);
            lblTxtAPagar.TabIndex = 1;
            lblTxtAPagar.Text = "Total a pagar:";
            // 
            // lblTotalAPagarDouble
            // 
            lblTotalAPagarDouble.AutoSize = true;
            lblTotalAPagarDouble.Font = new Font("Swis721 Cn BT", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblTotalAPagarDouble.Location = new Point(453, 301);
            lblTotalAPagarDouble.Name = "lblTotalAPagarDouble";
            lblTotalAPagarDouble.Size = new Size(47, 22);
            lblTotalAPagarDouble.TabIndex = 2;
            lblTotalAPagarDouble.Text = "Total";
            // 
            // menuStrip1
            // 
            menuStrip1.Dock = DockStyle.None;
            menuStrip1.Items.AddRange(new ToolStripItem[] { ordenarPorToolStripMenuItem });
            menuStrip1.Location = new Point(37, 17);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(94, 24);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // ordenarPorToolStripMenuItem
            // 
            ordenarPorToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menorPrecioAMayorToolStripMenuItem, mayorPrecioAMenorToolStripMenuItem, mayorCantidadAMenorToolStripMenuItem, mayorCantidadAMenorToolStripMenuItem1 });
            ordenarPorToolStripMenuItem.Name = "ordenarPorToolStripMenuItem";
            ordenarPorToolStripMenuItem.Size = new Size(86, 20);
            ordenarPorToolStripMenuItem.Text = "Ordenar por:";
            ordenarPorToolStripMenuItem.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // menorPrecioAMayorToolStripMenuItem
            // 
            menorPrecioAMayorToolStripMenuItem.Name = "menorPrecioAMayorToolStripMenuItem";
            menorPrecioAMayorToolStripMenuItem.Size = new Size(207, 22);
            menorPrecioAMayorToolStripMenuItem.Text = "Menor precio a mayor";
            menorPrecioAMayorToolStripMenuItem.Click += menorPrecioAMayorToolStripMenuItem_Click;
            // 
            // mayorPrecioAMenorToolStripMenuItem
            // 
            mayorPrecioAMenorToolStripMenuItem.Name = "mayorPrecioAMenorToolStripMenuItem";
            mayorPrecioAMenorToolStripMenuItem.Size = new Size(207, 22);
            mayorPrecioAMenorToolStripMenuItem.Text = "Mayor precio a menor";
            mayorPrecioAMenorToolStripMenuItem.Click += mayorPrecioAMenorToolStripMenuItem_Click;
            // 
            // mayorCantidadAMenorToolStripMenuItem
            // 
            mayorCantidadAMenorToolStripMenuItem.Name = "mayorCantidadAMenorToolStripMenuItem";
            mayorCantidadAMenorToolStripMenuItem.Size = new Size(207, 22);
            mayorCantidadAMenorToolStripMenuItem.Text = "Menor cantidad a mayor";
            mayorCantidadAMenorToolStripMenuItem.Click += MenorCantidadAMayorToolStripMenuItem_Click;
            // 
            // mayorCantidadAMenorToolStripMenuItem1
            // 
            mayorCantidadAMenorToolStripMenuItem1.Name = "mayorCantidadAMenorToolStripMenuItem1";
            mayorCantidadAMenorToolStripMenuItem1.Size = new Size(207, 22);
            mayorCantidadAMenorToolStripMenuItem1.Text = "Mayor cantidad a menor ";
            mayorCantidadAMenorToolStripMenuItem1.Click += mayorCantidadAMenorToolStripMenuItem1_Click;
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Font = new Font("Clarendon BT", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblPrecio.Location = new Point(289, 17);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(60, 19);
            lblPrecio.TabIndex = 4;
            lblPrecio.Text = "Precio";
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Font = new Font("Clarendon BT", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblCantidad.Location = new Point(467, 17);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(80, 19);
            lblCantidad.TabIndex = 5;
            lblCantidad.Text = "Cantidad";
            // 
            // lstViewCanasta
            // 
            lstViewCanasta.Columns.AddRange(new ColumnHeader[] { clmProductos, clmPrecio, clmCantidad });
            lstViewCanasta.Location = new Point(37, 68);
            lstViewCanasta.Name = "lstViewCanasta";
            lstViewCanasta.Size = new Size(510, 213);
            lstViewCanasta.TabIndex = 10;
            lstViewCanasta.UseCompatibleStateImageBehavior = false;
            lstViewCanasta.View = View.Details;
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
            // FrmCanasta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.CadetBlue;
            ClientSize = new Size(587, 388);
            Controls.Add(lstViewCanasta);
            Controls.Add(lblCantidad);
            Controls.Add(lblPrecio);
            Controls.Add(lblTotalAPagarDouble);
            Controls.Add(lblTxtAPagar);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FrmCanasta";
            Text = "Canasta";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblTxtAPagar;
        private Label lblTotalAPagarDouble;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem ordenarPorToolStripMenuItem;
        private ToolStripMenuItem menorPrecioAMayorToolStripMenuItem;
        private ToolStripMenuItem mayorPrecioAMenorToolStripMenuItem;
        private ToolStripMenuItem mayorCantidadAMenorToolStripMenuItem;
        private ToolStripMenuItem mayorCantidadAMenorToolStripMenuItem1;
        private Label lblPrecio;
        private Label lblCantidad;
        protected ListView lstViewCanasta;
        protected ColumnHeader clmProductos;
        protected ColumnHeader clmPrecio;
        protected ColumnHeader clmCantidad;
    }
}