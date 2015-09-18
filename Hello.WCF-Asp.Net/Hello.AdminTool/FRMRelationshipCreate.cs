using Hello.WCF.BuisnessLogic;
using Hello.WCF.Dataobjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hello.AdminTool
{
    public partial class FRMRelationshipCreate : Form
    {
        User user = new User();
        public FRMRelationshipCreate()
        {
            InitializeComponent();
            user = UserManager.GetUserByAccountName("Test");
        }

        private void bntFriendshipCreate_Click(object sender, EventArgs e)
        {

        }
    }
}
