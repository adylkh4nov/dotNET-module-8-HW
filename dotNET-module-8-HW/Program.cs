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
            SquaredArray squaredArray = new SquaredArray(5);

            squaredArray[0] = 2;
            squaredArray[1] = 3;
            squaredArray[2] = 4;
            squaredArray[3] = 5;
            squaredArray[4] = 6;

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Значение элемента с индексом {i} = {squaredArray[i]}");
            }

            // 2.
            Console.Write("Введите площадь помещения (в м2): ");
            double area = double.Parse(Console.ReadLine());

            Console.Write("Введите количество проживающих: ");
            int residents = int.Parse(Console.ReadLine());

            Console.Write("Введите сезон (осень/зима): ");
            string season = Console.ReadLine().ToLower();

            Console.Write("Есть ли льготы (да/нет): ");
            string hasDiscount = Console.ReadLine().ToLower();

            double heatingRate = 5.0;
            double waterRate = 2.0;
            double gasRate = 3.0;
            double repairRate = 10.0;

            if (season == "осень" || season == "зима")
            {
                heatingRate *= 1.2;
            }

            double heatingPayment = area * heatingRate;
            double waterPayment = residents * waterRate;
            double gasPayment = residents * gasRate;
            double repairPayment = area * repairRate;

            double discount = 0.0;

            if (hasDiscount == "да")
            {
                discount = heatingPayment * 0.3;
            }

            double totalHeating = heatingPayment - discount;
            double totalWater = waterPayment;
            double totalGas = gasPayment;
            double totalRepair = repairPayment;
            double totalPayment = totalHeating + totalWater + totalGas + totalRepair;

            Console.WriteLine("Вид платежа\t\tНачислено\tЛьготная скидка\tИтого");
            Console.WriteLine($"Отопление\t\t{heatingPayment:C}\t\t{discount:C}\t\t{totalHeating:C}");
            Console.WriteLine($"Вода\t\t\t{waterPayment:C}\t\t\t-\t\t{totalWater:C}");
            Console.WriteLine($"Газ\t\t\t{gasPayment:C}\t\t\t-\t\t{totalGas:C}");
            Console.WriteLine($"Ремонт\t\t\t{repairPayment:C}\t\t\t-\t\t{totalRepair:C}");
            Console.WriteLine($"Итого\t\t\t\t\t\t\t{totalPayment:C}");

            Console.ReadLine();
        }
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
