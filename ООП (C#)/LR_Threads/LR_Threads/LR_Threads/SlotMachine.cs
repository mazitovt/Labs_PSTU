using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace LR_Threads
{

    public delegate void SlotEventHandler(object sender, int slotIndex, int value);

    public class SlotMachine
    {
        public event SlotEventHandler SlotNumberChanged;

        private bool _isSpinning = false;
        private readonly Random _rnd;

        public bool IsSpinning => _isSpinning;
        public int[] Slots { get; init; }
        public int NumberOfSlots { get; init; }

        public SlotMachine()
        {

        }

        public SlotMachine(int numberOfSlots)
        {
            NumberOfSlots = numberOfSlots;
            Slots = new int[NumberOfSlots];
            //ShowResult();
            _rnd = new Random();
        }
        
        private void OnSlotNumberChanged(int slotIndex, int value)
        {
            SlotNumberChanged?.Invoke(this, slotIndex, value);
        }

        private void StartThreads(IEnumerable<Thread> threads)
        {
            int index = 0;

            foreach (var thread in threads)
            {
                thread.Start(index++);
            }
        }
        
        private bool AreDead(IEnumerable<Thread> threads)
        {
            foreach (var thread in threads)
            {
                while (thread.IsAlive)
                {
                    //Console.WriteLine("IsAlive");
                }
            }

            return true;
        }
        
        private IEnumerable<Thread> GenerateThreads(int numberOfThreads) 
            => Enumerable.Range(0, numberOfThreads)
                .Select(x => GenerateThread(Spin, ThreadPriority.Normal, $"{x}"))
                .ToArray();
        
        private Thread GenerateThread(ParameterizedThreadStart start, ThreadPriority priority, string name)
            => new Thread(start) { Priority = priority, Name = name };

        private void Spin(object obj)
        {
            int index = (int)obj;

            while (_isSpinning)
            {
                lock (Slots)
                {
                    var value = _rnd.Next(10);
                    var slotIndex = Int32.Parse(Thread.CurrentThread.Name);
                    OnSlotNumberChanged(slotIndex, value);
                    Slots[index] = value;
                }

                Thread.Sleep(100);
            }         
        }

        public void StartSpinning()
        {
            _isSpinning = true;

            StartThreads(GenerateThreads(NumberOfSlots));
        }
          
        public void StopSpinning() => _isSpinning = false;

        public void ShowResult()
        { 
            Console.WriteLine("Слоты: " + string.Join(" ", Slots));
        }
    }
}
