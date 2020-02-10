using System;
using System.Collections.Generic;
using System.IO;
class QueueWithTwoStacks<T>
{
    Stack<T> stackNewestOnTop = new Stack<T>();
    Stack<T> stackOldestOnTop = new Stack<T>();

    public void Enqueue(T value) { 
         stackNewestOnTop.Push(value);
    }

    public T Peek() {
         prepOld();
         return stackOldestOnTop.Peek();
    }

    public T Dequeue() {
         prepOld();
         return stackOldestOnTop.Pop();
    }
        
    private void prepOld() {
         if (stackOldestOnTop.Count == 0) {//if the queue is empty
            while(!(stackNewestOnTop.Count == 0)) { //while the stack is not empty
                stackOldestOnTop.Push(stackNewestOnTop.Pop()); //push the contents of the stack into the queue
            }
         }
    }
}
class Solution {
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        var stackQueue = new QueueWithTwoStacks<int>();
        int q = Convert.ToInt32(Console.ReadLine());

        for(int i = 0; i < q; i++) {
            string[] a_temp = Console.ReadLine().Split(' ');
            int type = Convert.ToInt32(a_temp[0]);
            if(type == 1) {
                int x = Convert.ToInt32(a_temp[1]);
                stackQueue.Enqueue(x);
            } else if(type == 2) {
                stackQueue.Dequeue();
            } else Console.WriteLine(stackQueue.Peek());
        }

        Console.ReadKey();
    }
}

