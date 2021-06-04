using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ViDu
{
    public partial class FrmMain : Form
    {
        
        public FrmMain()
        {
            InitializeComponent();
        }
        

        private void bàiTậpChàoHỏiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Baitapchaohoi bt = new Baitapchaohoi();
            bt.ShowDialog();
        }

        private void danhMụcHàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            status.Text = "Danh mục hàng hóa";
            FrmDMHH dm = new FrmDMHH();
            dm.ShowDialog();
            status.Text = "Ready";
        }
    }
}
