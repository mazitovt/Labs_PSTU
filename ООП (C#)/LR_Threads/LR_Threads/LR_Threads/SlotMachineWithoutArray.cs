using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LR_Threads
{
    class SlotMachineWithoutArray
    {

        private bool _isSpinning = false;
        private readonly Random _rnd;
        private int queue = 0;

        public int[] Slots { get; init; }
        public int NumberOfSlots { get; init; }


        public SlotMachineWithoutArray(int numberOfSlots)
        {
            NumberOfSlots = numberOfSlots;
            Slots = new int[NumberOfSlots];
            //ShowResult();
            _rnd = new Random();
        }

        private void StartThreads(IEnumerable<Thread> threads)
        {
            int index = 0;

            foreach (var thread in threads)
            {
                thread.Start(index++);
                Thread.Sleep(100);
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
                    int number = _rnd.Next(10);
                    Console.Write(Thread.CurrentThread.Name + ": " +  number + " ");
                    queue++;
                    CheckForNewLine();
                }
                Thread.Sleep(500);
            }
        }


        private void CheckForNewLine()
        {
            if (queue == NumberOfSlots)
            {
                queue = 0;
                Console.WriteLine();
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
