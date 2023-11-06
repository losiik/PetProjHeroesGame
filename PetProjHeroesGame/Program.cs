using PetProjHeroesGame;


namespace Programm
{
    class Programm
    {
        static public int GamersAmount;
        public static List<Gamer> gamersList = new List<Gamer>();

        static void CollectGamers() 
        {
            Console.Write("Введите количество игроков: ");
            GamersAmount = Convert.ToInt32(Console.ReadLine());

            if (GamersAmount < 2) 
            {
                Console.WriteLine("В эту игру можно играть только с друзьями");
                return;
            }

            int i = 0;
            while (i < GamersAmount)
            {
                Gamer gamer = new Gamer();
                Console.Write($"Введите имя игрока {i + 1}: ");
                gamer.Name = Console.ReadLine();
                Console.Write(
                    $"В игре существует 3 класса \n " +
                    $"1. {nameof(Wizard)}: Здоровье - {new Wizard().Health}, Урон - {new Wizard().Damage} \n " +
                    $"2. {nameof(Warrior)}: Здоровье - {new Warrior().Health}, Урон - {new Warrior().Damage} \n " +
                    $"3. {nameof(Archer)}: Здоровье - {new Archer().Health}, Урон - {new Archer().Damage} \n " +
                    $"Введите номер класса чтобы выбрать класс: "
                    );
                string? characterClass = Console.ReadLine();

                switch (characterClass)
                {
                    case "1":
                        gamer.gameCharacter = new Wizard();
                        break;
                    case "2":
                        gamer.gameCharacter = new Warrior();
                        break;
                    case "3":
                        gamer.gameCharacter = new Archer();
                        break;
                    default:
                        Console.WriteLine("Такого варианта не существует, попробуйте другой");
                        i--;
                        break;
                }

                if (gamer.gameCharacter != null) 
                {
                    gamersList.Add(gamer);
                }
                
                i++;
            }
        }

        static void GenerateFightMessage(int step) 
        {
            string gamersDamage = "";
            for (int i = 0; i < gamersList.Count; i++)
            {
                if (i != step % GamersAmount)
                {
                    gamersDamage += "\n" + Convert.ToString(i) + ". " + gamersList[i].Name + " Здоровье игрока - " + Convert.ToString(gamersList[i].gameCharacter.Health);
                }
            }
            Console.Write($"Выбирите имя игрока по которому хотите нанести урон {gamersDamage} \n Введите номер игрока: ");
        }

        static int Fight(int step) 
        {
            Gamer gamer = gamersList[step % GamersAmount];
            Console.Write($"Ход игрока {gamer.Name} \n");

            GenerateFightMessage(step);

            int damagedGamer = Convert.ToInt32(Console.ReadLine());

            if (damagedGamer == step % GamersAmount)
            {
                Console.WriteLine("Сэлфхарм в данной игре зпрещен");
                return step;
            }

            if (damagedGamer >= gamersList.Count)
            {
                Console.WriteLine("Похоже вы забыли позвать друзей :(");
                return step;
            }

            gamersList[damagedGamer].gameCharacter.GetDamage(gamer.gameCharacter.Damage);

            if (gamersList[damagedGamer].gameCharacter.isDead)
            {
                Console.WriteLine($"Игрок {gamer.Name} убил игрока {gamersList[damagedGamer].Name}");
                gamersList.RemoveAt(damagedGamer);
            }

            return step;

        }

        static void Main(string[] args)
        {
            CollectGamers();

            int step = 0;
            while (gamersList.Count > 1) 
            {
                step = Fight(step);

                step++;
            }

        }
    }
}