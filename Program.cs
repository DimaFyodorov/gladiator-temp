Console.Write("Введите начальный уровень здоровья: ");
if (!double.TryParse(Console.ReadLine(), out double health))
{
    Console.WriteLine("Ошибка: некорректное значение здоровья.");
    return;
}

Console.Write("Введите крепость брони в процентах от 0 до 100: ");
if (!double.TryParse(Console.ReadLine(), out double armorPercent))
{
    Console.WriteLine("Ошибка: некорректное значение брони.");
    return;
}

Random rand = new();
double attack = rand.NextDouble() * armorPercent;

double armorCoefficient = armorPercent / 100.0;
double damage = attack * (1.0 - armorCoefficient);

double remainingHealth = health - damage;

double remainingArmor = armorPercent - attack;

Console.WriteLine($"""

--- Результаты боя ---
Сила случайного удара:          {attack:F2}
Нанесенный урон с учетом брони: {damage:F2}
Оставшееся здоровье гладиатора: {remainingHealth:F2}
Оставшаяся процент брони:       {remainingArmor:F2}
""");

