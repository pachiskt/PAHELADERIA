using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Heladeria_CRUD
{
    public partial class MetodoPago : System.Web.UI.Page
    {
        string conexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvMetodoPago.Visible = false;
            }
        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                SqlDataAdapter da = new SqlDataAdapter("spListarMetodosPago", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataTable dt = new DataTable();
                da.Fill(dt);
                gvMetodoPago.DataSource = dt;
                gvMetodoPago.DataBind();
                gvMetodoPago.Visible = true;

            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("spAgregarMetodoPago", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@metodo_pago_id", txtId.Text.Trim());
                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                cmd.Parameters.AddWithValue("@descripcion", txtDescripcion.Text.Trim());

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                lblMensaje.Text = dt.Rows[0]["Mensaje"].ToString();
                gvMetodoPago.Visible = false;
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("spActualizarMetodoPago", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@metodo_pago_id", txtId.Text.Trim());
                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                cmd.Parameters.AddWithValue("@descripcion", txtDescripcion.Text.Trim());

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                lblMensaje.Text = dt.Rows[0]["Mensaje"].ToString();
                gvMetodoPago.Visible = false;
            }
        }

        protected void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("spBuscarMetodoPago", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Texto", txtBuscar.Text.Trim());
                cmd.Parameters.AddWithValue("@Criterio", ddlCriterio.SelectedValue);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvMetodoPago.DataSource = dt;
                gvMetodoPago.DataBind();
                gvMetodoPago.Visible = true;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("spEliminarMetodoPago", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@metodo_pago_id", txtEliminar.Text.Trim());

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                lblMensajeEliminar.Text = dt.Rows[0]["Mensaje"].ToString();
                gvMetodoPago.Visible = false;
            }        
        }

        protected void gvMetodoPago_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}