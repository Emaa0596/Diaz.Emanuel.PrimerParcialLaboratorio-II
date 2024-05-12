namespace WinFormCrud
{
    partial class FrmLogin
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
            textBoxUsuario = new TextBox();
            textBoxContraseña = new TextBox();
            label1 = new Label();
            label2 = new Label();
            botonIngresar = new Button();
            linkCrearUsuario = new LinkLabel();
            SuspendLayout();
            // 
            // textBoxUsuario
            // 
            textBoxUsuario.Location = new Point(99, 79);
            textBoxUsuario.Name = "textBoxUsuario";
            textBoxUsuario.Size = new Size(201, 23);
            textBoxUsuario.TabIndex = 0;
            // 
            // textBoxContraseña
            // 
            textBoxContraseña.Location = new Point(99, 160);
            textBoxContraseña.Name = "textBoxContraseña";
            textBoxContraseña.Size = new Size(201, 23);
            textBoxContraseña.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(99, 61);
            label1.Name = "label1";
            label1.Size = new Size(105, 15);
            label1.TabIndex = 2;
            label1.Text = "Correo electronico";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(99, 142);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 3;
            label2.Text = "Contraseña";
            // 
            // botonIngresar
            // 
            botonIngresar.Location = new Point(153, 213);
            botonIngresar.Name = "botonIngresar";
            botonIngresar.Size = new Size(92, 28);
            botonIngresar.TabIndex = 4;
            botonIngresar.Text = "Ingresar";
            botonIngresar.UseVisualStyleBackColor = true;
            botonIngresar.Click += botonIngresar_Click;
            // 
            // linkCrearUsuario
            // 
            linkCrearUsuario.AutoSize = true;
            linkCrearUsuario.Location = new Point(161, 248);
            linkCrearUsuario.Name = "linkCrearUsuario";
            linkCrearUsuario.Size = new Size(77, 15);
            linkCrearUsuario.TabIndex = 5;
            linkCrearUsuario.TabStop = true;
            linkCrearUsuario.Text = "Crear usuario";
            linkCrearUsuario.LinkClicked += linkCrearUsuario_LinkClicked;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(399, 272);
            Controls.Add(linkCrearUsuario);
            Controls.Add(botonIngresar);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxContraseña);
            Controls.Add(textBoxUsuario);
            Name = "FormLogin";
            Text = "Login";
            //FormClosing += FormLogin_FormClosing;
            Load += FormLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxUsuario;
        private TextBox textBoxContraseña;
        private Label label1;
        private Label label2;
        private Button botonIngresar;
        private LinkLabel linkCrearUsuario;
    }
}