using AutoGestion.BE.Seguridad;

namespace AutoGestion.Vista
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void mnuRegistrarCliente_Click(object sender, EventArgs e)
        {
            panelContenido.Controls.Clear();
            var control = new RegistrarCliente();
            control.Dock = DockStyle.Fill;
            panelContenido.Controls.Add(control);
        }

        private void mnuSolicitarModelo_Click(object sender, EventArgs e)
        {
            panelContenido.Controls.Clear();
            var control = new SolicitarModelo();
            control.Dock = DockStyle.Fill;
            panelContenido.Controls.Add(control);
        }

        private void mnuRealizarPago_Click(object sender, EventArgs e)
        {
            panelContenido.Controls.Clear();
            var control = new RealizarPago();
            control.Dock = DockStyle.Fill;
            panelContenido.Controls.Add(control);
        }

        private void mnuAutorizarVenta_Click(object sender, EventArgs e)
        {
            panelContenido.Controls.Clear();
            var control = new AutorizarVenta();
            control.Dock = DockStyle.Fill;
            panelContenido.Controls.Add(control);
        }

        private void mnuEmitirFactura_Click(object sender, EventArgs e)
        {
            panelContenido.Controls.Clear();
            var control = new EmitirFactura();
            control.Dock = DockStyle.Fill;
            panelContenido.Controls.Add(control);
        }

        private void mnuRealizarEntrega_Click(object sender, EventArgs e)
        {
            panelContenido.Controls.Clear();
            var control = new RealizarEntrega();
            control.Dock = DockStyle.Fill;
            panelContenido.Controls.Add(control);
        }

        private void mnuRegistrarOferta_Click(object sender, EventArgs e)
        {
            panelContenido.Controls.Clear();
            var control = new RegistrarOferta();
            control.Dock = DockStyle.Fill;
            panelContenido.Controls.Add(control);
        }

        private void mnuEvaluarVehiculo_Click(object sender, EventArgs e)
        {
            panelContenido.Controls.Clear();
            var control = new EvaluarEstado();
            control.Dock = DockStyle.Fill;
            panelContenido.Controls.Add(control);
        }

        private void mnuTasarVehiculo_Click(object sender, EventArgs e)
        {
            panelContenido.Controls.Clear();
            var control = new TasarVehiculo();
            control.Dock = DockStyle.Fill;
            panelContenido.Controls.Add(control);
        }

        private void mnuRegistrarCompra_Click(object sender, EventArgs e)
        {
            panelContenido.Controls.Clear();
            var control = new RegistrarDatos();
            control.Dock = DockStyle.Fill;
            panelContenido.Controls.Add(control);
        }

        private void mnuRegistrarComision_Click(object sender, EventArgs e)
        {
            panelContenido.Controls.Clear();
            var control = new RegistrarComision();
            control.Dock = DockStyle.Fill;
            panelContenido.Controls.Add(control);
        }

        private void mnuConsultarComisiones_Click(object sender, EventArgs e)
        {
            panelContenido.Controls.Clear();
            var control = new ConsultarComisiones();
            control.Dock = DockStyle.Fill;
            panelContenido.Controls.Add(control);
        }

        private void mnuRegistrarTurno_Click(object sender, EventArgs e)
        {
            panelContenido.Controls.Clear();
            var control = new RegistrarTurno();
            control.Dock = DockStyle.Fill;
            panelContenido.Controls.Add(control);
        }

        private void mnuRegistrarAsistencia_Click(object sender, EventArgs e)
        {
            panelContenido.Controls.Clear();
            var control = new RegistrarAsistencia();
            control.Dock = DockStyle.Fill;
            panelContenido.Controls.Add(control);
        }

        private void asignarRolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelContenido.Controls.Clear();
            var control = new AsignarRoles();
            control.Dock = DockStyle.Fill;
            panelContenido.Controls.Add(control);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var usuario = Sesion.UsuarioActual;

            // Si es superadmin, ve todo
            if (usuario.Nombre.ToLower() == "admin")
                return;

            // -------- GESTIÓN DE VENTAS --------
            mnuSolicitarModelo.Visible = usuario.TienePermiso("Solicitar Modelo");
            mnuRealizarPago.Visible = usuario.TienePermiso("Realizar Pago");
            mnuAutorizarVenta.Visible = usuario.TienePermiso("Autorizar Venta");
            mnuEmitirFactura.Visible = usuario.TienePermiso("Emitir Factura");
            mnuRealizarEntrega.Visible = usuario.TienePermiso("Realizar Entrega");

            // -------- GESTIÓN DE COMPRAS --------
            mnuRegistrarOferta.Visible = usuario.TienePermiso("Registrar Oferta");
            mnuEvaluarVehiculo.Visible = usuario.TienePermiso("Evaluar Vehículo");
            mnuTasarVehiculo.Visible = usuario.TienePermiso("Tasar Vehículo");
            mnuRegistrarCompra.Visible = usuario.TienePermiso("Registrar Compra");

            // -------- GESTIÓN DE COMISIONES --------
            mnuRegistrarComision.Visible = usuario.TienePermiso("Registrar Comisión");
            mnuConsultarComisiones.Visible = usuario.TienePermiso("Consultar Comisiones");

            // -------- GESTIÓN DE TURNOS --------
            mnuRegistrarTurno.Visible = usuario.TienePermiso("Registrar Turno");
            mnuRegistrarAsistencia.Visible = usuario.TienePermiso("Registrar Asistencia");

            // -------- SEGURIDAD --------
            mnuAsignarRoles.Visible = usuario.TienePermiso("Asignar Roles");
        }
    }
}
