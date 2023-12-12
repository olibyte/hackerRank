def countSwaps(a):
    swap_count = 0
        
    for i in range(0, len(a)):
        for j in range(0, len(a)-1):
            if a[j] > a[j+1]:
                a[j], a[j+1] = a[j+1], a[j]
                swap_count += 1
        
    print('Array is sorted in '+str(swap_count)+' swaps.')
    print('First Element: '+str(a[0]))
    print('Last Element: '+str(a[n-1]))