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
        private List<Usuario> _usuarios = new();
        private List<PermisoCompuesto> _roles = new();
        private List<PermisoSimple> _permisos = new();

        public AsignarRoles()
        {
            InitializeComponent();

            lstUsuarios.DisplayMember = "Nombre";
            lstRoles.DisplayMember = "Nombre";
            lstPermisos.DisplayMember = "Nombre";
            lstPermisos.SelectionMode = SelectionMode.MultiExtended;

            _usuarios = UsuarioXmlService.Leer();

            HashSet<string> permisosUnicos = new();
            HashSet<string> rolesCreados = new();

            foreach (var u in _usuarios)
            {
                lstUsuarios.Items.Add(u);

                if (u.Rol != null)
                {
                    // Cargar roles únicos
                    if (!rolesCreados.Contains(u.Rol.Nombre))
                    {
                        lstRoles.Items.Add(u.Rol);
                        rolesCreados.Add(u.Rol.Nombre);
                    }

                    // Cargar permisos simples únicos
                    foreach (var p in ObtenerPermisosSimples(u.Rol))
                    {
                        if (permisosUnicos.Add(p.Nombre))
                            lstPermisos.Items.Add(p);
                    }
                }
            }

            // Mostrar árbol con todos los usuarios y sus roles
            tvPermisos.Nodes.Clear();
            foreach (var u in _usuarios)
                CargarArbol(u.Rol, new TreeNode(u.Nombre));
        }

        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            string nombre = txtNuevoUsuario.Text.Trim();
            if (string.IsNullOrEmpty(nombre)) return;

            if (_usuarios.Any(u => u.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Ese usuario ya existe.");
                return;
            }

            var usuario = new Usuario { Nombre = nombre, Clave = "123" };
            _usuarios.Add(usuario);
            lstUsuarios.Items.Add(usuario);
            txtNuevoUsuario.Clear();
        }

        private void btnAgregarRol_Click_1(object sender, EventArgs e)
        {
            string nombre = txtNuevoRol.Text.Trim();
            if (string.IsNullOrEmpty(nombre)) return;

            var rol = new PermisoCompuesto { Nombre = nombre };
            _roles.Add(rol);
            lstRoles.Items.Add(rol);
            txtNuevoRol.Clear();
        }

        private void btnAgregarPermiso_Click_1(object sender, EventArgs e)
        {
            string nombre = txtNuevoPermiso.Text.Trim();
            if (string.IsNullOrEmpty(nombre)) return;

            var permiso = new PermisoSimple { Nombre = nombre };
            _permisos.Add(permiso);
            lstPermisos.Items.Add(permiso);
            lstPermisos.SelectedItem = permiso;
            txtNuevoPermiso.Clear();
        }

        private void btnGuardarRol_Click_1(object sender, EventArgs e)
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

            rol.ObtenerHijos().Clear();

            foreach (var item in lstPermisos.SelectedItems)
            {
                if (item is PermisoSimple permiso)
                    rol.Agregar(permiso);
            }

            usuario.Rol = rol;

            // Cargar usuarios existentes del XML
            List<Usuario> usuariosExistentes = UsuarioXmlService.Leer();

            var existente = usuariosExistentes.FirstOrDefault(u => u.Nombre == usuario.Nombre);
            if (existente != null)
                existente.Rol = rol;
            else
                usuariosExistentes.Add(usuario);

            UsuarioXmlService.Guardar(usuariosExistentes);

            // Recargar árbol completo
            tvPermisos.Nodes.Clear();
            foreach (var u in usuariosExistentes)
                CargarArbol(u.Rol, new TreeNode(u.Nombre));

            MessageBox.Show("Rol guardado correctamente.");
        }

        private List<PermisoSimple> ObtenerPermisosSimples(IPermiso permiso)
        {
            List<PermisoSimple> lista = new();

            if (permiso is PermisoSimple simple)
                lista.Add(simple);
            else
                foreach (var hijo in permiso.ObtenerHijos())
                    lista.AddRange(ObtenerPermisosSimples(hijo));

            return lista;
        }

        private void CargarArbol(IPermiso permiso, TreeNode nodoPadre)
        {
            if (permiso == null || nodoPadre == null) return;

            foreach (var hijo in permiso.ObtenerHijos())
            {
                TreeNode nodoHijo = new TreeNode(hijo.Nombre);
                nodoPadre.Nodes.Add(nodoHijo);

                if (hijo is PermisoCompuesto)
                    CargarArbol(hijo, nodoHijo);
            }

            tvPermisos.Nodes.Add(nodoPadre);
        }

        private void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            if (lstUsuarios.SelectedItem is Usuario usuario)
            {
                var confirm = MessageBox.Show($"¿Eliminar al usuario {usuario.Nombre}?", "Confirmar", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    _usuarios.Remove(usuario);
                    lstUsuarios.Items.Remove(usuario);

                    var usuariosExistentes = UsuarioXmlService.Leer();
                    usuariosExistentes.RemoveAll(u => u.Nombre == usuario.Nombre);
                    UsuarioXmlService.Guardar(usuariosExistentes);

                    tvPermisos.Nodes.Clear();
                    foreach (var u in usuariosExistentes)
                        CargarArbol(u.Rol, new TreeNode(u.Nombre));
                }
            }
        }

        private void btnEliminarRol_Click(object sender, EventArgs e)
        {
            if (lstRoles.SelectedItem is PermisoCompuesto rol)
            {
                var confirm = MessageBox.Show($"¿Eliminar el rol {rol.Nombre}?", "Confirmar", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    lstRoles.Items.Remove(rol);

                    // Quitamos ese rol de usuarios que lo tenían
                    foreach (var u in _usuarios)
                    {
                        if (u.Rol?.Nombre == rol.Nombre)
                            u.Rol = null;
                    }

                    UsuarioXmlService.Guardar(_usuarios);

                    tvPermisos.Nodes.Clear();
                    foreach (var u in _usuarios)
                        CargarArbol(u.Rol, new TreeNode(u.Nombre));
                }
            }
        }

        private void btnEliminarPermiso_Click(object sender, EventArgs e)
        {
            if (lstPermisos.SelectedItem is PermisoSimple permiso)
            {
                var confirm = MessageBox.Show($"¿Eliminar el permiso {permiso.Nombre}?", "Confirmar", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    lstPermisos.Items.Remove(permiso);

                    // Quitarlo de todos los roles existentes
                    foreach (var u in _usuarios)
                    {
                        if (u.Rol is PermisoCompuesto comp)
                        {
                            var hijos = comp.ObtenerHijos();
                            hijos.RemoveAll(p => p.Nombre == permiso.Nombre);
                        }
                    }

                    UsuarioXmlService.Guardar(_usuarios);

                    tvPermisos.Nodes.Clear();
                    foreach (var u in _usuarios)
                        CargarArbol(u.Rol, new TreeNode(u.Nombre));
                }
            }
        }

    }
}
