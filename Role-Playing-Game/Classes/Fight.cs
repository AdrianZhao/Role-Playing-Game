using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Role_Playing_Game.Classes
{
    class Fight
    {
        private Hero _hero;
        public Hero Hero { get { return _hero; } }
        public void SetHero(Hero hero)
        {
            _hero = hero;
        }
        private Monster _monster;
        public Monster Monster { get { return _monster; } }
        public void SetMonster(Monster monster)
        {
            _monster = monster;
        }
        public int HeroTurn(Hero hero, Monster monster)
        {
            int strength = hero.BaseStrength;
            int defence = monster.BaseDefence;
            int weaponDamage = hero.Weapon.Value;
            int attackDamage = strength + weaponDamage - defence;
            if (attackDamage >= 0)
            {
                return attackDamage;
            }
            return 0;
        }
        public int MonsterTurn(Hero hero, Monster monster)
        {
            int strength = monster.BaseStrength;
            int defence = hero.BaseDefence;
            int armourValue = hero.Armour.Value;
            int attackDamage = strength - defence - armourValue;
            if (attackDamage >= 0)
            {
                return attackDamage;
            }
            return 0;
        }
        public bool Result(Hero hero, Monster monster)
        {
            bool heroTurn = true;
            bool isWin = false;
            while (hero.CurrentHealth > 0 && monster.CurrentHealth > 0)
            {
                if (heroTurn)
                {
                    int damageDealt = HeroTurn(hero, monster);
                    if (monster.CurrentHealth - damageDealt > 0)
                    {
                        monster.SetCurrentHealth(monster.CurrentHealth - damageDealt);
                        Console.WriteLine($"{hero.Name} did {damageDealt} damage to monster {monster.Name}, {monster.Name} still have {monster.CurrentHealth}hp left.");
                    }
                    else
                    {
                        Console.WriteLine($"{hero.Name} did {damageDealt} damage to monster {monster.Name}, {monster.Name} have no hp left.");
                        monster.SetCurrentHealth(0);
                        WinGame(hero, monster);
                        hero.SetMoney(hero.Money + 10);
                        hero.EarnMoney(10);
                        isWin = true;
                    }
                }
                else
                {
                    int damageDealt = MonsterTurn(hero, monster);
                    if (hero.CurrentHealth - damageDealt > 0)
                    {
                        hero.SetCurrentHealth(hero.CurrentHealth - damageDealt);
                        Console.WriteLine($"Monster {monster.Name} did {damageDealt} damage to {hero.Name}, {hero.Name} still have {hero.CurrentHealth}hp left.");
                    }
                    else
                    {
                        Console.WriteLine($"Monster {monster.Name} did {damageDealt} damage to {hero.Name}, {hero.Name} have no hp left.");
                        hero.SetCurrentHealth(0);
                        LoseGame(hero, monster);
                    }
                }
                heroTurn = !heroTurn;
            }
            return isWin;
        }
        public void WinGame(Hero hero, Monster monster)
        {
            Console.WriteLine();
            Console.WriteLine("Fight result:");
            Console.WriteLine($"You, {hero.Name} have defeat the monster {monster.Name}. Congratulations!");
            hero.FightsWon();
        }
        public void LoseGame(Hero hero, Monster monster)
        {
            Console.WriteLine();
            Console.WriteLine("Fight result:");
            Console.WriteLine($"You, {hero.Name} have been defeated by the monster {monster.Name}.");
            hero.FightsLost();
        }
    }
}
