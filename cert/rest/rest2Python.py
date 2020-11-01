#!/bin/python3

import math
import os
import random
import re
import sys
#
# Complete the 'getNumDraws' function below.
#
# The function is expected to return an INTEGER.
# The function accepts INTEGER year as parameter.
#
import json
import requests

def getNumDraws(year):
    base = "https://jsonmock.hackerrank.com/api/football_matches"
    draw_endpoint = "https://jsonmock.hackerrank.com/api/football_matches?year={year}&team1goals={goals}&team2goals={goals}&page=1" 
    num_draws = 0
    for goals in range(3):
        # endpoint = base + "?year="+str(year)+"&team1goals="+str(goals)+"&team2goals="+str(goals)+"&page=1"
        draw_endpoint = draw_endpoint.format(year=year, goals=goals)
        # response = requests.get(endpoint)
        response = requests.get(draw_endpoint)
        response_json = response.json()
        total = response_json["total"]
        num_draws += total
    return num_draws
    
if __name__ == '__main__':
    fptr = open(os.environ['OUTPUT_PATH'], 'w')

    year = int(input().strip())

    result = getNumDraws(year)

    fptr.write(str(result) + '\n')

    fptr.close()
