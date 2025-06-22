using EvaluaciónGrupalPOOTema_6;
using System.Collections.Generic;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace EvaluacionGrupal6.Windows
{
    public partial class FrmEmpleadosAE : Form
    {
        public Empleado EmpleadoCreado { get; private set; } = null!;
        public FrmEmpleadosAE()
        {
            InitializeComponent();
        }

        private void FrmEmpleadosAE_Load(object sender, EventArgs e)
        {
            cbTipodePersonal.Items.AddRange(new string[] { "Seguridad", "Operario", "Supervisor", "Administrativo" });
            cbTipodePersonal.SelectedIndexChanged += cbTipodePersonal_SelectedIndexChanged;

            cbTurno.DataSource = Enum.GetValues(typeof(Operario.TurnoEnum));
            cbArea.DataSource = Enum.GetValues(typeof(Supervisor.AreaEnum));


            chbUsaArma.Visible = false;
            cbTurno.Visible = false;
            cbArea.Visible = false;
            txtHorasExtras.Visible = false;
        }

        private void cbTipodePersonal_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tipo = cbTipodePersonal.SelectedItem.ToString();

            chbUsaArma.Visible = (tipo == "Seguridad");
            cbTurno.Visible = (tipo == "Operario");
            cbArea.Visible = (tipo == "Supervisor");
            txtHorasExtras.Visible = (tipo == "Administrativo");
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string legajo = txtLegajo.Text.Trim().ToUpper();
            string nombre = txtNombre.Text.Trim();
            double antiguedad = double.Parse(txtAntiguedad.Text);
            double sueldoBase = double.Parse(txtSueldo.Text);
            DateTime fechaIngreso;
            if (!DateTime.TryParse(txtFechaIngreso.Text, out fechaIngreso))
            {
                MessageBox.Show("La fecha ingresada no es válida. Usá el formato yyyy-mm-dd.");
                return;
            }
            string tipo = cbTipodePersonal.SelectedItem.ToString();

            switch (tipo)
            {
                case "Seguridad":
                    EmpleadoCreado = new Seguridad(legajo, nombre, antiguedad, fechaIngreso, sueldoBase, chbUsaArma.Checked);
                    break;

                case "Operario":
                    var turno = (Operario.TurnoEnum)cbTurno.SelectedItem;
                    var adicional = (Operario.AdicionalTurnoEnum)((int)turno);
                    EmpleadoCreado = new Operario(legajo, nombre, turno, adicional, antiguedad, fechaIngreso, sueldoBase);
                    break;

                case "Supervisor":
                    var area = (Supervisor.AreaEnum)cbArea.SelectedItem;
                    EmpleadoCreado = new Supervisor(legajo, nombre, area, antiguedad, fechaIngreso, sueldoBase);
                    break;

                case "Administrativo":
                    var admin = new Administrativo(legajo, nombre, antiguedad, fechaIngreso, sueldoBase,2);
                    admin.HorasExtras = double.Parse(txtHorasExtras.Text);
                    EmpleadoCreado = admin;
                    break;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
