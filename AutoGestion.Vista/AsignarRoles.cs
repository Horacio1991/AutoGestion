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

        public AsignarRoles()
        {
            InitializeComponent();
            CargarCombos();
            _permisos = PermisoCompletoXmlService.Leer();
            CargarTreeViewPermisos();
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

    }
}
