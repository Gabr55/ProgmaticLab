using Packt.Shared;

namespace Packt.Shared;

public class AllCombinations
{
    // A method for calculating all combinations
    // where the desired value is obtained as a result 
    public static List<string> GetAllCombinations(
    IEnumerable<int> numbers,
    int requiredResult,
    string currentCombination = "",
    List<string>? allCombinations = null
    )
    {
        string[] operators = { "+", "-", "" };

        allCombinations ??= new List<string>();

        if (numbers.Count() > 0)
        {
            int firstNumber = numbers.First();
            IEnumerable<int> otherNumbers = numbers.Skip(1);

            foreach (string operatorItem in operators)
            {
                string newCombination = currentCombination
                    + firstNumber.ToString()
                    + operatorItem;

                if (!newCombination.EndsWith("+") 
                    && !newCombination.EndsWith("-") 
                    && firstNumber == 0)
                {
                    if (Evaluate.GetEvaluate(newCombination) == requiredResult)
                    {
                        allCombinations.Add($"{newCombination}={requiredResult}");
                    }
                }


                GetAllCombinations(
                    otherNumbers,
                    requiredResult,
                    newCombination,
                    allCombinations
                    );

            }
        }

        return allCombinations;

    }
}
