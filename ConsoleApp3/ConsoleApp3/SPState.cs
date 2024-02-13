using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    public interface SPState
    {
        void Terminate(SeasonParkingPass context);
        void Transfer(SeasonParkingPass context, Vehicle v1, Vehicle v2);
        void Renew(SeasonParkingPass context);
    }
}
