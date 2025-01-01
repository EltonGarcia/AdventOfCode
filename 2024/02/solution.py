#!/usr/bin/python3

from fileinput import input

reports = [[int(x) for x in line.split()] for line in input()]
#rps = [list(zip(x, x[1:])) for x in m]

r1 = 0
for rp in reports:
    l = list(zip(rp, rp[1:]))
    increasing = True
    invalidIdx = -1
    for i in range(0, len(l)):
        x, y = l[i]
        inc = y-x > 0
        delta = abs(x-y)
        if i == 0:
            increasing = inc
        elif inc != increasing:
            invalidIdx = i

        if delta <= 0 or delta >= 4:
            invalidIdx = i
    if invalidIdx == -1:
        r1 += 1

print("Part1:", r1)
print("Expected:", 432)
