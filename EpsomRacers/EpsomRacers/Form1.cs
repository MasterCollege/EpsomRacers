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
        bool MoveUp, MoveLeft, MoveRight = false;
        Single Turn = 0;
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e) { 
        
            if (e.KeyCode == Keys.Up) {
                MoveUp = true;
            }

            if (e.KeyCode == Keys.Left)
            {
                MoveLeft = true;
            }

            if (e.KeyCode == Keys.Right)
            {
                MoveRight = true;
            }
        
        
        }

        private void frmMain_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                MoveUp = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                MoveLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                MoveRight = false;
            }
        

        }

        private void gametick_Tick(object sender, EventArgs e)
        {
            if (MoveUp && MoveLeft)
            {
                Car.Location = new Point(Convert.ToInt32(Car.Location.X - 5 * Math.Sin(Turn)), Convert.ToInt32(Car.Location.Y - 5 * Math.Cos(Turn)));
                Turn += 0.05f;
            }
            else if (MoveUp && MoveRight)
            {
                Car.Location = new Point(Convert.ToInt32(Car.Location.X - 5 * Math.Sin(Turn)), Convert.ToInt32(Car.Location.Y - 5 * Math.Cos(Turn)));
                Turn -= 0.05f;
            }
            else if (MoveUp)
            {
                Car.Location = new Point(Convert.ToInt32(Car.Location.X - 5 * Math.Sin(Turn)), Convert.ToInt32(Car.Location.Y - 5 * Math.Cos(Turn)));
            }

            
        }
    }
}
