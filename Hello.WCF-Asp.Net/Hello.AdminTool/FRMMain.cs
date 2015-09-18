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
    public partial class FRMMain : Form
    {
        public FRMMain()
        {
            InitializeComponent();
        }

        private void bntCreateUser_Click(object sender, EventArgs e)
        {
            FRMUserCreate frmuser = new FRMUserCreate();
            frmuser.ShowDialog();
        }

        private void bntCreateMessage_Click(object sender, EventArgs e)
        {
            FRMMessageCreate frmMessage = new FRMMessageCreate();
            frmMessage.ShowDialog();
        }

        private void bntCreateRelationship_Click(object sender, EventArgs e)
        {
            FRMRelationshipCreate frmRelation = new FRMRelationshipCreate();
            frmRelation.ShowDialog();
        }
    }
}
