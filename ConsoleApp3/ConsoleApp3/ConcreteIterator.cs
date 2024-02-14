using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp3
{
    public class ConcreteIterator : Iterator
    {
        List<User_ParkingRecord> userParkingRecordList;
        int position = -1;

        public ConcreteIterator(List<User_ParkingRecord> UserParkingRecordList)
        {
            userParkingRecordList = UserParkingRecordList;
        }
        public bool hasNext()
        {
            return position < userParkingRecordList.Count() - 1;
        }

        public User_ParkingRecord next()
        {
            ++position;
            return userParkingRecordList[position];
        }
    }
}
