using System.Windows.Forms;
using WinFormCrud;

namespace WinFormTest
{
    [TestClass]
    public class FrmCrearUsuarioTest
    {
        FrmCrearUsuario frmUsuario;

        /// <summary>
        /// Inicializa el form con sus textbox y verifica al metodo para crear un usuario.
        /// </summary>
        [TestInitialize]
        public void InicializarFormulario()
        {
            this.frmUsuario = new FrmCrearUsuario();
            this.frmUsuario.Nombre = "Ema";
            this.frmUsuario.Apellido = "Diaz";
            this.frmUsuario.CorreoElectronico = "ema@gmail.com";
            this.frmUsuario.Contraseña = "1234";
            this.frmUsuario.Perfil = "Vendedor";
            this.frmUsuario.FormCrearUsuario_Load(null, null);
            this.frmUsuario.buttonCrearUsuario_Click(null, null); 
        }

        /// <summary>
        /// Verifica que encuentre al usuario y se configure el dialogo correspondiente.
        /// </summary>
        [TestMethod]
        public void PruebaBtnCrearUsuarioSuccess()
        {
            Assert.AreEqual(DialogResult.Cancel, this.frmUsuario.DialogResult);
        }
    }
}