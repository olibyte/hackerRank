def selection_sort(alist):
    size = len(alist)

    for i in range(size-1):
        min = i #nitialize min as left-most element

        for j in range(i + 1, size): #inner pass starts from the element one right 
            # print(i,j)

            if alist[j] < alist[min]:
                min = j #then we have a new min

        temp = alist[i]
        alist[i] = alist[min]
        alist[min] = temp
    
alist = [54, 24, 77, 93, 58]
selection_sort(alist)
print(alist)