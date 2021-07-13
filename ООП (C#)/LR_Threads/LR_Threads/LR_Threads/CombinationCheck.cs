using System.Collections.Generic;

namespace LR_Threads
{
    public class CombinationCheck
    {
        public int priority;
        private CheckingCombination checkingFunction;

        public bool IsChecked { get; private set; }
        public string Info { get; init; }

        public CombinationCheck(CheckingCombination function, string info)
        {
            checkingFunction = function;
            Info = info;
        }

        public void CheckCombination(IEnumerable<int> numbers)
        {
            IsChecked = checkingFunction(numbers);
        }
    }
}
