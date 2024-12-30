#!/usr/bin/python3

from fileinput import input

l,r = zip(*[[int(x) for x in line.split()] for line in input()])

a = sorted(l)
b = sorted(r)

r1 = sum([abs(x - y) for x,y in zip(a, b)])

print("Part1:", r1)
print("Expct:", 2580760)
# Part 1 - result: 2580760

ridx = 0
sum2 = 0
for left in a:
    for i in range(ridx, len(a)):
        right = b[i]
        if left == right:
            sum2 += left
        elif left < right:
            ridx = i
            break

print("")
print("Part2:", sum2)
print("Expct:", 25358365)
# Part 2 - result: 25358365
