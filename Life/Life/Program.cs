using System;
using Life;
using ConsolePrinterLibrary;

TimeController time = new TimeController();
GameController<ConsolePrinter> gc = new GameController<ConsolePrinter>(time);
time.Run();
Console.ReadKey(true);