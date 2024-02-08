using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment
{
    public interface SPState
    {
        void Terminate(SeasonParkingPass context);
        void Transfer(SeasonParkingPass context, Vehicle v1, Vehicle v2);
        void Renew(SeasonParkingPass context);
    }
}
