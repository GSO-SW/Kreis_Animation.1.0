using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kreis_Animation._1._0
{
    public partial class Form1 : Form
    {
        Graphics graphics;
        Timer timer;

        float Verschiebung;

        #region Grafik Elemente
        Pen KreisStift;
        Brush rectangleBrush;

        Rectangle Kreis;
        Rectangle Dreieck;
        #endregion
        public Form1()
        {
            InitializeComponent();

            #region Timer
            DoubleBuffered = true;

            timer = new Timer
            {
                Enabled = true,
                Interval = 10
            };
            timer.Tick += Time_Ticker;

            this.timer.Start();
            #endregion

            Verschiebung = 0.0f;

            #region Grafik Elemente
            speedLabel.Text = (speedTrackBar.Value).ToString();
            radiusLabel.Text = (radiusTrackBar.Value).ToString();
            sizeLabel.Text = (sizeTrackBar.Value).ToString();

            KreisStift = new Pen(Color.DarkGray, 3);
            rectangleBrush = new SolidBrush(Color.Black);

            Kreis = new Rectangle(new Point(this.ClientSize.Width / 2 - 100, this.ClientSize.Height / 2 - 100), new Size(200, 200));
            Dreieck = new Rectangle(new Point(this.ClientSize.Width / 2 - 10, this.ClientSize.Height / 2 - 110), new Size(20, 20));
            #endregion
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            graphics = e.Graphics;

            graphics.DrawEllipse(KreisStift, Kreis);
            graphics.FillEllipse(rectangleBrush, Dreieck);
        }

        private void Time_Ticker(object sender, EventArgs e)
        {
            Verschiebung += (float)speedTrackBar.Value / 100;

            Kreis = new Rectangle(new Point(this.ClientSize.Width / 2 - (radiusTrackBar.Value * 50), this.ClientSize.Height / 2 - (radiusTrackBar.Value * 50)), new Size(radiusTrackBar.Value * 100, radiusTrackBar.Value * 100));
            Dreieck = new Rectangle(new Point(Convert.ToInt32((this.ClientSize.Width / 2 - (radiusTrackBar.Value * 100) - (sizeTrackBar.Value * 10)) + (Math.Sin(Verschiebung) * (radiusTrackBar.Value * 50) + (radiusTrackBar.Value * 100) + sizeTrackBar.Value * 5)), Convert.ToInt32(this.ClientSize.Height / 2 - sizeTrackBar.Value * 5 - Math.Cos(Verschiebung) * (radiusTrackBar.Value * 50))), new Size(sizeTrackBar.Value * 10, sizeTrackBar.Value * 10));

            Invalidate();
        }

        private void Geschwindigkeits_Trackbar(object sender, EventArgs e)
        {
            speedLabel.Text = (speedTrackBar.Value).ToString();
        }

        private void RadiusTrackbar(object sender, EventArgs e)
        {
            radiusLabel.Text = (radiusTrackBar.Value).ToString();
        }

        private void Größen_Trackbar(object sender, EventArgs e)
        {
            sizeLabel.Text = (sizeTrackBar.Value).ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
