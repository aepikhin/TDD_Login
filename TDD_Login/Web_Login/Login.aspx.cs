using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Clases_Login;

namespace Web_Login
{
    public partial class Login : System.Web.UI.Page
    {
        DBPruebas db;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["db"] == null)
            {
                db = new DBPruebas();
                Session["db"] = db;
            }
            if(db == null)
                db = (DBPruebas)Session["db"];

            TextUsername.Focus();
        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            if(db.valida(TextUsername.Text, TextPassword.Text))
            {
                db.lanzaEvento(TextUsername.Text, "LoginWindow", TipoEvento.LOGIN_EXITO);
                Session["user"] = TextUsername.Text;
                Response.Redirect("~/Log.aspx");
            } else
            {
                string usuario = (TextUsername.Text.Trim() == "") ? "Desconocido" : TextUsername.Text;
                db.lanzaEvento(usuario, "LoginWindow", TipoEvento.LOGIN_FALLIDO);
                TextUsername.Focus();
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('Nombre de usuario y/o contraseña incorrectos. O usuario bloqueado.');", true);
            }
        }

        protected void ButtonCancelar_Click(object sender, EventArgs e)
        {
            TextUsername.Text = "";
            TextPassword.Text = "";
            TextUsername.Focus();
        }
    }
}