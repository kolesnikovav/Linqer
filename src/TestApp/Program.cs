using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Linqer;

namespace TestApp
{
    public class Student
    {
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public int Age {get;set;}
        public override string ToString()
        {
            return String.Format("{0}  {1}", FirstName, LastName);
        }
    }
    public class Employer
    {
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public int Age {get;set;}
        public override string ToString()
        {
            return String.Format("{0}  {1}", FirstName, LastName);
        }        
    }    
    class Program
    {
        static List<Student> students = new List<Student>();
        static List<Employer> employers = new List<Employer>();
        internal static void FillData()
        {
            students.Add(new Student { FirstName = "Tom", LastName = "Hanks"});
            students.Add(new Student { FirstName = "Brad", LastName = "Peet"});
            students.Add(new Student { FirstName = "Frank", LastName = "Sinatra"});

            employers.Add(new Employer { FirstName = "Tom", LastName = "Cruze"});
            employers.Add(new Employer { FirstName = "Seline", LastName = "Dion"});

        }
        static void Main(string[] args)
        {
            FillData();
            var res = students.Where(v => LinqerExtention.EqualPredicate(v, "FirstName", "Tom")).First();
            Console.WriteLine(res);
            Console.WriteLine("---------------------");
            var res2 = students.Where(LinqerExtention.GetCustomLambda(new Student(),"FirstName", "Tom", PredicateType.Equal)).First();
            Console.WriteLine(res2);            
            Console.WriteLine("Hello World!");
        }





    }
}
