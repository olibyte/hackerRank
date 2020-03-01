using System;
using System.Text;

namespace DoublyLinkedList
{
    public class DoublyLinkedList<T>
    { 
        private class Node<K> : INode<K>
        {
            public K Value { get; set; }
            public Node<K> Next { get; set; }
            public Node<K> Previous { get; set; }

            public Node(K value, Node<K> previous, Node<K> next)
            {
                Value = value;
                Previous = previous;
                Next = next;
            }

            // This is a ToString() method for the Node<K>
            // It represents a node as a tuple {'the previous node's value'-(the node's value)-'the next node's value')}. 
            // 'XXX' is used when the current node matches the First or the Last of the DoublyLinkedList<T>
            public override string ToString()
            {
                StringBuilder s = new StringBuilder();
                s.Append("{");
                s.Append(Previous.Previous == null ? "XXX" : Previous.Value.ToString());
                s.Append("-(");
                s.Append(Value);
                s.Append(")-");
                s.Append(Next.Next == null ? "XXX" : Next.Value.ToString());
                s.Append("}");
                return s.ToString();
            }

        } //nested node class

        // An important aspect of the DoublyLinkedList<T> is the use of two auxiliary nodes: the Head and the Tail. 
        // The both are introduced in order to significantly simplify the implementation of the class and make insertion functionality reduced just to a AddBetween(...)
        // These properties are private, thus are invisible to a user of the data structure, but are always maintained in it, even when the DoublyLinkedList<T> is formally empty. 
        // Remember about this crucial fact when you design and code other functions of the DoublyLinkedList<T> in this task.
        //instance variables
        private Node<T> Head { get; set; } //header sentinel
        private Node<T> Tail { get; set; } //trailer sentinel
        public int Count { get; private set; } = 0;
        public bool isEmpty() { return Count == 0; }

        public DoublyLinkedList() //constructs new empty list
        {
            Head = new Node<T>(default(T), null, null); //create head
            Tail = new Node<T>(default(T), Head, null); //create tail
            Head.Next = Tail; //header followed by trailer
        }

        public INode<T> First //returns first element
        {
            get { return isEmpty() ? null : Head.Next; }
            
        }

        public INode<T> Last //returns last element
        {
            get { return isEmpty() ? null : Tail.Previous; }
        }

        public INode<T> After(INode<T> node) //return INode<T> after given parameter node
        {
            if (node == null) throw new NullReferenceException();
            Node<T> node_current = node as Node<T>;
            if (node_current.Previous == null || node_current.Next == null) //parameter is not in the list
                throw new InvalidOperationException("The node referred as 'before' is no longer in the list");
            if (node_current.Next.Equals(Tail)) return null; //trailer sentinel
            else return node_current.Next;
        }
        public INode<T> Before(INode<T> node)
        {

            if (node == null) throw new NullReferenceException();
            Node<T> node_current = node as Node<T>;
            if (node_current.Previous == null || node_current.Next == null) //parameter is not in the list
                throw new InvalidOperationException("The node referred as 'after' is no longer in the list");
            if (node_current.Previous.Equals(Head)) return null; //header sentinel
            else return node_current.Previous;
        } //return INode<T> before given paramater node
        public INode<T> AddFirst(T value)
        {
            return AddBetween(value, Head, Head.Next);
        } //add and return node at beginning of list


        public INode<T> AddLast(T value)
        {
            return AddBetween(value, Tail.Previous, Tail);
        } //add and return node at end of list

        public void RemoveFirst() //remove node at start of list
        {
            if (isEmpty())
                throw new InvalidOperationException();
            Remove(Head.Next);
        }

        public void RemoveLast() //remove node at end of list
        {
            if (isEmpty())
                throw new InvalidOperationException();
            Remove(Tail.Previous);
        }
        public void Remove(INode<T> node)//removes given node
        {
            if (node == null)
                throw new NullReferenceException();
            if (Find(node.Value) == null)
                throw new InvalidOperationException("Node does not exist");

            Node<T> node_current = node as Node<T>; //safe cast the given node we want to remove
            
            if (node_current.Previous == null || node_current.Next == null) //parameter is not in the list
                throw new InvalidOperationException("The node referred as 'after' is no longer in the list");

            //cast current node's neighbours
            Node<T> previous = node_current.Previous;
            Node<T> next = node_current.Next;
            //reassign neighbouring nodes so nobody is pointing to current node
            previous.Next = next; //left neighbour of current now points to right neighbour
            next.Previous = previous; //right neighbour of current now points to left neighbour
            Count--; //shrink the list
        }
        
        public INode<T> AddBefore(INode<T> before, T value)
        {
            if (before == null)
                throw new NullReferenceException();
            Node<T> node_before = before as Node<T>; //safe cast
            if (node_before.Previous == null || node_before.Next == null)
                throw new InvalidOperationException();
            return AddBetween(value, node_before.Previous, node_before);        
        }

        public INode<T> AddAfter(INode<T> after, T value)
        {
            if (after == null)
                throw new NullReferenceException();
            Node<T> node_after = after as Node<T>; //safe cast
            if (node_after.Previous == null || node_after.Next == null)
                throw new InvalidOperationException();
            return AddBetween(value, node_after, node_after.Next);
        }
        public void Clear()
        {
            while(!isEmpty())
            {
                RemoveFirst();
            }
            Count = 0;
        }
        //private update method
        
        // This is a private method that creates a new node and inserts it in between the two given nodes referred as the previous and the next.
        // Use it when you wish to insert a new value (node) into the DoublyLinkedList<T>
        private Node<T> AddBetween(T value, Node<T> previous, Node<T> next)
        {
            Node<T> node = new Node<T>(value, previous, next);
            previous.Next = node;
            next.Previous = node;
            Count++;
            return node;
        }
             
        public INode<T> Find(T value)
        {
            Node<T> node = Head.Next;
            while (!node.Equals(Tail))
            {
                if (node.Value.Equals(value)) return node;
                node = node.Next;
            }
            return null;
        }

        public override string ToString()
        {
            if (Count == 0) return "[]";
            StringBuilder s = new StringBuilder();
            s.Append("[");
            int k = 0;
            Node<T> node = Head.Next;
            while (!node.Equals(Tail))
            {
                s.Append(node.ToString());
                node = node.Next;
                if (k < Count - 1) s.Append(",");
                k++;
            }
            s.Append("]");
            return s.ToString();
        }
            }
}