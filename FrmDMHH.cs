using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ViDu
{
    public partial class FrmDMHH : Form
    {
        public FrmDMHH()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-1LOB8EI;Initial Catalog=QLBH;Integrated Security=True");
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        string query;
        int i;
        bool isnhap = false; 
        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void updatedata()
        {
            conn.Open();
            query = "Select * from tblDMHH order by Mahh";
            da = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            dt.Clear();
            da.Fill(dt);
            grdhh.DataSource = dt;
            conn.Close();
        }
        private void FrmDMHH_Load(object sender, EventArgs e)
        {
            updatedata();            
        }

        private void grdhh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            napct();
        }

        private void btnfirst_Click(object sender, EventArgs e)
        {              
            grdhh.CurrentCell = grdhh[0, 0];
            napct();             
        }

        private void btnlast_Click(object sender, EventArgs e)
        {
            grdhh.CurrentCell = grdhh[0, grdhh.RowCount - 1];
            napct(); 
        }

        private void btnprevious_Click(object sender, EventArgs e)
        {
            i = grdhh.CurrentRow.Index;
            if (i>0)
            {
                grdhh.CurrentCell = grdhh[0, i-1];
                napct();
            }
        }

        private void btnnext_Click(object sender, EventArgs e)
        {
            i = grdhh.CurrentRow.Index;
            if (i < grdhh.RowCount)
            {
                grdhh.CurrentCell = grdhh[0, i + 1];
                napct();
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            txtmanhom.Enabled = true;
            txtmahh.Enabled = true;
            txtmahh.Text = "";
            txtmanhom.Text = "";
            txtsanxuat.Text = "";
            txtusd.Text = "";
            txtvnd.Text = "";
            txtdvt.Text = "";
            txttenhh.Text = "";
            isnhap = true; 
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (isnhap)
            {
                if (txtmahh.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập mã hàng hóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    conn.Open();
                    query = "Insert into tblDMHH Values ('" + txtmanhom.Text + "', '" + txtmahh.Text + "', '" + txttenhh.Text + "', '" + txtdvt.Text + "', '" + txtvnd.Text + "','" + txtusd.Text + "', '" + txtsanxuat.Text + "','0' )";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    updatedata();
                    isnhap = false;
                    txtmanhom.Enabled = false;
                    txtmahh.Enabled = false;
                }
            }
            else
            {
                conn.Open();
                query = "Update tblDMHH set tenHH = '"+txttenhh.Text+"', dvt = '"+txtdvt.Text+"', DGvnd = '"+txtvnd.Text+"', DGusd = '"+txtusd.Text+"', Sanxuat = '"+txtsanxuat.Text+"' where MaHH = '"+txtmahh.Text+"'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                updatedata();
            }
        }

        public void napct()
        {
            i = grdhh.CurrentRow.Index;
            txtmanhom.Text = grdhh[0, i].Value.ToString();
            txtmahh.Text = grdhh[1, i].Value.ToString();
            txttenhh.Text = grdhh[2, i].Value.ToString();
            txtdvt.Text = grdhh[3, i].Value.ToString();
            txtsanxuat.Text = grdhh[6, i].Value.ToString();
            txtusd.Text = grdhh[5, i].Value.ToString();
            txtvnd.Text = grdhh[4, i].Value.ToString();
        }

        private void btndel_Click(object sender, EventArgs e)
        {
            conn.Open();
            query = "Delete from tblDMHH where MaHH = '"+txtmahh.Text+"'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            updatedata();
            btnfirst.PerformClick();
        }
    }
}
