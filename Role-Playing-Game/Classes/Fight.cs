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
        public int HeroTurn()
        {
            int strength = _hero.BaseStrength;
            int defence = _monster.BaseDefence;
            int weaponDamage = _hero.Weapon.Value;
            int attackDamage = strength + weaponDamage - defence;
            if (attackDamage >= 0)
            {
                return attackDamage;
            }
            return 0;
        }
        public int MonsterTurn()
        {
            int strength = _monster.BaseStrength;
            int defence = _hero.BaseDefence;
            int armourValue = _hero.Armour.Value;
            int attackDamage = strength - defence - armourValue;
            if (attackDamage >= 0)
            {
                return attackDamage;
            }
            return 0;
        }
        public bool Result()
        {
            bool heroTurn = true;
            bool isWin = false;
            bool isHeroDamage = false;
            bool isMonsterDamage = false;
            while (_hero.CurrentHealth > 0 && _monster.CurrentHealth > 0)
            {
                if (heroTurn)
                {
                    int damageDealt = HeroTurn();
                    if (damageDealt == 0)
                    {
                        isHeroDamage = true;
                    }
                    if (_monster.CurrentHealth - damageDealt > 0)
                    {
                        _monster.SetCurrentHealth(_monster.CurrentHealth - damageDealt);
                        Console.WriteLine($"{_hero.Name} did {damageDealt} damage to monster {_monster.Name}, {_monster.Name} still have {_monster.CurrentHealth}hp left.");
                    }
                    else
                    {
                        Console.WriteLine($"{_hero.Name} did {damageDealt} damage to monster {_monster.Name}, {_monster.Name} have no hp left.");
                        _monster.SetCurrentHealth(0);
                        WinGame();
                        _hero.SetMoney(_hero.Money + _monster.Gold);
                        _hero.EarnMoney(_monster.Gold);
                        isWin = true;
                    }
                }
                else
                {
                    int damageDealt = MonsterTurn();
                    if (damageDealt == 0)
                    {
                        isMonsterDamage = true;
                    }
                    if (_hero.CurrentHealth - damageDealt > 0)
                    {
                        _hero.SetCurrentHealth(_hero.CurrentHealth - damageDealt);
                        Console.WriteLine($"Monster {_monster.Name} did {damageDealt} damage to {_hero.Name}, {_hero.Name} still have {_hero.CurrentHealth}hp left.");
                    }
                    else
                    {
                        Console.WriteLine($"Monster {_monster.Name} did {damageDealt} damage to {_hero.Name}, {_hero.Name} have no hp left.");
                        _hero.SetCurrentHealth(0);
                        LoseGame();
                    }
                }
                if (isHeroDamage && isMonsterDamage)
                {
                    EvenGame();
                    return true;
                }
                heroTurn = !heroTurn;
            }
            return isWin;
        }
        public void WinGame()
        {
            Console.WriteLine();
            Console.WriteLine("Fight result:");
            Console.WriteLine($"You, {_hero.Name} have defeat the monster {_monster.Name}. Congratulations!");
            _hero.FightsWon();
        }
        public void LoseGame()
        {
            Console.WriteLine();
            Console.WriteLine("Fight result:");
            Console.WriteLine($"You, {_hero.Name} have been defeated by the monster {_monster.Name}.");
            _hero.FightsLost();
        }
        public void EvenGame()
        {
            Console.WriteLine();
            Console.WriteLine("Fight result:");
            Console.WriteLine($"You, {_hero.Name} did 0 damage to {_monster.Name}. And monster {_monster.Name} did 0 damage to {_hero.Name}. You win the lottery! {_monster.Name} has defeated and here is $100 reward!");
            _hero.FightsWon();
        }
        public Fight(Hero hero, Monster monster)
        {
            SetHero(hero);
            SetMonster(monster);
        }
    }
}
