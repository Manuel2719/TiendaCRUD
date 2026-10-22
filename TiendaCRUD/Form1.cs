namespace TiendaCRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            dgvProductos.ReadOnly = true;
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.MultiSelect = false;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            CargarCategorias();

            btnAgregar.Click += btnAgregar_Click;
            btnActualizar.Click += btnActualizar_Click;
            btnEliminar.Click += btnEliminar_Click;
            btnLimpiar.Click += btnLimpiar_Click;
            dgvProductos.SelectionChanged += dgvProductos_SelectionChanged;

            CargarProductos();
            LimpiarCampos();
        }

        private void CargarCategorias()
        {
            using var db = new TiendaContext();

            var categorias = db.Categorias
                .OrderBy(c => c.Nombre)
                .ToList();

            cmbCategoria.DataSource = categorias;
            cmbCategoria.DisplayMember = "Nombre";
            cmbCategoria.ValueMember = "Id";
            cmbCategoria.SelectedIndex = -1;
        }

        private void CargarProductos()
        {
            try
            {
                using var db = new TiendaContext();

                var lista = (from p in db.Productos
                             join c in db.Categorias on p.CategoriaId equals c.Id
                             orderby p.Id
                             select new
                             {
                                 p.Id,
                                 p.Nombre,
                                 p.Precio,
                                 p.Stock,
                                 Categoria = c.Nombre,
                                 p.CategoriaId
                             }).ToList();

                dgvProductos.DataSource = lista;

                if (dgvProductos.Columns["CategoriaId"] != null)
                    dgvProductos.Columns["CategoriaId"].Visible = false;
                if (dgvProductos.Columns["Categoria"] != null)
                    dgvProductos.Columns["Categoria"].HeaderText = "Categoría";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los productos: " + ex.Message);
            }
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
            if (cmbCategoria.SelectedValue is not int)
            {
                MessageBox.Show("Debes seleccionar una categoría.");
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
            cmbCategoria.SelectedIndex = -1;
            dgvProductos.ClearSelection();
            txtNombre.Focus();
        }

        private void btnAgregar_Click(object? sender, EventArgs e)
        {
            if (!ValidarCampos(out string nombre, out decimal precio, out int stock))
                return;

            int categoriaId = (int)cmbCategoria.SelectedValue!;

            try
            {
                using var db = new TiendaContext();

                var producto = new Producto
                {
                    Nombre = nombre,
                    Precio = precio,
                    Stock = stock,
                    CategoriaId = categoriaId
                };

                db.Productos.Add(producto);
                db.SaveChanges();

                MessageBox.Show("Producto guardado correctamente.");

                CargarProductos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el producto: " + ex.Message);
            }
        }

        private void btnActualizar_Click(object? sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("Selecciona un producto de la tabla.");
                return;
            }
            if (!ValidarCampos(out string nombre, out decimal precio, out int stock))
                return;

            int categoriaId = (int)cmbCategoria.SelectedValue!;

            try
            {
                using var db = new TiendaContext();

                var producto = db.Productos.Find(id);
                if (producto == null)
                {
                    MessageBox.Show("El producto ya no existe.");
                    CargarProductos();
                    LimpiarCampos();
                    return;
                }

                producto.Nombre = nombre;
                producto.Precio = precio;
                producto.Stock = stock;
                producto.CategoriaId = categoriaId;
                db.SaveChanges();

                MessageBox.Show("Producto actualizado correctamente.");

                CargarProductos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el producto: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object? sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("Selecciona un producto de la tabla.");
                return;
            }

            var respuesta = MessageBox.Show(
                $"¿Seguro que deseas eliminar \"{txtNombre.Text}\"?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;

            try
            {
                using var db = new TiendaContext();

                var producto = db.Productos.Find(id);
                if (producto != null)
                {
                    db.Productos.Remove(producto);
                    db.SaveChanges();
                }

                MessageBox.Show("Producto eliminado correctamente.");

                CargarProductos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el producto: " + ex.Message);
            }
        }

        private void btnLimpiar_Click(object? sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void dgvProductos_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count == 0)
                return;

            var fila = dgvProductos.SelectedRows[0];

            txtId.Text = fila.Cells["Id"].Value?.ToString();
            txtNombre.Text = fila.Cells["Nombre"].Value?.ToString();
            txtPrecio.Text = fila.Cells["Precio"].Value?.ToString();
            txtStock.Text = fila.Cells["Stock"].Value?.ToString();

            if (fila.Cells["CategoriaId"].Value is int categoriaId)
                cmbCategoria.SelectedValue = categoriaId;
        }
    }
}