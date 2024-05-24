namespace WinFormCrud
{
    partial class FrmPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            LblUsuarioConectado = new Label();
            btnCarniceria = new Button();
            btnAlmacen = new Button();
            btnPanaderia = new Button();
            btnCanasta = new Button();
            SuspendLayout();
            // 
            // LblUsuarioConectado
            // 
            LblUsuarioConectado.AutoSize = true;
            LblUsuarioConectado.Location = new Point(539, 9);
            LblUsuarioConectado.Name = "LblUsuarioConectado";
            LblUsuarioConectado.Size = new Size(38, 15);
            LblUsuarioConectado.TabIndex = 0;
            LblUsuarioConectado.Text = "label1";
            // 
            // btnCarniceria
            // 
            btnCarniceria.BackColor = Color.Tomato;
            btnCarniceria.Font = new Font("Showcard Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnCarniceria.ForeColor = Color.DarkRed;
            btnCarniceria.Image = (Image)resources.GetObject("btnCarniceria.Image");
            btnCarniceria.ImageAlign = ContentAlignment.MiddleLeft;
            btnCarniceria.Location = new Point(376, 264);
            btnCarniceria.Name = "btnCarniceria";
            btnCarniceria.Size = new Size(179, 77);
            btnCarniceria.TabIndex = 2;
            btnCarniceria.Text = "Carniceria";
            btnCarniceria.TextAlign = ContentAlignment.MiddleRight;
            btnCarniceria.UseVisualStyleBackColor = false;
            btnCarniceria.Click += btnCarniceria_Click;
            // 
            // btnAlmacen
            // 
            btnAlmacen.BackColor = Color.LightSeaGreen;
            btnAlmacen.Font = new Font("Showcard Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnAlmacen.ForeColor = SystemColors.HotTrack;
            btnAlmacen.Image = (Image)resources.GetObject("btnAlmacen.Image");
            btnAlmacen.ImageAlign = ContentAlignment.MiddleLeft;
            btnAlmacen.Location = new Point(376, 37);
            btnAlmacen.Name = "btnAlmacen";
            btnAlmacen.Size = new Size(179, 77);
            btnAlmacen.TabIndex = 3;
            btnAlmacen.Text = "Almacen";
            btnAlmacen.TextAlign = ContentAlignment.MiddleRight;
            btnAlmacen.UseVisualStyleBackColor = false;
            btnAlmacen.Click += btnAlmacen_Click;
            // 
            // btnPanaderia
            // 
            btnPanaderia.BackColor = Color.Khaki;
            btnPanaderia.Font = new Font("Showcard Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnPanaderia.ForeColor = Color.Peru;
            btnPanaderia.Image = (Image)resources.GetObject("btnPanaderia.Image");
            btnPanaderia.ImageAlign = ContentAlignment.MiddleLeft;
            btnPanaderia.Location = new Point(376, 142);
            btnPanaderia.Name = "btnPanaderia";
            btnPanaderia.Size = new Size(179, 77);
            btnPanaderia.TabIndex = 4;
            btnPanaderia.Text = "Panaderia";
            btnPanaderia.TextAlign = ContentAlignment.MiddleRight;
            btnPanaderia.UseVisualStyleBackColor = false;
            btnPanaderia.Click += btnPanaderia_Click;
            // 
            // btnCanasta
            // 
            btnCanasta.BackColor = Color.CadetBlue;
            btnCanasta.FlatAppearance.BorderSize = 0;
            btnCanasta.Font = new Font("Humnst777 Blk BT", 14.25F, FontStyle.Italic, GraphicsUnit.Point);
            btnCanasta.ForeColor = Color.Gold;
            btnCanasta.Image = (Image)resources.GetObject("btnCanasta.Image");
            btnCanasta.ImageAlign = ContentAlignment.MiddleLeft;
            btnCanasta.Location = new Point(80, 115);
            btnCanasta.Name = "btnCanasta";
            btnCanasta.Size = new Size(179, 131);
            btnCanasta.TabIndex = 5;
            btnCanasta.Text = "Canasta";
            btnCanasta.TextAlign = ContentAlignment.MiddleRight;
            btnCanasta.UseVisualStyleBackColor = false;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.IndianRed;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(678, 421);
            Controls.Add(btnCanasta);
            Controls.Add(btnPanaderia);
            Controls.Add(btnAlmacen);
            Controls.Add(btnCarniceria);
            Controls.Add(LblUsuarioConectado);
            Name = "FrmPrincipal";
            Text = "Tienda";
            FormClosing += FormularioPrincipal_FormClosing;
            Load += FormularioPrincipal_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LblUsuarioConectado;
        private Button btnCarniceria;
        private Button btnAlmacen;
        private Button btnPanaderia;
        private Button btnCanasta;
    }
}
