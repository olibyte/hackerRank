class Heap:
    def __init__(self):
        self.elements = []
        self.index = {}

    def _swap(self, x, y):
        a = self.index[self.elements[x]]
        b = self.index[self.elements[y]]
        self.index[self.elements[y]] = a
        self.index[self.elements[x]] = b
        self.elements[x], self.elements[y] = self.elements[y], self.elements[x]

    def peek(self):
        if not self.elements:
            raise Exception("Cannot peek from an empty heap")
        return self.elements[0]

    def push(self,value):
        self.elements.append(value)
        current = len(self.elements) - 1
        self.index[value] = current
        self.heapify_up(current)

    def pop(self, value):
        current = self.index[value]
        self._swap(current, len(self.elements) -1)
        del self.index[value]
        self.elements.pop()

        if current < len(self.elements):
            self.heapify_down(self.heapify_up(current))

    def heapify_up(self,current):
        while current > 0:
            parent = (current - 1) // 2
            if self.elements[current] >= self.elements[parent]:
                break
            self._swap(current, parent)
            current = parent
        return current

    def heapify_down(self,current):
        while 2 * current + 1 < len(self.elements):
            l = 2 * current + 1
            r = 2 * current + 2
            m = l
            if r < len(self.elements) and self.elements[r] < self.elements[l]:
                m = r
            if self.elements[current] <= self.elements[m]:
                break
            self._swap(current, m)
            current = m
        return current

heap = Heap()

for i in range(int(input())):
    operation = [int(i) for i in input().split()]
    if operation[0] == 1:
        heap.push(operation[1])
    elif operation[0] == 2:
        heap.pop(operation[1])
    else:
        print(heap.peek())