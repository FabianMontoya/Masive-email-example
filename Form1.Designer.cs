namespace MasiveEmail
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLoadExcel = new System.Windows.Forms.Button();
            this.txtHoja = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFileRoute = new System.Windows.Forms.TextBox();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lPorcentaje = new System.Windows.Forms.Label();
            this.lCantidad = new System.Windows.Forms.Label();
            this.groupBoxProgreso = new System.Windows.Forms.GroupBox();
            this.panelPrincipal = new System.Windows.Forms.Panel();
            this.groupBoxProgreso.SuspendLayout();
            this.panelPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLoadExcel
            // 
            this.btnLoadExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoadExcel.Location = new System.Drawing.Point(6, 26);
            this.btnLoadExcel.Name = "btnLoadExcel";
            this.btnLoadExcel.Size = new System.Drawing.Size(145, 23);
            this.btnLoadExcel.TabIndex = 0;
            this.btnLoadExcel.Text = "Seleccionar Documento";
            this.btnLoadExcel.UseVisualStyleBackColor = true;
            this.btnLoadExcel.Click += new System.EventHandler(this.btnLoadExcel_Click);
            // 
            // txtHoja
            // 
            this.txtHoja.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHoja.Location = new System.Drawing.Point(157, 52);
            this.txtHoja.MaxLength = 50;
            this.txtHoja.Name = "txtHoja";
            this.txtHoja.Size = new System.Drawing.Size(113, 20);
            this.txtHoja.TabIndex = 1;
            this.txtHoja.Text = "Hoja1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre Hoja:";
            // 
            // txtFileRoute
            // 
            this.txtFileRoute.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileRoute.Location = new System.Drawing.Point(157, 28);
            this.txtFileRoute.Name = "txtFileRoute";
            this.txtFileRoute.ReadOnly = true;
            this.txtFileRoute.Size = new System.Drawing.Size(346, 20);
            this.txtFileRoute.TabIndex = 3;
            // 
            // btnEnviar
            // 
            this.btnEnviar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnEnviar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnviar.Location = new System.Drawing.Point(214, 89);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(105, 23);
            this.btnEnviar.TabIndex = 4;
            this.btnEnviar.Text = "Enviar Correos";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(6, 19);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(492, 23);
            this.progressBar.TabIndex = 5;
            // 
            // lPorcentaje
            // 
            this.lPorcentaje.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lPorcentaje.AutoSize = true;
            this.lPorcentaje.Location = new System.Drawing.Point(477, 45);
            this.lPorcentaje.Name = "lPorcentaje";
            this.lPorcentaje.Size = new System.Drawing.Size(21, 13);
            this.lPorcentaje.TabIndex = 7;
            this.lPorcentaje.Text = "0%";
            // 
            // lCantidad
            // 
            this.lCantidad.AutoSize = true;
            this.lCantidad.Location = new System.Drawing.Point(6, 45);
            this.lCantidad.Name = "lCantidad";
            this.lCantidad.Size = new System.Drawing.Size(21, 13);
            this.lCantidad.TabIndex = 8;
            this.lCantidad.Text = "0/-";
            // 
            // groupBoxProgreso
            // 
            this.groupBoxProgreso.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxProgreso.Controls.Add(this.progressBar);
            this.groupBoxProgreso.Controls.Add(this.lCantidad);
            this.groupBoxProgreso.Controls.Add(this.lPorcentaje);
            this.groupBoxProgreso.Location = new System.Drawing.Point(15, 140);
            this.groupBoxProgreso.Name = "groupBoxProgreso";
            this.groupBoxProgreso.Size = new System.Drawing.Size(507, 71);
            this.groupBoxProgreso.TabIndex = 9;
            this.groupBoxProgreso.TabStop = false;
            this.groupBoxProgreso.Text = "Progreso de envío";
            this.groupBoxProgreso.Visible = false;
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.Controls.Add(this.btnEnviar);
            this.panelPrincipal.Controls.Add(this.txtFileRoute);
            this.panelPrincipal.Controls.Add(this.label1);
            this.panelPrincipal.Controls.Add(this.txtHoja);
            this.panelPrincipal.Controls.Add(this.btnLoadExcel);
            this.panelPrincipal.Location = new System.Drawing.Point(15, 10);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Size = new System.Drawing.Size(507, 130);
            this.panelPrincipal.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 408);
            this.Controls.Add(this.panelPrincipal);
            this.Controls.Add(this.groupBoxProgreso);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MinimumSize = new System.Drawing.Size(550, 447);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enviador de correos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBoxProgreso.ResumeLayout(false);
            this.groupBoxProgreso.PerformLayout();
            this.panelPrincipal.ResumeLayout(false);
            this.panelPrincipal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoadExcel;
        private System.Windows.Forms.TextBox txtHoja;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFileRoute;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lPorcentaje;
        private System.Windows.Forms.Label lCantidad;
        private System.Windows.Forms.GroupBox groupBoxProgreso;
        private System.Windows.Forms.Panel panelPrincipal;
    }
}

