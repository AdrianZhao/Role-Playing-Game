using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Role_Playing_Game.Classes
{
    class Hero
    {
        private string _name;
        public string Name { 
            get { return _name; } 
        }
        public void SetName()
        {
            bool isName = false;
            while (!isName)
            {
                Console.Write("Enter your hero name (3 to 20 characters): ");
                string name = Console.ReadLine();
                Console.WriteLine();
                if (!String.IsNullOrEmpty(name) && name.Length >= 3 && name.Length <= 20)
                {
                    isName = true;
                    _name = name;
                }
                else
                {
                    Console.WriteLine("Your hero name should be 3 to 20 characters long.");
                }
            }
        }
        private static int s_total = 50;
        private int _baseStrength;
        public int BaseStrength { get { return _baseStrength; } }
        private int _baseDefence;
        public int BaseDefence { get { return _baseDefence; } }
        private int _originalHealth;
        public int OriginalHealth { get { return _originalHealth; } }
        private int _currentHealth;
        public int CurrentHealth { get { return _currentHealth; } }
        private int _money = 0;
        public int Money { get { return _money; } }
        private int _totalMoney = 0;
        public int TotalMoney { get { return _totalMoney; } }
        private int _fightsWon = 0;
        public int FightWon { get { return _fightsWon; } }
        private int _fightsLost = 0;
        public int FightLost { get { return _fightsLost; } }
        public void FightsWon()
        {
            _fightsWon++;
        }
        public void FightsLost()
        {
            _fightsLost++;
        }
        public void EarnMoney(int amount)
        {
            _totalMoney += amount;
        }
        public void SetCurrentHealth(int currentHealth)
        {
            if (currentHealth > 0 && currentHealth <= OriginalHealth) 
            {
                _currentHealth = currentHealth;
            }
            else if (currentHealth > 0 && currentHealth > OriginalHealth)
            {
                _currentHealth = OriginalHealth;
            }
            else
            {
                _currentHealth = 0;
            }
        }
        public void AddBaseStrength(int baseStrength)
        {
            if (baseStrength > 0)
            {
                _baseStrength += baseStrength;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(baseStrength), "You have to put a proper value to add strength.");
            }
        }
        public void AddBaseDefence(int baseDefence)
        {
            if (baseDefence > 0)
            {
                _baseDefence += baseDefence;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(baseDefence), "You have to put a proper value to add strength.");
            }
        }
        private WeaponAndArmour _weapon;
        public WeaponAndArmour Weapon { get { return _weapon; } }
        public void SetWeapon(WeaponAndArmour weapon)
        {
            _weapon = weapon;
        }
        private WeaponAndArmour _armour;
        public WeaponAndArmour Armour { get { return _armour; } }
        public void SetArmour(WeaponAndArmour armour)
        {
            _armour = armour;
        }
        public void SetMoney(int money)
        {
            _money = money;
        }
        public Hero()
        {
            SetName();
            Random rnd = new Random();
            _originalHealth = rnd.Next(10, s_total - 10);
            SetCurrentHealth(_originalHealth);
            _baseStrength = rnd.Next(5, s_total - _originalHealth - 5);
            _baseDefence = s_total - _originalHealth - _baseStrength;
        }
    }
}
