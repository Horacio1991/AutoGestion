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
    }
}
