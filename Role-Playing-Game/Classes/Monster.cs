using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Role_Playing_Game.Classes
{
    class Monster
    {
        private string _name;
        public string Name { get { return _name; } }
        public void SetName(string name)
        {
            if (name.Length >= 3 && name.Length <= 20)
            {
                _name = name;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(name), "Your monster name should be 3 to 20 characters long.");
            }
        }
        private int _baseStrength;
        public int BaseStrength { get { return _baseStrength; } }
        private int _baseDefence;
        public int BaseDefence { get { return _baseDefence; } }
        private int _originalHealth;
        public int OriginalHealth { get { return _originalHealth; } }
        private int _currentHealth;
        public int CurrentHealth { get { return _currentHealth; } }
        private static int _gold = 10;
        public int Gold { get { return _gold; } }
        public void SetCurrentHealth(int currentHealth)
        {
            if (currentHealth >= 0 && currentHealth <= OriginalHealth)
            {
                _currentHealth = currentHealth;
            }
            else
            {
                _currentHealth = 0;
            }
        }
        public void SetBaseStrength(int baseStrength)
        {
            if (baseStrength > 0)
            {
                _baseStrength = baseStrength;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(baseStrength), "Your monster's base strenght is too low.");
            }
        }
        public void SetBaseDefence(int baseDefence)
        {
            if (baseDefence > 0)
            {
                _baseDefence = baseDefence;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(baseDefence), "Your monster's base defence is too low.");
            }
        }
        public void SetOriginalHealth(int originalHealth)
        {
            if (originalHealth > 0)
            {
                _originalHealth = originalHealth;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(originalHealth), "Your monster's original health is too low.");
            }
        }
        public Monster(string name, int baseStrength, int baseDefence, int originalHealth)
        {
            SetName(name);
            SetBaseStrength(baseStrength);
            SetBaseDefence(baseDefence);
            SetOriginalHealth(originalHealth);
            SetCurrentHealth(OriginalHealth);
        }
    }
}
