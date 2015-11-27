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

        //Put these all as one line if you want but i prefer them on their own lines
        const Single Acceleration = 0.1f;
        const Single Deceleration = 0.25f; //Used for natural deceleration without break (Assuming we will have a break)
        const Single Brake = 0.5f;
        const Single MaxVel = 15f;
        const Single MinVel = -10f;
        Single Turn, TurningCircle, Radius = 0;

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
            //Should radius be a constant or a variable that changes when, for example, drifting?
            TurningCircle = 0.05f;
            Velocity = 0;
            Radius = 100;
            Car.Image = new Bitmap(Car.Width, Car.Height);
            
            
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
            //Update location as long as the vehicle is moving
            if (Math.Abs(Velocity) >= 0.05f)
            {
                                
                Car.Location = new Point(Convert.ToInt32(Car.Location.X - Velocity * Math.Sin(Turn)), Convert.ToInt32(Car.Location.Y - Velocity * Math.Cos(Turn)));
           
                if (MoveLeft)
                {
                    TurningCircle = Velocity / Radius;
                    Turn += TurningCircle;
                    Car.Image = new Bitmap(Car.Width, Car.Height);
                    using (Graphics g = Graphics.FromImage(Car.Image))
                    {
                        g.Clear(this.BackColor);
                        g.TranslateTransform(Car.Width / 2, Car.Height / 2);
                        float x = (-1 * Turn) * (360 / (2 * (float)Math.PI));
                        g.RotateTransform(x);
                        g.TranslateTransform(-Car.Width / 2, -Car.Height / 2);
                        //g.FillRectangle(Brushes.Red, 0, 0, Car.Width, Car.Height);
                        g.DrawImage(Image.FromFile(@"R8.png"), Car.Height/4, 0, Car.Height / 2, Car.Height);
                    }
                    
                }
                else if (MoveRight)
                {
                    TurningCircle = Velocity / Radius;
                    Turn -= TurningCircle;
                    Car.Image = new Bitmap(Car.Width, Car.Height);
                    using (Graphics g = Graphics.FromImage(Car.Image))
                    {
                        g.Clear(this.BackColor);
                        g.TranslateTransform(Car.Width / 2, Car.Height / 2);
                        float x = (-1 * Turn) * (360 / ( 2 * (float)Math.PI));
                        g.RotateTransform(x);
                        g.TranslateTransform(-Car.Width / 2, -Car.Height / 2);
                        //g.FillRectangle(Brushes.Red, 0, 0, Car.Width, Car.Height);
                        g.DrawImage(Image.FromFile(@"R8.png"), Car.Height/4, 0, Car.Height / 2, Car.Height);
                    }
                }
                
                if (Math.Abs(Turn) >= (2 * Math.PI))
                {
                    Turn = 0;
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
