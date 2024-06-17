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
            Codigo = new TextBox();
            Nombre = new TextBox();
            Precio = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            Aceptar = new Button();
            Cancelar = new Button();
            Cantidad = new TextBox();
            lblCantidad = new Label();
            SuspendLayout();
            // 
            // Codigo
            // 
            Codigo.Location = new Point(37, 46);
            Codigo.Name = "Codigo";
            Codigo.Size = new Size(196, 23);
            Codigo.TabIndex = 0;
            // 
            // Nombre
            // 
            Nombre.Location = new Point(37, 115);
            Nombre.Name = "Nombre";
            Nombre.Size = new Size(196, 23);
            Nombre.TabIndex = 1;
            // 
            // Precio
            // 
            Precio.Location = new Point(37, 185);
            Precio.MaxLength = 10;
            Precio.Name = "Precio";
            Precio.Size = new Size(196, 23);
            Precio.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 28);
            label1.Name = "label1";
            label1.Size = new Size(46, 15);
            label1.TabIndex = 3;
            label1.Text = "Código";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 97);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 4;
            label2.Text = "Nombre";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 167);
            label3.Name = "label3";
            label3.Size = new Size(40, 15);
            label3.TabIndex = 5;
            label3.Text = "Precio";
            // 
            // Aceptar
            // 
            Aceptar.Location = new Point(37, 309);
            Aceptar.Name = "Aceptar";
            Aceptar.Size = new Size(82, 45);
            Aceptar.TabIndex = 6;
            Aceptar.Text = "Aceptar";
            Aceptar.UseVisualStyleBackColor = true;
            Aceptar.Click += Aceptar_Click;
            // 
            // Cancelar
            // 
            Cancelar.Location = new Point(151, 309);
            Cancelar.Name = "Cancelar";
            Cancelar.Size = new Size(82, 45);
            Cancelar.TabIndex = 7;
            Cancelar.Text = "Cancelar";
            Cancelar.UseVisualStyleBackColor = true;
            Cancelar.Click += Cancelar_Click;
            // 
            // Cantidad
            // 
            Cantidad.Location = new Point(37, 249);
            Cantidad.MaxLength = 5;
            Cantidad.Name = "Cantidad";
            Cantidad.Size = new Size(196, 23);
            Cantidad.TabIndex = 8;
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(12, 231);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(55, 15);
            lblCantidad.TabIndex = 9;
            lblCantidad.Text = "Cantidad";
            // 
            // FrmProducto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(271, 392);
            Controls.Add(lblCantidad);
            Controls.Add(Cantidad);
            Controls.Add(Cancelar);
            Controls.Add(Aceptar);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Precio);
            Controls.Add(Nombre);
            Controls.Add(Codigo);
            Name = "FrmProducto";
            Text = "FrmProducto";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox Codigo;
        private TextBox Nombre;
        private TextBox Precio;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button Aceptar;
        private Button Cancelar;
        private TextBox Cantidad;
        private Label lblCantidad;
    }
}