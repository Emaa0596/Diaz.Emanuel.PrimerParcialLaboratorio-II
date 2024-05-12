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
            LblUsuarioConectado = new Label();
            listBox1 = new ListBox();
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
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(40, 37);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(599, 259);
            listBox1.TabIndex = 1;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(678, 421);
            Controls.Add(listBox1);
            Controls.Add(LblUsuarioConectado);
            Name = "FrmPrincipal";
            Text = "Form1";
            FormClosing += FormularioPrincipal_FormClosing;
            Load += FormularioPrincipal_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LblUsuarioConectado;
        private ListBox listBox1;
    }
}
