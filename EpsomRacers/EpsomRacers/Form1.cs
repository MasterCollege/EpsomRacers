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
        bool MoveUp, MoveLeft, MoveRight, MoveDown, Drifting = false;

        //Put these all as one line if you want but i prefer them on their own lines
        const Single Acceleration = 0.1f;
        const Single Deceleration = 0.25f; //Used for natural deceleration without break (Assuming we will have a break)
        const Single Brake = 0.5f;
        const Single MaxVel = 20f;
        const Single MinVel = -10f;
        DateTime TimeKeyPressed;
        Single Turn, TurningCircle, Radius, TempTurn = 0;

        private void frmMain_Load(object sender, EventArgs e)
        {
            //Interface setup
            //this.TopMost = true; (Do we want people tabbing out?)
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        Single Velocity;
        public frmMain()
        {
            InitializeComponent();
            //Not sure what TimeKeyPressed is for...
            TimeKeyPressed = DateTime.UtcNow;
            
            //Should radius be a constant or a variable that changes when, for example, drifting?
            TurningCircle = 0.05f;
            Velocity = 0;
            Radius = 100;
        }


        private void frmMain_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W ) {
                MoveUp = true;
                TimeKeyPressed = DateTime.Now;
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

            if (e.KeyCode == Keys.Space)
            {
                Drifting = true;
                this.BackColor = Color.Cyan;
                
                //Part of drifting solution Two
                //TempTurn = Turn;
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
            if (e.KeyCode == Keys.Space)
            {
                Drifting = false;
                this.BackColor = Color.White;
            }
            

        }

        private void gametick_Tick(object sender, EventArgs e)
        {

            //Two possible drifting mechanics (back colour changes for indication)
            //1. Sharper turn
            //2. Prevent car from turning temporarily while the space key is held down
            //   Variable 'Turn' will still update but won't have any effect until the 
            //   space key is released. (See Key_Down)




            //Solution One

            //if (Drifting)
            //{
            //    Radius = 65;
            //}
            //else
            //{
            //    Radius = 100;
            //}

            //Update location as long as the vehicle is moving
            if (Velocity != 0f)
            {

                //Solution Two

                //if (Drifting)
                //{
                //    Car.Location = new Point(Convert.ToInt32(Car.Location.X - Velocity * Math.Sin(TempTurn)), Convert.ToInt32(Car.Location.Y - Velocity * Math.Cos(TempTurn)));

                //}
                //else
                //{
                //    Car.Location = new Point(Convert.ToInt32(Car.Location.X - Velocity * Math.Sin(Turn)), Convert.ToInt32(Car.Location.Y - Velocity * Math.Cos(Turn)));
                //}
                
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
            //Forward acceleration
            if (MoveUp && Velocity < MaxVel)
            {
                Velocity += Acceleration;
            }
            else if (MoveUp == false && Velocity > 0f)
            {
                //If brakes are applied (Opposite direction key)
                if (MoveDown)
                {
                    Velocity -= Brake;
                }
                //Or else natural deceleration
                else
                {
                    Velocity -= Deceleration;
                }
            }
            //Backward acceleration
            if (MoveDown && Velocity > MinVel)
            {
                Velocity -= Acceleration ;
            }
            else if (MoveDown == false && Velocity < 0f)
            {
                //If brakes are applied (Opposite direction key)
                if (MoveUp)
                {
                    Velocity += Brake;
                }
                //Or else natural deceleration
                else
                {
                    Velocity += Deceleration;
                }
            }

        }

    }
}
