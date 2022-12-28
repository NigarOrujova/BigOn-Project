using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace OOPDiscuss
{
    record struct Person(int Id,string Name);
    //class Person : IEquatable<Person>
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }

    //    public Person(int id, string name)
    //    {
    //        Id = id;
    //        Name = name;
    //    }

    //    public override string ToString()
    //    {
    //        return $"{Id} | {Name}";
    //    }

    //    public bool Equals(Person other)
    //    {
    //        return this.Id == other.Id && this.Name == other.Name;
    //    }
    //}

    public class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new(21, "Aqil");

            Person person2 = new(21, "Aqil");

            if (person1.Equals(person2))
            {
                Console.WriteLine("Eynidir");
            }
            else
            {
                Console.WriteLine("Eyni deyildir");
            }
        }












        private static void Timer_Tick(object sender, TimerTickEventArgs e)
        {
            Console.Clear();
            Console.WriteLine($"{e.ExecuteTime:yyyy.MM.dd HH:mm:ss}");
            Console.Beep();

            //Action
            //Func
            //Predicate
        }

        static void Test1()
        {
            MyTimer timer = new MyTimer();

            timer.Tick += Timer_Tick;
            timer.Tick += Timer_Tick;
            timer.Tick -= Timer_Tick;
            timer.Tick += Timer_Tick;

            timer.Start();

            Console.ReadKey();
            timer.Stop();
        }
    }

    public class MyTimer
    {
        public event TimerTickHandler Tick;
        public int Id { get; set; }

        bool running = false;

        public void Start()
        {
            Task.Run(async () =>
            {
                running = true;
                while (running)
                {
                    var args = new TimerTickEventArgs { ExecuteTime = DateTime.Now };

                    this.Tick?.Invoke(this, args);
                    //DoWork();
                    await Task.Delay(TimeSpan.FromSeconds(1));
                }
            });
        }

        public void Stop()
        {
            running = false;
        }


        //private void DoWork()
        //{
        //    Console.Clear();
        //    Console.WriteLine($"{DateTime.Now:yyyy.MM.dd HH:mm:ss}");
        //    Console.Beep();
        //}
    }

    public class TimerTickEventArgs : EventArgs
    {
        public DateTime ExecuteTime { get; set; }
    }

    public delegate void TimerTickHandler(object sender, TimerTickEventArgs e);
}
