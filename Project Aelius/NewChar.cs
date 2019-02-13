using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Aelius
{
    public partial class NewChar : Form
    {
        public NewChar()
        {
            InitializeComponent();
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(nameBox.Text))
            {
                MessageBox.Show("Please Enter a Name");
                return;
            }
            if (String.IsNullOrWhiteSpace(classBox.Text))
            {
                MessageBox.Show("Please Select a Class");
                return;
            }
            PC pc = new PC();
            pc.Name = nameBox.Text;
            pc.Class = classBox.Text;
            pc.NewCharacter(pc);
        }
    }
}
