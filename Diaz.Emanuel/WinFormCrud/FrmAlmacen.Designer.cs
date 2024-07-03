namespace WinFormCrud
{
    partial class FrmAlmacen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAlmacen));
            SuspendLayout();
            // 
            // lstProductos
            // 
            //lstProductos.BackColor = Color.PaleGreen;
            // 
            //
            // FrmAlmacen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SeaGreen;
            ClientSize = new Size(580, 383);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmAlmacen";
            Text = "Almacen";
            Load += FrmAlmacen_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}