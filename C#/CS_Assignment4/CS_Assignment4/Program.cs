using System;
using CS_Assignment4;

Practice_working_with_Generics pwg = new Practice_working_with_Generics();
pwg.topic();

Console.WriteLine("\nQ1");
MyStack<int> myStack = new MyStack<int>();
myStack.Push(1);
myStack.Push(2);
myStack.Push(3);

Console.WriteLine("Count: " + myStack.Count());

Console.WriteLine("Pop: " + myStack.Pop()); 
Console.WriteLine("Count: " + myStack.Count());

MyStack<string> stringStack = new MyStack<string>();
stringStack.Push("Ritwik");
stringStack.Push("Sharma");

Console.WriteLine("Count: " + stringStack.Count());

Console.WriteLine("Pop: " + stringStack.Pop()); 
Console.WriteLine("Count: " + stringStack.Count()); 

Console.WriteLine("\nQ2");
MyList<int> intList = new MyList<int>();
intList.Add(1);
intList.Add(2);
intList.Add(3);

Console.WriteLine("Contains 2: " + intList.Contains(2)); 
Console.WriteLine("Find at index 1: " + intList.Find(1)); 

intList.InsertAt(4, 1);
Console.WriteLine("Find at index 1 after insert: " + intList.Find(1));

intList.DeleteAt(2);
Console.WriteLine("Find at index 2 after delete: " + intList.Find(2));

Console.WriteLine("Remove at index 0: " + intList.Remove(0)); 

intList.Clear();
Console.WriteLine("List cleared"); 

MyList<string> stringList = new MyList<string>();
stringList.Add("Ritwik");
stringList.Add("Sharma");

Console.WriteLine("Contains 'Ritwik': " + stringList.Contains("Ritwik")); 
Console.WriteLine("Find at index 1: " + stringList.Find(1));

Console.WriteLine("\nQ3");
IRepository<Entity> repository = new GenericRepository<Entity>();

var entity1 = new Entity { Id = 1, Name = "Ritwik" };
var entity2 = new Entity { Id = 2, Name = "Sharma" };

repository.Add(entity1);
repository.Add(entity2);
        
Console.WriteLine("All entities:");
foreach (var entity in repository.GetAll())
{
    Console.WriteLine($"Id: {entity.Id}, Name: {entity.Name}");
}

Console.WriteLine("Entity with Id 1:");
var entityById = repository.GetById(1);
if (entityById != null)
{
    Console.WriteLine($"Id: {entityById.Id}, Name: {entityById.Name}");
}

repository.Remove(entity1);
Console.WriteLine("All entities after removing entity1:");
foreach (var entity in repository.GetAll())
{
    Console.WriteLine($"Id: {entity.Id}, Name: {entity.Name}");
}

repository.Save();