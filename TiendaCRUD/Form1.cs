using System.ComponentModel;

namespace TiendaCRUD
{
    public partial class Form1 : Form
    {
        private readonly BindingList<Producto> productos = new();
        private int siguienteId = 1;

        public Form1()
        {
            InitializeComponent();

            dgvProductos.DataSource = productos;

            btnAgregar.Click += btnAgregar_Click;
            btnActualizar.Click += btnActualizar_Click;
            btnEliminar.Click += btnEliminar_Click;
            btnLimpiar.Click += btnLimpiar_Click;
            dgvProductos.SelectionChanged += dgvProductos_SelectionChanged;
        }

        private bool ValidarCampos(out string nombre, out decimal precio, out int stock)
        {
            nombre = txtNombre.Text.Trim();
            precio = 0;
            stock = 0;

            if (nombre == "")
            {
                MessageBox.Show("El nombre es obligatorio.");
                return false;
            }
            if (!decimal.TryParse(txtPrecio.Text, out precio) || precio < 0)
            {
                MessageBox.Show("El precio debe ser un número válido.");
                return false;
            }
            if (!int.TryParse(txtStock.Text, out stock) || stock < 0)
            {
                MessageBox.Show("El stock debe ser un número entero válido.");
                return false;
            }
            return true;
        }

        private void LimpiarCampos()
        {
            txtId.Clear();
            txtNombre.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
            dgvProductos.ClearSelection();
            txtNombre.Focus();
        }

        private void btnAgregar_Click(object? sender, EventArgs e)
        {
            if (!ValidarCampos(out string nombre, out decimal precio, out int stock)) return;

            productos.Add(new Producto
            {
                Id = siguienteId++,
                Nombre = nombre,
                Precio = precio,
                Stock = stock
            });
            LimpiarCampos();
        }

        private void btnActualizar_Click(object? sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count == 0 ||
                dgvProductos.CurrentRow?.DataBoundItem is not Producto p)
            {
                MessageBox.Show("Selecciona un producto de la tabla.");
                return;
            }
            if (!ValidarCampos(out string nombre, out decimal precio, out int stock)) return;

            p.Nombre = nombre;
            p.Precio = precio;
            p.Stock = stock;
            dgvProductos.Refresh();
            LimpiarCampos();
        }

        private void btnEliminar_Click(object? sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count == 0 ||
                dgvProductos.CurrentRow?.DataBoundItem is not Producto p)
            {
                MessageBox.Show("Selecciona un producto de la tabla.");
                return;
            }

            var r = MessageBox.Show($"¿Eliminar \"{p.Nombre}\"?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                productos.Remove(p);
                LimpiarCampos();
            }
        }

        private void btnLimpiar_Click(object? sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void dgvProductos_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0 &&
                dgvProductos.CurrentRow?.DataBoundItem is Producto p)
            {
                txtId.Text = p.Id.ToString();
                txtNombre.Text = p.Nombre;
                txtPrecio.Text = p.Precio.ToString();
                txtStock.Text = p.Stock.ToString();
            }
        }
    }
}