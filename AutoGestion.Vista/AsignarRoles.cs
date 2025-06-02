using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AutoGestion.Entidades.Seguridad;
using AutoGestion.Servicios;

namespace AutoGestion.Vista
{
    public partial class AsignarRoles : UserControl
    {
        private List<PermisoCompuesto> _roles = new();
        private List<PermisoSimple> _permisos = new();

        public AsignarRoles()
        {
            InitializeComponent();

            _roles = RolXmlService.Leer();
            CargarTreeViewRoles();
            _permisos = PermisoXmlService.Leer();
            CargarTreeViewPermisos();

        }
        private void CargarTreeViewRoles()
        {
            tvRoles.Nodes.Clear();

            foreach (var rol in _roles)
            {
                TreeNode nodoRol = new TreeNode(rol.Nombre);
                nodoRol.Tag = rol;

                AgregarHijosAlNodo(nodoRol, rol);

                tvRoles.Nodes.Add(nodoRol);
            }
        }

        private void AgregarHijosAlNodo(TreeNode nodoPadre, IPermiso permiso)
        {
            foreach (var hijo in permiso.ObtenerHijos())
            {
                TreeNode nodoHijo = new TreeNode(hijo.Nombre);
                nodoHijo.Tag = hijo;

                if (hijo is PermisoCompuesto)
                    AgregarHijosAlNodo(nodoHijo, hijo);

                nodoPadre.Nodes.Add(nodoHijo);
            }
        }

        private void btnAltaRol_Click_1(object sender, EventArgs e)
        {
            string nombre = txtNombreRol.Text.Trim();
            if (string.IsNullOrEmpty(nombre)) return;

            var nuevoRol = new PermisoCompuesto { Nombre = nombre };
            _roles.Add(nuevoRol);
            RolXmlService.Guardar(_roles);
            CargarTreeViewRoles();

            txtNombreRol.Clear();
            txtIdRol.Clear();
        }

        private void CargarTreeViewPermisos()
        {
            tvPermisos.Nodes.Clear();

            foreach (var permiso in _permisos)
            {
                TreeNode nodo = new TreeNode(permiso.Nombre);
                nodo.Tag = permiso;
                tvPermisos.Nodes.Add(nodo);
            }
        }

        private void btnAltaPermiso_Click(object sender, EventArgs e)
        {
            string nombre = txtNombrePermiso.Text.Trim();
            if (string.IsNullOrEmpty(nombre)) return;

            if (_permisos.Any(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Ese permiso ya existe.");
                return;
            }

            var nuevo = new PermisoSimple { Nombre = nombre };
            _permisos.Add(nuevo);
            PermisoXmlService.Guardar(_permisos);
            CargarTreeViewPermisos();

            txtNombrePermiso.Clear();
        }

    }
}
