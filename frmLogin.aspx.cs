using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace InfoToolsSV
{
    public partial class frmLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        string patron = "InfoToolsSV";
        protected void BtnIngresar_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConectar = new SqlConnection(ConfigurationManager.ConnectionStrings["conexionBD"].ConnectionString);
            SqlCommand cmd = new SqlCommand("SP_ValidarUsuario", sqlConectar)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Connection.Open();
            cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 50).Value = tbUsuario.Text;
            cmd.Parameters.Add("@Contrasenia", SqlDbType.VarChar, 50).Value = tbPassword.Text;
            cmd.Parameters.Add("@Patron", SqlDbType.VarChar, 50).Value = patron;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                //Agregamos una sesion de usuario
                Session["usuariologueado"] = tbUsuario.Text;
                Response.Redirect("frmIndex.aspx");
            }
            else
            {
                lblError.Text = "Error de Usuario o Contrasenia";
            }

            cmd.Connection.Close();
        }

        protected void BtnRegistro_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmRegistro.aspx");
        }
    }
}