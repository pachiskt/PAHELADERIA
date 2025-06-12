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
    public partial class Helado1 : System.Web.UI.Page
    {
        string conexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvHelados.Visible = false;
            }
        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlDataAdapter da = new SqlDataAdapter("spListarHelados", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataTable dt = new DataTable();
                da.Fill(dt);

                gvHelados.DataSource = dt;
                gvHelados.DataBind();
                gvHelados.Visible = true;
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("spAgregarHelado", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@helado_id", txtId.Text);
                cmd.Parameters.AddWithValue("@sabor_id", txtSaborId.Text);
                cmd.Parameters.AddWithValue("@tamano_id", txtTamanoId.Text);
                cmd.Parameters.AddWithValue("@precio_base", Convert.ToDecimal(txtPrecioBase.Text));
                cmd.Parameters.AddWithValue("@en_stock", chkStock.Checked);
                cmd.Parameters.AddWithValue("@imagen_url", txtImagen.Text);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                    lblMensaje.Text = dr["Mensaje"].ToString();
                con.Close();
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("spActualizarHelado", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@helado_id", txtId.Text);
                cmd.Parameters.AddWithValue("@sabor_id", txtSaborId.Text);
                cmd.Parameters.AddWithValue("@tamano_id", txtTamanoId.Text);
                cmd.Parameters.AddWithValue("@precio_base", Convert.ToDecimal(txtPrecioBase.Text));
                cmd.Parameters.AddWithValue("@en_stock", chkStock.Checked);
                cmd.Parameters.AddWithValue("@imagen_url", txtImagen.Text);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                    lblMensaje.Text = dr["Mensaje"].ToString();
                con.Close();
            }
        }

        protected void chkStock_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void ddlCriterio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("spBuscarHelado", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Texto", txtBuscar.Text);
                cmd.Parameters.AddWithValue("@Criterio", ddlCriterio.SelectedValue);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvHelados.DataSource = dt;
                gvHelados.DataBind();
                gvHelados.Visible = true;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("spEliminarHelado", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@helado_id", txtEliminar.Text);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                    lblMensajeEliminar.Text = dr["Mensaje"].ToString();
                con.Close();
            }
        }

        protected void gvHelados_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}