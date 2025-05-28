namespace AutoGestion.Vista
{
    partial class AsignarRoles
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
            tableLayoutPanel1 = new TableLayoutPanel();
            txtNuevoPermiso = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            lstUsuarios = new ListBox();
            btnAgregarUsuario = new Button();
            txtNuevoUsuario = new TextBox();
            btnAgregarRol = new Button();
            txtNuevoRol = new TextBox();
            lstRoles = new ListBox();
            btnAgregarPermiso = new Button();
            lstPermisos = new ListBox();
            tvPermisos = new TreeView();
            btnGuardarRol = new Button();
            label4 = new Label();
            label5 = new Label();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Controls.Add(txtNuevoPermiso, 2, 1);
            tableLayoutPanel1.Controls.Add(label2, 1, 0);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(lstUsuarios, 0, 3);
            tableLayoutPanel1.Controls.Add(btnAgregarUsuario, 0, 2);
            tableLayoutPanel1.Controls.Add(txtNuevoUsuario, 0, 1);
            tableLayoutPanel1.Controls.Add(btnAgregarRol, 1, 2);
            tableLayoutPanel1.Controls.Add(txtNuevoRol, 1, 1);
            tableLayoutPanel1.Controls.Add(lstRoles, 1, 3);
            tableLayoutPanel1.Controls.Add(btnAgregarPermiso, 2, 2);
            tableLayoutPanel1.Controls.Add(lstPermisos, 2, 3);
            tableLayoutPanel1.Controls.Add(tvPermisos, 3, 3);
            tableLayoutPanel1.Controls.Add(btnGuardarRol, 3, 2);
            tableLayoutPanel1.Controls.Add(label4, 3, 0);
            tableLayoutPanel1.Controls.Add(label3, 2, 0);
            tableLayoutPanel1.Location = new Point(0, 57);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 6.13107824F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 8.879493F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 75.26427F));
            tableLayoutPanel1.Size = new Size(657, 452);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // txtNuevoPermiso
            // 
            txtNuevoPermiso.Location = new Point(331, 48);
            txtNuevoPermiso.Name = "txtNuevoPermiso";
            txtNuevoPermiso.Size = new Size(158, 23);
            txtNuevoPermiso.TabIndex = 11;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Sans Serif Collection", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(331, 0);
            label3.Name = "label3";
            label3.Size = new Size(94, 45);
            label3.TabIndex = 2;
            label3.Text = "Permisos";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sans Serif Collection", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(167, 0);
            label2.Name = "label2";
            label2.Size = new Size(47, 45);
            label2.TabIndex = 1;
            label2.Text = "Rol";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sans Serif Collection", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(83, 45);
            label1.TabIndex = 0;
            label1.Text = "Usuario";
            // 
            // lstUsuarios
            // 
            lstUsuarios.DisplayMember = "\"Nombre\"";
            lstUsuarios.FormattingEnabled = true;
            lstUsuarios.Location = new Point(3, 115);
            lstUsuarios.Name = "lstUsuarios";
            lstUsuarios.SelectionMode = SelectionMode.MultiExtended;
            lstUsuarios.Size = new Size(158, 334);
            lstUsuarios.TabIndex = 6;
            // 
            // btnAgregarUsuario
            // 
            btnAgregarUsuario.Location = new Point(3, 75);
            btnAgregarUsuario.Name = "btnAgregarUsuario";
            btnAgregarUsuario.Size = new Size(158, 34);
            btnAgregarUsuario.TabIndex = 5;
            btnAgregarUsuario.Text = "Agregar Usuario";
            btnAgregarUsuario.UseVisualStyleBackColor = true;
            btnAgregarUsuario.Click += btnAgregarUsuario_Click;
            // 
            // txtNuevoUsuario
            // 
            txtNuevoUsuario.Location = new Point(3, 48);
            txtNuevoUsuario.Name = "txtNuevoUsuario";
            txtNuevoUsuario.Size = new Size(158, 23);
            txtNuevoUsuario.TabIndex = 7;
            // 
            // btnAgregarRol
            // 
            btnAgregarRol.Location = new Point(167, 75);
            btnAgregarRol.Name = "btnAgregarRol";
            btnAgregarRol.Size = new Size(158, 34);
            btnAgregarRol.TabIndex = 8;
            btnAgregarRol.Text = "Agregar Rol";
            btnAgregarRol.UseVisualStyleBackColor = true;
            // 
            // txtNuevoRol
            // 
            txtNuevoRol.Location = new Point(167, 48);
            txtNuevoRol.Name = "txtNuevoRol";
            txtNuevoRol.Size = new Size(158, 23);
            txtNuevoRol.TabIndex = 10;
            // 
            // lstRoles
            // 
            lstRoles.DisplayMember = "\"Nombre\"";
            lstRoles.FormattingEnabled = true;
            lstRoles.Location = new Point(167, 115);
            lstRoles.Name = "lstRoles";
            lstRoles.SelectionMode = SelectionMode.MultiExtended;
            lstRoles.Size = new Size(158, 334);
            lstRoles.TabIndex = 9;
            // 
            // btnAgregarPermiso
            // 
            btnAgregarPermiso.Location = new Point(331, 75);
            btnAgregarPermiso.Name = "btnAgregarPermiso";
            btnAgregarPermiso.Size = new Size(158, 34);
            btnAgregarPermiso.TabIndex = 12;
            btnAgregarPermiso.Text = "Agregar Permiso\n";
            btnAgregarPermiso.UseVisualStyleBackColor = true;
            // 
            // lstPermisos
            // 
            lstPermisos.DisplayMember = "\"Nombre\"";
            lstPermisos.FormattingEnabled = true;
            lstPermisos.Location = new Point(331, 115);
            lstPermisos.Name = "lstPermisos";
            lstPermisos.SelectionMode = SelectionMode.MultiExtended;
            lstPermisos.Size = new Size(158, 334);
            lstPermisos.TabIndex = 13;
            // 
            // tvPermisos
            // 
            tvPermisos.Location = new Point(495, 115);
            tvPermisos.Name = "tvPermisos";
            tvPermisos.Size = new Size(159, 334);
            tvPermisos.TabIndex = 14;
            // 
            // btnGuardarRol
            // 
            btnGuardarRol.Location = new Point(495, 75);
            btnGuardarRol.Name = "btnGuardarRol";
            btnGuardarRol.Size = new Size(158, 34);
            btnGuardarRol.TabIndex = 15;
            btnGuardarRol.Text = "Guardar";
            btnGuardarRol.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Sans Serif Collection", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(495, 0);
            label4.Name = "label4";
            label4.Size = new Size(157, 45);
            label4.TabIndex = 3;
            label4.Text = "Estructura del Rol";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Sans Serif Collection", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(247, 0);
            label5.Name = "label5";
            label5.Size = new Size(170, 54);
            label5.TabIndex = 1;
            label5.Text = "Asignación de Rol";
            // 
            // AsignarRoles
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label5);
            Controls.Add(tableLayoutPanel1);
            Name = "AsignarRoles";
            Size = new Size(657, 509);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnAgregarUsuario;
        private ListBox lstUsuarios;
        private TextBox txtNuevoUsuario;
        private Label label5;
        private TextBox txtNuevoPermiso;
        private Button btnAgregarRol;
        private TextBox txtNuevoRol;
        private ListBox lstRoles;
        private Button btnAgregarPermiso;
        private ListBox lstPermisos;
        private TreeView tvPermisos;
        private Button btnGuardarRol;
    }
}
