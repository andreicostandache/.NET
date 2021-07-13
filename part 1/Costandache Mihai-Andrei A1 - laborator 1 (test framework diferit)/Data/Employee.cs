using System;

namespace Data
{
    public abstract class Employee
    {
        
        public Employee(String firstName, String lastName, DateTime startDate, DateTime endDate, double salary)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            StartDate = startDate;
            EndDate = endDate;
            Salary = salary;
        }

        public Guid Id {get; private set;}
        public string FirstName {get; private set;}
        public string LastName{get; private set;}
        public DateTime StartDate {get; private set;}
        public DateTime EndDate {get; private set;}
        public double Salary {get; private set;}

        public string GetFullName(){
            return FirstName+" "+LastName ;
        }
        
        public bool IsActive(){
            return (DateTime.Now<EndDate && DateTime.Now>=StartDate);
        }
    }
}
