using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_Login
{
    public partial class Log : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // HEADER
            List<String> header = new List<String>(new String[] { "Fecha", "Usuario", "Tipo de acceso", "Seción", "Evento" });
            TableRow tRow = new TableRow();
            TableLog.Rows.Add(tRow);
            TableCell tCell;
            for(int i = 0; i < 5; i++)
            {
                tCell = new TableCell();
                tRow.Cells.Add(tCell);
                tCell.Text = header[i];
                tCell.Font.Bold = true;
            }

            //FILAS
            for(int i = 0; i < 2; i++)
            {
                tRow = new TableRow();
                TableLog.Rows.Add(tRow);
                for (int j = 0; j < 5; j++)
                {
                    tCell = new TableCell();
                    tRow.Cells.Add(tCell);
                    tCell.Text = "Prueba";
                }
            }

            tRow = new TableRow();
            TableLog.Rows.Add(tRow);
            tCell = new TableCell();
            tRow.Cells.Add(tCell);
            tCell.ColumnSpan = 3;

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

        }

        protected void ButtonLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
        }
    }
}