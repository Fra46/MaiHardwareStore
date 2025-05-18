namespace Presentacion
{
    partial class FrmRecuperarContrasena
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.linkVolverAtras = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnRecuperacion = new System.Windows.Forms.Button();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Controls.Add(this.linkVolverAtras);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnRecuperacion);
            this.groupBox1.Controls.Add(this.txtUsuario);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(166, 141);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(680, 452);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // linkVolverAtras
            // 
            this.linkVolverAtras.AutoSize = true;
            this.linkVolverAtras.Location = new System.Drawing.Point(6, 9);
            this.linkVolverAtras.Name = "linkVolverAtras";
            this.linkVolverAtras.Size = new System.Drawing.Size(106, 16);
            this.linkVolverAtras.TabIndex = 9;
            this.linkVolverAtras.TabStop = true;
            this.linkVolverAtras.Text = "<-- Volver atras...";
            this.linkVolverAtras.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkVolverAtras_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label2.Location = new System.Drawing.Point(73, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(534, 44);
            this.label2.TabIndex = 1;
            this.label2.Text = "No hay nada de qué preocuparse, le enviaremos un mensaje a su\r\npara correo ayudar" +
    "le a restablecer su contraseña.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(77, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Nombre de Usuario";
            // 
            // btnRecuperacion
            // 
            this.btnRecuperacion.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnRecuperacion.FlatAppearance.BorderSize = 0;
            this.btnRecuperacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecuperacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecuperacion.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRecuperacion.Location = new System.Drawing.Point(80, 293);
            this.btnRecuperacion.Name = "btnRecuperacion";
            this.btnRecuperacion.Size = new System.Drawing.Size(520, 48);
            this.btnRecuperacion.TabIndex = 5;
            this.btnRecuperacion.Text = "Enviar enlace de restablecimiento";
            this.btnRecuperacion.UseVisualStyleBackColor = false;
            this.btnRecuperacion.Click += new System.EventHandler(this.btnRecuperacion_Click);
            // 
            // txtUsuario
            // 
            this.txtUsuario.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(81, 231);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(520, 47);
            this.txtUsuario.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(98, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(484, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Olvidaste tu contraseña?";
            // 
            // FrmRecuperarContrasena
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 738);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmRecuperarContrasena";
            this.Text = "FrmRecuperarContrasena";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnRecuperacion;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkVolverAtras;
    }
}