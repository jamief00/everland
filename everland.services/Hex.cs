namespace everland.services
{
    public class Hex
    {

        // we will start with odd-r, which shoves odd rows to the right by 1
        public int Q { get; set; } //column
        public int R { get; set; } //row

        public int Radius { get; set; } // not a true radius but good approx to start


        public Hex(int Q, int R)
        {
            this.Q = Q;
            this.R = R;

            Radius = 5; //ToDo: dynamic
        }



    }


}