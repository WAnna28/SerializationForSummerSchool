using System;
using System.Collections.Generic;
using System.Text;

namespace SerializationForSummerSchool
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmployeeId { get; set; }
        public Address Address { get; set; }
        public Dictionary<string, int> Test { get; set; }
    }

    public class Address
    {
        public string ZipCode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}