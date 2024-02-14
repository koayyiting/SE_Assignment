using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    public class ConcreteAggregate : Aggregate
    {
        List<User_ParkingRecord> userParkingRecordList;

        public ConcreteAggregate(List<User_ParkingRecord> uprl)
        {
            userParkingRecordList = uprl;
        }
        public Iterator createIterator(List<User_ParkingRecord> userParkingRecordList)
        {
            return new ConcreteIterator(userParkingRecordList);
        }

        public Iterator createStaffIterator(List<User_ParkingRecord> userParkingRecordList)
        {
            return new StaffIterator(userParkingRecordList);
        }

        public Iterator createStudentIterator(List<User_ParkingRecord> userParkingRecordList)
        {
            return new StudentIterator(userParkingRecordList);
        }
    }
}
