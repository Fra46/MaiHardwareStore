using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using Datos;

namespace Presentacion
{
    public partial class FrmRecuperarContrasena: Form
    {
        public FrmRecuperarContrasena()
        {
            InitializeComponent();
        }

        private void AbrirFormulario(Form frm)
        {
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void linkVolverAtras_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            AbrirFormulario(new FrmPrincipal());
        }

        private void btnRecuperacion_Click(object sender, EventArgs e)
        {
            string emailDestino = txtUsuario.Text.Trim();

            if (string.IsNullOrEmpty(emailDestino))
            {
                MessageBox.Show("Por favor, ingrese su correo electrónico.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var repo = new EmpleadoRepository();
            if (!repo.ExisteCorreo(emailDestino))
            {
                MessageBox.Show("El correo electrónico no está registrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                // Configuración del cliente SMTP
                SmtpClient cliente = new SmtpClient("smtp.tuservidor.com", 587);
                cliente.Credentials = new NetworkCredential("tu_correo@tudominio.com", "tu_contraseña");
                cliente.EnableSsl = true;

                // Construcción del mensaje
                MailMessage mensaje = new MailMessage();
                mensaje.From = new MailAddress("tu_correo@tudominio.com", "Ferretería Maihardware");
                mensaje.To.Add(emailDestino);
                mensaje.Subject = "Recuperación de contraseña";
                mensaje.Body = "Haz clic en el siguiente enlace para restablecer tu contraseña: [enlace de recuperación]";
                mensaje.IsBodyHtml = false;

                cliente.Send(mensaje);

                MessageBox.Show("Se ha enviado un correo de recuperación.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar el correo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            
        }
    }
}
