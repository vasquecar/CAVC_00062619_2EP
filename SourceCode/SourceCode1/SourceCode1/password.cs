using System;
using System.Windows.Forms;

namespace SourceCode1
{
    public partial class password : Form
    {
        public password()
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
                    var idU = Conexion.ExecuteQuery($"SELECT idUser FROM APPUSER " +
                                                       $"WHERE username='{textBox2.Text}'");
                    var idUs = idU.Rows[0];
                    int idUser = Convert.ToInt32(idUs[0].ToString());
                    Conexion.ExecuteNonQuery($"UPDATE APPUSER SET password = '{textBox1.Text}' " +
                                                $"WHERE idUser='{idUser}'");
                    MessageBox.Show("Contraseña actualizada");
                    start win=new start();
                    win.Show();
                    this.Hide();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("ERROR");
            }
        }

        private void CambiarContraseña_FormClosing(object sender, FormClosingEventArgs e)
        {
            start win=new start();
            win.Show();
            this.Hide();
        }
    }
}
   