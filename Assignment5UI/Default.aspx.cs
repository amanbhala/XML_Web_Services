using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Assignment5TryItPage
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }
        protected void xmlverification(object sender, EventArgs e)
        {
            try
            {
                ServiceReference1.Service1Client myClient = new ServiceReference1.Service1Client();
                string res;
                res = myClient.verification(TextBox2.Text, TextBox3.Text);
                Label3.Text = res;
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid url", "Not a valid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        protected void xmlsearch(object sender, EventArgs e)
        {
            try
            {
                ServiceReference1.Service1Client myClient = new ServiceReference1.Service1Client();
                string res;
                res = myClient.SearchXmlWithDOM(TextBox7.Text, TextBox8.Text);
                Label4.Text = res;
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid url", "Not a valid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        protected void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox8_TextChanged(object sender, EventArgs e)
        {

        }
    }
}