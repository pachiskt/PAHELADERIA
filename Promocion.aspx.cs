using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Heladeria_CRUD
{
    public partial class Promocion : System.Web.UI.Page
    {
        string conexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Configuración inicial si es necesario
            }
        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlDataAdapter da = new SqlDataAdapter("spListarPromociones", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataTable dt = new DataTable();
                da.Fill(dt);
                gvPromociones.DataSource = dt;
                gvPromociones.DataBind();
                gvPromociones.Visible = true;
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("spAgregarPromocion", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@promocion_id", txtId.Text);
                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);
                cmd.Parameters.AddWithValue("@descuento", Convert.ToDecimal(txtDescuento.Text));
                cmd.Parameters.AddWithValue("@fecha_inicio", Convert.ToDateTime(txtFechaInicio.Text));
                cmd.Parameters.AddWithValue("@fecha_fin", Convert.ToDateTime(txtFechaFin.Text));
                cmd.Parameters.AddWithValue("@activa", chkActiva.Checked);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    lblMensaje.Text = dr["Mensaje"].ToString();
                }
                con.Close();

                // Limpiar campos después de agregar
                if (lblMensaje.Text.Contains("correctamente"))
                {
                    LimpiarCampos();
                }
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("spActualizarPromocion", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@promocion_id", txtId.Text);
                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);
                cmd.Parameters.AddWithValue("@descuento", Convert.ToDecimal(txtDescuento.Text));
                cmd.Parameters.AddWithValue("@fecha_inicio", Convert.ToDateTime(txtFechaInicio.Text));
                cmd.Parameters.AddWithValue("@fecha_fin", Convert.ToDateTime(txtFechaFin.Text));
                cmd.Parameters.AddWithValue("@activa", chkActiva.Checked);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    lblMensaje.Text = dr["Mensaje"].ToString();
                }
                con.Close();
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("spEliminarPromocion", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@promocion_id", txtEliminar.Text);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    lblMensaje1.Text = dr["Mensaje"].ToString();
                }
                con.Close();

                // Limpiar campo de eliminación si fue exitoso
                if (lblMensaje1.Text.Contains("correctamente"))
                {
                    txtEliminar.Text = "";
                }
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("spBuscarPromocion", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Texto", txtBuscar.Text);
                cmd.Parameters.AddWithValue("@Criterio", ddlCriterio.SelectedValue);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvPromociones.DataSource = dt;
                gvPromociones.DataBind();
                gvPromociones.Visible = true;
            }
        }

        protected void gvPromociones_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Llenar los campos con la promoción seleccionada
            GridViewRow row = gvPromociones.SelectedRow;

            txtId.Text = row.Cells[1].Text; // Asumiendo que la columna 1 es promocion_id
            txtNombre.Text = row.Cells[2].Text; // nombre
            txtDescripcion.Text = row.Cells[3].Text; // descripcion
            txtDescuento.Text = row.Cells[4].Text; // descuento

            // Convertir fechas al formato correcto para el TextBox
            DateTime fechaInicio, fechaFin;
            if (DateTime.TryParse(row.Cells[5].Text, out fechaInicio))
                txtFechaInicio.Text = fechaInicio.ToString("yyyy-MM-dd");

            if (DateTime.TryParse(row.Cells[6].Text, out fechaFin))
                txtFechaFin.Text = fechaFin.ToString("yyyy-MM-dd");

            // Convertir el estado activo a checkbox
            bool activa;
            if (bool.TryParse(row.Cells[7].Text, out activa))
                chkActiva.Checked = activa;
        }

        private void LimpiarCampos()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtDescuento.Text = "";
            txtFechaInicio.Text = "";
            txtFechaFin.Text = "";
            chkActiva.Checked = false;
        }
    }
}