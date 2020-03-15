//HashTable

//good for fast key value lookups
//hash function takes in a string, converts it to a hashcode, maps it to an index in the array
//chaining -> if there's a collision, store it in a linked list
//O(1) for a good Hashtable, O(N) for lots of collisions
//this implementation uses Linear Probing for collision resolution
//Table allows only integers as values. Hash function to be used is the remainder of division by 128.
//Linear probing is applied to resolve collisions. In case the slot, indicated by hash function, has already been occupied, algorithm tries to find an empty one by probing consequent slots in the array.

//Note.Linear probing is not the best techique to be used when table is of a constant size.When load factor exceeds particular value (appr. 0.7), hash table performance will decrease nonlinearly.Also, the number of stored key-value pairs is limited to the size of the table (128).
//remove method omitted for simplicity.
public class HashEntry
{
    private int key;
    private int value;

    internal HashEntry(int key, int value)
    {
        this.key = key;
        this.value = value;
    }
    public int GetKey()
    {
        return key;
    }
    public int GetValue()
    {
        return value;
    }
}
public class HashMap
{
    private static int TABLE_SIZE = 128;
    HashEntry[] table;
    public HashMap()
    {
        table = new HashEntry[TABLE_SIZE];
        for (int i = 0; i < TABLE_SIZE; i++)
            table[i] = null;
    }
    public int Get(int key)
    {
        int hash = (key % TABLE_SIZE);
        while (table[hash] != null && table[hash].GetKey() != key)
            hash = (hash + 1) % TABLE_SIZE;
        if (table[hash] == null)
            return -1;
        else
            return table[hash].GetValue();
    }
    public void Put(int key, int value)
    {
        int hash = (key % TABLE_SIZE);
        while (table[hash] != null && table[hash].GetKey() != key)
            hash = (hash + 1) % TABLE_SIZE;
        table[hash] = new HashEntry(key, value);
    }
}