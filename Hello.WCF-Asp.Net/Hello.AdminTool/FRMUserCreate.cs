using System;
using System.Text;
using System.Windows.Forms;
using Hello.WCF.Dataobjects;
using Hello.WCF.BuisnessLogic;

namespace Hello.AdminTool
{
    public partial class FRMUserCreate : Form
    {
        public FRMUserCreate()
        {
            InitializeComponent();
        }

        private void bntCreateUser_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.accountName = txtAccountName.Text;
            System.Text.ASCIIEncoding enc = new ASCIIEncoding();
            user.password = enc.GetBytes(txtPassword.Text);
            UserManager.CreateUser(user);
            Close();
        }
    }
}
