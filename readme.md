# Cron Expression Parser
The objective of this project is to receive a cron expression and display it in a friendly way.

## Usage
To run the project simply call it from a command line with one argument that contains all six parameters.

`CronExpressionParser "*/15 0 1,15 * 1-5 /usr/bin/find"`

The parameters are space separated and in this example we have:
```
minutes          : */15
hour             : 0
day of the month : 1 to 15
month            : every
day of the week  : 1 to 5
command:         : /usr/bin/find
```

### Examples

`CronExpressionParser.exe "*/15 0 1,15 * 1-5 /usr/bin/find"`

```
minute         0 15 30 45
hour           0
dayOfTheMonth  1 15
month          1 2 3 4 5 6 7 8 9 10 11 12
dayOfTheWeek   1 2 3 4 5
command        /usr/bin/find
```
---

`CronExpressionParser.exe "1-10 0-20 1 * * /usr/bin/find"`
```
minute         1 2 3 4 5 6 7 8 9 10
hour           0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20
dayOfTheMonth  1
month          1 2 3 4 5 6 7 8 9 10 11 12
dayOfTheWeek   0 1 2 3 4 5 6
command        /usr/bin/find
```
---

`CronExpressionParser.exe "* * * * * /usr/bin/find"`
```
minute         0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24
25 26 27 28 29 30 31 32 33 34 35 36 37 38 39 40 41 42 43 44 45 46 47 48 49 50 51
52 53 54 55 56 57 58 59
hour           0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23
dayOfTheMonth  1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25
26 27 28 29 30
month          1 2 3 4 5 6 7 8 9 10 11 12
dayOfTheWeek   0 1 2 3 4 5 6
command        /usr/bin/find
```

## Special Characters
Currently the only special characters supported are:

##*
Every in the category

##-
Range, for example `1-4` will result in `1 2 3 4`

##/
Skipped, this parameter requires one before and one after the slash, the one before the slash is the starting point, and the one after is the skip for example: `0/3` will result in `0 3 6 9...`
and `2/3` will result in `2 5 8 11...` until the end of the values in the category.

# Error Handling
In case one of the parameters is incorrect or outside the range of the category, the app will produce a friendly error message.