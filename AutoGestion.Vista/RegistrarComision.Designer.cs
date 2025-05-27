namespace AutoGestion.Vista
{
    partial class RegistrarComision
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
            dgvVentas = new DataGridView();
            label2 = new Label();
            label3 = new Label();
            txtPorcentaje = new TextBox();
            cmbEstado = new ComboBox();
            btnRegistrar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sans Serif Collection", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(184, 54);
            label1.TabIndex = 0;
            label1.Text = "REgistrar Comisión";
            // 
            // dgvVentas
            // 
            dgvVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVentas.Location = new Point(11, 40);
            dgvVentas.Name = "dgvVentas";
            dgvVentas.Size = new Size(414, 270);
            dgvVentas.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 338);
            label2.Name = "label2";
            label2.Size = new Size(66, 15);
            label2.TabIndex = 2;
            label2.Text = "Porcentaje:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(228, 338);
            label3.Name = "label3";
            label3.Size = new Size(45, 15);
            label3.TabIndex = 3;
            label3.Text = "Estado:";
            // 
            // txtPorcentaje
            // 
            txtPorcentaje.Location = new Point(84, 330);
            txtPorcentaje.Name = "txtPorcentaje";
            txtPorcentaje.Size = new Size(138, 23);
            txtPorcentaje.TabIndex = 4;
            // 
            // cmbEstado
            // 
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Location = new Point(279, 330);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(121, 23);
            cmbEstado.TabIndex = 5;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Location = new Point(226, 374);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(174, 42);
            btnRegistrar.TabIndex = 6;
            btnRegistrar.Text = "Registrar Comisión";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // RegistrarComision
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnRegistrar);
            Controls.Add(cmbEstado);
            Controls.Add(txtPorcentaje);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(dgvVentas);
            Controls.Add(label1);
            Name = "RegistrarComision";
            Size = new Size(438, 430);
            ((System.ComponentModel.ISupportInitialize)dgvVentas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dgvVentas;
        private Label label2;
        private Label label3;
        private TextBox txtPorcentaje;
        private ComboBox cmbEstado;
        private Button btnRegistrar;
    }
}
