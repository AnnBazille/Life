using System;
using LifeLibrary;
using ConsolePrinterLibrary;

TimeController<ConsolePrinter> time = new TimeController<ConsolePrinter>();
time.GameControllers.Add(new GameController<ConsolePrinter>(new Cell233<ConsolePrinter>()));
time.Run();
Console.ReadKey(true);