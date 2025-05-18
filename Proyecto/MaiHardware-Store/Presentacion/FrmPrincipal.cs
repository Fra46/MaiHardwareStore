using Logica;
using System;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FrmPrincipal : Form
    {
        private TelegramBotService BotService;

        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private async void FrmPrincipal_Load(object sender, EventArgs e)
        {
            BotService = new TelegramBotService();
            await BotService.Iniciar();
        }

        private void AbrirFormulario(Form frm)
        {
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtContrasena.Text;

            var usuarioService = new UsuarioService();
            string tipoUsuario = usuarioService.Autenticar(usuario, contrasena);

            if (!string.IsNullOrEmpty(tipoUsuario))
            {
                Form frmDestino = null;
                if (tipoUsuario == "admin")
                    frmDestino = new FrmAdministrador();
                else if (tipoUsuario == "empleado")
                    frmDestino = new FrmEmpleado();

                if (frmDestino != null)
                {
                    this.Hide();
                    AbrirFormulario(frmDestino);
                }
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsuario.Clear();
                txtContrasena.Clear();
                txtUsuario.Focus();
            }
        }

        private void linkOlvidaste_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            AbrirFormulario(new FrmRecuperarContrasena());
        }
    }
}