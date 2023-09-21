using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            if (!loadEmployees()) return;
        }

        private bool loadEmployees()
        {
            try
            {
                DatosDataGridView.DataSource = employeesM.GetAll();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
