using System;

namespace FightingGame
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new FightingGame())
                game.Run();
        }
    }
}
