using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Heladeria_CRUD
{
    public partial class Sabor1 : System.Web.UI.Page
    {
        string conexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvSabores.Visible = false;
            }
        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                SqlDataAdapter da = new SqlDataAdapter("spListarSabores", cn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvSabores.DataSource = dt;
                gvSabores.DataBind();
                gvSabores.Visible = true;
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

        protected void txtCategoriaId_TextChanged(object sender, EventArgs e)
        {

        }

        protected void chkPopular_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("spAgregarSabor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@sabor_id", txtId.Text);
                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);
                cmd.Parameters.AddWithValue("@categoria_id", txtCategoriaId.Text);
                cmd.Parameters.AddWithValue("@es_popular", chkPopular.Checked);

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    lblMensaje.Text = dr["Mensaje"].ToString();
                    gvSabores.Visible = true;
                    btnListar_Click(null, null);
                }
                cn.Close();
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("spActualizarSabor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@sabor_id", txtId.Text);
                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);
                cmd.Parameters.AddWithValue("@categoria_id", txtCategoriaId.Text);
                cmd.Parameters.AddWithValue("@es_popular", chkPopular.Checked);

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    lblMensaje.Text = dr["Mensaje"].ToString();
                    gvSabores.Visible = true;
                    btnListar_Click(null, null);
                }
                cn.Close();
            }
        }

        protected void ddlCriterio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("spBuscarSabor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Texto", txtBuscar.Text);
                cmd.Parameters.AddWithValue("@Criterio", ddlCriterio.SelectedValue);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvSabores.DataSource = dt;
                gvSabores.DataBind();
                gvSabores.Visible = true;
            }
        }

        protected void txtEliminar_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("spEliminarSabor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@sabor_id", txtEliminar.Text);

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    lblMensaje1.Text = dr["Mensaje"].ToString();
                    gvSabores.Visible = true;
                    btnListar_Click(null, null);
                }
                cn.Close();
            }
        }

        protected void gvSabores_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}