using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    public interface Aggregate
    {
        Iterator createIterator(List<User_ParkingRecord> uprl);
    }
}
