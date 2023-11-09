using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace final_project_DB
{
    public partial class vendor : sample3
    {
        bool flag = false;
        int pid;
        OracleConnection con;
        public vendor()
        {
            InitializeComponent();
        }

        private void vendor_Load(object sender, EventArgs e)
        {
            string conStr = @"DATA SOURCE = localhost:1521 / XE; USER ID = 21L-5430_project; PASSWORD = 123";
            con = new OracleConnection(conStr);
           
            vid.Enabled = false;
            company.Enabled = false;
            category.Enabled = false;
            product.Enabled = false;
            quantity.Enabled = false;
            ppid.Enabled = false;
            ddate.Enabled = false;

        }
        public override void button1_Click(object sender, EventArgs e)
        {

            vid.Clear();
            company.Clear();
            category.Clear();
            product.Clear();
            quantity.Clear();
            ddate.Clear();
            ppid.Clear();


            vid.Enabled = true;
            company.Enabled = true;
            category.Enabled = true;
            product.Enabled = true;
            quantity.Enabled = true;
            ddate.Enabled = true;
            ppid.Enabled = true;

        }

        public override void button2_Click(object sender, EventArgs e)
        {
            flag = true;
            vid.Enabled = true;
            company.Enabled = true;
            category.Enabled = true;
            product.Enabled = true;
            quantity.Enabled = true;
            ddate.Enabled = true;
            ppid.Enabled = true;



        }
        private void updateGrid()
        {
            con.Open();
            OracleCommand getEmps = con.CreateCommand();
            getEmps.CommandText = " SELECT * FROM vendor";
            getEmps.CommandType = CommandType.Text;
            OracleDataReader empDR = getEmps.ExecuteReader();//display
            DataTable empDT = new DataTable();//get data from datatable
            empDT.Load(empDR);
            dataGridView1.DataSource = empDT;
            con.Close();
        }

        public override void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            string sql = "DELETE FROM vendor WHERE vendor_id = :vid";

            // create an OracleCommand object with the SQL statement and connection
            OracleCommand cmd = new OracleCommand(sql, con);

            // add parameter values from the textbox
            cmd.Parameters.Add(":vid", OracleDbType.Int32).Value = Convert.ToInt32(vid.Text);

            // execute the SQL statement
            int rows = cmd.ExecuteNonQuery();

            // close the database connection
            con.Close();
            MessageBox.Show("Record deleted successfully");
             updateGrid();
            vid.Clear();
            company.Clear();
            category.Clear();
            product.Clear();
            quantity.Clear();
            ddate.Clear();
            ppid.Clear();

            vid.Enabled = false;
            company.Enabled = false;
            category.Enabled = false;
            product.Enabled = false;
            quantity.Enabled = false;
            ddate.Enabled = false;
            ppid.Enabled = false;


        }

        public override void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (flag == false)////insert
                {
                    con.Open();
                    OracleCommand insertEmp = con.CreateCommand();
                    insertEmp.CommandText = " INSERT INTO vendor VALUES('" + vid.Text + "','" + company.Text + "','" + category.Text + "','" + ppid.Text + "','" + product.Text + "','" + quantity.Text + "','" + ddate.Text + "')";
                    insertEmp.CommandType = CommandType.Text;
                    int rows = insertEmp.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show(" Data Inserted Successfully! ");
                    }
                    con.Close();
                    updateGrid();

                    vid.Clear();
                    company.Clear();
                    category.Clear();
                    product.Clear();
                    quantity.Clear();
                    ddate.Clear();
                    ppid.Clear();


                    vid.Enabled = false;
                    company.Enabled = false;
                    category.Enabled = false;
                    product.Enabled = false;
                    quantity.Enabled = false;
                    ddate.Enabled = false;
                    ppid.Enabled = false;

                }
                else///update
                {
                    con.Open();

                    string sql = "UPDATE vendor SET vendor_id = :vid ,company = :name,  category= :phone_no,product_id=:cute,  product_name = :address, quantity = :address1,purchase_date=:address2 WHERE vendor_id = :vid";

                    // create an OracleCommand object with the SQL statement and connection
                    OracleCommand cmd = new OracleCommand(sql, con);

                    // add parameter values from the textboxes
                    cmd.Parameters.Add(":vid", OracleDbType.Int32).Value = Convert.ToInt32(vid.Text);
                    cmd.Parameters.Add(":name", OracleDbType.Varchar2).Value = company.Text;
                    cmd.Parameters.Add(":phone_no", OracleDbType.Varchar2).Value = category.Text;
                    cmd.Parameters.Add(":cute", OracleDbType.Int32).Value = ppid.Text;
                    cmd.Parameters.Add(":address", OracleDbType.Varchar2).Value = product.Text;
                    cmd.Parameters.Add(":address1", OracleDbType.Int32).Value = quantity.Text;
                    cmd.Parameters.Add(":address2", OracleDbType.Date).Value = ddate.Text;

                    // execute
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show(" Data Updated Successfully! ");
                    }

                    con.Close();

                    
                   
                     updateGrid();

                    vid.Enabled = false;
                    company.Enabled = false;
                    category.Enabled = false;
                    product.Enabled = false;
                    quantity.Enabled = false;
                    ddate.Enabled = false;
                    ppid.Enabled = false;
                    flag = false;
                    vid.Clear();
                    company.Clear();
                    category.Clear();
                    product.Clear();
                    quantity.Clear();
                    ddate.Clear();
                    ppid.Clear();

                }
            }
            catch
            {

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];///getting pid from where
                pid = Convert.ToInt32(row.Cells[0].Value.ToString());
                vid.Text = row.Cells[0].Value.ToString();
                company.Text = row.Cells[1].Value.ToString();
                category.Text = row.Cells[2].Value.ToString();
                ppid.Text = row.Cells[3].Value.ToString();
                product.Text = row.Cells[4].Value.ToString();
                quantity.Text = row.Cells[5].Value.ToString();
                ddate.Text = row.Cells[6].Value.ToString();


            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            main_screen obj2 = new main_screen();
            main.showWindow(obj2, this, mdi.ActiveForm);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dataGridView1.DataSource;
            if (dataGridView1.RowCount > 0)
            {
                dt.Clear();
            }
            updateGrid();
       

        }
        private void updateGrid1()
        {
            con.Open();
            OracleCommand getEmps = con.CreateCommand();
            getEmps.CommandText = " select p.product_id,p.product_name,c.name as category,p.category as cid,p.quantity as stock_avilable,p.BARCODE from product p,category c where p.category = c.cid ";
            getEmps.CommandType = CommandType.Text;
            OracleDataReader empDR = getEmps.ExecuteReader();//display
            DataTable empDT = new DataTable();//get data from datatable
            empDT.Load(empDR);
            dataGridView1.DataSource = empDT;

            con.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dataGridView1.DataSource;
            if (dataGridView1.RowCount > 0)
            {
                dt.Clear();
            }

            //dt.Clear();
            updateGrid1();
        }
    }
}
