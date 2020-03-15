// Hash table. Collision resolution by chaining (closed addressing)
// Chaining is a possible way to resolve collisions. Each slot of the array contains a link to a singly-linked list containing key-value pairs with the same hash. New key-value pairs are added to the end of the list. Lookup algorithm searches through the list to find matching key. Initially table slots contain nulls. List is being created, when value with the certain hash is added for the first time.
// Complexity analysis
// Assuming, that hash function distributes hash codes uniformly and table allows dynamic resizing, amortized complexity of insertion, removal and lookup operations is constant. Actual time, taken by those operations linearly depends on table's load factor.
// Code snippets
// Code given below implements chaining with list heads. It means, that hash table entries contain first element of a linked-list, instead of storing pointer to it.
public class LinkedHashEntry
{
    private int key;
    private int value;
    private LinkedHashEntry next;
    internal LinkedHashEntry(int key, int value)
    {
        this.key = key;
        this.value = value;
        this.next = null;
    }
   public int GetValue()
    {
        return value;
    }
    public void SetValue(int value)
    {
        this.value = value;
    }
    public int GetKey()
    {
        return key;
    }
    public LinkedHashEntry GetNext()
    {
        return next;
    }
    public void SetNext(LinkedHashEntry next)
    {
        this.next = next;
    }
}
public class HashMap
{
    private static int TABLE_SIZE = 128;
    LinkedHashEntry[] table;
    public HashMap()
    {
        table = new LinkedHashEntry[TABLE_SIZE];
        for (int i = 0; i < TABLE_SIZE; i++)
            table[i] = null;
    }
    public int Get(int key)
    {
        int hash = (key % TABLE_SIZE);
        if (table[hash] == null)
            return -1;
        else
        {
            LinkedHashEntry entry = table[hash];
            while (entry != null && entry.GetKey() != key)
                entry = entry.GetNext();
            if (entry == null)
                return -1;
            else
                return entry.GetValue();
        }
    }
    public void Put(int key, int value)
    {
        int hash = (key % TABLE_SIZE);
        if (table[hash] == null)
            table[hash] = new LinkedHashEntry(key, value);
        else
        {
            LinkedHashEntry entry = table[hash];
            while (entry.GetNext() != null && entry.GetKey() != key)
                entry = entry.GetNext();
            if (entry.GetKey() == key)
                entry.SetValue(value);
            else
                entry.SetNext(new LinkedHashEntry(key, value));
        }
    }
    public void Remove(int key)
    {
        int hash = (key % TABLE_SIZE);
        if (table[hash] != null)
        {
            LinkedHashEntry prevEntry = null;
            LinkedHashEntry entry = table[hash];

            while (entry.GetNext() != null && entry.GetKey() != key)
            {
                prevEntry = entry;
                entry = entry.GetNext();
            }

            if (entry.GetKey() == key)
            {
                if (prevEntry == null)
                    table[hash] = entry.GetNext();
                else
                    prevEntry.SetNext(entry.GetNext());
            }
        }
    }
}