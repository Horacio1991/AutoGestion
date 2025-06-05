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
        private List<PermisoCompleto> _permisos = new();
        private List<PermisoCompuesto> _roles = new(); // lista de roles


        public AsignarRoles()
        {
            InitializeComponent();
            CargarCombos();
            _permisos = PermisoCompletoXmlService.Leer();
            CargarTreeViewPermisos();
            CargarTreeViewUsuarios();
            CargarTreeViewRoles();

        }

        private void CargarCombos()
        {
            cmbPermisoMenu.Items.Clear();
            cmbPermisoMenu.Items.AddRange(new[]
            {
                "Gestión Ventas",
                "Gestión Compras",
                "Gestión Comisiones",
                "Gestión Turnos",
                "Seguridad"
            });

            cmbPermisoMenu.SelectedIndexChanged += cmbPermisoMenu_SelectedIndexChanged;
        }

        private void cmbPermisoMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbPermisoItem.Items.Clear();

            switch (cmbPermisoMenu.SelectedItem.ToString())
            {
                case "Gestión Ventas":
                    cmbPermisoItem.Items.AddRange(new[]
                    {
                        "Solicitar Modelo", "Registrar Cliente", "Realizar Pago", "Autorizar Venta",
                        "Emitir Factura", "Realizar Entrega"
                    });
                    break;
                case "Gestión Compras":
                    cmbPermisoItem.Items.AddRange(new[]
                    {
                        "Registrar Vehículo", "Evaluar Estado", "Tasar Vehículo", "Registrar Datos"
                    });
                    break;
                case "Gestión Comisiones":
                    cmbPermisoItem.Items.AddRange(new[]
                    {
                        "Registrar Comisión", "Consultar Comisiones"
                    });
                    break;
                case "Gestión Turnos":
                    cmbPermisoItem.Items.AddRange(new[]
                    {
                        "Registrar Turno", "Registrar Asistencia"
                    });
                    break;
                case "Seguridad":
                    cmbPermisoItem.Items.Add("Asignar Roles");
                    break;
            }
        }

        private void btnAltaPermiso_Click(object sender, EventArgs e)
        {
            string nombrePermiso = txtNombrePermiso.Text.Trim();
            string menuSeleccionado = cmbPermisoMenu.SelectedItem?.ToString();
            string itemSeleccionado = cmbPermisoItem.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(nombrePermiso) || string.IsNullOrEmpty(menuSeleccionado) || string.IsNullOrEmpty(itemSeleccionado))
            {
                MessageBox.Show("Complete todos los campos.");
                return;
            }

            var permisoExistente = _permisos.FirstOrDefault(p => p.Nombre == nombrePermiso);

            if (permisoExistente != null)
            {
                var menuExistente = permisoExistente.MenuItems.FirstOrDefault(m => m.Menu == menuSeleccionado);
                if (menuExistente != null)
                {
                    if (!menuExistente.Items.Contains(itemSeleccionado))
                    {
                        menuExistente.Items.Add(itemSeleccionado);
                    }
                    else
                    {
                        MessageBox.Show("Este ítem ya está asignado.");
                        return;
                    }
                }
                else
                {
                    permisoExistente.MenuItems.Add(new MenuPermiso
                    {
                        Menu = menuSeleccionado,
                        Items = new List<string> { itemSeleccionado }
                    });
                }
            }
            else
            {
                var nuevoPermiso = new PermisoCompleto
                {
                    ID = GeneradorID.ObtenerID<PermisoCompleto>(),
                    Nombre = nombrePermiso,
                    MenuItems = new List<MenuPermiso>
                    {
                        new MenuPermiso
                        {
                            Menu = menuSeleccionado,
                            Items = new List<string> { itemSeleccionado }
                        }
                    }
                };

                _permisos.Add(nuevoPermiso);
            }

            PermisoCompletoXmlService.Guardar(_permisos);
            CargarTreeViewPermisos();
        }

        private void CargarTreeViewPermisos()
        {
            tvPermisos.Nodes.Clear();

            foreach (var permiso in _permisos)
            {
                TreeNode permisoNode = new TreeNode(permiso.Nombre)
                {
                    Tag = permiso // ✅ ASIGNAMOS EL OBJETO AL NODO
                };

                foreach (var menu in permiso.MenuItems)
                {
                    TreeNode menuNode = new TreeNode(menu.Menu);
                    foreach (var item in menu.Items)
                    {
                        menuNode.Nodes.Add(new TreeNode(item));
                    }
                    permisoNode.Nodes.Add(menuNode);
                }

                tvPermisos.Nodes.Add(permisoNode);
            }
        }


        private void tvPermisos_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node?.Tag is PermisoCompleto permiso)
            {
                txtNombrePermiso.Text = permiso.Nombre;
            }
        }


        private void btnEliminarPermiso_Click(object sender, EventArgs e)
        {
            if (tvPermisos.SelectedNode == null || tvPermisos.SelectedNode.Tag is not PermisoCompleto permisoSeleccionado)
            {
                MessageBox.Show("Seleccioná un permiso válido para eliminar.");
                return;
            }

            var confirmar = MessageBox.Show($"¿Seguro que deseas eliminar el permiso '{permisoSeleccionado.Nombre}'?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirmar != DialogResult.Yes) return;

            _permisos.RemoveAll(p => p.ID == permisoSeleccionado.ID);
            PermisoCompletoXmlService.Guardar(_permisos);
            CargarTreeViewPermisos();
            txtNombrePermiso.Clear();
            MessageBox.Show("Permiso eliminado correctamente.");
        }

        private void CargarTreeViewUsuarios()
        {
            tvUsuarios.Nodes.Clear();
            var usuarios = UsuarioXmlService.Leer();

            foreach (var usuario in usuarios)
            {
                TreeNode nodo = new TreeNode(usuario.Nombre)
                {
                    Tag = usuario
                };
                tvUsuarios.Nodes.Add(nodo);
            }
        }

        private void tvUsuarios_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node?.Tag is not Usuario usuario) return;

            txtIdUsuario.Text = usuario.ID.ToString();
            txtNombreUsuario.Text = usuario.Nombre;
            txtContrasenaUsuario.Text = usuario.Clave; // Mostramos encriptada por defecto
            chkEncriptar.Checked = false;
        }

        private void chkEncriptar_CheckedChanged(object sender, EventArgs e)
        {
            if (tvUsuarios.SelectedNode?.Tag is not Usuario usuario) return;

            if (chkEncriptar.Checked)
                txtContrasenaUsuario.Text = Encriptacion.DesencriptarPassword(usuario.Clave);
            else
                txtContrasenaUsuario.Text = usuario.Clave;
        }

        private void CargarTreeViewRoles()
        {
            tvRoles.Nodes.Clear();
            _roles = RolXmlService.Leer();

            foreach (var rol in _roles)
            {
                TreeNode nodoRol = new TreeNode(rol.Nombre)
                {
                    Tag = rol
                };
                tvRoles.Nodes.Add(nodoRol);
            }
        }

        private void btnAltaRol_Click(object sender, EventArgs e)
        {
            string nombreRol = txtNombreRol.Text.Trim();
            if (string.IsNullOrEmpty(nombreRol))
            {
                MessageBox.Show("Ingresá un nombre para el rol.");
                return;
            }

            var nuevoRol = new PermisoCompuesto
            {
                ID = GeneradorID.ObtenerID<PermisoCompuesto>(),
                Nombre = nombreRol
            };

            _roles.Add(nuevoRol);
            RolXmlService.Guardar(_roles);
            CargarTreeViewRoles();
            txtNombreRol.Clear();
        }

        private void tvRoles_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node?.Tag is PermisoCompuesto rol)
                txtNombreRol.Text = rol.Nombre;
        }

        private void btnModificarRol_Click(object sender, EventArgs e)
        {
            if (tvRoles.SelectedNode?.Tag is not PermisoCompuesto rolSeleccionado)
            {
                MessageBox.Show("Seleccioná un rol para modificar.");
                return;
            }

            string nuevoNombre = txtNombreRol.Text.Trim();
            if (string.IsNullOrEmpty(nuevoNombre))
            {
                MessageBox.Show("El nombre no puede estar vacío.");
                return;
            }

            rolSeleccionado.Nombre = nuevoNombre;
            RolXmlService.Guardar(_roles);
            CargarTreeViewRoles();
            txtNombreRol.Clear();
        }

        private void btnEliminarRol_Click(object sender, EventArgs e)
        {
            if (tvRoles.SelectedNode?.Tag is not PermisoCompuesto rolSeleccionado)
            {
                MessageBox.Show("Seleccioná un rol para eliminar.");
                return;
            }

            var confirmar = MessageBox.Show($"¿Eliminar el rol '{rolSeleccionado.Nombre}'?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirmar != DialogResult.Yes) return;

            _roles.RemoveAll(r => r.ID == rolSeleccionado.ID);
            RolXmlService.Guardar(_roles);
            CargarTreeViewRoles();
            txtNombreRol.Clear();
        }

    }


}
