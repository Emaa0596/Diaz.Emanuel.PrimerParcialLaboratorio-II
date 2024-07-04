using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Unicode;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormCrud
{
    public partial class FrmVisualizador : Form
    {
        public FrmVisualizador()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void FrmVisualizador_Load(object sender, EventArgs e)
        {
           this.CargarDatosAlVisualizador();
        }
        /// <summary>
        /// Carga los datos de los usuarios ingresados al visualizador. Si no existe el archivo lanza una excepcion propia.
        /// </summary>
        private void CargarDatosAlVisualizador()
        {
            try
            {
                if (File.Exists(@".\usuariosLogueo.log"))
                {
                    using (StreamReader sr = new StreamReader(@".\usuariosLogueo.log", true))
                    {
                        string? usuario;
                        while ((usuario = sr.ReadLine()) != null)
                        {
                            lstUsuariosLogin.Items.Add(usuario);
                        }
                    }
                }
                else
                {
                    throw new ErrorAlLeerLogsException();
                }

            }
            catch (ErrorAlLeerLogsException e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            catch (Exception e) 
            {
                MessageBox.Show("Ocurrió un error inesperado: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}
