namespace EvaluacionGrupal6.Windows
{
    partial class FrmEmpleadosAE
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtNombre = new TextBox();
            label2 = new Label();
            txtLegajo = new TextBox();
            label3 = new Label();
            txtAntiguedad = new TextBox();
            label4 = new Label();
            txtSueldo = new TextBox();
            cbTipodePersonal = new ComboBox();
            label5 = new Label();
            cbTurno = new ComboBox();
            label6 = new Label();
            chbUsaArma = new CheckBox();
            txtFechaIngreso = new TextBox();
            label7 = new Label();
            label8 = new Label();
            txtHorasExtras = new TextBox();
            cbArea = new ComboBox();
            label9 = new Label();
            btnOK = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(56, 62);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(116, 59);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 21);
            label2.Name = "label2";
            label2.Size = new Size(84, 15);
            label2.TabIndex = 2;
            label2.Text = "Nro de Legajo:";
            // 
            // txtLegajo
            // 
            txtLegajo.Location = new Point(116, 18);
            txtLegajo.Name = "txtLegajo";
            txtLegajo.Size = new Size(100, 23);
            txtLegajo.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(245, 22);
            label3.Name = "label3";
            label3.Size = new Size(72, 15);
            label3.TabIndex = 4;
            label3.Text = "Antiguedad:";
            // 
            // txtAntiguedad
            // 
            txtAntiguedad.Location = new Point(323, 19);
            txtAntiguedad.Name = "txtAntiguedad";
            txtAntiguedad.Size = new Size(100, 23);
            txtAntiguedad.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(245, 59);
            label4.Name = "label4";
            label4.Size = new Size(46, 15);
            label4.TabIndex = 6;
            label4.Text = "Sueldo:";
            // 
            // txtSueldo
            // 
            txtSueldo.Location = new Point(297, 59);
            txtSueldo.Name = "txtSueldo";
            txtSueldo.Size = new Size(100, 23);
            txtSueldo.TabIndex = 7;
            // 
            // cbTipodePersonal
            // 
            cbTipodePersonal.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTipodePersonal.FormattingEnabled = true;
            cbTipodePersonal.Items.AddRange(new object[] { "Seguridad", "Operario", "Supervisor", "Administrativo" });
            cbTipodePersonal.Location = new Point(170, 149);
            cbTipodePersonal.Name = "cbTipodePersonal";
            cbTipodePersonal.Size = new Size(121, 23);
            cbTipodePersonal.TabIndex = 10;
            cbTipodePersonal.SelectedIndexChanged += cbTipodePersonal_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(26, 152);
            label5.Name = "label5";
            label5.Size = new Size(138, 15);
            label5.TabIndex = 11;
            label5.Text = "Elegir Tipo de Empleado:";
            // 
            // cbTurno
            // 
            cbTurno.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTurno.FormattingEnabled = true;
            cbTurno.Items.AddRange(new object[] { "Mañana", "Tarde", "Noche" });
            cbTurno.Location = new Point(170, 194);
            cbTurno.Name = "cbTurno";
            cbTurno.Size = new Size(121, 23);
            cbTurno.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(90, 197);
            label6.Name = "label6";
            label6.Size = new Size(74, 15);
            label6.TabIndex = 13;
            label6.Text = "Elegir Turno:";
            // 
            // chbUsaArma
            // 
            chbUsaArma.AutoSize = true;
            chbUsaArma.Location = new Point(315, 152);
            chbUsaArma.Name = "chbUsaArma";
            chbUsaArma.Size = new Size(77, 19);
            chbUsaArma.TabIndex = 14;
            chbUsaArma.Text = "Usa Arma";
            chbUsaArma.UseVisualStyleBackColor = true;
            // 
            // txtFechaIngreso
            // 
            txtFechaIngreso.Location = new Point(217, 103);
            txtFechaIngreso.Name = "txtFechaIngreso";
            txtFechaIngreso.Size = new Size(100, 23);
            txtFechaIngreso.TabIndex = 15;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(112, 106);
            label7.Name = "label7";
            label7.Size = new Size(99, 15);
            label7.TabIndex = 16;
            label7.Text = "Fecha de Ingreso:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(90, 229);
            label8.Name = "label8";
            label8.Size = new Size(74, 15);
            label8.TabIndex = 17;
            label8.Text = "Horas Extras:";
            // 
            // txtHorasExtras
            // 
            txtHorasExtras.Location = new Point(170, 229);
            txtHorasExtras.Name = "txtHorasExtras";
            txtHorasExtras.Size = new Size(100, 23);
            txtHorasExtras.TabIndex = 18;
            // 
            // cbArea
            // 
            cbArea.DropDownStyle = ComboBoxStyle.DropDownList;
            cbArea.FormattingEnabled = true;
            cbArea.Items.AddRange(new object[] { "Personal", "Fabrica", "Ventas" });
            cbArea.Location = new Point(170, 271);
            cbArea.Name = "cbArea";
            cbArea.Size = new Size(121, 23);
            cbArea.TabIndex = 19;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(130, 274);
            label9.Name = "label9";
            label9.Size = new Size(34, 15);
            label9.TabIndex = 20;
            label9.Text = "Area:";
            // 
            // btnOK
            // 
            btnOK.Location = new Point(80, 335);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 43);
            btnOK.TabIndex = 21;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(267, 335);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 43);
            btnCancelar.TabIndex = 22;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // FrmEmpleadosAE
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(577, 390);
            Controls.Add(btnCancelar);
            Controls.Add(btnOK);
            Controls.Add(label9);
            Controls.Add(cbArea);
            Controls.Add(txtHorasExtras);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(txtFechaIngreso);
            Controls.Add(chbUsaArma);
            Controls.Add(label6);
            Controls.Add(cbTurno);
            Controls.Add(label5);
            Controls.Add(cbTipodePersonal);
            Controls.Add(txtSueldo);
            Controls.Add(label4);
            Controls.Add(txtAntiguedad);
            Controls.Add(label3);
            Controls.Add(txtLegajo);
            Controls.Add(label2);
            Controls.Add(txtNombre);
            Controls.Add(label1);
            Name = "FrmEmpleadosAE";
            Text = "FrmEmpleadosAE";
            Load += FrmEmpleadosAE_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtNombre;
        private Label label2;
        private TextBox txtLegajo;
        private Label label3;
        private TextBox txtAntiguedad;
        private Label label4;
        private TextBox txtSueldo;
        private ComboBox cbTipodePersonal;
        private Label label5;
        private ComboBox cbTurno;
        private Label label6;
        private CheckBox chbUsaArma;
        private TextBox txtFechaIngreso;
        private Label label7;
        private Label label8;
        private TextBox txtHorasExtras;
        private ComboBox cbArea;
        private Label label9;
        private Button btnOK;
        private Button btnCancelar;
    }
}
