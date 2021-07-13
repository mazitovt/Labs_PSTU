using System;
using System.Reflection;

namespace ExecutablesLibrary
{
    public class File : ShortFile, IComparable, ICloneable
    {


//----------СВОЙСТВА----------
        public static string Type = "Файл";
        public void Init()
        {
            Console.Write("\nВведите имя: ");
            Name = Console.ReadLine();
            Size = Input.IntInput("Введите размер файла (от 0 до 500000): ", 0, 500000);
            Id = Input.IntInput("Введите ИД (от 100 до 9999): ", 100, 9999);
            Publisher = new Publisher();
        }
        public string Extension { get; set; }
        public Publisher Publisher { get; set; }
        public int Size { get; set; }
        public string FileType { get; set; }     
        public ShortFile BaseFile
        {
            get
            {
                return new ShortFile
                {
                    Name = this.Name,
                    Id = this.Id,                 
                };
            }
        }


//----------ПУБЛИЧНЫЕ МЕТОДЫ----------
        public object ShallowClone()
        {
            return this.MemberwiseClone();
        }
 
        public object Clone()
        {
            Publisher p = new Publisher(this.Publisher.Name, this.Publisher.Id);

            Type type = this.GetType();
            ConstructorInfo[] ctor = type.GetConstructors();
            var temp = ctor[1].Invoke(new object[] { this.Name, this.Size, this.Id, p });

            return temp;
        }

        public int CompareTo(object obj)
        {
            File file = (File)obj;

            if (Size == file.Size) return 0;
            if (Size > file.Size) return 1;
            else return -1;
        }

        public string GetInfo()
        {
            return $"Name: {Name}, Id: {Id}, Size: {Size} MB, Publisher : {Publisher.Id}, {Publisher.Name}";
        }

        public void ShowInfo()
        {
            Console.WriteLine($"| Name: {Name,-27} | Id: {Id,3} | Size: {Size,10} MB | Publisher: {Publisher.Id}, {Publisher.Name,-10}|");
        }

        public override string ToString()
        {
            return $"Имя: {Name,-25}| ИД: {Id,-8} | Размер: {Size,6} Mb | Издатель: {Publisher}";
        }

        public virtual void ShowStatus()
        {
            Console.WriteLine("Статус файла не доступен.");
        }

        public override bool Equals(object other)
        {
            if (
                Name == ((File)other).Name &&
                Id == ((File)other).Id &&
                Size == ((File)other).Size &&
                Publisher.Equals(((File)other).Publisher)
                )

            //    var a = Name == ((File)other).Name;
            //var b = Id == ((File)other).Id;
            //var c = Size == ((File)other).Size;
            //var d = Publisher.Equals(((File)other).Publisher);

            //if (a && b && c && d)
            {
                return true;
            }
            else
            {
                return false;
            }
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
    }
}