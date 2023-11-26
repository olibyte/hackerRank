def hourglassSum(arr):
    biggest_hourglass = -63
    for i in range(4):
        for j in range(4):
            hourglass = (
                arr[i][j]+arr[i][j+1]+arr[i][j+2]+
                arr[i+1][j+1]+
                arr[i+2][j]+arr[i+2][j+1]+arr[i+2][j+2]
            )
            if hourglass > biggest_hourglass:
                biggest_hourglass = hourglass

    return biggest_hourglass