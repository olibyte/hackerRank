def countTriplets(arr, r):
    triplets_count = 0
    '''Bad solution, O(n^3) time complexity'''
    # think of a first, middle, and last triplet as:
    # arr[i],arr[i] * r, arr[i] * r * r
    # the bad solution, O(n^3) time complexity
    # twins = {}
    # triplets = {}

    # for i in range(0, len(arr)):
    #     for j in range(0, len(arr)):
    #         for k in range(0, len(arr)):
    #             if arr[i] * r == arr[j] and arr[j] * r == arr[k]:
    #                 triplets_count += 1
    freq = {}
    twins = {}

    for element in arr:
        if element % r == 0:
            prev = element // r # has a left sibling
            triplets_count += twins.get(prev, 0) 

            if prev in freq:
                twins[element] = twins.get(element, 0) + freq[prev] 
            else:
                twins[element] = 0

        freq[element] = freq.get(element, 0) + 1

    return triplets_count

'''two dictionaries (freq and twins) are used to keep track of the frequency of elements and the count of potential triplets. The main loop traverses the array, and for each element, it checks if it is a valid middle element in a triplet. If so, it calculates the count of triplets and updates the dictionaries accordingly.'''
