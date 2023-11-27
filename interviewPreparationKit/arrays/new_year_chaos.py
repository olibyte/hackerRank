def minimumBribes(q):
    # Write your code here
    # O(n^2) time (quadratic), O(1) space (constant)
    bribes = 0
    is_chaotic = False
    # Starting from front of the queue
    for i in range(0, n):
        # if person is more than 2 spots from their sticker, queue is too chaotic
        if q[i] - (i+1) > 2:  # q[0] != 1
            is_chaotic = True
            break
        # otherwise person is in a valid position, has bribed either 0, 1, or 2 people
        current_person = max(0, q[i] - 2)
        # iterates over the people who were in front of the current person (within the last two positions).
        for j in range(current_person, i):
            # if the person at index j (the briber) has a higher sticker number than the current person (bribe_accepter), they received a bribe from the person at index j.
            if q[j] > q[i]:
                bribes += 1
    if is_chaotic:
        print('Too chaotic')
    else:
        print(bribes)

# optimized solution using inversion counts. O(n) time, O(1) space
#  an inversion occurs when a person with a higher sticker number is in front of a person with a lower sticker number. When we walk through the queue from back to front, we are essentially counting the number of inversions for each person.
# Since a person can only receive a bribe from someone with a higher sticker number, counting from the end of the queue ensures that we do not double-count inversions. Once a person is positioned correctly (i.e., after receiving their maximum allowed bribes), we won't count them again in subsequent iterations.
# By counting inversions from back to front, we efficiently track the number of bribes for each person without the need for nested loops. This contributes to the linear time complexity of the algorithm.
def minimum_bribes(q):
    bribes = 0
    # iterate through queue from back to front
    for i in range(n - 1, -1, -1):
        # Check if the person has bribed more than 2 people
        if q[i] - (i + 1) > 2:
            print('Too chaotic')
            return

        # Count the number of persons with higher sticker numbers in front
        for j in range(max(0, q[i] - 2), i):
            if q[j] > q[i]:
                bribes += 1

    print(bribes)