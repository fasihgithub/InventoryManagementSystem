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
using System;



namespace final_project_DB
{

   
      
    

    public partial class sales : sample
    {
        int counter1 = 0;
        OracleConnection con;
        int hello;
        bool flag = false;
        public sales()
        {
            InitializeComponent();
        }




        private void sales_Load(object sender, EventArgs e)
        {

            string conStr = @"DATA SOURCE = localhost:1521 / XE; USER ID = 21L-5430_project; PASSWORD = 123";
            con = new OracleConnection(conStr);
            perprice.Enabled = false;
            total.Enabled = false;
            try
            {
                con.Open();
             maxi.Enabled=false;
                comboBox1.DataSource = null;
                OracleCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT product_id,product_name FROM product";
                cmd.CommandType = CommandType.Text;
                OracleDataReader da = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(da);
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "product_name";
                comboBox1.ValueMember = "product_id";
                recepit.Text =Convert.ToString( GetUniqueNumber());
                recepit.Enabled = false;
                comboBox1.ResetText();

                con.Close();

            }
            catch
            {

            }

        }
        private static Random random = new Random();

        public static int GetUniqueNumber()
        {
            return random.Next(1000,9899 + 1);
        }
        private void updateGrid()
        {
            con.Open();
            OracleCommand getEmps = con.CreateCommand();
            getEmps.CommandText = " SELECT * FROM product";
            getEmps.CommandType = CommandType.Text;
            OracleDataReader empDR = getEmps.ExecuteReader();//display
            DataTable empDT = new DataTable();//get data from datatable
            empDT.Load(empDR);
            dataGridView1.DataSource = empDT;
            con.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();//////heere
            counter1 = 0;
            flag = false;
            textBox1.Clear();
            textBox1.Text = "0";
            cid.Clear();
            comboBox1.ResetText();
            numericUpDown1.Value = 0;
            perprice.Clear();
            total.Clear();
             DataTable dt = (DataTable)dataGridView1.DataSource;
            //if (dataGridView1.RowCount > 0)
            //{
            //    dt.Clear();
            //}
          //  dt.Rows.Clear();
            dataGridView1.Columns.Clear();

            recepit.Text = Convert.ToString(GetUniqueNumber());
            con.Close();


            //int hello = Convert.ToInt32(comboBox1.SelectedValue);
            //con.Open();
            //OracleCommand getEmps = con.CreateCommand();
            //getEmps.CommandText = "SELECT per_unit_price FROM product WHERE product_id = :productId";
            //getEmps.Parameters.Add("productId", OracleDbType.Int32).Value = hello;
            //OracleDataReader empDR = getEmps.ExecuteReader();
            //if (empDR.Read())
            //{
            //    perprice.Text = empDR.GetDecimal(0).ToString(); // get the value of the first column as a decimal and convert it to a string
            //}
            //else
            //{
            //    perprice.Text = ""; // no rows returned, set the textbox to empty
            //}

            //int fasih = Convert.ToInt32(perprice.Text) * Convert.ToInt32(numericUpDown1.Value);

            //total.Text = fasih.ToString();
            //con.Close();


            //OracleCommand getEmp = con.CreateCommand();
            //getEmps.CommandText = "SELECT per_unit_price FROM product WHERE product_id = hello";
            //getEmps.Parameters.Add("productId", OracleDbType.Int32).Value = hello;
            //OracleDataReader empDR = getEmps.ExecuteReader();
            //if (empDR.Read())
            //{
            //    perprice.Text = empDR.GetDecimal(0).ToString(); // get the value of the first column as a decimal and convert it to a string
            //}
            //else
            //{
            //    perprice.Text = ""; // no rows returned, set the textbox to empty
            //}


            //con.Close();

        }
       int counter=0;
        int k = 0;
        int rows;
        private void button1_Click(object sender, EventArgs e)
        {try
                //here i need to generate again unique number;
                {
              
                counter = 0;
                flag = false;
                con.Open();
                OracleCommand insertEmp = con.CreateCommand();
                //prev     //insertEmp.CommandText = " INSERT INTO sales (customer_id,product_id,quantity,per_unit_price,total) VALUES('" + cid.Text + "','" + comboBox1.SelectedValue + "','" + numericUpDown1.Value + "','" + perprice.Text + "','" + total.Text + "')";
                //insertEmp.CommandType = CommandType.Text;
                //int rows = insertEmp.ExecuteNonQuery();
                //if (rows > 0)
                //{
                //    MessageBox.Show(" Inventory updated successfully! Thankyou! ");
                //    con.Close();
                //}
           //////here changing .....

///
                foreach(DataGridViewRow row in dataGridView1.Rows)
                {

                    if (k >= counter1)
                        break;

                    //if(counter==0)
                    //{
                    //    counter++;
                    //    continue;
                    //}

                    insertEmp.CommandText = " INSERT INTO sales (customer_id,product_id,quantity,per_unit_price,total,recepit_id) values('" + cid.Text + "','" + Convert.ToInt32(row.Cells[0].Value.ToString()) + "','" + Convert.ToInt32(row.Cells[2].Value.ToString()) + "','" + Convert.ToInt32(row.Cells[3].Value.ToString()) + "','" + Convert.ToInt32(row.Cells[4].Value.ToString()) + "','"+ Convert.ToInt32(recepit.Text) + "')";
                    insertEmp.CommandType = CommandType.Text;
                    rows+= insertEmp.ExecuteNonQuery();
                    k++;
                }
                if (rows > 0)
                {
                    dataGridView1.Columns.Clear();
                    //     dataGridView1.Rows.Clear();
                    
                    MessageBox.Show(" Inventory updated successfully! Thankyou for your Purchase! ");
                    con.Close();
                }
                recepit.Text = Convert.ToString(GetUniqueNumber());
                textBox1.Clear();
                textBox1.Text = "0";
            }
            catch
            {
                con.Close();
            }
            
         //   updateGrid();
            cid.Clear();
            numericUpDown1.Value=0;
            perprice.Clear();
            total.Clear();
            counter1 = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            main_screen obj = new main_screen();
            main.showWindow(obj, this, mdi.ActiveForm);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
          

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            con.Open();
            dataGridView1.Columns.Clear();
        //    dataGridView1.Rows.Clear();
            //DataTable dt = (DataTable)dataGridView1.DataSource;
            //if (dataGridView1.RowCount > 0)
            //{
            //    dt.Clear();
            //}
          
            OracleCommand getEmps = con.CreateCommand();
            getEmps.CommandText = " SELECT * FROM sales";
            getEmps.CommandType = CommandType.Text;
            OracleDataReader empDR = getEmps.ExecuteReader();//display
            DataTable empDT = new DataTable();//get data from datatable
            empDT.Load(empDR);
            dataGridView1.DataSource = empDT;
            con.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pid_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dataGridView1.DataSource;
            if (dataGridView1.RowCount > 0)
            {
                dt.Clear();
            }

            //dt.Clear();
            updateGrid();

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int hello = Convert.ToInt32(comboBox1.SelectedValue);
            con.Open();
            OracleCommand getEmps = con.CreateCommand();
            getEmps.CommandText = "SELECT per_unit_price FROM product WHERE product_id = :productId";
            getEmps.Parameters.Add("productId", OracleDbType.Int32).Value = hello;
            OracleDataReader empDR = getEmps.ExecuteReader();
            if (empDR.Read())
            {
                perprice.Text = empDR.GetDecimal(0).ToString(); // get the value of the first column as a decimal and convert it to a string
            }
            else
            {
                perprice.Text = ""; // no rows returned, set the textbox to empty
            }

            int fasih = Convert.ToInt32(perprice.Text) * Convert.ToInt32(numericUpDown1.Value);

            total.Text = fasih.ToString();
            con.Close();
        }

        private void comboBox1_Validated(object sender, EventArgs e)
        {
            hello = Convert.ToInt32(comboBox1.SelectedValue);
            con.Open();
            OracleCommand getEmps = con.CreateCommand();
            getEmps.CommandText = "SELECT per_unit_price FROM product WHERE product_id = :productId";
            getEmps.Parameters.Add("productId", OracleDbType.Int32).Value = hello;
            OracleDataReader empDR = getEmps.ExecuteReader();
            if (empDR.Read())
            {
                perprice.Text = empDR.GetDecimal(0).ToString(); // get the value of the first column as a decimal and convert it to a string
            }
            else
            {
                perprice.Text = ""; // no rows returned, set the textbox to empty
            }

            int fasih = Convert.ToInt32(perprice.Text) * Convert.ToInt32(numericUpDown1.Value);

            total.Text = fasih.ToString();
            con.Close();

        }

        private void numericUpDown1_Validated(object sender, EventArgs e)
        {
            //int hello = Convert.ToInt32(comboBox1.SelectedValue);
            //con.Open();
            //OracleCommand getEmps = con.CreateCommand();
            //getEmps.CommandText = "SELECT per_unit_price FROM product WHERE product_id = :productId";
            //getEmps.Parameters.Add("productId", OracleDbType.Int32).Value = hello;
            //OracleDataReader empDR = getEmps.ExecuteReader();
            //if (empDR.Read())
            //{
            //    perprice.Text = empDR.GetDecimal(0).ToString(); // get the value of the first column as a decimal and convert it to a string
            //}
            //else
            //{
            //    perprice.Text = ""; // no rows returned, set the textbox to empty
            //}

            //int fasih = Convert.ToInt32(perprice.Text) * Convert.ToInt32(numericUpDown1.Value);

            //total.Text = fasih.ToString();
            //con.Close();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
   
        private void button7_Click(object sender, EventArgs e)
        {
            
            if (cid.Text==""|| comboBox1.SelectedIndex==-1||numericUpDown1.Value==0)
            {
                MessageBox.Show(" Invalid Selection!");
            }
            else if(numericUpDown1.Value>Convert.ToInt32(maxi.Text))
            {
                MessageBox.Show("Not enough quantity available!");

            }
            else
            {  //{
            //    DataTable dt = (DataTable)dataGridView1.DataSource;
            //    if (dataGridView1.RowCount > 0)
            //    {
            //        dt.Clear();
            //    }
                //      dataGridView1.Columns.Clear();
                //     dataGridView1.Rows.Clear();
                if (flag==false)
                {
                    //DataGridView dataGridView1 = new DataGridView();
                    dataGridView1.DataSource = null;
                

                    dataGridView1.Columns.Add("product_id", "Product ID");
                    dataGridView1.Columns.Add("ProductName", "Product Name");
                    dataGridView1.Columns.Add("quantity", "Quantity");
                    dataGridView1.Columns.Add("per_unit_price", "Per Unit Price");
                    dataGridView1.Columns.Add("total", "Total");

                    flag = true;
                }
                counter1++;
                dataGridView1.Rows.Add(hello, comboBox1.Text, numericUpDown1.Value, perprice.Text, total.Text);
                int he = Convert.ToInt32(textBox1.Text);
                he += Convert.ToInt32(total.Text);
                textBox1.Text = he.ToString();
                numericUpDown1.Value = 0;
                perprice.Clear();
                total.Clear();
                comboBox1.ResetText();
                maxi.Clear();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void recepit_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_Validating(object sender, CancelEventArgs e)
        {
            //int hello = Convert.ToInt32(comboBox1.SelectedValue);
            //con.Open();
            //OracleCommand getEmps = con.CreateCommand();
            //getEmps.CommandText = "SELECT per_unit_price FROM product WHERE product_id = :productId";
            //getEmps.Parameters.Add("productId", OracleDbType.Int32).Value = hello;
            //OracleDataReader empDR = getEmps.ExecuteReader();
            //if (empDR.Read())
            //{
            //    perprice.Text = empDR.GetDecimal(0).ToString(); // get the value of the first column as a decimal and convert it to a string
            //}
            //else
            //{
            //    perprice.Text = ""; // no rows returned, set the textbox to empty
            //}

            //int fasih = Convert.ToInt32(perprice.Text) * Convert.ToInt32(numericUpDown1.Value);

            //total.Text = fasih.ToString();
            //con.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            numericUpDown1.Value = 0;
            //con.Open();
            if (comboBox1.SelectedIndex != 0)
            {
                con.Open();
                int hello = Convert.ToInt32(comboBox1.SelectedValue);
                OracleCommand getEmps = con.CreateCommand();
                getEmps.CommandText = "SELECT quantity FROM product WHERE product_id = :productId";
                getEmps.Parameters.Add("productId", OracleDbType.Int32).Value = hello;
                OracleDataReader empDR = getEmps.ExecuteReader();
                if (empDR.Read())
                {
                    maxi.Text = empDR.GetDecimal(0).ToString(); // get the value of the first column as a decimal and convert it to a string
                }
                else
                {
                    perprice.Text = ""; // no rows returned, set the textbox to empty
                }

                //int fasih = Convert.ToInt32(perprice.Text) * Convert.ToInt32(numericUpDown1.Value);

                //total.Text = fasih.ToString();
                con.Close();
            }
        }
    }
}