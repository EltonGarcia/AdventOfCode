#!/usr/bin/python3

from fileinput import input

a = []
b = []
for line in input():
    arr = line.split('   ')
    a.append(int(arr[0]))
    b.append(int(arr[1]))

a.sort()
b.sort()

sum = 0
for i in range(0, len(a)):
    v = b[i] - a[i]
    sum += v if v > 0 else v*-1

print("Part1:", sum)
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
