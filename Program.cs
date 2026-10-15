namespace Gladiator;

class Program
{
    static void Main(string[] args)
    {
        Gladiator glad1, glad2;

        do
        {
            Console.WriteLine("--- Создание Первого Гладиатора ---");
            glad1 = CreateGladiator();

            Console.WriteLine("\n--- Создание Второго Гладиатора ---");
            glad2 = CreateGladiator();

        } while (glad1 == null || glad2 == null);

        Random rand = new();
        Console.WriteLine("\n=== БОЙ НАЧИНАЕТСЯ ===");

        double attack1 = 10.0 + rand.NextDouble() * 90.0;
        glad2.TakeDamage(attack1);

        Console.WriteLine($"\nГладиатор 1 наносит удар силой {attack1:F2}!");
        Console.WriteLine($"Гладиатор 2 получил чистый урон: {glad2.LastDamageTaken:F2}. Остаток здоровья: {glad2.Health:F2}, Броня: {glad2.ArmorPercent:F2}%");

        double attack2 = 10.0 + rand.NextDouble() * 90.0;
        glad1.TakeDamage(attack2);

        Console.WriteLine($"\nГладиатор 2 наносит ответный удар силой {attack2:F2}!");
        Console.WriteLine($"Гладиатор 1 получил чистый урон: {glad1.LastDamageTaken:F2}. Остаток здоровья: {glad1.Health:F2}, Броня: {glad1.ArmorPercent:F2}%");

        Console.WriteLine("\n=== ИТОГ БОЯ ===");
        if (glad1.Health > glad2.Health)
        {
            Console.WriteLine($"Победил Гладиатор 1! (Остаток здоровья: {glad1.Health:F2})");
        }
        else if (glad2.Health > glad1.Health)
        {
            Console.WriteLine($"Победил Гладиатор 2! (Остаток здоровья: {glad2.Health:F2})");
        }
        else
        {
            Console.WriteLine("Ничья! Оба гладиатора имеют одинаковое количество здоровья.");
        }
    }

    static Gladiator CreateGladiator()
    {
        Console.Write("Введите начальный уровень здоровья: ");
        if (!double.TryParse(Console.ReadLine(), out double health) || health <= 0)
        {
            Console.WriteLine("Ошибка: некорректное значение здоровья.");
            return null!;
        }

        Console.Write("Введите крепость брони в процентах от 0 до 100: ");
        if (!double.TryParse(Console.ReadLine(), out double armorPercent) || armorPercent < 0 || armorPercent > 100)
        {
            Console.WriteLine("Ошибка: некорректное значение брони.");
            return null!;
        }

        return new Gladiator(health, armorPercent);
    }
}

public class Gladiator(double health, double armorPercent)
{
    public double Health { get; private set; } = health;
    public double ArmorPercent { get; private set; } = armorPercent;

    public double LastDamageTaken { get; private set; }

    public void TakeDamage(double attack)
    {
        double armorCoefficient = ArmorPercent / 100.0;
        LastDamageTaken = attack * (1.0 - armorCoefficient);

        Health -= LastDamageTaken;
        ArmorPercent -= attack;

        if (Health < 0) Health = 0;
        if (ArmorPercent < 0) ArmorPercent = 0;
    }
}
