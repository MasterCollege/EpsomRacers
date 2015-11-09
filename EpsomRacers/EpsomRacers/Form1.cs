﻿using System;
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
        const Single MaxVel = 20f;
        const Single MinVel = -10f;
        DateTime TimeKeyPressed;
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
            TimeKeyPressed = DateTime.UtcNow;
            TurningCircle = 0.05f;
            Velocity = 0;
            Radius = 65;
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

            if (Velocity != 0f)
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
            if (MoveUp && Velocity < MaxVel)
            {
                Velocity += Acceleration;
            }
            else if (MoveUp == false && Velocity > 0f)
            {
                if (MoveDown)
                {
                    Velocity -= 0.5f;
                }
                else
                {
                    Velocity -= Deceleration;
                }
            }
            if (MoveDown && Velocity > MinVel)
            {
                Velocity -= Acceleration ;
            }
            else if (MoveDown == false && Velocity < 0f)
            {
                if (MoveUp)
                {
                    Velocity += 0.5f;
                }
                else
                {
                    Velocity += Deceleration;
                }
            }

        }

    }
}
