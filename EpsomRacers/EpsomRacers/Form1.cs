using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EpsomRacers
{
    public partial class frmMain : Form
    {
        bool MoveUp, MoveLeft, MoveRight, MoveDown = false;
        List<Car> Racers;
       
       
        private void frmMain_Load(object sender, EventArgs e)
        {
            //Interface setup
            //this.TopMost = true; (Do we want people tabbing out?)
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            Racers = new List<Car>();
        }

        public frmMain()
        {
            InitializeComponent();
            
        }

        private void frmMain_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W ) {
                MoveUp = true;
            }

            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                MoveLeft = true;
            }

            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                MoveRight = true;
            }

            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                MoveDown = true;
            }

            if (e.KeyCode == Keys.Escape)
            {
                System.Windows.Forms.Application.Exit();
            }
            
            
        }

        private void frmMain_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
            {
                MoveUp = false;
            }
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                MoveLeft = false;
            }
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                MoveRight = false;
            }
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                MoveDown = false;
            }
            

        }



        private void gametick_Tick(object sender, EventArgs e)
        {
            foreach (Car Racer in Racers)
            {
                Racer.UpdatePosition(MoveLeft, MoveRight, MoveUp, MoveDown);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Racer = new Car(this);
            Racers.Add(Racer);
        }
     

    }
}
