namespace WinFormCrud
{
    partial class FormCrearUsuario
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
            textBoxNombre = new TextBox();
            textBoxApellido = new TextBox();
            textBoxCorreoElectronico = new TextBox();
            textBoxContraseña = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            CrearUsuario = new Button();
            comboBoxPerfil = new ComboBox();
            PerfilDeUsuario = new Label();
            SuspendLayout();
            // 
            // textBoxNombre
            // 
            textBoxNombre.Location = new Point(75, 38);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.Size = new Size(172, 23);
            textBoxNombre.TabIndex = 0;
            // 
            // textBoxApellido
            // 
            textBoxApellido.Location = new Point(75, 96);
            textBoxApellido.Name = "textBoxApellido";
            textBoxApellido.Size = new Size(172, 23);
            textBoxApellido.TabIndex = 1;
            // 
            // textBoxCorreoElectronico
            // 
            textBoxCorreoElectronico.Location = new Point(75, 202);
            textBoxCorreoElectronico.Name = "textBoxCorreoElectronico";
            textBoxCorreoElectronico.Size = new Size(172, 23);
            textBoxCorreoElectronico.TabIndex = 2;
            // 
            // textBoxContraseña
            // 
            textBoxContraseña.Location = new Point(75, 258);
            textBoxContraseña.Name = "textBoxContraseña";
            textBoxContraseña.Size = new Size(172, 23);
            textBoxContraseña.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(75, 20);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 4;
            label1.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(75, 78);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 5;
            label2.Text = "Apellido";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(75, 184);
            label3.Name = "label3";
            label3.Size = new Size(105, 15);
            label3.TabIndex = 6;
            label3.Text = "Correo electronico";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(75, 240);
            label4.Name = "label4";
            label4.Size = new Size(102, 15);
            label4.TabIndex = 7;
            label4.Text = "Nueva contraseña";
            // 
            // CrearUsuario
            // 
            CrearUsuario.Location = new Point(114, 311);
            CrearUsuario.Name = "CrearUsuario";
            CrearUsuario.Size = new Size(93, 28);
            CrearUsuario.TabIndex = 8;
            CrearUsuario.Text = "Crear Usuario";
            CrearUsuario.UseVisualStyleBackColor = true;
            CrearUsuario.Click += buttonCrearUsuario_Click;
            // 
            // comboBoxPerfil
            // 
            comboBoxPerfil.FormattingEnabled = true;
            comboBoxPerfil.Items.AddRange(new object[] { "Cliente", "Vendedor", "Administrador" });
            comboBoxPerfil.Location = new Point(75, 149);
            comboBoxPerfil.Name = "comboBoxPerfil";
            comboBoxPerfil.Size = new Size(121, 23);
            comboBoxPerfil.TabIndex = 9;
            // 
            // PerfilDeUsuario
            // 
            PerfilDeUsuario.AutoSize = true;
            PerfilDeUsuario.Location = new Point(75, 131);
            PerfilDeUsuario.Name = "PerfilDeUsuario";
            PerfilDeUsuario.Size = new Size(92, 15);
            PerfilDeUsuario.TabIndex = 10;
            PerfilDeUsuario.Text = "Perfil de usuario";
            // 
            // FormCrearUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(322, 351);
            Controls.Add(PerfilDeUsuario);
            Controls.Add(comboBoxPerfil);
            Controls.Add(CrearUsuario);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxContraseña);
            Controls.Add(textBoxCorreoElectronico);
            Controls.Add(textBoxApellido);
            Controls.Add(textBoxNombre);
            Name = "FormCrearUsuario";
            Text = "FormCrearUsuario";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxNombre;
        private TextBox textBoxApellido;
        private TextBox textBoxCorreoElectronico;
        private TextBox textBoxContraseña;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button CrearUsuario;
        private ComboBox comboBoxPerfil;
        private Label PerfilDeUsuario;
    }
}