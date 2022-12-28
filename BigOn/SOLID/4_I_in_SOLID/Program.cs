using System;

namespace _4_I_in_SOLID
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    class ModernPrinter : ICopier, IPrinter,IScaner
    {
        public void Copy(string v)
        {
            Console.WriteLine("coping....");
        }

        public void Print(string v)
        {
            Console.WriteLine("Printing...");
        }

        public void Scan(string v)
        {
            Console.WriteLine("scanning...");
        }
    }

    public interface ICopier
    {
        void Copy(string v);
    }

    public interface IPrinter
    {
        void Print(string v);
    }

    public interface IScaner
    {
        void Scan(string v);
    }

    public interface IModernPrinter : IScaner, IPrinter, ICopier
    {

    }
}
