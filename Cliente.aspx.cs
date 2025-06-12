using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Heladeria_CRUD
{
    public partial class Cliente : System.Web.UI.Page
    {
        string conexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlDataAdapter da = new SqlDataAdapter("spListarClientes", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataTable dt = new DataTable();
                da.Fill(dt);
                gvClientes.DataSource = dt;
                gvClientes.DataBind();
                gvClientes.Visible = true;
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("spAgregarCliente", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DNI", txtDNI.Text);
                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@telefono",
                    string.IsNullOrEmpty(txtTelefono.Text) ? (object)DBNull.Value : txtTelefono.Text);
                cmd.Parameters.AddWithValue("@email",
                    string.IsNullOrEmpty(txtEmail.Text) ? (object)DBNull.Value : txtEmail.Text);
                cmd.Parameters.AddWithValue("@direccion",
                    string.IsNullOrEmpty(txtDireccion.Text) ? (object)DBNull.Value : txtDireccion.Text);
                cmd.Parameters.AddWithValue("@puntos_fidelidad",
                    string.IsNullOrEmpty(txtPuntos.Text) ? 0 : Convert.ToInt32(txtPuntos.Text));

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    lblMensaje.CssClass = dr["CodError"].ToString() == "0" ?
                        "message-label message-success" : "message-label message-error";
                    lblMensaje.Text = dr["Mensaje"].ToString();
                }
                con.Close();

                // Limpiar campos después de agregar
                if (lblMensaje.CssClass.Contains("message-success"))
                {
                    txtDNI.Text = "";
                    txtNombre.Text = "";
                    txtTelefono.Text = "";
                    txtEmail.Text = "";
                    txtDireccion.Text = "";
                    txtPuntos.Text = "0";
                }
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("spActualizarCliente", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DNI", txtDNI.Text);
                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@telefono",
                    string.IsNullOrEmpty(txtTelefono.Text) ? (object)DBNull.Value : txtTelefono.Text);
                cmd.Parameters.AddWithValue("@email",
                    string.IsNullOrEmpty(txtEmail.Text) ? (object)DBNull.Value : txtEmail.Text);
                cmd.Parameters.AddWithValue("@direccion",
                    string.IsNullOrEmpty(txtDireccion.Text) ? (object)DBNull.Value : txtDireccion.Text);
                cmd.Parameters.AddWithValue("@puntos_fidelidad",
                    string.IsNullOrEmpty(txtPuntos.Text) ? (object)DBNull.Value : Convert.ToInt32(txtPuntos.Text));

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    lblMensaje.CssClass = dr["CodError"].ToString() == "0" ?
                        "message-label message-success" : "message-label message-error";
                    lblMensaje.Text = dr["Mensaje"].ToString();
                }
                con.Close();
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("spEliminarCliente", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DNI", txtEliminar.Text);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    lblMensajeEliminar.CssClass = dr["CodError"].ToString() == "0" ?
                        "message-label message-success" : "message-label message-error";
                    lblMensajeEliminar.Text = dr["Mensaje"].ToString();
                }
                con.Close();

                // Limpiar campo después de eliminar
                if (lblMensajeEliminar.CssClass.Contains("message-success"))
                {
                    txtEliminar.Text = "";
                }
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("spBuscarCliente", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Texto", txtBuscar.Text);
                cmd.Parameters.AddWithValue("@Criterio", ddlCriterio.SelectedValue);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvClientes.DataSource = dt;
                gvClientes.DataBind();
                gvClientes.Visible = true;
            }
        }

        protected void gvClientes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Resaltar puntos de fidelidad
                if (e.Row.Cells.Count > 6) // Asegurar que existe la columna de puntos
                {
                    TableCell puntosCell = e.Row.Cells[6];
                    if (int.TryParse(puntosCell.Text, out int puntos))
                    {
                        puntosCell.Text = $"<span class='puntos-badge'>{puntos} puntos</span>";
                    }
                }

                // Formatear fecha de registro
                if (e.Row.Cells.Count > 5) // Celda de fecha_registro
                {
                    TableCell fechaCell = e.Row.Cells[5];
                    if (DateTime.TryParse(fechaCell.Text, out DateTime fecha))
                    {
                        fechaCell.Text = fecha.ToString("dd/MM/yyyy");
                    }
                }
            }
        }
    }
}