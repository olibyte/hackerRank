"""
Detect a cycle in a linked list. Note that the head pointer may be 'None' if the list is empty.

A Node is defined as: 
 
    class Node(object):
        def __init__(self, data = None, next_node = None):
            self.data = data
            self.next = next_node
"""


# def has_cycle(head):
    # if head is not None:#as long as head isn't null
        # node = head;
        # while node is not None: #walk through the list
            # node = node.next
           # # if second node is null...
           # # when the nodes of both list have the same data
            # if head.next is not None and node == head.next and node.data == head.next.data:
                # return True #we've found the merge point
            # return False #
        # return True #traversed the list and terminate once there are no more nodes. 

#using Floyd's Tortoise and Hare Cycle-finding algorithm
def has_cycle(head):
    if head is None:
        return False #no merge point if list is empty

    fast = head.next #nodes need to start in different places otherwise they'll collide in the beginning
    slow = head

    while fast is not None and fast.next is not None and slow is not None: #fast is walking 2 at a time, so need to account for case where fast.next is not none
        if fast == slow:
            return True

        fast = fast.next.next   #fast node walks 2 steps at a time
        slow = slow.next        #slow walks 1 at a time
    return False #if they traverse to the end and haven't collided we know there's no merge point