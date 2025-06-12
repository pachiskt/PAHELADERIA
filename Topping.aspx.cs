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
    public partial class Topping1 : System.Web.UI.Page
    {
        string conexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvToppings.Visible = false;
            }
        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                SqlDataAdapter da = new SqlDataAdapter("spListarToppings", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvToppings.DataSource = dt;
                gvToppings.DataBind();
                gvToppings.Visible = true;
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("spAgregarTopping", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@topping_id", txtId.Text.Trim());
                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                cmd.Parameters.AddWithValue("@precio", decimal.Parse(txtPrecio.Text));
                cmd.Parameters.AddWithValue("@stock", int.Parse(txtStock.Text));
                cmd.Parameters.AddWithValue("@activo", chkActivo.Checked ? 1 : 0);

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                    lblMensaje.Text = dr["Mensaje"].ToString();
                cn.Close();
            }

            LimpiarCampos();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("spActualizarTopping", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@topping_id", txtId.Text.Trim());
                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                cmd.Parameters.AddWithValue("@precio", decimal.Parse(txtPrecio.Text));
                cmd.Parameters.AddWithValue("@stock", int.Parse(txtStock.Text));
                cmd.Parameters.AddWithValue("@activo", chkActivo.Checked ? 1 : 0);

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                    lblMensaje.Text = dr["Mensaje"].ToString();
                cn.Close();
            }

            LimpiarCampos();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("spBuscarTopping", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Texto", txtBuscar.Text.Trim());
                cmd.Parameters.AddWithValue("@Criterio", ddlCriterio.SelectedValue);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvToppings.DataSource = dt;
                gvToppings.DataBind();
                gvToppings.Visible = true;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("spEliminarTopping", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@topping_id", txtEliminar.Text.Trim());

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                    lblMensajeEliminar.Text = dr["Mensaje"].ToString();
                cn.Close();
            }

            txtEliminar.Text = "";
        }
        private void LimpiarCampos()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
            chkActivo.Checked = false;
        }
        protected void gvToppings_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}