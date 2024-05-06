namespace WinFormCrud
{
    public partial class FormularioPrincipal : Form
    {
        public FormularioPrincipal()
        {
            InitializeComponent();
            
        }

        private void FormularioPrincipal_Load(object sender, EventArgs e)
        {
            FormLogin UsuarioLogueado = new FormLogin();
            UsuarioLogueado.ShowDialog();
        }
    }
}
