using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CapaNegocio;


namespace CapaPresentación
{
    public partial class FrmManteBase : Form
    {
        public FrmManteBase()
        {
            InitializeComponent();
        }


        private void FrmManteBase_Load(object sender, EventArgs e)
        {
           

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
           
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
           
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["eliminar"].Index)
            {
                DataGridViewCheckBoxCell chkeliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                chkeliminar.Value = !Convert.ToBoolean(chkeliminar.Value);
            }
        }

        private void chkeliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkeliminar.Checked)
            {
                this.dataListado.Columns[0].Visible = true;
            }
            else
            {
                this.dataListado.Columns[0].Visible = false;
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

    }
}
