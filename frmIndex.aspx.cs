using System;

namespace InfoToolsSV
{
    public partial class frmIndex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuariologueado"] != null)
            {
                string usuariologueado = Session["usuariologueado"].ToString();
                lblBienvenida.Text = "Bienvenido/a " + usuariologueado;
            }
            else
            {
                Response.Redirect("frmLogin.aspx");
            }
        }
        protected void BtnCerrar_Click(object sender, EventArgs e)
        {
            Session.Remove("usuariologueado");
            Response.Redirect("frmLogin.aspx");
        }
    }
}