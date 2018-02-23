using System;

namespace _03Mankind
{
    class StartUp
    {
        static void Main()
        {
            try
            {
                string[] studentInfo = Console.ReadLine().Split();
                string[] workerInfo = Console.ReadLine().Split();

                Student student = new Student(studentInfo[0], studentInfo[1], studentInfo[2]);
                Worker worker = new Worker(workerInfo[0], workerInfo[1], double.Parse(workerInfo[2]), double.Parse(workerInfo[3]));

                Console.WriteLine(student);
                Console.WriteLine();
                Console.WriteLine(worker);
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine(argEx.Message);
            }
        }
    }
}
