using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MeteoProg.Days;

namespace MeteoProg
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            DaysOfWeek c = new DaysOfWeek();
            
            c.Days();

            InitializeComponent();
        }
    }
}
