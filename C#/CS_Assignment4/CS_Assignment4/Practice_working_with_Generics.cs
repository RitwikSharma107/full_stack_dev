namespace CS_Assignment4;

public class Practice_working_with_Generics
{
    public void topic(){Console.WriteLine("### Practice working with Generics ###");}
}

/* **************************************************** */

public class MyStack<T>
{
    private List<T> _elements = new List<T>();

    // Returns the number of elements in the stack
    public int Count()
    {
        return _elements.Count;
    }

    // Removes and returns the top element of the stack
    public T Pop()
    {
        if (_elements.Count == 0)
        {
            throw new InvalidOperationException("The stack is empty.");
        }

        T topElement = _elements[_elements.Count - 1];
        _elements.RemoveAt(_elements.Count - 1);
        return topElement;
    }

    // Adds an element to the top of the stack
    public void Push(T item)
    {
        _elements.Add(item);
    }
}

/* **************************************************** */

public class MyList<T>
{
    private List<T> _elements = new List<T>();

    // Adds an element to the list
    public void Add(T element)
    {
        _elements.Add(element);
    }

    // Removes and returns the element at the specified index
    public T Remove(int index)
    {
        if (index < 0 || index >= _elements.Count)
        {
            throw new ArgumentOutOfRangeException("index");
        }

        T element = _elements[index];
        _elements.RemoveAt(index);
        return element;
    }

    // Checks if the list contains the specified element
    public bool Contains(T element)
    {
        return _elements.Contains(element);
    }

    // Clears all elements from the list
    public void Clear()
    {
        _elements.Clear();
    }

    // Inserts an element at the specified index
    public void InsertAt(T element, int index)
    {
        if (index < 0 || index > _elements.Count)
        {
            throw new ArgumentOutOfRangeException("index");
        }

        _elements.Insert(index, element);
    }

    // Deletes the element at the specified index
    public void DeleteAt(int index)
    {
        if (index < 0 || index >= _elements.Count)
        {
            throw new ArgumentOutOfRangeException("index");
        }

        _elements.RemoveAt(index);
    }

    // Finds and returns the element at the specified index
    public T Find(int index)
    {
        if (index < 0 || index >= _elements.Count)
        {
            throw new ArgumentOutOfRangeException("index");
        }

        return _elements[index];
    }
}

/* **************************************************** */
public interface IEntity
{
    int Id { get; set; }
}

// IRepository<T> interface with the specified methods
public interface IRepository<T> where T : class, IEntity
{
    void Add(T item);
    void Remove(T item);
    void Save();
    IEnumerable<T> GetAll();
    T GetById(int id);
}

// GenericRepository<T> class
public class GenericRepository<T> : IRepository<T> where T : class, IEntity
{
    private readonly List<T> _items = new List<T>();

    // Adds an item to the repository
    public void Add(T item)
    {
        _items.Add(item);
    }

    // Removes an item from the repository
    public void Remove(T item)
    {
        _items.Remove(item);
    }

    // Saves changes (in this example, no actual data source is used)
    public void Save()
    {
        // Saving changes to a database
        Console.WriteLine("Saved to database");
    }

    // Retrieves all items from the repository
    public IEnumerable<T> GetAll()
    {
        return _items;
    }

    // Retrieves an item by its ID
    public T GetById(int id)
    {
        return _items.SingleOrDefault(item => item.Id == id);
    }
}

// Example of an entity class that implements IEntity
public class Entity : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
}

/* **************************************************** */