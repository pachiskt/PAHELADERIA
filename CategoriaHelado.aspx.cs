using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace Heladeria_CRUD
{
    public partial class CategoriaHelado : System.Web.UI.Page
    {
        string conexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvCRUD.Visible = false; 
            }
        }
        private void CargarCategorias()
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("spListarCategorias", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvCRUD.DataSource = dt;
                gvCRUD.DataBind();
                gvCRUD.Visible = true;
            }
        }

        protected void btnListarTodo_Click(object sender, EventArgs e)
        {
            CargarCategorias();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("spAgregarCategoria", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@categoria_id", txtId.Text.Trim());
                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                cmd.Parameters.AddWithValue("@descripcion", txtDescripcion.Text.Trim());

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    lblMensaje.Text = dr["Mensaje"].ToString();
                }
                conn.Close();

                CargarCategorias();
                LimpiarCampos();
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("spActualizarCategoria", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@categoria_id", txtId.Text.Trim());
                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                cmd.Parameters.AddWithValue("@descripcion", txtDescripcion.Text.Trim());

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    lblMensaje.Text = dr["Mensaje"].ToString();
                }
                conn.Close();

                CargarCategorias();
                LimpiarCampos();
            }
        }

        protected void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ddlCriterio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("spBuscarCategoria", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Texto", txtBuscar.Text.Trim());
                cmd.Parameters.AddWithValue("@Criterio", ddlCriterio.SelectedValue);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvCRUD.DataSource = dt;
                gvCRUD.DataBind();
            }
        }

        protected void txtIdEliminar_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("spEliminarCategoria", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@categoria_id", txtIdEliminar.Text.Trim());

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    lblMensaje1.Text = dr["Mensaje"].ToString();
                    lblMensaje1.ForeColor = (dr["CodError"].ToString() == "0") ? System.Drawing.Color.Green : System.Drawing.Color.Red;
                }
                conn.Close();

                // Mostrar la tabla actualizada
                CargarCategorias();
                gvCRUD.Visible = true;

                txtIdEliminar.Text = "";
            }
        }
        private void LimpiarCampos()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
        }
        protected void gvCRUC_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}