using System;

namespace Start
{
    class Program
    {
        static void Main(string[] args)
        {
            double A, B, C, media, result;
            A = double.Parse(Console.ReadLine());
            B = double.Parse(Console.ReadLine());
            C = double.Parse(Console.ReadLine());
            
            
            media = (( A * 2) + (  B * 3) + (C * 5));
            result = media / 10;

            Console.WriteLine("MEDIA = {0}", result.ToString("0.0"));
            Console.ReadKey();
        }
    }
}