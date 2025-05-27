namespace AutoGestion.Vista
{
    partial class RealizarPago
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
            lblRealizarPago = new Label();
            cmbTipoPago = new ComboBox();
            txtMonto = new TextBox();
            txtCuotas = new TextBox();
            txtDetalles = new TextBox();
            btnRegistrarPago = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // lblRealizarPago
            // 
            lblRealizarPago.AutoSize = true;
            lblRealizarPago.Font = new Font("Sans Serif Collection", 15.7499981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRealizarPago.Location = new Point(134, 0);
            lblRealizarPago.Name = "lblRealizarPago";
            lblRealizarPago.Size = new Size(175, 72);
            lblRealizarPago.TabIndex = 0;
            lblRealizarPago.Text = "Realizar Pago";
            // 
            // cmbTipoPago
            // 
            cmbTipoPago.FormattingEnabled = true;
            cmbTipoPago.Location = new Point(146, 75);
            cmbTipoPago.Name = "cmbTipoPago";
            cmbTipoPago.Size = new Size(267, 23);
            cmbTipoPago.TabIndex = 1;
            cmbTipoPago.SelectedIndexChanged += cmbTipoPago_SelectedIndexChanged;
            // 
            // txtMonto
            // 
            txtMonto.Location = new Point(146, 121);
            txtMonto.Name = "txtMonto";
            txtMonto.Size = new Size(267, 23);
            txtMonto.TabIndex = 2;
            // 
            // txtCuotas
            // 
            txtCuotas.Location = new Point(146, 164);
            txtCuotas.Name = "txtCuotas";
            txtCuotas.Size = new Size(267, 23);
            txtCuotas.TabIndex = 3;
            // 
            // txtDetalles
            // 
            txtDetalles.Location = new Point(153, 211);
            txtDetalles.Multiline = true;
            txtDetalles.Name = "txtDetalles";
            txtDetalles.Size = new Size(260, 68);
            txtDetalles.TabIndex = 4;
            // 
            // btnRegistrarPago
            // 
            btnRegistrarPago.Location = new Point(153, 299);
            btnRegistrarPago.Name = "btnRegistrarPago";
            btnRegistrarPago.Size = new Size(260, 42);
            btnRegistrarPago.TabIndex = 5;
            btnRegistrarPago.Text = "Registrar Pago";
            btnRegistrarPago.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 75);
            label1.Name = "label1";
            label1.Size = new Size(81, 15);
            label1.TabIndex = 6;
            label1.Text = "Tipo De Pago:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 121);
            label2.Name = "label2";
            label2.Size = new Size(46, 15);
            label2.TabIndex = 7;
            label2.Text = "Monto:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(29, 164);
            label3.Name = "label3";
            label3.Size = new Size(114, 15);
            label3.TabIndex = 8;
            label3.Text = "Cantidad de Cuotas:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(29, 211);
            label4.Name = "label4";
            label4.Size = new Size(51, 15);
            label4.TabIndex = 9;
            label4.Text = "Detalles:";
            // 
            // RealizarPago
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnRegistrarPago);
            Controls.Add(txtDetalles);
            Controls.Add(txtCuotas);
            Controls.Add(txtMonto);
            Controls.Add(cmbTipoPago);
            Controls.Add(lblRealizarPago);
            Name = "RealizarPago";
            Size = new Size(441, 390);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblRealizarPago;
        private ComboBox cmbTipoPago;
        private TextBox txtMonto;
        private TextBox txtCuotas;
        private TextBox txtDetalles;
        private Button btnRegistrarPago;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}
