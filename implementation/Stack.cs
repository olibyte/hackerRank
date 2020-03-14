public class Stack
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
    Node top; //remove from the top

    public bool IsEmpty()
    {
        return top == null; //if top is null, Stack is empty.
    }
    public int Peek()
    {
        return top.data; //want data at top
    }
    public void Push(int data)
    {
        Node node = new Node(data);
        node.next = top; //points to 'old top'
        top = node; //top is now the new node
    }
    public int Pop()
    {
        int data = top.data; //get data on top
        top = top.next; //top should be pointed to next element
        return data;
    }
}