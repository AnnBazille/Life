using System;
using Life;
using ConsolePrinterLibrary;

TimeController<ConsolePrinter> time = new TimeController<ConsolePrinter>();
time.GameControllers.Add(new GameController<ConsolePrinter>(new Cell23()));
time.Run();
Console.ReadKey(true);