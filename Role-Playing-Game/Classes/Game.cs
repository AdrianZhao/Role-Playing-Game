using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Role_Playing_Game.Classes
{
    class Game
    { 
        private Hero _hero;
        private HashSet<Monster> _monsters;
        private List<WeaponAndArmour> _storeWeapons;
        private List<WeaponAndArmour> _storeArmours;
        private List<WeaponAndArmour> _startWeapon;
        private List<WeaponAndArmour> _startArmour;
        private HashSet<Monster> tempMonsters;
        public Game()
        {
            _monsters = new HashSet<Monster>
            {
                new Monster("Zha Zha", 20, 20, 200),
                new Monster("Nuo Mi", 6, 6, 30),
                new Monster("Xiao Gou", 10, 10, 40),
                new Monster("Hao Mao", 8, 8, 35),
                new Monster("Huai Mao", 9, 9, 10),
                new Monster("Good Cat", 5, 9, 40),
                new Monster("Bad Cat", 9, 3, 20)
            };
            _storeWeapons = new List<WeaponAndArmour>
            {
                new WeaponAndArmour("Wood Sword", 2, 5),
                new WeaponAndArmour("Stone Sword", 4, 15),
                new WeaponAndArmour("Iron Sword", 8, 25),
                new WeaponAndArmour("Gold Sword", 16, 35),
                new WeaponAndArmour("Diamond Sword", 32, 45)
            };
            _storeArmours = new List<WeaponAndArmour>
            {
                new WeaponAndArmour("Stone Armour", 4, 15),
                new WeaponAndArmour("Iron Armour", 8, 25),
                new WeaponAndArmour("Gold Armour", 16, 35),
                new WeaponAndArmour("Diamond Armour", 32, 45)
            };
            _startWeapon = new List<WeaponAndArmour>
            {
                new WeaponAndArmour("Green Wood Stick", 2, 0),
                new WeaponAndArmour("Blue Wood Stick", 2, 0),
                new WeaponAndArmour("Yellow Wood Stick", 2, 0)
            };
            _startArmour = new List<WeaponAndArmour>
            {
                new WeaponAndArmour("Green Wood Armour", 2, 0),
                new WeaponAndArmour("Blue Wood Armour", 2, 0),
                new WeaponAndArmour("Yellow Wood Armour", 2, 0)
            };
            tempMonsters = _monsters;
        }
        public void StartGame()
        {
            Console.WriteLine("Welcome to the beat Monster Game!");
            Console.WriteLine();
            CreateHero();
            EquipHero();
            MainMenu();
        }
        private void CreateHero()
        {
            Console.WriteLine("Create your hero:");
            _hero = new Hero();
            Console.WriteLine();
            Console.WriteLine($"Hero {_hero.Name} has been created!");
        }
        private void EquipHero()
        {
            Console.WriteLine();
            Console.WriteLine("Equip your hero:");
            Console.WriteLine("Available weapons:");
            DisplayItems(_startWeapon);
            int weaponIndex = 0;
            bool isValidInput1 = false;
            while (!isValidInput1)
            {
                isValidInput1 = int.TryParse(Console.ReadLine(), out weaponIndex);
                if (weaponIndex > _startWeapon.Count || weaponIndex < 1)
                {
                    isValidInput1 = false;
                    Console.WriteLine($"Please enter a proper value in the list.");
                }
            }
            _hero.SetWeapon(_startWeapon.ElementAt(weaponIndex - 1));
            Console.WriteLine($"You choosed \"{_hero.Weapon.Name}\" for your start weapon");
            Console.WriteLine();
            Console.WriteLine("Available armours:");
            DisplayItems(_startArmour);
            int armourIndex = 0;
            bool isValidInput2 = false;
            while (!isValidInput2)
            {
                isValidInput2 = int.TryParse(Console.ReadLine(), out armourIndex);
                if (armourIndex > _startArmour.Count || armourIndex < 1)
                {
                    isValidInput2 = false;
                    Console.WriteLine($"Please enter a proper value in the list.");
                }
            }
            _hero.SetArmour(_startArmour.ElementAt(armourIndex - 1));
            Console.WriteLine($"You choosed \"{_hero.Armour.Name}\" for your start armour");
            Console.WriteLine();
            GetStatus(_hero);
            Console.WriteLine();
        }
        public void MainMenu()
        {
            Console.WriteLine("MAIN MENU");
            Console.WriteLine("1. Display Statistics");
            Console.WriteLine("2. Fight Monsters");
            Console.WriteLine("3. Hero Status");
            Console.WriteLine("4. Go To The Store.");
            Console.WriteLine("5. Exit");
            Console.WriteLine();
            bool isValidInput = false;
            int index;
            while (!isValidInput)
            {
                isValidInput = int.TryParse(Console.ReadLine(), out index);
                switch (index)
                {
                    case 1:
                        DisplayStatistics();
                        break;
                    case 2: 
                        FightMonsters();
                        break;
                    case 3: 
                        GetStatus(_hero);
                        isValidInput = false;
                        MainMenu();
                        break;
                    case 4:
                        StoreMenu();
                        isValidInput = false;
                        break;
                    case 5:
                        Console.WriteLine();
                        Console.WriteLine("You choose to exit. Game is over now.");
                        Environment.Exit(0);
                        break;
                    default: 
                        isValidInput = false;
                        Console.WriteLine("Please enter a valid input.");
                        break;
                }
            }
        }
        private void DisplayStatistics()
        {
            Console.WriteLine($"Number of games played: {_hero.FightWon + _hero.FightLost}");
            Console.WriteLine($"Number of fights won: {_hero.FightWon}");
            Console.WriteLine($"Number of fights lost: {_hero.FightLost}");
            Console.WriteLine($"Number of total money earned: {_hero.TotalMoney}");
            Console.WriteLine();
            MainMenu();
        }
        public void StoreMenu()
        {
            bool isExit = false;
            do
            {
                Console.WriteLine("STORE MENU");
                Console.WriteLine("1. Shop weapons");
                Console.WriteLine("2. Shop armours");
                Console.WriteLine("Press Enter to return to Main Menu");
                int tempIndex;
                bool isInput = false;
                while (!isInput)
                {
                    string temp = Console.ReadLine();
                    if (string.IsNullOrEmpty(temp))
                    {
                        isExit = true;
                        break;
                    }
                    else
                    {
                        isInput = int.TryParse(temp, out tempIndex);
                        if (tempIndex == 1)
                        {
                            int storeWeapon;
                            Console.WriteLine($"You have ${_hero.Money}. Here are the weapons in store:");
                            DisplayItems(_storeWeapons);
                            Console.WriteLine("Press Enter to return to Main Menu");
                            bool isValidInput = false;
                            while (!isValidInput)
                            {
                                string tempString = Console.ReadLine();
                                if (string.IsNullOrEmpty(tempString))
                                {
                                    isExit = true;
                                    break;
                                }
                                else
                                {
                                    isValidInput = int.TryParse(tempString, out storeWeapon);
                                    if (storeWeapon > _storeWeapons.Count || storeWeapon < 1)
                                    {
                                        isValidInput = false;
                                        Console.WriteLine("Please enter a proper value in the list.");
                                        Console.WriteLine("Press Enter to return to Main Menu");
                                    }
                                    else if (_hero.Money < _storeWeapons.ElementAt(storeWeapon - 1).Price)
                                    {
                                        isValidInput = false;
                                        Console.WriteLine($"You don't have enough money to buy {_storeWeapons.ElementAt(storeWeapon - 1).Name}.");
                                        Console.WriteLine("Press Enter to return to Main Menu");
                                    }
                                    else
                                    {
                                        _hero.SetMoney(_hero.Money - _storeWeapons.ElementAt(storeWeapon - 1).Price);
                                        _hero.SetWeapon(_storeWeapons.ElementAt(storeWeapon - 1));
                                        Console.WriteLine($"You have equiped with new weapon {_storeWeapons.ElementAt(storeWeapon - 1).Name}");
                                        Console.WriteLine($"Now you have ${_hero.Money}");
                                    }
                                }
                            }
                        } 
                        else if (tempIndex == 2)
                        {
                            int storeArmours;
                            Console.WriteLine($"You have ${_hero.Money}. Here are the weapons in store:");
                            DisplayItems(_storeArmours);
                            Console.WriteLine("Press Enter to return to Main Menu");
                            bool isValidInput = false;
                            while (!isValidInput)
                            {
                                string tempString = Console.ReadLine();
                                if (string.IsNullOrEmpty(tempString))
                                {
                                    isExit = true;
                                    break;
                                }
                                else
                                {
                                    isValidInput = int.TryParse(tempString, out storeArmours);
                                    if (storeArmours > _storeArmours.Count || storeArmours < 1)
                                    {
                                        isValidInput = false;
                                        Console.WriteLine("Please enter a proper value in the list.");
                                        Console.WriteLine("Press Enter to return to Main Menu");
                                    }
                                    else if (_hero.Money < _storeArmours.ElementAt(storeArmours - 1).Price)
                                    {
                                        isValidInput = false;
                                        Console.WriteLine($"You don't have enough money to buy {_storeArmours.ElementAt(storeArmours - 1).Name}.");
                                        Console.WriteLine("Press Enter to return to Main Menu");
                                    }
                                    else
                                    {
                                        _hero.SetMoney(_hero.Money - _storeArmours.ElementAt(storeArmours - 1).Price);
                                        _hero.SetArmour(_storeArmours.ElementAt(storeArmours - 1));
                                        Console.WriteLine($"You have equiped with new weapon {_storeArmours.ElementAt(storeArmours - 1).Name}");
                                        Console.WriteLine($"Now you have ${_hero.Money}");
                                    }
                                }
                            }
                        }
                        else
                        {
                            isInput = false;
                            Console.WriteLine("Please enter a proper value in the list.");
                            Console.WriteLine("Press Enter to return to Main Menu");
                        }
                    }
                }
            } while (!isExit);
            MainMenu();
        }
        public void GetStatus(Hero hero)
        {
            Console.WriteLine("Here is your hero status:");
            Console.WriteLine($"Hero Name: {hero.Name}");
            Console.WriteLine($"Hero Health: {hero.CurrentHealth}");
            Console.WriteLine($"Hero Strength: {hero.BaseStrength}");
            Console.WriteLine($"Hero Defence: {hero.BaseDefence}");
            Console.WriteLine($"Hero Weapon: {hero.Weapon.Name}");
            Console.WriteLine($"Hero Armour: {hero.Armour.Name}");
            Console.WriteLine();
            MainMenu();
        }
        private void DisplayItems(List<WeaponAndArmour> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {items[i].Name} (Power: {items[i].Value}, Price: {items[i].Price})");
            }
        }
        private Random _random = new Random();
        private Monster GetRandomMonster(HashSet<Monster> tempMonsters)
        {
            if (tempMonsters.Count <= 0)
            {
                Console.WriteLine();
                Console.WriteLine("You already beat all the monsters in the game. You win the game!");
                Environment.Exit(0);
            }
            int index = _random.Next(tempMonsters.Count);
            Monster monster = tempMonsters.ElementAt(index);
            tempMonsters.Remove(tempMonsters.ElementAt(index));
            return monster;
        }
        public void ResetMonster()
        {
            tempMonsters = _monsters;
        }
        public void FightMonsters()
        {
            Monster monster = GetRandomMonster(tempMonsters);
            Console.WriteLine("Fight begins now:");
            Console.WriteLine();
            Fight fight = new Fight();
            fight.SetHero(_hero);
            fight.SetMonster(monster);
            if (!fight.Result(_hero, monster))
            {
                ResetMonster();
                _hero.SetCurrentHealth(_hero.OriginalHealth);
                Console.WriteLine();
                Console.WriteLine($"{_hero.Name} is dead.");
                Console.WriteLine($"{_hero.Name} is Revivaled. Game restart.");
                Console.WriteLine($"The monster has been reset.");
                Console.WriteLine();
                GetStatus(_hero);
            }
            MainMenu();
        }
    }
}
