﻿namespace WinFormCrud
{
    partial class FrmCarniceria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCarniceria));
            SuspendLayout();
            // 
            // lstProductos
            // 
            lstProductos.BackColor = Color.Tomato;
            // 
            // FrmCarniceria
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Brown;
            ClientSize = new Size(579, 386);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmCarniceria";
            Text = "Carniceria";
            Load += FrmCarniceria_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}