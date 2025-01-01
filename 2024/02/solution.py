#!/usr/bin/python3

from fileinput import input

reports = [[int(x) for x in line.split()] for line in input()]

def getInvalidIndex(rp) -> int:
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
        if invalidIdx != -1:
            break

    return invalidIdx

def listExcludingIdx(l, idx):
    return l[:idx] + l[idx+1 :]

r1 = 0
r2 = 0
for rp in reports:
    invalidIdx = getInvalidIndex(rp)
    if invalidIdx == -1:
        r1 += 1
        r2 += 1
    else:
        rpD1 = listExcludingIdx(rp, invalidIdx)
        noCur = getInvalidIndex(rpD1)
        if noCur == -1:
            r2 += 1
            continue

        if invalidIdx-1 >= 0:
            rpD2 = listExcludingIdx(rp, invalidIdx-1)
            noPrev = getInvalidIndex(rpD2)
            if noPrev == -1:
                r2 += 1
                continue

        if invalidIdx+1 < len(rp):
            rpD3 = listExcludingIdx(rp, invalidIdx+1)
            noNext = getInvalidIndex(rpD3)
            if noNext == -1:
                r2 += 1
                continue

print("Part1:", r1)
print("Expected:", 432)

print("")
print("Part2:", r2)
print("Expected:", 488)
