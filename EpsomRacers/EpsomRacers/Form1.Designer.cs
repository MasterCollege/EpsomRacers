namespace EpsomRacers
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Car = new System.Windows.Forms.PictureBox();
            this.gametick = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Car)).BeginInit();
            this.SuspendLayout();
            // 
            // Car
            // 
            this.Car.BackColor = System.Drawing.Color.Red;
            this.Car.Location = new System.Drawing.Point(275, 248);
            this.Car.Name = "Car";
            this.Car.Size = new System.Drawing.Size(44, 67);
            this.Car.TabIndex = 0;
            this.Car.TabStop = false;
            // 
            // gametick
            // 
            this.gametick.Enabled = true;
            this.gametick.Interval = 1;
            this.gametick.Tick += new System.EventHandler(this.gametick_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 369);
            this.Controls.Add(this.Car);
            this.KeyPreview = true;
            this.Name = "frmMain";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.Car)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Car;
        private System.Windows.Forms.Timer gametick;

    }
}

