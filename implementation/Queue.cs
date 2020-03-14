public class Queue
{
    internal class Node
    {
        internal int data;
        internal Node next;
        public Node(int data)
        {
            this.data = data;
        }
    }
    Node head; //remove from the head
    Node tail; //add things here

    public bool IsEmpty()
    {
        return head == null; //if head is null, Queue is empty.
    }
    public int Peek()
    {
        return head.data; //want data at front
    }
    public void Add(int data) //add to the back of the queue i.e. Enqueue
    {
        Node node = new Node(data);
        if (tail != null)
        {
            tail.next = node; //tail's next pointer is new node
        }
        tail = node; //otherwise update the tail
        if (head == null) //if queue is completely empty
        {
            head = node;
        }
    }
    public int Remove() //i.e. Dequeue
    {
        int data = head.data;
        head = head.next; //essentially removing it from the queue
        if (head == null)
        {
            tail = null; //make sure you set tail to null
        }
        return data;
    }
}