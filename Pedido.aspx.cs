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
    public partial class Pedido1 : System.Web.UI.Page
    {
        string conexion = ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPedidos();
                CargarMetodosPago();
                
            }
        }
        void CargarPedidos()
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlDataAdapter da = new SqlDataAdapter("spListarPedidos", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvPedidos.DataSource = dt;
                gvPedidos.DataBind();
            }
        }
        void CargarMetodosPago()
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlDataAdapter da = new SqlDataAdapter("spListarMetodosPago", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                ddlMetodoPago.DataSource = dt;
                ddlMetodoPago.DataTextField = "nombre";
                ddlMetodoPago.DataValueField = "metodo_pago_id";
                ddlMetodoPago.DataBind();
            }
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            EjecutarComando("spAgregarPedido", true);
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            EjecutarComando("spActualizarPedido", false);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("spEliminarPedido", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pedido_id", txtPedidoID.Text);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    lblMensaje.Text = dr["Mensaje"].ToString();
                }
                con.Close();
                CargarPedidos();
                LimpiarCampos();
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        void LimpiarCampos()
        {
            txtPedidoID.Text = "";
            txtClienteID.Text = "";
            txtEmpleadoID.Text = "";
            txtFechaPedido.Text = "";
            txtTotal.Text = "";
            txtEstado.Text = "";
            txtObservaciones.Text = "";
            lblMensaje.Text = "";
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand("spBuscarPedido", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Texto", txtBuscar.Text);
                cmd.Parameters.AddWithValue("@Criterio", ddlCriterio.SelectedValue);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvPedidos.DataSource = dt;
                gvPedidos.DataBind();
            }
        }

        protected void gvPedidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvPedidos.SelectedRow;
            txtPedidoID.Text = row.Cells[1].Text;
            txtClienteID.Text = row.Cells[2].Text;
            txtEmpleadoID.Text = row.Cells[3].Text;
            txtFechaPedido.Text = Convert.ToDateTime(row.Cells[4].Text).ToString("yyyy-MM-ddTHH:mm");
            ddlMetodoPago.SelectedValue = row.Cells[5].Text;
            txtTotal.Text = row.Cells[6].Text;
            txtEstado.Text = row.Cells[7].Text;
            txtObservaciones.Text = Server.HtmlDecode(row.Cells[8].Text);
        }

        void EjecutarComando(string procedimiento, bool esNuevo)
        {
            using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand(procedimiento, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@pedido_id", txtPedidoID.Text);
                cmd.Parameters.AddWithValue("@cliente_id", txtClienteID.Text);
                cmd.Parameters.AddWithValue("@empleado_id", txtEmpleadoID.Text);
                cmd.Parameters.AddWithValue("@fecha_pedido", Convert.ToDateTime(txtFechaPedido.Text));
                cmd.Parameters.AddWithValue("@metodo_pago_id", ddlMetodoPago.SelectedValue);
                cmd.Parameters.AddWithValue("@total", Convert.ToDecimal(txtTotal.Text));
                cmd.Parameters.AddWithValue("@estado", txtEstado.Text);
                cmd.Parameters.AddWithValue("@observaciones", txtObservaciones.Text);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    lblMensaje.Text = dr["Mensaje"].ToString();
                }
                con.Close();
                CargarPedidos();
                LimpiarCampos();
            }
        }

    }
}