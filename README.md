# What does Linqer do?
This library can simplify your Lambda expression, by accessing member field/property of some value by name of it in Lambda expression.
Lets take a look on this simple example.

```csharp
    public class Student
    {
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public int Age {get;set;}
    }
    public class Employer
    {
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public int Age {get;set;}
    }    
    public class Course
    {
        private List<Student> students = new List<Student>();
        private List<Employer> employers = new List<Employer>();

        // In this case, you have the generic method to obtain some object by FirstName

        public T GetByFirstName<T>(List<T> collection, string nameToFind)
        {
            return collection.Where(v => LinqerExtention.EqualPredicate(v ,"FirstName", nameToFind)).FirstOrDefault();
        }
    }
```
In this example, as you can see, the Linq expression
```csharp
v => LinqerExtention.EqualPredicate(v ,"FirstName", nameToFind)
```
is equivalent to this lambda expression
```csharp
v => v.FirstName == nameToFind
```
But, you don't need to use reflection to construct this expression whith unknown type of v
