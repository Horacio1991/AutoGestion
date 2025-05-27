namespace AutoGestion.Vista
{
    partial class RegistrarDatos
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtDominio = new TextBox();
            txtDatosTecnicos = new TextBox();
            txtDetallesPago = new TextBox();
            cmbTipoPago = new ComboBox();
            cmbEstadoStock = new ComboBox();
            btnBuscar = new Button();
            btnRegistrar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sans Serif Collection", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(155, 22);
            label1.Name = "label1";
            label1.Size = new Size(155, 54);
            label1.TabIndex = 0;
            label1.Text = "Registrar Datos";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 78);
            label2.Name = "label2";
            label2.Size = new Size(123, 15);
            label2.TabIndex = 1;
            label2.Text = "Domínio del vehículo:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 114);
            label3.Name = "label3";
            label3.Size = new Size(171, 15);
            label3.TabIndex = 2;
            label3.Text = "Motor, chasis, documentación:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(17, 214);
            label4.Name = "label4";
            label4.Size = new Size(80, 15);
            label4.TabIndex = 3;
            label4.Text = "Tipo de pago:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(17, 249);
            label5.Name = "label5";
            label5.Size = new Size(51, 15);
            label5.TabIndex = 4;
            label5.Text = "Detalles:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(17, 285);
            label6.Name = "label6";
            label6.Size = new Size(104, 15);
            label6.TabIndex = 5;
            label6.Text = "Estado en el stock:";
            // 
            // txtDominio
            // 
            txtDominio.Location = new Point(191, 70);
            txtDominio.Name = "txtDominio";
            txtDominio.Size = new Size(172, 23);
            txtDominio.TabIndex = 6;
            // 
            // txtDatosTecnicos
            // 
            txtDatosTecnicos.Location = new Point(191, 106);
            txtDatosTecnicos.Name = "txtDatosTecnicos";
            txtDatosTecnicos.Size = new Size(172, 23);
            txtDatosTecnicos.TabIndex = 7;
            // 
            // txtDetallesPago
            // 
            txtDetallesPago.Location = new Point(191, 241);
            txtDetallesPago.Name = "txtDetallesPago";
            txtDetallesPago.Size = new Size(172, 23);
            txtDetallesPago.TabIndex = 9;
            // 
            // cmbTipoPago
            // 
            cmbTipoPago.FormattingEnabled = true;
            cmbTipoPago.Location = new Point(191, 206);
            cmbTipoPago.Name = "cmbTipoPago";
            cmbTipoPago.Size = new Size(172, 23);
            cmbTipoPago.TabIndex = 10;
            // 
            // cmbEstadoStock
            // 
            cmbEstadoStock.FormattingEnabled = true;
            cmbEstadoStock.Location = new Point(191, 277);
            cmbEstadoStock.Name = "cmbEstadoStock";
            cmbEstadoStock.Size = new Size(172, 23);
            cmbEstadoStock.TabIndex = 11;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(375, 70);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(138, 23);
            btnBuscar.TabIndex = 12;
            btnBuscar.Text = "Buscar Oferta";
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Location = new Point(191, 321);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(172, 41);
            btnRegistrar.TabIndex = 13;
            btnRegistrar.Text = "Registrar Datos";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // RegistrarDatos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnRegistrar);
            Controls.Add(btnBuscar);
            Controls.Add(cmbEstadoStock);
            Controls.Add(cmbTipoPago);
            Controls.Add(txtDetallesPago);
            Controls.Add(txtDatosTecnicos);
            Controls.Add(txtDominio);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "RegistrarDatos";
            Size = new Size(516, 450);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtDominio;
        private TextBox txtDatosTecnicos;
        private TextBox txtDetallesPago;
        private ComboBox cmbTipoPago;
        private ComboBox cmbEstadoStock;
        private Button btnBuscar;
        private Button btnRegistrar;
    }
}
