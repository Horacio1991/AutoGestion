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
    }
}
