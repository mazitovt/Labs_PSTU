using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_Threads
{
    public delegate bool CheckingCombination(IEnumerable<int> numbers);

    static class CombinationCheckMethods
    {

        //три одинаковых числа, два одинаковых числа, три единицы, три семерки, две единицы, имеется четверка

        private static bool IsCountOfNumber(IEnumerable<int> numbers, int checkNumber, int countOfNumber)
        {
            if (numbers.Where(number => number == checkNumber).Count() >= countOfNumber)
                return true;

            return false;
        }
        private static bool IsCountOfSameNumbers(IEnumerable<int> numbers, int countOfSameNumbers)
        {
            foreach (var index in Enumerable.Range(0, numbers.Count()))
            {
                if (IsCountOfNumber(numbers, numbers.ElementAt(index), countOfSameNumbers))
                    return true;
            }

            return false;
        }

        public static CheckingCombination ThreeSameNumbers = (numbers) => IsCountOfSameNumbers(numbers, 3);

        public static CheckingCombination TwoSameNumbers = (numbers) => IsCountOfSameNumbers(numbers, 2);

        public static CheckingCombination ThreeOnes = (numbers) => IsCountOfNumber(numbers, 1, 3);

        public static CheckingCombination TwoOnes = (numbers) => IsCountOfNumber(numbers, 1, 2);

        public static CheckingCombination ThreeSevens = (numbers) => IsCountOfNumber(numbers, 7, 3);

        public static CheckingCombination AtLeastOneFour = (numbers) => numbers.Any(number => number == 4);
    }
}
