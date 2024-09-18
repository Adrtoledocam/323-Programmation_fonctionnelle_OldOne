using System.Reflection.PortableExecutable;
using Gpx;

namespace Rando
{
    public partial class Rando : Form
    {

        private List<GpxTrackPoint> trackPoints;


        private const double LAT_OFFSET = 46.39;
        private const double LONG_OFFSET = 7.61;


        public Rando()
        {
            InitializeComponent();
            using (GpxReader reader = new GpxReader(File.Open("gemmikandersteg.gpx", FileMode.Open)))
            {
                while (reader.Read())
                {
                    switch (reader.ObjectType)
                    {
                        case GpxObjectType.Metadata:
                            Console.WriteLine(reader.Metadata);
                            break;
                        case GpxObjectType.WayPoint:
                            Console.WriteLine(reader.WayPoint);
                            break;
                        case GpxObjectType.Route:
                            Console.WriteLine(reader.Route);
                            break;
                        case GpxObjectType.Track:
                            Console.WriteLine(reader.Track);
                            trackPoints = reader.Track.Segments[0].TrackPoints.ToList();
                            break;
                    }
                }
            }
        }

        private void Rando_Form_Paint(object sender, PaintEventArgs e)
        {
            Pen myPen = new Pen(Color.Red);
            myPen.Width = 2;

            Point[] points = new Point[4] { new Point(30, 50), new Point(50, 10), new Point(80, 50), new Point(111, 400) };
            this.CreateGraphics().DrawLines(myPen, points);
        }

        private void Rando_Load(object sender, EventArgs e)
        {

        }
    }
}
