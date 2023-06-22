using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Role_Playing_Game.Classes
{
    class WeaponAndArmour
    {
        private string _name;
        public string Name { get { return _name; } }
        private int _value;
        public int Value { get { return _value; } }
        private int _price;
        public int Price { get { return _price; } }
        public WeaponAndArmour(string name, int value, int price)
        {
            if (!string.IsNullOrEmpty(name))
            {
                _name = name;
            }
            else
            {
                throw new ArgumentNullException(nameof(name), "Weapon and Armour needs a proper name.");
            }
            if (value >= 0)
            {
                _value = value;
            }
            else
            {
                throw new ArgumentException(nameof(value), "The value needs to be a proper value.");
            }
            if (price >= 0)
            {
                _price = price;
            }
            else
            {
                throw new ArgumentException(nameof(price), "The price needs to be a proper value.");
            }
        }
    }
}
