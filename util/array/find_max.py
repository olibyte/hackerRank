def find_max(given_list):
    current_max = None
    for item in given_list:
        if current_max == None:
            current_max = item
        elif item > current_max:
            current_max = item
    return current_max
