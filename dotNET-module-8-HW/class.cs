using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNETModule8HW
{
    public class Program
    {
        static void Main(string[] args)
        {
            // 1.
            //SquaredArray squaredArray = new SquaredArray(5);

            //squaredArray[0] = 2;
            //squaredArray[1] = 3;
            //squaredArray[2] = 4;
            //squaredArray[3] = 5;
            //squaredArray[4] = 6;

            //for (int i = 0; i < 5; i++)
            //{
            //    Console.WriteLine($"Значение элемента с индексом {i} = {squaredArray[i]}");
            //}

            // 2

            Comunalka Comunalka = new Comunalka(5.0, 2.0, 3.0, 1.0);

        
            Comunalka.SetParameters(true, 100, 4, true, false);

           
            Comunalka.CalculateAndPrintTable();

            Console.WriteLine("Газ: " + Comunalka["газ"]);
            Console.WriteLine("Отопление: " + Comunalka["Отопление"]);
            Console.WriteLine("Ремонт: " + Comunalka["Ремонт"]);
            Console.WriteLine("Вода: " + Comunalka["вода"]);

        }
    }
    class SquaredArray
    {
        private int[] array;

        public SquaredArray(int size)
        {
            array = new int[size];
        }

        public int this[int index]
        {
            get
            {
                if (index >= 0 && index < array.Length)
                {
                    return array[index];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            set
            {
                if (index >= 0 && index < array.Length)
                {
                    array[index] = value * value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }
    }
}