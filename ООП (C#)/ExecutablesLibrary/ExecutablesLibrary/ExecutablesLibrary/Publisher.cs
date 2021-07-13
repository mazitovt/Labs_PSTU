using System;

namespace ExecutablesLibrary
{
    public class Publisher: ICloneable, IComparable
    {
        public Publisher()
        {
            Console.WriteLine("\nВведите имя издателя:");
            Name = Console.ReadLine();
            Id = Input.IntInput("Введите ИД издателя (от 1000 до 10000):", 1000, 10000);
        }
        public Publisher(string name, int id)
        {
            Name = name;
            Id = id;
        }
        public string Name { get; set; }
        public int Id { get; set; }

        public object Clone()
        {
            return new Publisher(this.Name, this.Id);
        }

        public int CompareTo(object obj)
        {
            return Id.CompareTo(((Publisher)obj).Id);
        }

        public override bool Equals(object other)
        {
            //return (Name == other.Name && Id == other.Id) ? true : false;

            if (Name == ((Publisher)other).Name && Id == ((Publisher)other).Id)
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {

            //Get hash code for the Name field if it is not null.
            int hashProductName = Name == null ? 0 : Name.GetHashCode();

            //Get hash code for the Code field.
            int hashProductCode = Id.GetHashCode();

            //Calculate the hash code for the product.
            return hashProductName ^ hashProductCode;
        }

        public override string ToString()
        {
            return $"Имя: {Name}, ИД: {Id}";
        }
    }
}