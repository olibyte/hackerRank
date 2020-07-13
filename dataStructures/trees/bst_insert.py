class Node:
    def __init__(self, info):
        self.info = info  
        self.left = None  
        self.right = None 
        self.level = None 

    def __str__(self):
        return str(self.info) 

def preOrder(root):
    if root == None:
        return
    print (root.info, end=" ")
    preOrder(root.left)
    preOrder(root.right)
    
class BinarySearchTree:
    def __init__(self): 
        self.root = None

#Node is defined as
#self.left (the left child of the node)
#self.right (the right child of the node)
#self.info (the value of the node)

    def insert(self, val):
        # Enter your code here
        node = Node(val) #node for val insertion
        if self.root == None: #if BST is empty
            self.root = node #insert at root
            return self.root

        cur = self.root #start from root
        while cur:
            if val < cur.info: #if val is less than current node val
                if cur.left: #if there is a left child
                    cur = cur.left # this left child is now root to be considered
                else:
                    cur.left = node #insert here
                    break
            elif val > cur.info: #if val is greater than root
                if cur.right: #if right child is present
                    cur = cur.right #right child is now root to be considered
                else:
                    cur.right = node #insert here
                    break
        return self.root
tree = BinarySearchTree()
t = int(input())

arr = list(map(int, input().split()))

for i in range(t):
    tree.insert(arr[i])

preOrder(tree.root)
