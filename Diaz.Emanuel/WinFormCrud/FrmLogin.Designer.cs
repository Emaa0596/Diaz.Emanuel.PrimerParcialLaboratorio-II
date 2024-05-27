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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
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
            textBoxUsuario.Location = new Point(118, 200);
            textBoxUsuario.MaxLength = 30;
            textBoxUsuario.Name = "textBoxUsuario";
            textBoxUsuario.Size = new Size(201, 23);
            textBoxUsuario.TabIndex = 0;
            //textBoxUsuario.TextChanged += textBoxUsuario_TextChanged;
            // 
            // textBoxContraseña
            // 
            textBoxContraseña.Location = new Point(118, 253);
            textBoxContraseña.MaxLength = 20;
            textBoxContraseña.Name = "textBoxContraseña";
            textBoxContraseña.PasswordChar = '*';
            textBoxContraseña.Size = new Size(201, 23);
            textBoxContraseña.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Khaki;
            label1.Font = new Font("Arial Rounded MT Bold", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(117, 173);
            label1.Name = "label1";
            label1.Size = new Size(202, 24);
            label1.TabIndex = 2;
            label1.Text = "Correo electronico";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Khaki;
            label2.Font = new Font("Arial Rounded MT Bold", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(154, 226);
            label2.Name = "label2";
            label2.Size = new Size(128, 24);
            label2.TabIndex = 3;
            label2.Text = "Contraseña";
            // 
            // botonIngresar
            // 
            botonIngresar.Location = new Point(172, 296);
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
            linkCrearUsuario.BackColor = Color.Transparent;
            linkCrearUsuario.Location = new Point(180, 338);
            linkCrearUsuario.Name = "linkCrearUsuario";
            linkCrearUsuario.Size = new Size(77, 15);
            linkCrearUsuario.TabIndex = 5;
            linkCrearUsuario.TabStop = true;
            linkCrearUsuario.Text = "Crear usuario";
            linkCrearUsuario.LinkClicked += linkCrearUsuario_LinkClicked;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 128, 0);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(436, 362);
            Controls.Add(linkCrearUsuario);
            Controls.Add(botonIngresar);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxContraseña);
            Controls.Add(textBoxUsuario);
            Name = "FrmLogin";
            Text = "Login";
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