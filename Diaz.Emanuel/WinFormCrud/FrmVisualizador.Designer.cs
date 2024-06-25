namespace WinFormCrud
{
    partial class FrmVisualizador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVisualizador));
            lstUsuariosLogin = new ListBox();
            SuspendLayout();
            // 
            // lstUsuariosLogin
            // 
            lstUsuariosLogin.Dock = DockStyle.Fill;
            lstUsuariosLogin.FormattingEnabled = true;
            lstUsuariosLogin.ItemHeight = 15;
            lstUsuariosLogin.Location = new Point(0, 0);
            lstUsuariosLogin.Name = "lstUsuariosLogin";
            lstUsuariosLogin.Size = new Size(690, 272);
            lstUsuariosLogin.TabIndex = 0;
            // 
            // FrmVisualizador
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(690, 272);
            Controls.Add(lstUsuariosLogin);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmVisualizador";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Visualizador de usuarios";
            Load += FrmVisualizador_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListBox lstUsuariosLogin;
    }
}