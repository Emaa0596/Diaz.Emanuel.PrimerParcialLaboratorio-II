using System.Windows.Forms;
using WinFormCrud;

namespace WinFormTest
{
    [TestClass]
    public class FrmCrearUsuarioTest
    {
        FrmCrearUsuario frmUsuario;

        [TestInitialize]
        public void Inicializar()
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

        [TestMethod]
        public void PruebaBtnCrearUsuarioSuccess()
        {
            Assert.AreEqual(DialogResult.Cancel, this.frmUsuario.DialogResult);
        }
    }
}