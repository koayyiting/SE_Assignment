using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    public class ExpiredState : SPState
    {
        // System retrieve for user’s season pass
        SeasonParkingPass pass;
        public ExpiredState(SeasonParkingPass p)
        {
            pass = p;
        }
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
