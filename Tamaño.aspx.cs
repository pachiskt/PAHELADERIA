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
    public partial class Tamaño : System.Web.UI.Page
    {
        string conexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvTamaño.Visible = false;
            }
        }

        protected void btnListar_Click(object sender, EventArgs e)
        {          

            using (SqlConnection conn = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("spListarTamanos", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvTamaño.DataSource = dt;
                gvTamaño.DataBind();
                gvTamaño.Visible = true;
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("spAgregarTamano", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tamano_id", txtId.Text);
                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@precio_adicional", decimal.Parse(txtPrecioAdicional.Text));
                cmd.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    lblMensaje.Text = dr["Mensaje"].ToString();
                }
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("spActualizarTamano", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tamano_id", txtId.Text);
                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@precio_adicional", decimal.Parse(txtPrecioAdicional.Text));
                cmd.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    lblMensaje.Text = dr["Mensaje"].ToString();
                }
            }
        }

        protected void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("spBuscarTamano", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Texto", txtBuscar.Text);
                cmd.Parameters.AddWithValue("@Criterio", ddlCriterio.SelectedValue);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvTamaño.DataSource = dt;
                gvTamaño.DataBind();
                gvTamaño.Visible = true;
            }

        }

        protected void ddlCriterio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("spEliminarTamano", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tamano_id", txtEliminar.Text);

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    lblMensajeEliminar.Text = dr["Mensaje"].ToString();
                }
            }
        }

        protected void gvTamaño_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}