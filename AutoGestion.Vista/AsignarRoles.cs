using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AutoGestion.Entidades.Seguridad;

namespace AutoGestion.Vista
{
    public partial class AsignarRoles : UserControl
    {
        private List<Usuario> _usuarios = new();
        private List<PermisoCompuesto> _roles = new();
        private List<PermisoSimple> _permisos = new();

        public AsignarRoles()
        {
            InitializeComponent();
        }

        // AGREGAR USUARIO
        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            string nombre = txtNuevoUsuario.Text.Trim();
            if (string.IsNullOrEmpty(nombre)) return;

            var usuario = new Usuario { Nombre = nombre, Clave = "123" }; // clave por defecto
            _usuarios.Add(usuario);

            lstUsuarios.Items.Add(usuario);
            txtNuevoUsuario.Clear();
        }

        // AGREGAR ROL
        private void btnAgregarRol_Click(object sender, EventArgs e)
        {
            string nombre = txtNuevoRol.Text.Trim();
            if (string.IsNullOrEmpty(nombre)) return;

            var rol = new PermisoCompuesto { Nombre = nombre };
            _roles.Add(rol);

            lstRoles.Items.Add(rol);
            txtNuevoRol.Clear();
        }

        // AGREGAR PERMISO
        private void btnAgregarPermiso_Click(object sender, EventArgs e)
        {
            string nombre = txtNuevoPermiso.Text.Trim();
            if (string.IsNullOrEmpty(nombre)) return;

            var permiso = new PermisoSimple { Nombre = nombre };
            _permisos.Add(permiso);

            lstPermisos.Items.Add(permiso);
            txtNuevoPermiso.Clear();
        }

        // GUARDAR ROL y ASIGNAR AL USUARIO
        private void btnGuardarRol_Click(object sender, EventArgs e)
        {
            if (lstUsuarios.SelectedItem == null)
            {
                MessageBox.Show("Seleccioná un usuario.");
                return;
            }

            if (lstRoles.SelectedItem == null)
            {
                MessageBox.Show("Seleccioná un rol.");
                return;
            }

            if (lstPermisos.SelectedItems.Count == 0)
            {
                MessageBox.Show("Seleccioná al menos un permiso.");
                return;
            }

            var usuario = (Usuario)lstUsuarios.SelectedItem;
            var rol = (PermisoCompuesto)lstRoles.SelectedItem;

            // Limpiar hijos actuales del rol
            rol.ObtenerHijos().Clear();

            foreach (var item in lstPermisos.SelectedItems)
            {
                if (item is PermisoSimple permiso)
                    rol.Agregar(permiso);
            }

            usuario.Rol = rol;

            // Mostrar en el árbol
            tvPermisos.Nodes.Clear();
            CargarArbol(usuario.Rol, null);

            MessageBox.Show("Rol asignado correctamente.");
        }

        // RECURSIVO PARA ARMAR TREEVIEW
        private void CargarArbol(IPermiso permiso, TreeNode nodoPadre)
        {
            TreeNode nodo = new TreeNode(permiso.Nombre) { Tag = permiso };

            if (nodoPadre == null)
                tvPermisos.Nodes.Add(nodo);
            else
                nodoPadre.Nodes.Add(nodo);

            foreach (var hijo in permiso.ObtenerHijos())
                CargarArbol(hijo, nodo);
        }
    }
}
