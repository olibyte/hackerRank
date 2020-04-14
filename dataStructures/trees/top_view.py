class Node:
    def __init__(self, info): 
        self.info = info  
        self.left = None  
        self.right = None 
        self.level = None 

    def __str__(self):
        return str(self.info) 

class BinarySearchTree:
    def __init__(self): 
        self.root = None

    def create(self, val):  
        if self.root == None:
            self.root = Node(val)
        else:
            current = self.root
         
            while True:
                if val < current.info:
                    if current.left:
                        current = current.left
                    else:
                        current.left = Node(val)
                        break
                elif val > current.info:
                    if current.right:
                        current = current.right
                    else:
                        current.right = Node(val)
                        break
                else:
                    break

"""
Node is defined as
self.left (the left child of the node)
self.right (the right child of the node)
self.info (the value of the node)
"""
def top_view(root, m, hd,level):
    if not root:
        return 
    if hd in m:
        if level < m[hd][1]:
            m.update( {hd : [root.info,level] })
    else:
        m[hd] = [root.info,level]

    top_view(root.left, m, hd-1,level+1)
    top_view(root.right,m, hd+1, level+1)
def topView(root):
    m={}
    top_view(root, m, 0,0)
    mn = 100000
    mx = -100000
    for key,value in m.items():
        if mx < key:
            mx = key
        if mn > key:
            mn = key
    i = mn
    while i <= mx:
        print (m[i][0],end = " ")
        i = i+1


tree = BinarySearchTree()
t = int(input())

arr = list(map(int, input().split()))

for i in range(t):
    tree.create(arr[i])

topView(tree.root)