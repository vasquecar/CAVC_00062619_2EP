using System;
using System.Windows.Forms;

namespace SourceCode1
{
    public partial class start : Form
    {
        public start()
        {
            InitializeComponent();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Equals("") ||
                    textBox2.Text.Equals(""))
                {
                    MessageBox.Show("Llene correctamente los datos");
                }
                else
                {
                    String User = textBox2.Text;
                    
                    var pass = Conexion.ExecuteQuery($"SELECT password FROM APPUSER " +
                                                        $"WHERE username = '{textBox2.Text}'");
                    var passw = pass.Rows[0];
                    String passWord = passw[0].ToString();

                    if (textBox1.Text.Equals(passWord))
                    {
                        var ad = Conexion.ExecuteQuery($"SELECT userType FROM APPUSER " +
                                                          $"WHERE username = '{textBox2.Text}'");
                        var adm = ad.Rows[0];
                        bool admin = Convert.ToBoolean(adm[0].ToString());
                         
                        MessageBox.Show("Bienvenido a HUGO ");
                        Form1 win= new Form1(User,admin);
                        win.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Contraseña incorrecta!");
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("ERROR");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            password win = new password();
            win.Show();
            this.Hide();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}