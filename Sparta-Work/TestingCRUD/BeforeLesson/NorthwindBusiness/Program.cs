using System;

namespace NorthwindBusiness
{
    class Program
    {
        static void Main(string[] args)
        {
            DelegateExercise obj = new DelegateExercise();
            obj.LongRunning(CallBack);
        }
        static void CallBack(int i)
        {
            Console.WriteLine(i);
        }
    }
    class DelegateExercise
    {
        public delegate void CallBack(int i);
        public void LongRunning(CallBack obj)
        {
            for(int i=0; i<10000; i++)
            {
                //Does something
                obj(i);
            }
        }
    }
}
