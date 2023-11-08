using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProjHeroesGame
{
    internal class ConsoleUserInterface
    {
        public static Setup setup = new Setup();

        public void CollectGamersAmount()
        {
            Console.Write("Введите количество игроков: ");
            setup.GamersAmount = Convert.ToInt32(Console.ReadLine());

            if (setup.GamersAmount < 2)
            {
                Console.WriteLine("В эту игру можно играть только с друзьями");
                return;
            }
        }

        public string GenerateSetupMessage()
        {
            string setupMessage = $"В игре существует 3 класса \n " +
                    $"1. {nameof(Wizard)}: Здоровье - {new Wizard().Health}, Урон - {new Wizard().Damage} \n " +
                    $"2. {nameof(Warrior)}: Здоровье - {new Warrior().Health}, Урон - {new Warrior().Damage} \n " +
                    $"3. {nameof(Archer)}: Здоровье - {new Archer().Health}, Урон - {new Archer().Damage} \n " +
                    $"Введите номер класса чтобы выбрать класс: ";

            return setupMessage;
        }

        public void CollectGamers()
        {
            int i = 0;
            while (i < setup.GamersAmount)
            {
                Gamer gamer = new Gamer();
                Console.Write($"Введите имя игрока {i + 1}: ");
                gamer.Name = Console.ReadLine();
                Console.Write(GenerateSetupMessage());
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
                    setup.AddGamers(gamer);
                }

                i++;
            }
        }

        public void GenerateFightMessage(int step)
        {
            string gamersDamage = "";
            for (int i = 0; i < setup.GetGamersAmount(); i++)
            {
                if (i != step % setup.GamersAmount)
                {
                    Gamer gamer = setup.GetGamerById(i);
                    gamersDamage += "\n" + Convert.ToString(i) + ". " + gamer.Name + " Здоровье игрока - " + Convert.ToString(gamer.gameCharacter.Health);
                }
            }
            Console.Write($"Выбирите имя игрока по которому хотите нанести урон {gamersDamage} \n Введите номер игрока: ");
        }

        public int Fight(int step)
        {
            Fight fight = new Fight();
            Gamer damagerGamer = setup.GetGamerById(step % setup.GamersAmount);
            Console.Write($"Ход игрока {damagerGamer.Name} \n");

            GenerateFightMessage(step);

            int damagedGamerId = Convert.ToInt32(Console.ReadLine());

            if (damagedGamerId == step % setup.GamersAmount)
            {
                Console.WriteLine("Сэлфхарм в данной игре зпрещен");
                return step;
            }

            if (damagedGamerId >= setup.GetGamersAmount())
            {
                Console.WriteLine("Похоже вы забыли позвать друзей :(");
                return step;
            }

            Gamer damagedGamer = setup.GetGamerById(damagedGamerId);
            bool isDead = fight.Fighting(damagedGamerId, damagerGamer, damagedGamer);

            if (isDead)
            {
                Console.WriteLine($"Игрок {damagerGamer.Name} убил игрока {damagedGamer.Name}");
            }

            return step;

        }
    }
}
