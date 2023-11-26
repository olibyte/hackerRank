def reverse_array(array, start, end):
    while start < end:
        array[start], array[end] = array[end], array[start]
        start += 1
        end -= 1
    return array
def rotLeft(a, d):
    # Write your code here
    # in-place solution: O(n) time, O(1) space
    reverse_array(a, 0, d-1)
    reverse_array(a, d, n-1)
    reverse_array(a, 0, n-1)
    return a
    
    # in-place solution using string slicing syntax
    # # Perform left rotations in-place
    # a[:] = a[d:] + a[:d]
    # return a

    #  naive solution: O(n) time, O(n) space. includes print debugging
    # tmp_array = a.copy()
    # right_length = n - d  # n=5,d=4,n-d = 1
    # left_length = d  # 4
    
    # print('right_length: '+str(right_length))
    # print('left_length: '+str(left_length))
    # print('for i in range(right_length...')

    # # copy right into tmp_array
    # for i in range(right_length):
    #     tmp_array[i] = a[left_length+i]  # tmp_array[0] = 5
    #     print('tmp_array['+str(i)+'] = '+str(a[left_length]))
    
    # print('for i in range(left_length)...')
    # for i in range(left_length):
    #     tmp_array[i+right_length] = a[i]  # tmp_array[0+1] = a[0]
    #     print('tmp_array['+str(i)+'] = '+str(i+right_length))
    
    # print(tmp_array)
    # print(a)
    # a = tmp_array
    # return a