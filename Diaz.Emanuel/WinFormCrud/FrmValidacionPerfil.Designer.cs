namespace WinFormCrud
{
    partial class FrmValidacionPerfil
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
            TxtBoxClavePerfil = new TextBox();
            label1 = new Label();
            BtnIngresarPerfil = new Button();
            SuspendLayout();
            // 
            // TxtBoxClavePerfil
            // 
            TxtBoxClavePerfil.Location = new Point(46, 85);
            TxtBoxClavePerfil.MaxLength = 20;
            TxtBoxClavePerfil.Name = "TxtBoxClavePerfil";
            TxtBoxClavePerfil.PasswordChar = '*';
            TxtBoxClavePerfil.Size = new Size(158, 23);
            TxtBoxClavePerfil.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(63, 50);
            label1.Name = "label1";
            label1.Size = new Size(124, 15);
            label1.TabIndex = 1;
            label1.Text = "Ingrese clave del perfil";
            // 
            // BtnIngresarPerfil
            // 
            BtnIngresarPerfil.Location = new Point(88, 132);
            BtnIngresarPerfil.Name = "BtnIngresarPerfil";
            BtnIngresarPerfil.Size = new Size(75, 23);
            BtnIngresarPerfil.TabIndex = 2;
            BtnIngresarPerfil.Text = "Ingresar";
            BtnIngresarPerfil.UseVisualStyleBackColor = true;
            BtnIngresarPerfil.Click += BtnIngresarPerfil_Click;
            // 
            // FrmValidacionPerfil
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(251, 167);
            Controls.Add(BtnIngresarPerfil);
            Controls.Add(label1);
            Controls.Add(TxtBoxClavePerfil);
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "FrmValidacionPerfil";
            Text = "Validacion del perfil";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TxtBoxClavePerfil;
        private Label label1;
        private Button BtnIngresarPerfil;
    }
}