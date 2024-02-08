using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
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
