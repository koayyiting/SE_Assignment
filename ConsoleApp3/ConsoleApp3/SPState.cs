using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    public interface SPState
    {
        void Terminate(SeasonParkingPass context);
        void Transfer(SeasonParkingPass context);
        void Renew(SeasonParkingPass context);
    }
}
