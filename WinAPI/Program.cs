using PInvoke;
using System.Security.Principal;


// Получение дескриптора текущего окна при помощи nuget пакета PInvoke
IntPtr actWinHandle = User32.GetForegroundWindow();
Console.WriteLine($"Дескриптор текущего окна (HWID): {actWinHandle}");

// Получение названия текущего открытого окна
var curWinName = User32.GetWindowText(User32.GetForegroundWindow());
Console.WriteLine($"Название текущего окна: {curWinName}");

// Проверка на запуск программы от имени администратора (работает при выполненном Release)
if (WindowsIdentity.GetCurrent().Owner.IsWellKnown(WellKnownSidType.BuiltinAdministratorsSid))
    Console.WriteLine($"Приложение запущено пользователем {WindowsIdentity.GetCurrent().Name}, с правами администратора");
else
    Console.WriteLine($"Приложение запущено пользователем {WindowsIdentity.GetCurrent().Name}, без прав администратора");

// бесконечный цикл для проверки соотетствия текущего активного окна предыдущему
while (true)
{
    // Провекра соотвтетствия текущего окна предыдущего
    if (actWinHandle != User32.GetForegroundWindow())
    {
        actWinHandle = User32.GetForegroundWindow();
        curWinName = User32.GetWindowText(User32.GetForegroundWindow());
        Console.WriteLine($"Название текущего окна изменилось на: {curWinName}");
    }

    // Пауза для разгрузки процессора
    Thread.Sleep(TimeSpan.FromMilliseconds(200));

}