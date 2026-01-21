namespace PracticaFinal
{
    partial class Form01DepartamentosFinal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            cmbDepartamentos = new ComboBox();
            txtId = new TextBox();
            txtLocalidad = new TextBox();
            txtNombre = new TextBox();
            label5 = new Label();
            lstEmpleados = new ListBox();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            txtApellido = new TextBox();
            txtOficio = new TextBox();
            txtSalario = new TextBox();
            btnUpdate = new Button();
            btnInsertarDepartamento = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(37, 50);
            label1.Name = "label1";
            label1.Size = new Size(88, 15);
            label1.TabIndex = 0;
            label1.Text = "Departamentos";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(37, 138);
            label2.Name = "label2";
            label2.Size = new Size(17, 15);
            label2.TabIndex = 2;
            label2.Text = "id";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(37, 203);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 3;
            label3.Text = "Nombre";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(37, 270);
            label4.Name = "label4";
            label4.Size = new Size(58, 15);
            label4.TabIndex = 4;
            label4.Text = "Localidad";
            // 
            // cmbDepartamentos
            // 
            cmbDepartamentos.FormattingEnabled = true;
            cmbDepartamentos.Location = new Point(37, 79);
            cmbDepartamentos.Name = "cmbDepartamentos";
            cmbDepartamentos.Size = new Size(149, 23);
            cmbDepartamentos.TabIndex = 5;
            cmbDepartamentos.SelectedIndexChanged += cmbDepartamentos_SelectedIndexChanged;
            // 
            // txtId
            // 
            txtId.Location = new Point(37, 167);
            txtId.Name = "txtId";
            txtId.Size = new Size(149, 23);
            txtId.TabIndex = 6;
            // 
            // txtLocalidad
            // 
            txtLocalidad.Location = new Point(37, 313);
            txtLocalidad.Name = "txtLocalidad";
            txtLocalidad.Size = new Size(149, 23);
            txtLocalidad.TabIndex = 7;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(37, 234);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(149, 23);
            txtNombre.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(310, 50);
            label5.Name = "label5";
            label5.Size = new Size(65, 15);
            label5.TabIndex = 9;
            label5.Text = "Empleados";
            // 
            // lstEmpleados
            // 
            lstEmpleados.FormattingEnabled = true;
            lstEmpleados.Location = new Point(310, 90);
            lstEmpleados.Name = "lstEmpleados";
            lstEmpleados.Size = new Size(204, 289);
            lstEmpleados.TabIndex = 10;
            lstEmpleados.SelectedIndexChanged += lstEmpleados_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(633, 90);
            label6.Name = "label6";
            label6.Size = new Size(51, 15);
            label6.TabIndex = 11;
            label6.Text = "Apellido";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(633, 170);
            label7.Name = "label7";
            label7.Size = new Size(39, 15);
            label7.TabIndex = 12;
            label7.Text = "Oficio";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(633, 257);
            label8.Name = "label8";
            label8.Size = new Size(42, 15);
            label8.TabIndex = 13;
            label8.Text = "Salario";
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(633, 130);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(149, 23);
            txtApellido.TabIndex = 14;
            // 
            // txtOficio
            // 
            txtOficio.Location = new Point(633, 203);
            txtOficio.Name = "txtOficio";
            txtOficio.Size = new Size(149, 23);
            txtOficio.TabIndex = 15;
            // 
            // txtSalario
            // 
            txtSalario.Location = new Point(633, 313);
            txtSalario.Name = "txtSalario";
            txtSalario.Size = new Size(149, 23);
            txtSalario.TabIndex = 16;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(633, 366);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(128, 51);
            btnUpdate.TabIndex = 17;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnInsertarDepartamento
            // 
            btnInsertarDepartamento.Location = new Point(52, 359);
            btnInsertarDepartamento.Name = "btnInsertarDepartamento";
            btnInsertarDepartamento.Size = new Size(123, 58);
            btnInsertarDepartamento.TabIndex = 18;
            btnInsertarDepartamento.Text = "Insertar departamneto";
            btnInsertarDepartamento.UseVisualStyleBackColor = true;
            btnInsertarDepartamento.Click += btnInsertarDepartamento_ClickAsync;
            // 
            // Form01DepartamentosFinal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnInsertarDepartamento);
            Controls.Add(btnUpdate);
            Controls.Add(txtSalario);
            Controls.Add(txtOficio);
            Controls.Add(txtApellido);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(lstEmpleados);
            Controls.Add(label5);
            Controls.Add(txtNombre);
            Controls.Add(txtLocalidad);
            Controls.Add(txtId);
            Controls.Add(cmbDepartamentos);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form01DepartamentosFinal";
            Text = "Form01DepartamentosFinal";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox cmbDepartamentos;
        private TextBox txtId;
        private TextBox txtLocalidad;
        private TextBox txtNombre;
        private Label label5;
        private ListBox lstEmpleados;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox txtApellido;
        private TextBox txtOficio;
        private TextBox txtSalario;
        private Button btnUpdate;
        private Button btnInsertarDepartamento;
    }
}