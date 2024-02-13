using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    public class ExitedState : SPState
    {
        public void Renew(SeasonParkingPass context)
        {
            throw new NotImplementedException();
        }

        public void Terminate(SeasonParkingPass context)
        {
            throw new NotImplementedException();
        }

        public void Transfer(SeasonParkingPass context, Vehicle v1, Vehicle v2)
        {
            throw new NotImplementedException();
        }
    }
}
