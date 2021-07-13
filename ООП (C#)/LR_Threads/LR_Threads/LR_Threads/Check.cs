using System.Collections.Generic;

namespace LR_Threads
{
    public record Check(CheckingCombination CheckingFunction, string Info)
    {
        public bool IsChecked { get; private set; } = false;

        public void CheckCombination(IEnumerable<int> numbers)
        {
            IsChecked = CheckingFunction(numbers);
        }
    }
}
