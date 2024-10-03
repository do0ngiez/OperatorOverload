using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverload
{

    // Employee class definition
    class Employee
    {
        public int Id { get; set; }
        public string fName { get; set; }
        public string lName { get; set; }

        public static bool operator ==(Employee emp1, Employee emp2)
        {
            if (ReferenceEquals(emp1, emp2))
            {
                return true;
            }

            if (emp1 is null || emp2 is null)
            {
                return false;
            }

            return emp1.Id == emp2.Id;
        }

        public static bool operator !=(Employee emp1, Employee emp2)
        {
            return !(emp1 == emp2);
        }

        public override bool Equals(object obj)
        {
            //if the passed object is not an Employee, return false
            if (obj == null || !(obj is Employee))
            {
                return false;
            }

            //compare the id properties
            Employee emp = (Employee)obj;
            return Id == emp.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Employee employee1 = new Employee() { Id = 1, fName = "Yujin", lName = "Ahn" };

            Employee employee2 = new Employee() { Id = 2, fName = "Minju", lName = "Kim" };

            //compare ==
            if (employee1 == employee2)
            {
                Console.WriteLine("The two employees are equal.");
            }
            else
            {
                Console.WriteLine("The two employees are not equal.");
            }

            //compare !=
            if (employee1 != employee2)
            {
                Console.WriteLine("The two employees are different.");
            }
            else
            {
                Console.WriteLine("The two employees are the same.");
            }

            Console.ReadLine();
        }
    }
}
