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
        DateTime TimeKeyPressed;
        Single Turn, TurningCircle, Radius = 0;
        Single Velocity;
        public frmMain()
        {
            InitializeComponent();
            TimeKeyPressed = DateTime.UtcNow;
            TurningCircle = 0.05f;
            Velocity = 0;
            Radius = 65;
        }

        private void frmMain_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Up)
            {
                MoveUp = true;
                TimeKeyPressed = DateTime.Now;
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

            //Does not work at the moment
            if (Velocity > 0f)
            {
                Car.Location = new Point(Convert.ToInt32(Car.Location.X - Velocity * Math.Sin(Turn)), Convert.ToInt32(Car.Location.Y - Velocity * Math.Cos(Turn)));
                if (MoveLeft)
                {
                    TurningCircle = Velocity / Radius;
                    Turn += TurningCircle;
                }
                else if (MoveRight)
                {
                    TurningCircle = Velocity / Radius;
                    Turn -= TurningCircle;
                }

            }
            if (MoveUp && Velocity < 10f)
            {
                Velocity += 0.1f;
            }
            else if (MoveUp == false && Velocity > 0f)
            {
                Velocity -= 0.2f;
            }

        }

    }
}
