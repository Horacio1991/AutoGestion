namespace AutoGestion.Vista
{
    partial class RealizarEntrega
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
            dgvEntregas = new DataGridView();
            btnEntregar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvEntregas).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sans Serif Collection", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(161, 54);
            label1.TabIndex = 0;
            label1.Text = "Realizar Entrega";
            // 
            // dgvEntregas
            // 
            dgvEntregas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEntregas.Location = new Point(3, 46);
            dgvEntregas.Name = "dgvEntregas";
            dgvEntregas.Size = new Size(474, 166);
            dgvEntregas.TabIndex = 1;
            // 
            // btnEntregar
            // 
            btnEntregar.Location = new Point(317, 235);
            btnEntregar.Name = "btnEntregar";
            btnEntregar.Size = new Size(148, 45);
            btnEntregar.TabIndex = 2;
            btnEntregar.Text = "Confirmar Entrega";
            btnEntregar.UseVisualStyleBackColor = true;
            btnEntregar.Click += btnEntregar_Click;
            // 
            // RealizarEntrega
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnEntregar);
            Controls.Add(dgvEntregas);
            Controls.Add(label1);
            Name = "RealizarEntrega";
            Size = new Size(480, 339);
            ((System.ComponentModel.ISupportInitialize)dgvEntregas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dgvEntregas;
        private Button btnEntregar;
    }
}
