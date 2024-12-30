#!/bin/bash

curl "https://adventofcode.com/2024/day/$1/input" -X GET -H "Cookie: session=$AOC_COOKIE"
