using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BetterPaths
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pathToTest = @"rester";
            MessageBox.Show($"pathToTest: {pathToTest} for 'IsWellFormedPath' is {BetterPath.IsWellFormedPath(pathToTest)}");
            pathToTest = @"r:ster";
            MessageBox.Show($"pathToTest: {pathToTest} for 'IsWellFormedPath' is {BetterPath.IsWellFormedPath(pathToTest)}");
            pathToTest = @"rr\ster";
            MessageBox.Show($"pathToTest: {pathToTest} for 'IsWellFormedPath' is {BetterPath.IsWellFormedPath(pathToTest)}");
            pathToTest = @"r:\ter";
            MessageBox.Show($"pathToTest: {pathToTest} for 'IsWellFormedPath' is {BetterPath.IsWellFormedPath(pathToTest)}");
        }
    }
}
