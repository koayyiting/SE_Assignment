using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    public interface Iterator
    {
        User_ParkingRecord next();
        bool hasNext();
    }
}
