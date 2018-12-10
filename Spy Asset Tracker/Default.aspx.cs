using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Spy_Asset_Tracker
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var names = new string[0];
                var elections = new int[0];
                var subterfuge = new double[0];

                ViewState.Add("names", names);
                ViewState.Add("elections", elections);
                ViewState.Add("subterfuge", subterfuge);
            }
        }

        protected void addAssetButton_Click(object sender, EventArgs e)
        {
            string[] names = (string[]) ViewState["names"];
            int[] elections = (int[]) ViewState["elections"];
            double[] subterfuges = (double[]) ViewState["subterfuge"];

            Array.Resize(ref names, names.Length + 1);
            Array.Resize(ref elections, elections.Length + 1);
            Array.Resize(ref subterfuges, subterfuges.Length + 1);

            int newName = names.GetUpperBound(0);
            int newElection = elections.GetUpperBound(0);
            int newSubterfuge = subterfuges.GetUpperBound(0);

            names[newName] = nameTextBox.Text;
            elections[newElection] = int.Parse(electionsTextBox.Text);
            subterfuges[newSubterfuge] = double.Parse(subterfugeTextBox.Text);

            ViewState["names"] = names;
            ViewState["elections"] = elections;
            ViewState["subterfuge"] = subterfuges;

            resultLabel.Text = $"Total Elections Rigged: {elections.Sum()}<br/>" +
                               $"Average Acts of Subterfuge per Asset: {subterfuges.Average():N2}<br/>" +
                               $"(Last asset you added: {names[newName]})";
        }
    }
}