#!/usr/bin/python3

from fileinput import input

m = [[int(x) for x in line.split()] for line in input()]
rps = [list(zip(x, x[1:])) for x in m]

r1 = 0
for l in rps:
    valid = True
    increasing = True
    for i in range(0, len(l)):
        x, y = l[i]
        inc = y-x > 0
        delta = abs(x-y)
        if i == 0:
            increasing = inc
        else:
            valid = valid and inc == increasing

        valid = valid and delta > 0 and delta < 4
    if valid:
        r1 += 1

print("Part1:", r1)
