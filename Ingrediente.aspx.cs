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
    public partial class Ingrediente : System.Web.UI.Page
    {
        string conexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlDataAdapter da = new SqlDataAdapter("spListarIngredientes", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataTable dt = new DataTable();
                da.Fill(dt);
                gvIngredientes.DataSource = dt;
                gvIngredientes.DataBind();
                gvIngredientes.Visible = true;
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("spAgregarIngrediente", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ingrediente_id", txtId.Text);
                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@proveedor_id", txtProveedorId.Text);
                cmd.Parameters.AddWithValue("@helado_id", txtHeladoId.Text);
                cmd.Parameters.AddWithValue("@unidad_medida", txtUnidadMedida.Text);
                cmd.Parameters.AddWithValue("@precio_por_unidad", Convert.ToDecimal(txtPrecioUnidad.Text));
                cmd.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    lblMensaje.Text = dr["Mensaje"].ToString();
                }
                con.Close();
            }
        }
        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("spActualizarIngrediente", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ingrediente_id", txtId.Text);
                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@proveedor_id", txtProveedorId.Text);
                cmd.Parameters.AddWithValue("@helado_id", txtHeladoId.Text);
                cmd.Parameters.AddWithValue("@unidad_medida", txtUnidadMedida.Text);
                cmd.Parameters.AddWithValue("@precio_por_unidad", Convert.ToDecimal(txtPrecioUnidad.Text));
                cmd.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);

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
                SqlCommand cmd = new SqlCommand("spEliminarIngrediente", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ingrediente_id", txtEliminar.Text);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    lblMensaje1.Text = dr["Mensaje"].ToString();
                }
                con.Close();
            }
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("spBuscarIngrediente", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Texto", txtBuscar.Text);
                cmd.Parameters.AddWithValue("@Criterio", ddlCriterio.SelectedValue);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvIngredientes.DataSource = dt;
                gvIngredientes.DataBind();
                gvIngredientes.Visible = true;
            }
        }
    }
}