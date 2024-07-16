using System.Data;

namespace project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            DBconnenctions dBconnections = new DBconnenctions();
            DataTable dt = dBconnections.Getdata();
            dataGridView1.DataSource = dt;
        }
    }
}
