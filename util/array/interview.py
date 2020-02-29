def printUnorderedPairs(arrayA, arrayB):
    arrayALength = len(arrayA)
    arrayBLength = len(arrayB)
    for i in range(arrayALength):
        for j in range(arrayBLength):
            if(arrayA[i] < arrayB[j]):
                print(str(arrayA[i]) + ' ' + str(arrayB[j]))


def reverse(list):
    # reversed_list = list[::-1])
    # reversed_list = list.reverse()
    reversed_list = []
    for i in list:
        reversed_list.insert(i,len(list)- i + 1)
    print(reversed_list)


def is_prime(n):
    if (n==1):
        return False
    elif (n==2):
        return True;
    else:
        for x in range(2,n):
            if(n % x==0):
                return False
        return True

def factorial(n):
    # if(n < 2):
    #     return 1
    # else:
    #     return n * factorial(n-1)

    #ITERATIVE
    result = 1
    for x in range(2, n + 1):
        result *= x
    return result

def swap(a,b):
    if(a == b):
        return
    # temp = a
    # a = b
    # b = temp
    return b, a
    #a, b = b, a simple syntax without using a temp

def fib(n):
    #computer the nth fibonacci number
    if (n<= 0):
        return 0
    elif (n == 1):
        return 1
    else:
        return fib(n-1) + fib(n-2)

def copy_list(list):
    copy = []
    for value in list:
        copy.append(value)
    return copy


numbers = [1, 2, 3, 4]
letters = ['a', 'b', 'c', 'd']
x = 'blue'
y = 'red'

the_copy = copy_list(letters)
print(the_copy)
