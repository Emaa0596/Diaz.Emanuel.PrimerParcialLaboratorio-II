﻿namespace WinFormCrud
{
    partial class FrmPanaderia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPanaderia));
            SuspendLayout();
            // 
            // lstProductos
            // 
            lstProductos.BackColor = Color.Khaki;
            lstProductos.Location = new Point(49, 79);
            // 
            // FrmPanaderia
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Peru;
            ClientSize = new Size(568, 356);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmPanaderia";
            Text = "Panaderia";
            Load += FrmPanaderia_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}