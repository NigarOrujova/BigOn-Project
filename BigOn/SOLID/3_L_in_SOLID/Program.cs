using System;

namespace _3_L_in_SOLID
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Rectangular rect = new Rectangular();
            rect.Width = 2;
            rect.Height = 3;
            Print(rect);

            Rectangular square = new Square();
            square.Width = 2;
            square.Height = 3;
            Print(square);

        }

        static void Print(Rectangular shape)
        {
            Console.WriteLine($"{shape.GetType().Name}| Width:{shape.Width} Height:{shape.Height}");
            Console.WriteLine($"Perimeter: {shape.Perimeter()}");
            Console.WriteLine($"Area: {shape.Area()}");
        }
    }

    class Rectangular
    {
        public virtual double Width { get; set; }
        public virtual double Height { get; set; }

        public double Perimeter()
        {
            return (this.Height + this.Width) * 2;
        }

        public double Area()
        {
            return this.Height * this.Width;
        }
    }

    class Square : Rectangular
    {
        public override double Height
        {
            set
            {
                base.Width = value;
                base.Height = value;
            }
        }
        public override double Width
        {
            set
            {
                base.Width = value;
                base.Height = value;
            }
        }
    }
}
