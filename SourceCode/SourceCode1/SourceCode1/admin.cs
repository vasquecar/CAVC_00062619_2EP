using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace SourceCode1
{
    public partial class admin : UserControl
    {
        public admin()
        {
            InitializeComponent();
        }
         private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBox3.Text.Equals("")||
                   textBox1.Text.Equals(""))
                {
                    MessageBox.Show("Llene correctamente los datos!");
                }
                else
                {
                    string User = textBox3.Text;
                    var users = Conexion.ExecuteQuery("SELECT username FROM APPUSER");
                    bool equal = false;

                    foreach (DataRow row in users.Rows)
                    {
                        if (User.Equals(row[0].ToString()))
                            equal = true;
                    }

                    if (equal == false)
                    {
                        if (radioButton1.Checked)
                        {
                            Conexion.ExecuteNonQuery($"INSERT INTO APPUSER(fullname, username, password, userType)" +
                                                        $" VALUES('{textBox1.Text}','{textBox3.Text}','{textBox3.Text}',true)");
                            MessageBox.Show("Usuario agregado");
                        }
                        else
                        {
                            Conexion.ExecuteNonQuery($"INSERT INTO APPUSER(fullname, username, password, userType)" +
                                                        $" VALUES('{textBox1.Text}','{textBox3.Text}','{textBox3.Text}',false)");
                            MessageBox.Show("Usuario agregado");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Dato existente, vuelva a intentarlo");
                    }
                    Administrador_Load(sender, e);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("ERROR");
            }
        }

        private void Administrador_Load(object sender, EventArgs e)
        {
            try
            {
                var user = Conexion.ExecuteQuery("SELECT username FROM APPUSER");
                var negocio = Conexion.ExecuteQuery("SELECT name FROM BUSINESS");
                var producto = Conexion.ExecuteQuery("SELECT name FROM PRODUCT");
                var dt = Conexion.ExecuteQuery("SELECT * FROM APPUSER");
                var dt2 = Conexion.ExecuteQuery("SELECT * FROM APPORDER");
                var userCombo = new List<string>();
                var negocioCombo = new List<string>();
                var productoCombo = new List<string>();

                foreach (DataRow row in user.Rows)
                {
                    userCombo.Add(row[0].ToString());
                }
            
                foreach (DataRow row in negocio.Rows)
                {
                    negocioCombo.Add(row[0].ToString());
                }
            
                foreach (DataRow row in producto.Rows)
                {
                    productoCombo.Add(row[0].ToString());
                }
                
                comboBox1.DataSource = userCombo;
                comboBox2.DataSource = negocioCombo;
                comboBox3.DataSource = negocioCombo;
                comboBox4.DataSource = negocioCombo;
                dataGridView1.DataSource = dt;
                dataGridView2.DataSource = dt2;
            }
            catch (Exception exception)
            {
                MessageBox.Show("ERROR");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var idU = Conexion.ExecuteQuery($"SELECT idUser FROM APPUSER " +
                                                   $"WHERE username='{comboBox1.SelectedItem}'");
                var idUs = idU.Rows[0];
                int idUser = Convert.ToInt32(idUs[0].ToString());
                Conexion.ExecuteNonQuery($"DELETE FROM APPUSER WHERE idUser='{idUser}'");
                
                //Actualizando datos
                Administrador_Load(sender,e);
                MessageBox.Show("Usuario eliminado!");
                
            }
            catch (Exception exception)
            {
                MessageBox.Show("ERROR");
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox4.Text.Equals("")||
                    textBox5.Text.Equals(""))
                {
                    MessageBox.Show("Llene correctamente los datos");
                }
                else{
                    Conexion.ExecuteNonQuery($"INSERT INTO BUSINESS(name,description) " +
                                            $"VALUES('{textBox5.Text}','{textBox4.Text}')");
                    MessageBox.Show("Agregado!");
                    Administrador_Load(sender,e);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Llene correctamente los datos");
            }
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                var idB = Conexion.ExecuteQuery($"SELECT idBusiness FROM BUSINESS " +
                                                   $"WHERE name='{comboBox2.SelectedItem}'");
                var idBus = idB.Rows[0];
                int idBusiness = Convert.ToInt32(idBus[0].ToString());
                Conexion.ExecuteNonQuery($"DELETE FROM BUSINESS WHERE idBusiness='{idBusiness}'");
                MessageBox.Show("Eliminado!");
                Administrador_Load(sender,e);
            }
            catch (Exception exception)
            {
                MessageBox.Show("ERROR");
            }
        }
        
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox6.Text.Equals(""))
                {
                    MessageBox.Show("Llene correctamente los datos");
                }
                else
                {
                    var idB = Conexion.ExecuteQuery($"SELECT idBusiness FROM BUSINESS " +
                                                   $"WHERE name='{comboBox3.SelectedItem}'");
                    var idBus = idB.Rows[0];
                    int idBusiness = Convert.ToInt32(idBus[0].ToString());
                    Conexion.ExecuteNonQuery($"INSERT INTO PRODUCT(idBusiness, name) " +
                                            $"VALUES({idBusiness},'{textBox6.Text}')");
                    MessageBox.Show("Producto Agregado");
                   Administrador_Load(sender,e);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Llene correctamente los datos");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                var idP = Conexion.ExecuteQuery($"SELECT idProduct FROM PRODUCT " +
                                                   $"WHERE name='{comboBox5.SelectedItem}'");
                var idPr = idP.Rows[0];
                int idProduct = Convert.ToInt32(idPr[0].ToString());    
                Conexion.ExecuteNonQuery($"DELETE FROM PRODUCT WHERE idProduct='{idProduct}'");
                MessageBox.Show("Producto Eliminado!");
                 Administrador_Load(sender,e);
            }
            catch (Exception exception)
            {
                MessageBox.Show("ERROR");
            }
        }

        private void comboBox4_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var producto = Conexion.ExecuteQuery("SELECT name FROM PRODUCT");
            var productoCombo = new List<string>();
            foreach (DataRow row in producto.Rows)
            {
                productoCombo.Add(row[0].ToString());
            }
            comboBox5.DataSource=null;
            comboBox5.Items.Clear();
            comboBox5.DataSource = productoCombo;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text=textBox3.Text;
        }
    }
}
