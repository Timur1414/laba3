using System;
using System.Collections.Generic;

namespace laba3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vector a = new Vector(1, 2, 3);
            Vector b = new Vector(2, 4, 6);
            Console.WriteLine(a + a == b);

            //List<Car> cars = new List<Car>();
            //cars.Add(new Car("A", "a", 100));
            //cars.Add(new Car("B", "b", 50));
            //CarsCatalog catalog = new CarsCatalog(cars);
            //Console.WriteLine(catalog[0]);

            //CurrencyUSD currencyFrom = new CurrencyUSD(10);
            //CurrencyRUB currencyTo = new CurrencyRUB(0);
            //currencyTo = currencyFrom;
            //Console.WriteLine(currencyTo.Value);
        }

        public struct Vector
        {
            private int x, y, z;
            
            public Vector(int x, int y, int z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }

            public static Vector operator +(Vector a, Vector b)
            {
                return new Vector(a.x + b.x, a.y + b.y, a.z + b.z);
            }
            public static Vector operator *(Vector a, Vector b)
            {
                return new Vector(a.y * b.z - a.z * b.y, a.z * b.x - a.x * b.z, a.x * b.y - a.y * b.x);
            }
            public static Vector operator *(Vector a, int k)
            {
                return new Vector(a.x * k, a.y * k, a.z * k);
            }
            public static bool operator ==(Vector a, Vector b)
            {
                return (a.x == b.x && a.y == b.y && a.z == b.z);
            }
            public static bool operator !=(Vector a, Vector b)
            {
                return (a.x != b.x || a.y != b.y || a.z != b.z);
            }
            public static bool operator >(Vector a, Vector b)
            {
                double length1 = Math.Sqrt(a.x * a.x + a.y * a.y + a.z * a.z);
                double length2 = Math.Sqrt(b.x * b.x + b.y * b.y + b.z * b.z);
                return length1 > length2;
            }
            public static bool operator <(Vector a, Vector b)
            {
                double length1 = Math.Sqrt(a.x * a.x + a.y * a.y + a.z * a.z);
                double length2 = Math.Sqrt(b.x * b.x + b.y * b.y + b.z * b.z);
                return length1 < length2;
            }
        }

        class Car : IEquatable<Car>
        {
            public string Name { get; private set; }
            public string Engine { get; private set; }
            public int MaxSpeed { get; private set; }

            public Car(string name, string engine, int maxSpeed)
            {
                this.Name = name;
                this.Engine = engine;
                this.MaxSpeed = maxSpeed;
            }
            
            public override string ToString()
            {
                return Name;
            }

            public bool Equals(Car other)
            {
                if (other == null) return false;
                return Name == other.Name;
            }

            public override int GetHashCode()
            {
                return Name.GetHashCode();
            }
        }
        class CarsCatalog
        {
            private List<Car> cars;

            public CarsCatalog(List<Car> cars) => this.cars = cars;
            public string this[int index]
            {
                get
                {
                    Car car = cars[index];
                    return $"Name: {car.Name}    Engine: {car.Engine}";
                }
            }
        }


        class Currency
        {
            public int Value { get; private set; }

            public Currency(int value)
            {
                Value = value;
            }
        }
        class CurrencyUSD : Currency
        {
            public CurrencyUSD(int value) : base(value) { }
            public static implicit operator CurrencyEUR(CurrencyUSD item)
            {
                return new CurrencyEUR(item.Value + 1);
            }
            public static implicit operator CurrencyRUB(CurrencyUSD item)
            {
                return new CurrencyRUB(item.Value - 1);
            }
        }
        class CurrencyEUR : Currency
        {
            public CurrencyEUR(int value) : base(value) { }
            public static implicit operator CurrencyUSD(CurrencyEUR item)
            {
                return new CurrencyUSD(item.Value - 1);
            }
            public static implicit operator CurrencyRUB(CurrencyEUR item)
            {
                return new CurrencyRUB(item.Value - 2);
            }
        }
        class CurrencyRUB : Currency
        {
            public CurrencyRUB(int value) : base(value) { }
            public static implicit operator CurrencyUSD(CurrencyRUB item)
            {
                return new CurrencyUSD(item.Value + 1);
            }
            public static implicit operator CurrencyEUR(CurrencyRUB item)
            {
                return new CurrencyEUR(item.Value + 2);
            }
        }
    }
}
