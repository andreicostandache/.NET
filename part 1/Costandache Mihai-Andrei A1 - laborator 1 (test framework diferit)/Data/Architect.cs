using System;

namespace Data
{
    public class Architect : Employee
    {
        public string Style {get;private set;}
        public Architect (String firstName, String lastName, DateTime start, DateTime end, double salary,string style) : base(firstName, lastName, start, end, salary)
        {
            Style=style;
        }
    }
}
