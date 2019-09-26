using System;
using System.Collections.Generic;
using System.Linq;


namespace sqlite_persistence
{
    class Program
    {
        private static PlayerContext _playerContext = new PlayerContext();

        private static void Main(string[] args)
        {
            ShowPlayerStats();
        }

        private static void ShowPlayerStats()
        {
            Console.WriteLine();
            Console.WriteLine("Your player stats:");
            
            foreach (var player in GetPlayers())
            {
                Console.WriteLine($"{player.Id}: {player.Name} / {player.Shield} - ({player.DateRegistered})");
            }
            ShowPlayerMenu();
        }

        private static List<Player> GetPlayers() => _playerContext.Players.ToList();


        private static void ShowPlayerMenu()
        {
            Console.WriteLine();
            Console.WriteLine("(A)dd Player");
            Console.WriteLine("(#) of Player to Edit");
            Console.WriteLine("(Q)uit");

            var choice = Console.ReadKey(true).KeyChar.ToString();
            int id;
            if (int.TryParse(choice, out id)) EditPlayerData(id);
            else
                switch (choice.ToUpper())
                {
                    case "A":
                        EnterPlayerData();
                        break;

                    case "Q":
                        return;

                    default:
                        ShowPlayerStats();
                        break;
                }
        }

        private static void EnterPlayerData()
        {
            Console.Write("Name of player: ");
            var name = Console.ReadLine();
            Console.Write("Max protection value (1 - 5): ");
            var shield = Console.ReadLine();
            var player = new Player { Name = name, Shield = int.Parse(shield), DateRegistered = DateTime.Now };
            _playerContext.Players.Add(player);
            _playerContext.SaveChanges();
            ShowPlayerStats();
        }

        private static void EditPlayerData(int id)
        {
            var player = _playerContext.Players.Find(id);
            if (player == null)
            {
                Console.WriteLine("Not Found");
            }
            else
            {
                Console.Write($"Name) {player.Name}(Enter for no change): ");
                var name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name)) player.Name = name;

                Console.Write($"Shield) {player.Shield} (Enter for no change): ");
                var shield = Console.ReadLine();
                if (!string.IsNullOrEmpty(shield)) player.Shield = int.Parse(shield);
                player.DateRegistered = DateTime.Now;

                //save it
                _playerContext.SaveChanges();
            }

            ShowPlayerStats();
        }
    }

}

