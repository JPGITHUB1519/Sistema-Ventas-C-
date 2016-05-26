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
    public partial class FrmPresentacion : FrmManteBase
    {
        public FrmPresentacion()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(txtNombre, "Ingrese el nombre de la categoria");
            this.ttMensaje.SetToolTip(txtIdcategoria, "Ingrese el id de la categoría");
        }

        private bool IsNuevo = false;
        private bool IsEditar = false;

        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[0].Visible = false;
        }

        private void Mostrar()
        {
            this.dataListado.DataSource = NPresentacion.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros :" + Convert.ToString(dataListado.Rows.Count);
        }

        private void Habilitar(bool cond)
        {
            this.txtNombre.ReadOnly = !cond;
            this.txtIdcategoria.ReadOnly = !cond;
            this.txtDescripcion.ReadOnly = !cond;
 
        }

        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Mensaje de Error

        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void limpiar()
        {
            this.txtNombre.Text = string.Empty;
            this.txtIdcategoria.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
        }

        private void buscarnombre()
        {
            this.dataListado.DataSource = NPresentacion.BuscarNombre(this.txtBuscar.Text.Trim());
            this.OcultarColumnas();
            lblTotal.Text = Convert.ToString("Total : " + this.dataListado.Rows.Count);
        }

        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;

            }
        }

        private void FrmPresentacion_Load(object sender, EventArgs e)
        {
            
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
            

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.btnNuevo.Enabled = false;
            this.btnEditar.Enabled = false;
            this.btnGuardar.Enabled = true;
            this.btnCancelar.Enabled = true;
            this.Habilitar(true);
            this.txtNombre.Focus();
            this.limpiar();
 
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.buscarnombre();
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.buscarnombre();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";

                if (this.txtNombre.Text == string.Empty)
                {
                    MensajeError("Falta Ingresar algunos Datos");
                    ErrorIcono.SetError(txtNombre, "Ingrese un nombre");

                }

                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = NPresentacion.Insertar(txtNombre.Text.Trim().ToUpper(), txtDescripcion.Text.Trim().ToUpper());
                    }

                    if (this.IsEditar)
                    {
                        rpta = NPresentacion.Editar(Convert.ToInt32(this.txtIdcategoria.Text.Trim()), this.txtNombre.Text.Trim().ToUpper(), this.txtDescripcion.Text.Trim().ToUpper());
                            
                    }

                    if(rpta.Equals("OK"))
                    {
                        if(this.IsNuevo)
                        {
                            MensajeOk("Se insertó de forma correcta el registro");
                        }
                        else
                        {
                            MensajeOk("Se actualizó de forma correcta el registro");
                        }
                    }
                    else
                    {
                        this.MensajeError(rpta); 
                    }

                    this.IsEditar = false;
                    this.IsNuevo = false;
                    this.limpiar();
                    this.Botones();
                    this.Mostrar();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
 
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.limpiar();
            this.Habilitar(false);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;

                Opcion = MessageBox.Show("¿Realmente desea eliminar los registros?", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string Rpta = "";
                    string codigo;
                    int cont_eliminados = 0;
                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = NPresentacion.eliminar(Convert.ToInt32(codigo));

                            if (Rpta.Equals("OK"))
                            {
                                
                                cont_eliminados++;
                            }   

                            else
                            {
                                this.MensajeError(Rpta);
                            }

                        }

                    }

                    // show messages deletes
                    if (cont_eliminados > 0)
                    {
                        if (cont_eliminados == 1)
                        {
                            this.MensajeOk("Se elimino un registro");
                        }
                        else
                        {
                            this.MensajeOk("Se eliminaron " + cont_eliminados + " registros");
                        }
                    }

                    this.chkeliminar.Checked = false;

                    this.Mostrar();

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void chkeliminar_CheckedChanged(object sender, EventArgs e)
        {
           
        }
    }
}
