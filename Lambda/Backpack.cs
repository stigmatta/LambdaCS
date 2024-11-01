using System;
using System.Collections.Generic;

namespace BackpackClass
{
    public delegate void AddHandler(BackpackObj obj);

    public class Arrays
    {
        public static string[] Fabrics = { "Cotton", "Silk", "Wool", "Linen", "Polyester" };
    }

    public class BackpackObj
    {
        private int volume;
        private string name;

        public int Volume
        {
            get => volume;
            set
            {
                if (value > 0)
                {
                    volume = value;
                }
            }
        }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name can't be null or empty");
                }
                name = value;
            }
        }

        public BackpackObj(string name, int volume)
        {
            Name = name;
            Volume = volume;
        }
    }

    public class Backpack
    {
        private string color, manufactor, fabrics;
        private int weight, volume;
        private int occupiedVolume;
        private List<BackpackObj> objects;

        public event AddHandler ObjectAdded;

        public string Color
        {
            get => color;
            set
            {
                if (Enum.TryParse<ConsoleColor>(value, true, out _))
                {
                    color = value;
                }
                else
                {
                    throw new ArgumentException("Color isn't valid");
                }
            }
        }

        public string Manufactor
        {
            get => manufactor;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Manufactor can't be null or empty");
                }
                manufactor = value;
            }
        }

        public string Fabrics
        {
            get => fabrics;
            set
            {
                if (Array.Exists(Arrays.Fabrics, fabric => fabric.Equals(value, StringComparison.OrdinalIgnoreCase)))
                {
                    fabrics = value;
                }
                else
                {
                    throw new ArgumentException("There is no such fabric");
                }
            }
        }

        public int Weight
        {
            get => weight;
            set
            {
                if (value > 0)
                {
                    weight = value;
                }
            }
        }

        public int Volume
        {
            get => volume;
            set
            {
                if (value > 0)
                {
                    volume = value;
                }
            }
        }

        public Backpack(string color, string manufactor, string fabrics, int weight, int volume)
        {
            Color = color;
            Manufactor = manufactor;
            Fabrics = fabrics;
            Weight = weight;
            Volume = volume;
            occupiedVolume = 0;
            objects = new List<BackpackObj>();

            ObjectAdded += delegate (BackpackObj obj)
            {
                Console.WriteLine($"Object '{obj.Name}' added to the backpack.");
            };
        }

        public void AddObject(BackpackObj obj)
        {
            if (obj == null)
            {
                Console.WriteLine("Object cannot be null.");
                return;
            }

            if (occupiedVolume + obj.Volume > Volume)
            {
                throw new InvalidOperationException("Not enough volume in the backpack to add this object.");
            }

            objects.Add(obj);
            occupiedVolume += obj.Volume;
            ObjectAdded?.Invoke(obj);
        }
    }
}
