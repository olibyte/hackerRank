

    // Complete the insertNodeAtPosition function below.

    /*
     * For your reference:
     *
     * SinglyLinkedListNode {
     *     int data;
     *     SinglyLinkedListNode next;
     * }
     *
     */
    static SinglyLinkedListNode insertNodeAtPosition(SinglyLinkedListNode head, int data, int position) {

       
        SinglyLinkedListNode originalHead = head;

        SinglyLinkedListNode tmp = new SinglyLinkedListNode(data);

        int i = 0;

        while(i < position - 1 && head.next != null)
        {
            head = head.next;
            i++;
        }
        tmp.next = head.next;
        head.next = tmp;

        return originalHead;
    }