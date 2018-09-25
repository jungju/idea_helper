using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SilverlightApplication1.Web
{
    public partial class GetImages : System.Web.UI.Page
    {
        SlotMachine _Sm = new SlotMachine();
        protected void Page_Load(object sender, EventArgs e)
        {
            List<string> imgs = _Sm.GetRandomItems();

            string resString = "";

            foreach (string item in imgs)
            {
                resString += "," + item;
            }

            Response.Clear();
            Response.Write(resString);
            Response.End();
        }
    }
}
