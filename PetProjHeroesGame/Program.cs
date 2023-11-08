using PetProjHeroesGame;


namespace Programm
{
    class Programm
    {
        public static ConsoleUserInterface consoleUserInterface = new ConsoleUserInterface();
        public static Setup setup = new Setup();

        static void Main(string[] args)
        {
            consoleUserInterface.CollectGamersAmount();
            consoleUserInterface.CollectGamers();

            int step = 0;
            while (setup.GetGamersAmount() > 1)
            {
                step = consoleUserInterface.Fight(step);

                step++;
            }

        }
    }
}