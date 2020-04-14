def bubble_sort(arr):
    n = len(arr)
    for i in range(0,n):
        for j in range(0, n - i - 1):
            if arr[j] > arr[j+1]:
                arr[j],arr[j+1] = arr[j+1], arr[j]
    return arr

#If there is no swapping in a particular pass, it means the array has become sorted, so we should not perform the further passes. 
# For this we can have a flag variable which is set to true before each pass and is made false when a swapping is performed.
def bubble_sort_optimized(arr):
    n = len(arr)
    for i in range(0, n):
        flag = False
        for j in range(0, n - i - 1):
            if arr[j] > arr[j+1]:
                flag = True
                arr[j],arr[j+1] = arr[j+1], arr[j]
        if flag == False: #array is sorted
            return
    return arr


my_arr = [10,5,6,3,2]
my_other_arr = [20,5,8,34,76,8,8,5,5]
print('Unsorted: %s' % my_arr)

bubble_sort(my_arr)

print('Sorted: %s' % my_arr)

print('Unsorted: %s' % my_other_arr)

bubble_sort(my_other_arr)

print('Sorted: %s' % my_other_arr)

