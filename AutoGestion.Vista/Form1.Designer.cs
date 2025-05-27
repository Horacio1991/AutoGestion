namespace AutoGestion.Vista
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuPrincipal = new MenuStrip();
            gestionVentasToolStripMenuItem = new ToolStripMenuItem();
            mnuSolicitarModelo = new ToolStripMenuItem();
            mnuRegistrarCliente = new ToolStripMenuItem();
            mnuRealizarPago = new ToolStripMenuItem();
            mnuAutorizarVenta = new ToolStripMenuItem();
            mnuEmitirFactura = new ToolStripMenuItem();
            mnuRealizarEntrega = new ToolStripMenuItem();
            gestiónComprasToolStripMenuItem = new ToolStripMenuItem();
            mnuRegistrarOferta = new ToolStripMenuItem();
            mnuEvaluarVehiculo = new ToolStripMenuItem();
            mnuTasarVehiculo = new ToolStripMenuItem();
            mnuRegistrarCompra = new ToolStripMenuItem();
            gestionComisionesToolStripMenuItem = new ToolStripMenuItem();
            mnuRegistrarComision = new ToolStripMenuItem();
            mnuConsultarComisiones = new ToolStripMenuItem();
            gestiónTurnosToolStripMenuItem = new ToolStripMenuItem();
            mnuRegistrarTurno = new ToolStripMenuItem();
            mnuRegistrarAsistencia = new ToolStripMenuItem();
            panelContenido = new Panel();
            menuPrincipal.SuspendLayout();
            SuspendLayout();
            // 
            // menuPrincipal
            // 
            menuPrincipal.Items.AddRange(new ToolStripItem[] { gestionVentasToolStripMenuItem, gestiónComprasToolStripMenuItem, gestionComisionesToolStripMenuItem, gestiónTurnosToolStripMenuItem });
            menuPrincipal.Location = new Point(0, 0);
            menuPrincipal.Name = "menuPrincipal";
            menuPrincipal.Size = new Size(800, 24);
            menuPrincipal.TabIndex = 0;
            menuPrincipal.Text = "menuStrip1";
            // 
            // gestionVentasToolStripMenuItem
            // 
            gestionVentasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mnuSolicitarModelo, mnuRegistrarCliente, mnuRealizarPago, mnuAutorizarVenta, mnuEmitirFactura, mnuRealizarEntrega });
            gestionVentasToolStripMenuItem.Name = "gestionVentasToolStripMenuItem";
            gestionVentasToolStripMenuItem.Size = new Size(96, 20);
            gestionVentasToolStripMenuItem.Text = "Gestión Ventas";
            // 
            // mnuSolicitarModelo
            // 
            mnuSolicitarModelo.Name = "mnuSolicitarModelo";
            mnuSolicitarModelo.Size = new Size(160, 22);
            mnuSolicitarModelo.Text = "Solicitar Modelo";
            mnuSolicitarModelo.Click += mnuSolicitarModelo_Click;
            // 
            // mnuRegistrarCliente
            // 
            mnuRegistrarCliente.Name = "mnuRegistrarCliente";
            mnuRegistrarCliente.Size = new Size(160, 22);
            mnuRegistrarCliente.Text = "Registrar Cliente";
            mnuRegistrarCliente.Click += mnuRegistrarCliente_Click;
            // 
            // mnuRealizarPago
            // 
            mnuRealizarPago.Name = "mnuRealizarPago";
            mnuRealizarPago.Size = new Size(160, 22);
            mnuRealizarPago.Text = "Realizar Pago";
            mnuRealizarPago.Click += mnuRealizarPago_Click;
            // 
            // mnuAutorizarVenta
            // 
            mnuAutorizarVenta.Name = "mnuAutorizarVenta";
            mnuAutorizarVenta.Size = new Size(160, 22);
            mnuAutorizarVenta.Text = "Autorizar Venta";
            mnuAutorizarVenta.Click += mnuAutorizarVenta_Click;
            // 
            // mnuEmitirFactura
            // 
            mnuEmitirFactura.Name = "mnuEmitirFactura";
            mnuEmitirFactura.Size = new Size(160, 22);
            mnuEmitirFactura.Text = "Emitir Factura";
            mnuEmitirFactura.Click += mnuEmitirFactura_Click;
            // 
            // mnuRealizarEntrega
            // 
            mnuRealizarEntrega.Name = "mnuRealizarEntrega";
            mnuRealizarEntrega.Size = new Size(160, 22);
            mnuRealizarEntrega.Text = "Realizar Entrega";
            mnuRealizarEntrega.Click += mnuRealizarEntrega_Click;
            // 
            // gestiónComprasToolStripMenuItem
            // 
            gestiónComprasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mnuRegistrarOferta, mnuEvaluarVehiculo, mnuTasarVehiculo, mnuRegistrarCompra });
            gestiónComprasToolStripMenuItem.Name = "gestiónComprasToolStripMenuItem";
            gestiónComprasToolStripMenuItem.Size = new Size(110, 20);
            gestiónComprasToolStripMenuItem.Text = "Gestión Compras";
            // 
            // mnuRegistrarOferta
            // 
            mnuRegistrarOferta.Name = "mnuRegistrarOferta";
            mnuRegistrarOferta.Size = new Size(180, 22);
            mnuRegistrarOferta.Text = "Registrar Oferta";
            mnuRegistrarOferta.Click += mnuRegistrarOferta_Click;
            // 
            // mnuEvaluarVehiculo
            // 
            mnuEvaluarVehiculo.Name = "mnuEvaluarVehiculo";
            mnuEvaluarVehiculo.Size = new Size(180, 22);
            mnuEvaluarVehiculo.Text = "Evaluar Vehículo";
            mnuEvaluarVehiculo.Click += mnuEvaluarVehiculo_Click;
            // 
            // mnuTasarVehiculo
            // 
            mnuTasarVehiculo.Name = "mnuTasarVehiculo";
            mnuTasarVehiculo.Size = new Size(180, 22);
            mnuTasarVehiculo.Text = "Tasar Vehículo";
            mnuTasarVehiculo.Click += mnuTasarVehiculo_Click;
            // 
            // mnuRegistrarCompra
            // 
            mnuRegistrarCompra.Name = "mnuRegistrarCompra";
            mnuRegistrarCompra.Size = new Size(180, 22);
            mnuRegistrarCompra.Text = "Registrar Compra";
            mnuRegistrarCompra.Click += mnuRegistrarCompra_Click;
            // 
            // gestionComisionesToolStripMenuItem
            // 
            gestionComisionesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mnuRegistrarComision, mnuConsultarComisiones });
            gestionComisionesToolStripMenuItem.Name = "gestionComisionesToolStripMenuItem";
            gestionComisionesToolStripMenuItem.Size = new Size(124, 20);
            gestionComisionesToolStripMenuItem.Text = "Gestion Comisiones";
            // 
            // mnuRegistrarComision
            // 
            mnuRegistrarComision.Name = "mnuRegistrarComision";
            mnuRegistrarComision.Size = new Size(190, 22);
            mnuRegistrarComision.Text = "Registrar Comisión";
            // 
            // mnuConsultarComisiones
            // 
            mnuConsultarComisiones.Name = "mnuConsultarComisiones";
            mnuConsultarComisiones.Size = new Size(190, 22);
            mnuConsultarComisiones.Text = "Consultar Comisiones";
            // 
            // gestiónTurnosToolStripMenuItem
            // 
            gestiónTurnosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mnuRegistrarTurno, mnuRegistrarAsistencia });
            gestiónTurnosToolStripMenuItem.Name = "gestiónTurnosToolStripMenuItem";
            gestiónTurnosToolStripMenuItem.Size = new Size(99, 20);
            gestiónTurnosToolStripMenuItem.Text = "Gestión Turnos";
            // 
            // mnuRegistrarTurno
            // 
            mnuRegistrarTurno.Name = "mnuRegistrarTurno";
            mnuRegistrarTurno.Size = new Size(176, 22);
            mnuRegistrarTurno.Text = "Registrar Turno";
            // 
            // mnuRegistrarAsistencia
            // 
            mnuRegistrarAsistencia.Name = "mnuRegistrarAsistencia";
            mnuRegistrarAsistencia.Size = new Size(176, 22);
            mnuRegistrarAsistencia.Text = "Registrar Asistencia";
            // 
            // panelContenido
            // 
            panelContenido.BorderStyle = BorderStyle.FixedSingle;
            panelContenido.Dock = DockStyle.Fill;
            panelContenido.Location = new Point(0, 24);
            panelContenido.Name = "panelContenido";
            panelContenido.Size = new Size(800, 426);
            panelContenido.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelContenido);
            Controls.Add(menuPrincipal);
            MainMenuStrip = menuPrincipal;
            Name = "Form1";
            Text = "Form1";
            menuPrincipal.ResumeLayout(false);
            menuPrincipal.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuPrincipal;
        private ToolStripMenuItem gestionVentasToolStripMenuItem;
        private ToolStripMenuItem mnuSolicitarModelo;
        private ToolStripMenuItem mnuRegistrarCliente;
        private ToolStripMenuItem mnuRealizarPago;
        private ToolStripMenuItem mnuAutorizarVenta;
        private ToolStripMenuItem mnuEmitirFactura;
        private ToolStripMenuItem mnuRealizarEntrega;
        private ToolStripMenuItem gestiónComprasToolStripMenuItem;
        private ToolStripMenuItem mnuRegistrarOferta;
        private ToolStripMenuItem mnuEvaluarVehiculo;
        private ToolStripMenuItem mnuTasarVehiculo;
        private ToolStripMenuItem mnuRegistrarCompra;
        private ToolStripMenuItem gestionComisionesToolStripMenuItem;
        private ToolStripMenuItem mnuRegistrarComision;
        private ToolStripMenuItem mnuConsultarComisiones;
        private ToolStripMenuItem gestiónTurnosToolStripMenuItem;
        private ToolStripMenuItem mnuRegistrarTurno;
        private ToolStripMenuItem mnuRegistrarAsistencia;
        private Panel panelContenido;
    }
}
