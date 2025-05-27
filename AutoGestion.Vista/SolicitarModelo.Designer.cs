namespace AutoGestion.Vista
{
    partial class SolicitarModelo
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
            lblBuscarVehiculo = new Label();
            lblModelo = new Label();
            txtModelo = new TextBox();
            btnBuscar = new Button();
            lblResultados = new Label();
            dgvResultados = new DataGridView();
            Marca = new DataGridViewTextBoxColumn();
            Modelo = new DataGridViewTextBoxColumn();
            Año = new DataGridViewTextBoxColumn();
            Color = new DataGridViewTextBoxColumn();
            Km = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvResultados).BeginInit();
            SuspendLayout();
            // 
            // lblBuscarVehiculo
            // 
            lblBuscarVehiculo.AutoSize = true;
            lblBuscarVehiculo.Font = new Font("Sans Serif Collection", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBuscarVehiculo.Location = new Point(0, 0);
            lblBuscarVehiculo.Name = "lblBuscarVehiculo";
            lblBuscarVehiculo.Size = new Size(157, 54);
            lblBuscarVehiculo.TabIndex = 0;
            lblBuscarVehiculo.Text = "Buscar Vehículo";
            // 
            // lblModelo
            // 
            lblModelo.AutoSize = true;
            lblModelo.Font = new Font("Sans Serif Collection", 8.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblModelo.Location = new Point(37, 43);
            lblModelo.Name = "lblModelo";
            lblModelo.Size = new Size(70, 41);
            lblModelo.TabIndex = 1;
            lblModelo.Text = "Modelo:";
            // 
            // txtModelo
            // 
            txtModelo.Location = new Point(103, 48);
            txtModelo.Name = "txtModelo";
            txtModelo.Size = new Size(220, 23);
            txtModelo.TabIndex = 2;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(329, 48);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 3;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // lblResultados
            // 
            lblResultados.AutoSize = true;
            lblResultados.Font = new Font("Sans Serif Collection", 8.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblResultados.Location = new Point(3, 94);
            lblResultados.Name = "lblResultados";
            lblResultados.Size = new Size(89, 41);
            lblResultados.TabIndex = 4;
            lblResultados.Text = "Resultados";
            // 
            // dgvResultados
            // 
            dgvResultados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResultados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvResultados.Columns.AddRange(new DataGridViewColumn[] { Marca, Modelo, Año, Color, Km });
            dgvResultados.Location = new Point(10, 123);
            dgvResultados.Name = "dgvResultados";
            dgvResultados.ReadOnly = true;
            dgvResultados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResultados.Size = new Size(541, 222);
            dgvResultados.TabIndex = 5;
            // 
            // Marca
            // 
            Marca.HeaderText = "Marca";
            Marca.Name = "Marca";
            Marca.ReadOnly = true;
            // 
            // Modelo
            // 
            Modelo.HeaderText = "Modelo";
            Modelo.Name = "Modelo";
            Modelo.ReadOnly = true;
            // 
            // Año
            // 
            Año.HeaderText = "Año";
            Año.Name = "Año";
            Año.ReadOnly = true;
            // 
            // Color
            // 
            Color.HeaderText = "Color";
            Color.Name = "Color";
            Color.ReadOnly = true;
            // 
            // Km
            // 
            Km.HeaderText = "Km";
            Km.Name = "Km";
            Km.ReadOnly = true;
            // 
            // SolicitarModelo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvResultados);
            Controls.Add(lblResultados);
            Controls.Add(btnBuscar);
            Controls.Add(txtModelo);
            Controls.Add(lblModelo);
            Controls.Add(lblBuscarVehiculo);
            Name = "SolicitarModelo";
            Size = new Size(554, 348);
            ((System.ComponentModel.ISupportInitialize)dgvResultados).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBuscarVehiculo;
        private Label lblModelo;
        private TextBox txtModelo;
        private Button btnBuscar;
        private Label lblResultados;
        private DataGridView dgvResultados;
        private DataGridViewTextBoxColumn Marca;
        private DataGridViewTextBoxColumn Modelo;
        private DataGridViewTextBoxColumn Año;
        private DataGridViewTextBoxColumn Color;
        private DataGridViewTextBoxColumn Km;
    }
}
