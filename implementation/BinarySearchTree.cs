using System;

class Node
{
    Node left, right; //pointers to the left and right node
    int data;
    public Node(int data) //constructor
    {
        this.data = data;
    }

    public void Insert(int value) //takes in a node value, looking to the left and the right for insertion point
    {
        if (value <= data) 
        {
            if (left == null) //no node?
            {
                left = new Node(value); //becomes new node
            }
            else
            {
                left.Insert(value); //push down recursion stack
            }
        }
        else
        {
            if (right == null)
            {
                right = new Node(value);
            }
            else
            {
                right.Insert(value);
            }
        }
    }
    public bool Contains(int value)
    {
        if (value == data) //found it!
            return true;
        else if (value < data)
        {
            if (left == null) //no node, we know it's false
            {
                return false;
            }
            else
            {
                return left.Contains(value); //otherwise ask left node 
            }
        }
        else
        {
            if (right == null) //no node
            {
                return false;
            }
            else
            {
                return right.Contains(value); //otherwise ask right node
            }
        }
    }
    public void PrintInOrder()
    {
        if (left != null)
        {
            left.PrintInOrder();
        }
        Console.WriteLine(data);
        if (right != null)
        {
            right.PrintInOrder();
        }
    }
}