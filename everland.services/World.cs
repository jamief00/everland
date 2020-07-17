using Svg;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Net.WebSockets;
using System.Text;

namespace everland.services
{
    public class World
    {
        private List<WorldMember> Members { get; set; }
        //private List<Hex> Hexes { get; set; }

        private Hex[,] Hexes { get; set; }
        private int Columns { get; set; }
        private int Rows { get; set; }

        public World(int Columns, int Rows)
        {
            Members = new List<WorldMember>();
            Hexes = new Hex[Rows, Columns];
            this.Columns = Columns;
            this.Rows = Rows;

            for(var r=0; r<Rows; r++)
            {
                for(var q=0; q<Columns; q++)
                {
                    Hexes[r, q] = new Hex(q, r);
                    //Hexes.Add(new Hex(q, r));
                }
            }

        }

        public void Draw(int width, int height)
        {
            //var b = new Bitmap(width, height);

            var hexWidth = Math.Floor((double)(width / (Columns*2)));
            var hexHeight = Math.Floor((double)(height / (Rows+1)))*2;

            hexWidth = hexHeight = Math.Min(hexWidth, hexHeight);

            var svgDoc = new SvgDocument
            {
                Width = 1000,
                Height = 1000,
                ViewBox = new SvgViewBox(0, 0, 1000, 1000),
            };

            var group = new SvgGroup();
            svgDoc.Children.Add(group);

            for (var r=0; r<Hexes.GetLength(0); r++)
            {
                for (var q=0; q<Hexes.GetLength(1); q++)
                {
                    //var currentHex = Hexes[r, q];
                    int offsetRow = !(r % 2 == 0) ? 1 : 0;

                    var originX = (q * hexWidth * 1.5) + (hexWidth / 2) + (offsetRow * hexWidth*0.75);// ((q+1) * hexWidth)/2;
                    var originY = (r * hexHeight/2) + (hexHeight / 2); // ((r+1) * hexHeight)/2;

                    var ax = originX - (hexWidth / 4);
                    var ay = originY - (hexHeight / 2);

                    var bx = originX + (hexWidth / 4);
                    var by = originY - (hexHeight / 2);

                    var cx = originX + (hexWidth / 2);
                    var cy = originY;

                    var dx = originX + (hexWidth / 4);
                    var dy = originY + (hexHeight / 2);

                    var ex = originX - (hexWidth / 4);
                    var ey = originY  + (hexHeight / 2);

                    var fx = originX - (hexWidth / 2);
                    var fy = originY;

                    var p = new SvgPolygon();

                    p.Points = new SvgPointCollection();


                    p.Points.Add(new SvgUnit((float)ax));
                    p.Points.Add(new SvgUnit((float)ay));

                    p.Points.Add(new SvgUnit((float)bx));
                    p.Points.Add(new SvgUnit((float)by));

                    p.Points.Add(new SvgUnit((float)cx));
                    p.Points.Add(new SvgUnit((float)cy));

                    p.Points.Add(new SvgUnit((float)dx));
                    p.Points.Add(new SvgUnit((float)dy));

                    p.Points.Add(new SvgUnit((float)ex));
                    p.Points.Add(new SvgUnit((float)ey));

                    p.Points.Add(new SvgUnit((float)fx));
                    p.Points.Add(new SvgUnit((float)fy));

                    p.Stroke = new SvgColourServer(Color.Black);
                    p.Fill = new SvgColourServer(Color.White);

                    group.Children.Add(p);

                    //DrawLine(b, ax, ay, bx, by);
                    //DrawLine(b, bx, by, cx, cy);
                    //DrawLine(b, cx, cy, dx, dy);
                    //DrawLine(b, dx, dy, ex, ey);
                    //DrawLine(b, ex, ey, fx, fy);
                    //DrawLine(b, fx, fy, ax, ay);

                    //DrawText(b, ax, ay, q, r);


                }
            }

            //b.Save(@"c:\temp\output.jpg");
            svgDoc.Write(@"c:\temp\output.svg");

        }

        

        public void DrawLine(Bitmap b, int x1, int y1, int x2, int y2)
        {
            Pen blackPen = new Pen(Color.Black, 3);

            // Draw line to screen.
            using (var graphics = Graphics.FromImage(b))
            {
                graphics.DrawLine(blackPen, x1, y1, x2, y2);
            }
        }

        public void DrawText(Bitmap b, int x, int y, int q, int r)
        {
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            Font drawFont = new Font("Arial", 10);

            // Draw line to screen.
            using (var graphics = Graphics.FromImage(b))
            {
                graphics.DrawString($"{q},{r}", drawFont, drawBrush, x, y);
            }
        }


        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach(var h in Hexes)
            {
                sb.AppendLine($"Hex ({h.R}, {h.Q})");
            }

            return sb.ToString();
        }
    }
}