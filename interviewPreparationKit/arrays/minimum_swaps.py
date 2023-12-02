def minimumSwaps(arr):
    if len(arr) < 2:
        return 0

    minimum_swaps = 0
    index = 0
    while index < len(arr):
        if arr[index] == index + 1:
            index += 1
            continue
        swap(arr, index, (arr[index] - 1))
        minimum_swaps += 1

    return minimum_swaps

def swap(arr, left_index, right_index):
    temp = arr[left_index]
    arr[left_index] = arr[right_index]
    arr[right_index] = temp