using System.Collections.Generic;
using System.Linq;

namespace LR_Threads
{
    public class SlotAnalytics
    {
        private readonly IEnumerable<int> _slots;
        private readonly List<string> _result = new();

        public string Result { get => _result.Any() ? string.Join("\n", _result) : "В последовательности нет искомых комбинаций."; }

        public SlotAnalytics(IEnumerable<int> slots)
        {
            _slots = slots;
        }

        public void AnalyzeSlotsWithClass()
        {
            _result.Clear();

            var ThreeSameNumbersCheck = new CombinationCheck(CombinationCheckMethods.ThreeSameNumbers, "В последовательности есть три одинаковых числа.");
            var TwoSameNumbersCheck = new CombinationCheck(CombinationCheckMethods.TwoSameNumbers, "В последовательности есть два одинаковых числа.");
            var ThreeOnesCheck = new CombinationCheck(CombinationCheckMethods.ThreeOnes, "В последовательности есть три единицы.");
            var ThreeSevensCheck = new CombinationCheck(CombinationCheckMethods.ThreeSevens, "В последовательности есть три семерки.");
            var TwoOnesCheck = new CombinationCheck(CombinationCheckMethods.TwoOnes, "В последовательности есть две единицы.");
            var AtLeastOneFourCheck = new CombinationCheck(CombinationCheckMethods.AtLeastOneFour, "В последовательности имеется четверка.");

            foreach (var check in new[] { ThreeSameNumbersCheck, TwoSameNumbersCheck, ThreeOnesCheck, ThreeSevensCheck, TwoOnesCheck, AtLeastOneFourCheck })
                check.CheckCombination(_slots);

            if (ThreeSameNumbersCheck.IsChecked & TwoSameNumbersCheck.IsChecked)
                _result.Add(ThreeSameNumbersCheck.Info);
            else if (TwoSameNumbersCheck.IsChecked)
                _result.Add(TwoSameNumbersCheck.Info);

            if (ThreeOnesCheck.IsChecked & TwoOnesCheck.IsChecked)
                _result.Add(ThreeOnesCheck.Info);
            else if (TwoOnesCheck.IsChecked)
                _result.Add(TwoOnesCheck.Info);

            if (ThreeSevensCheck.IsChecked)
                _result.Add(ThreeSevensCheck.Info);

            if (AtLeastOneFourCheck.IsChecked)
                _result.Add(AtLeastOneFourCheck.Info);
        }

        public void AnalyzeSlotsWithRecord()
        {
            _result.Clear();

            var ThreeSameNumbersCheck = new Check(CombinationCheckMethods.ThreeSameNumbers, "В последовательности есть три одинаковых числа.");
            var TwoSameNumbersCheck = new Check(CombinationCheckMethods.TwoSameNumbers, "В последовательности есть два одинаковых числа.");
            var ThreeOnesCheck = new Check(CombinationCheckMethods.ThreeOnes, "В последовательности есть три единицы.");
            var ThreeSevensCheck = new Check(CombinationCheckMethods.ThreeSevens, "В последовательности есть три семерки.");
            var TwoOnesCheck = new Check(CombinationCheckMethods.TwoOnes, "В последовательности есть две единицы.");
            var AtLeastOneFourCheck = new Check(CombinationCheckMethods.AtLeastOneFour, "В последовательности имеется четверка.");

            foreach (var check in new[] { ThreeSameNumbersCheck, TwoSameNumbersCheck, ThreeOnesCheck, ThreeSevensCheck, TwoOnesCheck, AtLeastOneFourCheck })
                check.CheckCombination(_slots);

            if (TwoSameNumbersCheck.IsChecked)
            {
                if (ThreeSameNumbersCheck.IsChecked)
                {
                    _result.Add(ThreeSameNumbersCheck.Info);                    
                }
                else
                {
                    _result.Add(TwoSameNumbersCheck.Info);
                }
            }

            //if (ThreeSameNumbersCheck.IsChecked & TwoSameNumbersCheck.IsChecked)
            //    _result.Add(ThreeSameNumbersCheck.Info);
            //else if (TwoSameNumbersCheck.IsChecked)
            //    _result.Add(TwoSameNumbersCheck.Info);


            if (TwoOnesCheck.IsChecked)
            {
                if (ThreeOnesCheck.IsChecked)
                {
                    _result.Add(ThreeOnesCheck.Info);

                }
                else
                {
                    _result.Add(TwoOnesCheck.Info);
                }
            }

            //if (ThreeOnesCheck.IsChecked & TwoOnesCheck.IsChecked)
            //    _result.Add(ThreeOnesCheck.Info);
            //else if (TwoOnesCheck.IsChecked)
            //    _result.Add(TwoOnesCheck.Info);

            if (ThreeSevensCheck.IsChecked)
                _result.Add(ThreeSevensCheck.Info);

            if (AtLeastOneFourCheck.IsChecked)
                _result.Add(AtLeastOneFourCheck.Info);
        }
    }
}
