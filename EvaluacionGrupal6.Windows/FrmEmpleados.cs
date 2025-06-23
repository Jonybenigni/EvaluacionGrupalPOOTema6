using EvaluacionGrupal6.Datos;
using EvaluaciónGrupalPOOTema_6;

namespace EvaluacionGrupal6.Windows
{
    public partial class FrmEmpleados : Form
    {
        private readonly RepositorioEmpleadosOperadores _repoEmpleadosOperadores;
        private readonly RepositorioEmpleadosLinq _repoEmpleadosLinq;

        private List<Empleado> _empleado = new();

        public FrmEmpleados(RepositorioEmpleadosOperadores repoEmpleadosOperadores)
        {
            InitializeComponent();
            _repoEmpleadosOperadores = repoEmpleadosOperadores;
        }

        private void FrmPaises_Load(object sender, EventArgs e)
        {
            _empleado = _repoEmpleadosOperadores.GetEmpleado();
            MostrarDatosEnGrilla();
        }

        private void toolStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TsbNuevo_Click(object sender, EventArgs e)
        {
            FrmEmpleadoAE frm = new FrmEmpleadoAE() { Text = "Nuevo Empleado" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            Empleado? empleado = frm.GetEmpleado();
            if (empleado == null) return;

            if (_repoEmpleadosOperadores.Existe(empleado))
            {
                _repoEmpleadosOperadores.Guardar(empleado);
                DataGridViewRow r = new DataGridViewRow();
                r.CreateCells(DgvDatos);
                SetearFila(r, empleado);
                AgregarFila(r);
                MessageBox.Show("Empleado agregado", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Empleado existente", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void MostrarDatosEnGrilla()
        {
            DgvDatos.Rows.Clear();
            foreach (Empleado empleado in _empleado)
            {
                DataGridViewRow r = new DataGridViewRow();
                r.CreateCells(DgvDatos);
                SetearFila(r, empleado);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            DgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Empleado empleado)
        {
            r.Cells[0].Value = empleado.EmpleadoId;
            r.Cells[1].Value = empleado.Nombre;

            r.Tag = empleado;
        }

        private void TsbBorrar_Click(object sender, EventArgs e)
        {
            if (DgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = DgvDatos.SelectedRows[0];
            Empleado empleadoBorrar = (Empleado)r.Tag!;
            DialogResult dr = MessageBox.Show($"¿Desea borrar el Empleado {empleadoBorrar}?",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No) return;
            _repoEmpleadosOperadores.Borrar(empleadoBorrar);
            DgvDatos.Rows.Remove(r);
            MessageBox.Show("País eliminado");
        }

        private void TsbEditar_Click(object sender, EventArgs e)
        {
            if (DgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = DgvDatos.SelectedRows[0];
            Empleado? empleado = (Empleado)r.Tag!;
            FrmEmpleadosAE frm = new FrmEmpleadosAE() { Text = "Editar Empleado" };
            frm.SetEmpleado(empleado);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            empleado = frm.GetPais();
            if (empleado == null) return;

            if (!_repoEmpleadosOperadores.Existe(empleado))
            {
                _repoEmpleadosOperadores.Guardar(empleado);
                SetearFila(r, empleado);

                MessageBox.Show("Empleado editado", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Empleado existente", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void TsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
