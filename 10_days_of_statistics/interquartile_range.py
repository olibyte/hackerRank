# Enter your code here. Read input from STDIN. Print output to STDOUT
n = int(input())
nums = sorted([int(num) for num in input().split()])

def median(nums):
    if (len(nums) % 2) == 0:
        return int(sum(nums[len(nums) // 2-1:len(nums) // 2+1]) / 2)
    else:
        return nums[len(nums) // 2]

def quartiles(n, nums):
    q1 = median(nums[:len(nums) // 2])
    q2 = median(nums)
    if (n % 2)  == 0:
        q3 = median(nums[len(nums) // 2:])
    else:
        q3 = median(nums[len(nums) // 2+1:])
    return (q1, q2, q3)
def iqr(q1,q3):
    return q3 - q1
q1, q2, q3 = quartiles(n, nums)
# print('{0}{3}{1}{3}{2}'.format(q1, q2, q3, '\n'))
print(iqr(q1,q3))