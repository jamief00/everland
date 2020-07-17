using System;
using System.Collections.Generic;
using System.Text;

namespace everland.services
{
    public class Game
    {
        public Guid Id { get; set; }

        public Game()
        {
            Id = Guid.NewGuid();
            

        }




    }
}
