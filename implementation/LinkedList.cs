public class Node {
    int data;
    Node next;
    public Node(int data)
    {
        this.data;
    }
}   
public class LinkedList
{
    Node head;
    public void Append(int data)
    {
        if (head == null) //list is empty
        {
            head = new Node(data);
            return;
        }
        Node current = head;
        while (current.next != null)  //walk through until...
        {
            current = current.next;
        }
        current.next = new Node(data);
    }
    public void Prepend(int data)
    {
        Node newHead = new Node(data);
        head.next = head;
        head = newHead;
    }
    public void DeleteWithValue(int data)
    {
        //special cases
        if (head == null) 
            return;
        if (head == data) //if the head is the node to delete
        {
            head = head.next; //point head to its neighbour effectively cutting it out of the list 
            return; //NOTE: Node is never explicitly destroyed but noone can access it
        }

        Node current = head;
        while (current.next != null)
        {
            if (current.next.data == data) //if it's the node with the value to delete //
            {
                current.next = current.next.next; //point it to its neighbour
                return;
            }
            current = current.next; //finally point the current node to its neighbour
        }
    }
}