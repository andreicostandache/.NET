using System;

namespace Data
{
    public class Manager : Employee
    {
        public string ManagedDepartment {get;private set;}
        public Manager (String firstName, String lastName, DateTime start, DateTime end, double salary,string managedDepartment ) : base(firstName, lastName, start, end, salary)
        {
            ManagedDepartment=managedDepartment;
        }
    }
}
