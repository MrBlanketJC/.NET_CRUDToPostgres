using System;
using System.Drawing;
using System.Windows.Forms;
//
using CAM;


namespace CRUD
{
    public partial class frmEmployees : Form
    {
        EmployeesManager employeesM = new EmployeesManager();
        public frmEmployees()
        {
            InitializeComponent();
        }

        private void frmEmployees_Load(object sender, EventArgs e)
        {
            if (!loadEmployees(true, false)) return;
        }

        private bool loadEmployees(bool flag, bool pointer)
        {
            try
            {
                DatosDataGridView.DataSource = employeesM.GetAll(pointer, txtFilter.Text.Trim());

                if (flag)
                {
                    DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
                    btnEdit.Name = "Edit";
                    btnEdit.Text = "Edit";
                    btnEdit.HeaderText = "";
                    btnEdit.DataPropertyName = "Edit";
                    btnEdit.UseColumnTextForButtonValue = true;//Agregar el texto al boton
                    btnEdit.DefaultCellStyle.NullValue = null;
                    btnEdit.FlatStyle = FlatStyle.Flat;
                    btnEdit.CellTemplate.Style.BackColor = Color.FromArgb(255, 140, 0);
                    btnEdit.CellTemplate.Style.ForeColor = Color.White;
                    btnEdit.CellTemplate.Style.SelectionBackColor = Color.FromArgb(255, 140, 0);
                    DatosDataGridView.Columns.Add(btnEdit);

                    DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
                    btnDelete.Name = "Delete";
                    btnDelete.Text = "Delete";
                    btnDelete.HeaderText = "";
                    btnDelete.DataPropertyName = "Delete";
                    btnDelete.UseColumnTextForButtonValue = true;//Habilitar texto al boton
                    btnDelete.DefaultCellStyle.NullValue = null;
                    btnDelete.FlatStyle = FlatStyle.Flat;
                    btnDelete.CellTemplate.Style.BackColor = Color.FromArgb(220, 50, 40);
                    btnDelete.CellTemplate.Style.ForeColor = Color.White;
                    btnDelete.CellTemplate.Style.SelectionBackColor = Color.FromArgb(220, 50, 40);
                    DatosDataGridView.Columns.Add(btnDelete);
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en loadEmployees: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmEmployeeNew miForm = new frmEmployeeNew();
            miForm.ShowDialog();
            if (!miForm.xClicked)
            {
                if (!loadEmployees(false, false)) return;
            }
        }

        private void DatosDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Comprobar si se hizo clic en la columna Editar
            if (e.ColumnIndex == DatosDataGridView.Columns["Edit"].Index && e.RowIndex >= 0)
            {
                int rowIndex = e.RowIndex;// Obtener el índice de la fila seleccionada

                int IDRegistro = Convert.ToInt32(DatosDataGridView.Rows[rowIndex].Cells["IDEmpleados"].Value);
                frmEmployeeNew miForm = new frmEmployeeNew();
                miForm.frmIDRegistro = IDRegistro;
                miForm.ShowDialog();
                if (!miForm.xClicked)
                {
                    if (!loadEmployees(false, false)) return;
                    txtFilter.Clear();
                }

            }
            // Comprobar si se hizo clic en la columna Eliminar
            else if (e.ColumnIndex == DatosDataGridView.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                int rowIndex = e.RowIndex;
                int IDRegistro = Convert.ToInt32(DatosDataGridView.Rows[rowIndex].Cells["IDEmpleados"].Value);                
                var result = MessageBox.Show("Desea eliminar el registro: " + DatosDataGridView.Rows[rowIndex].Cells["Apellidos"].Value.ToString() + " " + DatosDataGridView.Rows[rowIndex].Cells["Nombres"].Value.ToString(), "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    if (!delete(IDRegistro)) return;
                    if (!loadEmployees(false, false)) return;
                    txtFilter.Clear();
                }
            }
        }

        private bool delete(int IDEmployee)
        {
            try
            {
                employeesM.Delete(IDEmployee);
                MessageBox.Show("Registro eliminado correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en delete: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void txtFilter_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilter.Text))
            {
                if (!loadEmployees(false, false)) return;
            }
            else
            {
                if (!loadEmployees(false, true)) return;
            }
        }
    }
}
