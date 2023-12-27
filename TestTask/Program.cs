using static System.Console;

using Packt.Shared;

// Range numbers from 9 to 0
IEnumerable<int> numberRange = Enumerable.Range(0, 9 + 1).Reverse().ToArray();

// Required result
const int REQUIRED_RESULT = 200;

// Init list with results
List<string> combinations = AllCombinations.GetAllCombinations(numberRange, REQUIRED_RESULT);

// Display results
foreach (string combination in combinations)
{
    WriteLine(combination);
}