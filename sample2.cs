using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Types;
using Oracle.ManagedDataAccess.Client;

namespace final_project_DB/////set public override
{
    public partial class sample2 :sample
    {
        bool flag = false;
        int pid;
        OracleConnection con;
        public sample2()
        {
            InitializeComponent();
        }

        private void sample2_Load(object sender, EventArgs e)
        {
            string conStr = @"DATA SOURCE = localhost:1521 / XE; USER ID = 21L-5430_project; PASSWORD = 123";
            con = new OracleConnection(conStr);
            updateGrid();
                id.Enabled=false;
            name.Enabled = false;
            comboBox1.Enabled = false;
            quantity.Enabled = false;
            rack.Enabled = false;
            barcode.Enabled = false;
            price.Enabled = false;
           updateGrid();
            try
            {
                con.Open();
                comboBox1.Items.Clear();
                comboBox1.DataSource = null;
                OracleCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT cid,name FROM category";
                cmd.CommandType = CommandType.Text;
                OracleDataReader da = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(da);
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "name";
                comboBox1.ValueMember = "cid";
                con.Close();
            }
            catch
            {

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
        private void updateGrid()
        {
            con.Open();
            OracleCommand getEmps = con.CreateCommand();
            getEmps.CommandText = " SELECT* FROM product" ;
            getEmps.CommandType = CommandType.Text;
            OracleDataReader empDR = getEmps.ExecuteReader();//display
            DataTable empDT = new DataTable();//get data from datatable
            empDT.Load(empDR);
            dataGridView1.DataSource = empDT;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            price.Clear();
            id.Clear();
            name.Clear();
            //comboBox1.
            quantity.Clear();
            rack.Clear();
            barcode.Clear();
            id.Enabled = true;
                name.Enabled =true;
            comboBox1.Enabled=true;
                quantity.Enabled = true;
                rack.Enabled = true;
                barcode.Enabled = true;
            price.Enabled = true;
            //try
            //{
            //    con.Open();
            //    comboBox1.Items.Clear();
            //    comboBox1.DataSource = null;
            //    OracleCommand cmd = con.CreateCommand();
            //    cmd.CommandText = "SELECT cid,name FROM category";
            //    cmd.CommandType = CommandType.Text;
            //    OracleDataReader da = cmd.ExecuteReader();
            //    DataTable dt = new DataTable();
            //    dt.Load(da);
            //    comboBox1.DataSource = dt;
            //    comboBox1.DisplayMember = "name";
            //    comboBox1.ValueMember = "cid";
            //    con.Close();
            //}
            //catch
            //{

            //}

           // updateGrid();
        }

        private void id_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            rack obj3 = new rack();
            main.showWindow(obj3, this, mdi.ActiveForm);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];///getting pid from where
                pid = Convert.ToInt32(row.Cells[0].Value.ToString());
                id.Text = row.Cells[0].Value.ToString();
                name.Text = row.Cells[1].Value.ToString();
               comboBox1.SelectedItem = row.Cells[2].Value.ToString();
                quantity.Text = row.Cells[3].Value.ToString();
                rack.Text = row.Cells[4].Value.ToString();
                barcode.Text = row.Cells[5].Value.ToString();
                price.Text = row.Cells[6].Value.ToString();
            }

        }

       public virtual void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {try
            {
                if (flag == false)////insert
                {
                    con.Open();
                    OracleCommand insertEmp = con.CreateCommand();//converting to int combo box if reqied
                    insertEmp.CommandText = " INSERT INTO product VALUES('" + id.Text + "','" + name.Text + "','" + comboBox1.SelectedValue + "','" + quantity.Text + "','" + rack.Text + "','" + barcode.Text + "','" + price.Text + "')";
                    insertEmp.CommandType = CommandType.Text;
                    int rows = insertEmp.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show(" Data Inserted Successfully! ");
                    }
                    con.Close();
                    updateGrid();
                    id.Clear();
                    name.Clear();
                    //category.Clear();
                    price.Clear();
                    quantity.Clear();
                    rack.Clear();
                    barcode.Clear();
                    id.Enabled = false;
                    name.Enabled = false;
                  comboBox1.Enabled = false;
                    quantity.Enabled = false;
                    rack.Enabled = false;
                    barcode.Enabled = false;
                    price.Enabled = false;
                }
                else///update
                {
                    con.Open();

                    string sql = "UPDATE product SET product_id = :id, product_name = :name, category = :category, quantity = :quantity, rackno = :Rack, barcode = :barcode, per_unit_price = :price WHERE product_id = :id";

                    // create an OracleCommand object with the SQL statement and connection
                    OracleCommand cmd = new OracleCommand(sql, con);

                    // add parameter values from the textboxes
                    cmd.Parameters.Add(":id", OracleDbType.Int32).Value = Convert.ToInt32(id.Text);
                    cmd.Parameters.Add(":name", OracleDbType.Varchar2).Value = name.Text;
                    cmd.Parameters.Add(":category", OracleDbType.Varchar2).Value = comboBox1.SelectedValue;
                    cmd.Parameters.Add(":quantity", OracleDbType.Int32).Value = Convert.ToInt32(quantity.Text);
                    cmd.Parameters.Add(":Rack", OracleDbType.Varchar2).Value = rack.Text;
                    cmd.Parameters.Add(":barcode", OracleDbType.Varchar2).Value = barcode.Text;
                    cmd.Parameters.Add(":price", OracleDbType.Int32).Value = price.Text;

                    // execute
                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        MessageBox.Show(" Data Updated Successfully! ");
                    }


                    con.Close();
                    updateGrid();
                    id.Clear();
                    name.Clear();
                    //comboBox1.Clear();
                    price.Clear();
                    quantity.Clear();
                    rack.Clear();
                    barcode.Clear();
                    id.Enabled = false;
                    name.Enabled = false;
                    comboBox1.Enabled = false;
                    quantity.Enabled = false;
                    rack.Enabled = false;
                    barcode.Enabled = false;
                    price.Enabled = false;
                    flag = false;
                }
            }
            catch
            {

            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            flag = true;
            id.Enabled = true;
            name.Enabled = true;
          comboBox1.Enabled = true;
            quantity.Enabled = true;
            rack.Enabled = true;
            barcode.Enabled = true;
            price.Enabled = true;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            string sql = "DELETE FROM product WHERE product_id = :id";

            // create an OracleCommand object with the SQL statement and connection
            OracleCommand cmd = new OracleCommand(sql, con);

            // add parameter values from the textbox
            cmd.Parameters.Add(":id", OracleDbType.Int32).Value = Convert.ToInt32(id.Text);

            // execute the SQL statement
            int rows = cmd.ExecuteNonQuery();

            // close the database connection
            con.Close();
            MessageBox.Show("Record deleted successfully");
        updateGrid();
            id.Clear();
            name.Clear();
            //category.Clear();
            quantity.Clear();
            rack.Clear();
            barcode.Clear();
            price.Clear();
            id.Enabled = false;
            name.Enabled = false;
           comboBox1.Enabled = false;
            quantity.Enabled = false;
            rack.Enabled = false;
            barcode.Enabled = false;
            price.Enabled = false;

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
