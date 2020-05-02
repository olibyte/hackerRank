#Best case: O(n**2)

def insertion_sort(list):
    n = len(list)
    for i in range(1, n):
        key = list[i]
        j = i - 1

        while (j>=0 and key < list[j]):
            list[j + 1] = list[j]
            j -= 1
        list[j + 1] = key
    print("Sorted list:  %s" % list)

lst = []
size = int(input("\nEnter size of the list: \t"))
 
for i in range(size):
    elements = int(input("Enter the element: \t"))
    lst.append(elements)
 
insertion_sort(lst)