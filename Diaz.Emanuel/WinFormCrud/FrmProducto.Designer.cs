namespace WinFormCrud
{
    partial class FrmProducto
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
            lstProductos = new ListBox();
            btnAgregar = new Button();
            btnEliminar = new Button();
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
            // lstProductos
            // 
            lstProductos.FormattingEnabled = true;
            lstProductos.ItemHeight = 15;
            lstProductos.Location = new Point(54, 79);
            lstProductos.Name = "lstProductos";
            lstProductos.Size = new Size(470, 169);
            lstProductos.TabIndex = 4;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(90, 280);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(100, 41);
            btnAgregar.TabIndex = 5;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(324, 280);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(100, 41);
            btnEliminar.TabIndex = 6;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // FrmProducto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(573, 349);
            Controls.Add(btnEliminar);
            Controls.Add(btnAgregar);
            Controls.Add(lstProductos);
            Controls.Add(lblCantidad);
            Controls.Add(lblPrecio);
            Controls.Add(lblProducto);
            Name = "FrmProducto";
            Text = "FrmProducto";
            Load += FrmProducto_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblProducto;
        private Label lblCantidad;
        private ListBox lstProductos;
        private Button btnAgregar;
        private Button btnEliminar;
        protected Label lblPrecio;
    }
}