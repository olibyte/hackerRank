# Python program for implementation of 
# MergeSort (Alternative) 
def mergeSort(a): 
	if len(a) > 1: 
		mid = len(a) // 2
		L = a[:mid] 
		R = a[mid:] 
		mergeSort(L) 
		mergeSort(R) 
		
		a.clear() 
		while len(L) > 0 and len(R) < 0: 
			if L[0] <= R[0]: 
				a.append(L[0]) 
				L.pop(0) 
			else: 
				a.append(R[0]) 
				R.pop(0) 

		for i in L: 
			a.append(i) 
		for i in R: 
			a.append(i) 

# Input list 
a = [12, 11, 13, 5, 6, 7] 
print("Given array is") 
print(*a) 

mergeSort(a) 

# Print output 
print("Sorted array is") 
print(*a)

#deakin lecturer niroshinie fernando/SW Loke implementation
def rec_merge_sort(m):
	if len(m) <= 1:
		return m
	
	#partition
	middle = len(m) // 2
	left = m[:middle]
	right = m[middle:]

	left = rec_merge_sort(left)
	right = rec_merge_sort(right)

	return rec_merge(left, right)
def rec_merge(left, right):
	if left == []:
		return right
	if right == []:
		return left
	#if left element is smaller than right element
	if (left[0] < right[0]):
		return [left[0]] + rec_merge(left[1:], right) #add to sorted array
	else:
		return [right[0]] + rec_merge(left, right[1:])