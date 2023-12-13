
def merge_sort(arr):
    # Check if the array has more than one element
    if len(arr) > 1:
        # Find the middle index of the array
        mid = len(arr) // 2

        # Divide the array into two halves
        left_half = arr[:mid]
        right_half = arr[mid:]

        # Recursively apply merge_sort to each half
        merge_sort(left_half)
        merge_sort(right_half)

        # Merge the two halves
        merge(arr, left_half, right_half)


def merge(arr, left, right):
    # Initialize indices for the left, right, and merged arrays
    i = 0
    j = 0
    k = 0

    # Compare elements from both halves and merge them in sorted order
    while i < len(left) and j < len(right):
        if left[i] < right[j]:
            arr[k] = left[i]
            i += 1
        else:
            arr[k] = right[j]
            j += 1
        k += 1

    # Copy any remaining elements from the left half
    while i < len(left):
        arr[k] = left[i]
        i += 1
        k += 1

    # Copy any remaining elements from the right half
    while j < len(right):
        arr[k] = right[j]
        j += 1
        k += 1
 
def maximumToys(prices, k):
    # Write your code here
    toy_count = 0
    merge_sort(prices)
    # prices.sort() #can use python's in-built sorting algorithm.
    for p in prices:
        if p <= k:
            toy_count += 1
            k -= p
        else:
            break
            
    return toy_count  
# sort the array ascending in price
# purchase elements decrementing k