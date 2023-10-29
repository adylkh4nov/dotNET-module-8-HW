using System;

class Comunalka
{
    private double heatingRate;  // тариф на отопление за 1 м2
    private double waterRate;    // тариф на воду за 1 человека
    private double gasRate;      // тариф на газ за 1 человека
    private double repairRate;   // тариф на текущий ремонт за 1 м2
    private bool isWinter;       // сезон: true - зима, false - лето
    private int area;            // метраж помещения
    private int residentsCount;  // количество проживающих
    private bool veteranLabor;   // льготы для ветерана труда
    private bool veteranWar;     // льготы для ветерана войны
    public Comunalka(double heatingRate, double waterRate, double gasRate, double repairRate)
    {
        this.heatingRate = heatingRate;
        this.waterRate = waterRate;
        this.gasRate = gasRate;
        this.repairRate = repairRate;
    }
    public double this[string paymentType]
    {
        get
        {
            switch (paymentType.ToLower())
            {
                case "отопление":
                    return CalculateHeating();
                case "вода":
                    return CalculateWater();
                case "газ":
                    return CalculateGas();
                case "ремонт":
                    return CalculateRepair();
                default:
                    throw new ArgumentException("Недопустимый тип платежа");
            }
        }
    }

    public void SetParameters(bool isWinter, int area, int residentsCount, bool veteranLabor, bool veteranWar)
    {
        this.isWinter = isWinter;
        this.area = area;
        this.residentsCount = residentsCount;
        this.veteranLabor = veteranLabor;
        this.veteranWar = veteranWar;
    }

    public void CalculateAndPrintTable()
    {
        Console.WriteLine("Вид платежа\tНачислено\tЛьготная скидка\tИтого");

        double totalSum = 0;

        totalSum += PrintTableRow("Отопление", CalculateHeating());
        totalSum += PrintTableRow("Вода", CalculateWater());
        totalSum += PrintTableRow("Газ", CalculateGas());
        totalSum += PrintTableRow("Ремонт", CalculateRepair());

        Console.WriteLine("\nИтоговая сумма: {0}", totalSum);
    }

    private double CalculateHeating()
    {
        double rate = heatingRate * area;
        if (isWinter)
        {
            rate *= 1.5; // Увеличиваем тариф зимой
        }
        return ApplyDiscount(rate);
    }

    private double CalculateWater()
    {
        return ApplyDiscount(waterRate * residentsCount);
    }

    private double CalculateGas()
    {
        return ApplyDiscount(gasRate * residentsCount);
    }

    private double CalculateRepair()
    {
        return ApplyDiscount(repairRate * area);
    }

    private double ApplyDiscount(double amount)
    {
        if (veteranLabor)
        {
            amount -= 0.3 * amount; // 30% скидка для ветерана труда
        }
        if (veteranWar)
        {
            amount -= 0.5 * amount; // 50% скидка для ветерана войны
        }
        return amount;
    }

    private double PrintTableRow(string paymentType, double amount)
    {
        double discount = 0;
        if (veteranLabor || veteranWar)
        {
            discount = amount * 0.3; // Льготы для ветеранов
        }

        double total = amount - discount;

        // Используем PadRight для выравнивания строк
        Console.WriteLine($"{paymentType,-15}\t{amount,-15}\t{discount,-15}\t{total,-15}");

        return total;
    }

}
