RadioSession[] sessions = new RadioSession[1];

for (int i = 0; i < sessions.Length; i++)
{
    Console.Write("Введите позывной: ");
    sessions[i].CallSign = Console.ReadLine();

    Console.Write("Введите частоту: ");
    sessions[i].Frequency = double.Parse(Console.ReadLine());

    Console.Write("Введите дату сеанса (дд.мм.гггг): ");
    sessions[i].Date = DateOnly.Parse(Console.ReadLine());

    Console.Write("Введите время начала сеанса (чч:мм): ");
    sessions[i].StartTime = TimeOnly.Parse(Console.ReadLine());

    Console.Write("Введите время окончания сеанса (чч:мм): ");
    sessions[i].EndTime = TimeOnly.Parse(Console.ReadLine());

    Console.Write("Введите количество переданных групп: ");
    sessions[i].GroupCount = int.Parse(Console.ReadLine());
}

Console.WriteLine("\nСкорость передачи групп в минуту по каждому из сеансов:");
foreach (var session in sessions)
{
    double duration = (session.EndTime - session.StartTime).TotalMinutes;
    double speed = session.GroupCount / duration;
    Console.WriteLine($"Позывной: {session.CallSign}, Скорость: {speed:F2} групп/мин");
}

Console.Write("\nВведите дату для поиска (дд.мм.гггг): ");
DateOnly searchDate = DateOnly.Parse(Console.ReadLine());

Console.Write("Введите начальное время (чч:мм): ");
TimeOnly startTime = TimeOnly.Parse(Console.ReadLine());

Console.Write("Введите конечное время (чч:мм): ");
TimeOnly endTime = TimeOnly.Parse(Console.ReadLine());

Console.WriteLine("\nИнформация о выходе радистов на связь:");
foreach (var session in sessions)
{
    if (session.Date == searchDate && session.StartTime >= startTime && session.EndTime <= endTime)
    {
        Console.WriteLine($"Позывной: {session.CallSign}, Частота: {session.Frequency}, Время: {session.StartTime} - {session.EndTime}");
    }
}
struct RadioSession
{
    public string CallSign;
    public double Frequency;
    public DateOnly Date;
    public TimeOnly StartTime;
    public TimeOnly EndTime;
    public int GroupCount;
}