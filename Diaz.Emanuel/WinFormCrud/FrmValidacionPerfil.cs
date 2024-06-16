﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormCrud
{
    public partial class FrmValidacionPerfil : Form
    {
        private string claveSupervisor;
        private string claveAdministrador;
        private string perfilSolicitado;
        public FrmValidacionPerfil(string perfilSolicitado)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.claveSupervisor = "@supersupervisor";
            this.claveAdministrador = "@superadministrador";
            this.perfilSolicitado = perfilSolicitado;
            this.DialogResult = DialogResult.Cancel;
        }

        private void BtnIngresarPerfil_Click(object sender, EventArgs e)
        {
            string claveIngresada = this.TxtBoxClavePerfil.Text;
            if (this.perfilSolicitado == "Supervisor")
            {
                if (claveIngresada == this.claveSupervisor)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Error en la clave de supervisor","Clave incorrecta",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.Cancel;
                }
            }
            else if(this.perfilSolicitado == "Administrador")
            {
                if (claveIngresada == this.claveAdministrador)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Error en la clave de Administrador", "Clave incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.Cancel;
                }
            }
            this.Close();
        }
    }
}
