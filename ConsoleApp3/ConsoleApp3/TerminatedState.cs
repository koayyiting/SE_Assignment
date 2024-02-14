using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    public class TerminatedState : SPState
    {
        // System retrieve for user’s season pass
        SeasonParkingPass pass;
        public TerminatedState(SeasonParkingPass p)
        {
            pass = p;
        }
        public void Renew(SeasonParkingPass context)
        {
            Console.WriteLine("Your pass has already been terminated.");
        }

        public void Terminate(SeasonParkingPass context)
        {
            Console.WriteLine("The Season Pass is already in terminated state.");
        }

        public void Transfer(SeasonParkingPass context)
        {
            throw new NotImplementedException();
        }
    }
}
