# Enter your code here. Read input from STDIN. Print output to STDOUT
n = int(input())
arr = sorted(map(int,input().split(' ')))

# print(n)
# print(arr)


def calculate_mean(arr):
    mean = 0
    for i in range(n):
        mean += arr[i]
    return mean/n

def calculate_median(arr):
    n = len(arr)
    median = 0
    mid = n // 2
    if n % 2 == 0:
        median = (arr[mid] + arr[mid-1]) / 2
    else:
        median = arr[mid]
    return median

def calculate_mode(arr):
    # initialise mode and counter for max freq
    mode = arr[0]
    max_freq = 0
    for i in range(n):
        # walk through arr elements and keep count of occurences
        freq = 0
        for j in range(n):
            if(arr[j] == arr[i]):
                freq += 1
        # after iteration check what our max_freq is
        #if the element for this pass is most frequent, redefine our mode
        if (freq > max_freq):
            max_freq = freq
            mode = arr[i]
    return mode

print(calculate_mean(arr))
print(calculate_median(arr))
print(calculate_mode(arr))