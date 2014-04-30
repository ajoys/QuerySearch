using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;

namespace QuerySearch
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void submit_Click(object sender, EventArgs e)
        {
            //Getting the date picked from calender
            string date = datepick.SelectionRange.Start.ToString().Substring(0,10);
            //Lane
            string lane = dropBox.Text.ToString();
            //Rearanging the date to match the SQL database
            string day = date.Substring(0, 2);
            string month = date.Substring(3, 2);
            string year = date.Substring(6, 4);
            if (int.Parse(day) < 10)
            {
                day = day.Replace("0", "");
            }
            if (int.Parse(month) < 10)
            {
                month = month.Replace("0", "");
            }
            date = month + "/" + day + "/" + year;

            //If the user wants to see all the parts scanned from that day. 
            if (lane == "All")
            {
                //opening connection
                string MyConnectionString = "Data Source=OSH4DPC005\\SQLEXPRESS;Initial Catalog=DMZ;Integrated Security=SSPI; User ID=user1; Password = dmzdatabase;";
                SqlConnection connection = new SqlConnection(MyConnectionString);

                //Adding a % sign to the date so the query will return any part that has this date in its lane number
                date = date + "%";

                try
                {
                    //opening conenction and setting up the query
                    connection.Open();

                    //RAW DATA
                    if (Raw.Checked == true)
                    {
                        SqlCommand cmd = new SqlCommand("SELECT * FROM Parts WHERE Truck_Number LIKE @trucknumber", connection);
                        cmd.Parameters.AddWithValue("@trucknumber", date);

                        SqlDataReader dr;

                        dr = cmd.ExecuteReader();
                        int i = 0;
                        //Creating name for the file
                        string truckinfo = date.Replace("/", "-").Replace("%", "");

                        //Writing all the data from the truck into a file
                        date = date.Replace("%", "");
                        using (StreamWriter sw = new StreamWriter("S:\\Share\\DMZ\\Reports\\"+truckinfo + "_fullday_raw.txt"))
                        {
                            //Header
                            sw.WriteLine("   {0, 10}{1,10}{2,10}    {3,-23}{4,-10}", "Part Number", "Total", "Packs", "Serial Number", "Type");
                            while (dr.Read())
                            {
                                //Creating Numbers along the side
                                i++;
                                if (i >= 10)
                                {
                                    sw.Write("{0,1}.", i);
                                }
                                else
                                {
                                    sw.Write("{0,1}. ", i);
                                }

                                // Counts to 4, each piece of data in the database
                                for (int j = 0; j <= 4; j++)
                                {
                                    if (j == 3)
                                    {
                                        sw.Write("    {0, -23}", dr.GetString(4));
                                    }
                                    else if (j == 1 || j == 2)
                                    {
                                        sw.Write("{0, 10}", dr.GetInt32(j));
                                    }
                                    else if (j == 4)
                                    {
                                        sw.Write("{0,-10}", dr.GetString(6));
                                    }
                                    else
                                    {
                                        sw.Write("{0, 10}", dr.GetString(j));
                                    }

                                }
                                sw.WriteLine();

                            }
                        }
                        connection.Close();
                        MessageBox.Show("Report Created!");
                    }

                    //TALLY DATA
                    else if (Tally.Checked == true)
                    {
                        //Query
                        SqlCommand cmd = new SqlCommand("SELECT Part_Number, SUM(Total), SUM(Number_of_Packs) FROM Parts WHERE Truck_Number LIKE @TruckNumber GROUP BY Part_Number", connection);
                        cmd.Parameters.AddWithValue("@TruckNumber", date);

                        SqlDataReader dr;

                        dr = cmd.ExecuteReader();
                        int i = 0;
                        //Creating FIle Name
                        string truckinfo = date.Replace("/", "-").Replace("%", "");

                        //Writing all the data from the truck into a file
                        date = date.Replace("%", "");
                        using (StreamWriter sw = new StreamWriter("S:\\Share\\DMZ\\Reports\\" + truckinfo + "_fullday_tally.txt"))
                        {
                            sw.WriteLine("   {0, 10}{1,10}{2,10}", "Part Number", "Total", "Packs");
                            sw.WriteLine("---------------------------------");
                            sw.WriteLine();
                            while (dr.Read())
                            {
                                i++;
                                if (i >= 10)
                                {
                                    sw.Write("{0,1}.", i);
                                }
                                else
                                {
                                    sw.Write("{0,1}. ", i);
                                }

                                // Counts to 2, 0 for Part Number, 1 for total, 2 for number of packs
                                for (int j = 0; j <= 2; j++)
                                {
                                    if (j == 1 || j == 2)
                                    {
                                        sw.Write("{0, 10}", dr.GetInt32(j));
                                    }
                                    else
                                    {
                                        sw.Write("{0, 10}", dr.GetString(j));
                                    }

                                }
                                sw.WriteLine();
                                sw.WriteLine("---------------------------------");

                            }
                        }
                        connection.Close();
                        MessageBox.Show("Report Created!");
                    }
                  
                }
                catch (Exception p)
                {
                    Console.WriteLine(p);
                }
            }
            else if (lane == "") 
            {
                MessageBox.Show("Please Select a Lane");
            }
            else 
            {
                //opening connection - This is where the info needed to open the database 
                string MyConnectionString = "Data Source=OSH4DPC005\\SQLEXPRESS;Initial Catalog=DMZ;Integrated Security=SSPI; User ID=user1; Password = dmzdatabase;";
                SqlConnection connection = new SqlConnection(MyConnectionString);

                try
                {
                    string truckNumber = date + " -" + lane;
                    //opening conenction and setting up the query
                    connection.Open();

                    //RAW DATA
                    if (Raw.Checked == true)
                    {
                        SqlCommand cmd = new SqlCommand("SELECT * FROM Parts WHERE Truck_Number LIKE @trucknumber ORDER BY Part_Number", connection);
                        cmd.Parameters.AddWithValue("@trucknumber", truckNumber);
                        SqlCommand op = new SqlCommand("SELECT Operator FROM Parts WHERE Truck_Number LIKE @TruckNumber", connection);
                        op.Parameters.AddWithValue("@trucknumber", truckNumber);

                        SqlDataReader dr;
                        SqlDataReader newdr;

                        newdr = op.ExecuteReader();
                        newdr.Read();
                        string name = newdr.GetString(0);
                        newdr.Close();
                        dr = cmd.ExecuteReader();

                        int i = 0;
                        string truckinfo = truckNumber.Replace("/", "-").Replace("%", "");

                        //Writing all the data from the truck into a file
                        using (StreamWriter sw = new StreamWriter("S:\\Share\\DMZ\\Reports\\" + truckinfo + "_raw.txt"))
                        {
                            sw.WriteLine("   {0, 10}{1,10}{2,10}    {3,-23}{4,-10}", "Part Number", "Total", "Packs", "Serial Number", "Type");
                            sw.WriteLine("   Operator: {0}", name);
                            while (dr.Read())
                            {
                                i++;
                                if (i >= 10)
                                {
                                    sw.Write("{0,1}.", i);
                                }
                                else
                                {
                                    sw.Write("{0,1}. ", i);
                                }

                                // Counts to 4, each piece of data in the database
                                for (int j = 0; j <= 4; j++)
                                {
                                    if (j == 3)
                                    {
                                        sw.Write("    {0, -23}", dr.GetString(4));
                                    }
                                    else if (j == 1 || j == 2)
                                    {
                                        sw.Write("{0, 10}", dr.GetInt32(j));
                                    }
                                    else if (j == 4)
                                    {
                                        sw.Write("    {0,-10}", dr.GetString(6));
                                    }
                                    else
                                    {
                                        sw.Write("{0, 10}", dr.GetString(j));
                                    }

                                }
                                sw.WriteLine();

                            }
                        }
                        connection.Close();
                        MessageBox.Show("Report Created!");
                    }

                    //TALLY DATA
                    else if (Tally.Checked == true)
                    {
                        //Query
                        SqlCommand cmd = new SqlCommand("SELECT Part_Number, SUM(Total), SUM(Number_of_Packs) FROM Parts WHERE Truck_Number LIKE @TruckNumber GROUP BY Part_Number", connection);
                        cmd.Parameters.AddWithValue("@TruckNumber", truckNumber);
                        SqlCommand op = new SqlCommand("SELECT Operator FROM Parts WHERE Truck_Number LIKE @TruckNumber", connection);
                        op.Parameters.AddWithValue("@trucknumber", truckNumber);

                        SqlDataReader dr;
                        SqlDataReader newdr;

                        newdr = op.ExecuteReader();
                        newdr.Read();
                        string name = newdr.GetString(0);
                        newdr.Close();

                        dr = cmd.ExecuteReader();
                        int i = 0;
                        //Creating FIle Name
                        string truckinfo = truckNumber.Replace("/", "-").Replace("%", "");

                        //Writing all the data from the truck into a file
                        date = date.Replace("%", "");
                        using (StreamWriter sw = new StreamWriter("S:\\Share\\DMZ\\Reports\\" + truckinfo + "_tally.txt"))
                        {
                            sw.WriteLine("   {0, 10}{1,10}{2,10}          Operator:{3}", "Part Number", "Total", "Packs", name);
                            sw.WriteLine("---------------------------------");
                            sw.WriteLine();
                            while (dr.Read())
                            {
                                i++;
                                if (i >= 10)
                                {
                                    sw.Write("{0,1}.", i);
                                }
                                else
                                {
                                    sw.Write("{0,1}. ", i);
                                }

                                // Counts to 2, 0 for Part Number, 1 for total, 2 for number of packs
                                for (int j = 0; j <= 2; j++)
                                {
                                    if (j == 1 || j == 2)
                                    {
                                        sw.Write("{0, 10}", dr.GetInt32(j));
                                    }
                                    else
                                    {
                                        sw.Write("{0, 10}", dr.GetString(j));
                                    }

                                }
                                sw.WriteLine();
                                sw.WriteLine("---------------------------------");

                            }
                        }
                        connection.Close();
                        MessageBox.Show("Report Created!");
                    }
                    
                }
                
                catch (Exception p)
                {
                    MessageBox.Show(p.ToString());
                }
           } 
        }   

    }
}
