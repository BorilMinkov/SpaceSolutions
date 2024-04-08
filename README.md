# SpaceSolutions
Current implementation works with csv files, which use "," as delimiter and makes use of outlook as smtp server provider.

Improvements:

- Can be improved by making the program async/multi-threaded depending on purpose
- Better error handling
- Implementing the bonus tasks
- Implement method to read firsst couple of lines of csv file to detect csv delimiter instead of hardcoded
- Implement method to parse the user sender email and create the appropriate smtp client
- Put result csv in separate unique directory(get local date and time for it) to stop results from messing up subsequent runs
- remove whitespaces from user input

Why this was not implemented:
Went over the time I had assignment to myself to complete the assignment
