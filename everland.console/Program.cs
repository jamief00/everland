using everland.services;
using Svg;
using System;
using System.Diagnostics;
using System.Drawing;

namespace everland.console
{
    class Program
    {
        static void Main(string[] args)
        {
            var g = new World(10, 20);

            g.Draw(1000,1000);


            
        }
    }
}
