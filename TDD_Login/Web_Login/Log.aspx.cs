using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Clases_Login;

namespace Web_Login
{
    public partial class Log : System.Web.UI.Page
    {
        DBPruebas db;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["db"] == null)
            {
                db = new DBPruebas();
                Session["db"] = db;
            }
            if (db == null)
                db = (DBPruebas)Session["db"];
            if (Session["user"] == null)
                Response.Redirect("~/Login.aspx");


            // HEADER
            List<String> header = new List<String>(new String[] { "Fecha", "Usuario", "Tipo de acceso", "Seción" });
            TableRow tRow = new TableRow();
            TableLog.Rows.Add(tRow);
            TableCell tCell;
            for(int i = 0; i < 4; i++)
            {
                tCell = new TableCell();
                tRow.Cells.Add(tCell);
                tCell.Text = header[i];
                tCell.Font.Bold = true;
            }

            //FILAS
            IList<Evento> logs = db.verLog();
            for (int i = 0; i < logs.Count; i++)
            {
                tRow = new TableRow();
                TableLog.Rows.Add(tRow);
                tCell = new TableCell();
                tRow.Cells.Add(tCell);
                tCell.Text = "" + logs[i].Fecha;
                tCell = new TableCell();
                tRow.Cells.Add(tCell);
                tCell.Text = logs[i].Username;
                tCell = new TableCell();
                tRow.Cells.Add(tCell);
                tCell.Text = "" + logs[i].TipoEvento;
                tCell = new TableCell();
                tRow.Cells.Add(tCell);
                tCell.Text = logs[i].Seccion;
            }

            tRow = new TableRow();
            TableLog.Rows.Add(tRow);
            tCell = new TableCell();
            tRow.Cells.Add(tCell);
            tCell.ColumnSpan = 2;

            // BOTONES
            Button btn1 = new Button();
            Button btn2 = new Button();
            btn1.ID = "ButtonBorrar";
            btn2.ID = "ButtonLogout";
            btn1.Text = "Borrar";
            btn2.Text = "Logout";
            btn1.Click += new EventHandler(ButtonBorrar_Click);
            btn2.Click += new EventHandler(ButtonLogout_Click);
            
            tCell = new TableCell();
            tRow.Cells.Add(tCell);
            tCell.Controls.Add(btn1);
            tCell = new TableCell();
            tRow.Cells.Add(tCell);
            tCell.Controls.Add(btn2);
        }

        protected void ButtonBorrar_Click(object sender, EventArgs e)
        {
            string usuario = (Session["user"] != null) ? (string)Session["user"] : "Desconocido";
            if (db.esAdministrador(usuario))
            {
                db.borrarLog();
                db.lanzaEvento(usuario, "LogWindow", TipoEvento.BORRADO);
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('Log borrado con exito.');", true);
                Response.Redirect("~/Log.aspx");
            } else
            {
                db.lanzaEvento(usuario, "LogWindow", TipoEvento.BORRADO_ILEGAL);
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", "alert('Usted no es administrador.');", true);
                Response.Redirect("~/Log.aspx");
            }
        }

        protected void ButtonLogout_Click(object sender, EventArgs e)
        {
            string usuario = (Session["user"] != null) ? (string)Session["user"] : "Desconocido";
            db.lanzaEvento(usuario, "LogWindow", TipoEvento.LOGOUT);
            Session["user"] = null;
            Response.Redirect("~/Login.aspx");
        }
    }
}