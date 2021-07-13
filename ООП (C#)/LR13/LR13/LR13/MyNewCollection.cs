using System;
using System.Collections.Generic;
using LR12_2;

namespace LR13
{
    // СОРТИРОВКА??
    // ОЧИСТКА??

    //CollectionCountChanged, которое происходит при добавлении нового элемента в коллекцию или при удалении элемента из коллекции;
    //через объект CollectionHandlerEventArgs cобытие передает имя коллекции, строку с информацией о том, 
    //что в коллекцию был добавлен новый элемент или из нее был удален элемент, ссылку на добавленный или удаленный элемент;

    //CollectionReferenceChanged, которое происходит, когда одной из ссылок, входящих в коллекцию, присваивается новое значение; 
    //через объект CollectionHandlerEventArgs событие передает имя коллекции, строку с информацией о том, 
    //что был заменен элемент в коллекции, и ссылку на новый элемент.
    public class MyNewCollection<T>: MyCollection<T> where T : ICloneable
    {

//---------СВОЙСТВА---------
        public string Name { get; init; }


//---------СОБЫТИЯ---------
        public event CollectionHandler CollectionCountChanged;
        public event CollectionHandler CollectionReferenceChanged;


//---------ИНДЕКСАТОР---------
        public override T this[int index] 
        { 
            get => base[index];
            set 
            {
                base[index] = value; 
                OnCollectionReferenceChanged(new CollectionHandlerEventArgs(this.Name, "Замена элемента", this.ToString(), this[index]));
            }
        }


//---------КОНСТРУТОРЫ---------
        public MyNewCollection(): base()
        {
            Name = "Коллекция без имени";
        }

        public MyNewCollection(string name): base()
        {
            Name = name;
        }

        public MyNewCollection(string name, int capacity) : base(capacity)
        {
            Name = name;
        }

        public MyNewCollection(string name, IEnumerable<T> enumerable)
        {
            Name = name;

            foreach (var item in enumerable)
                Add(item);
        }


        //---------ДЕКОНСТРУТКОР---------


        //---------ДЕСТРУТКОР---------


//--------МЕТОДЫ ДЛЯ ЗАПУСКА СОБЫТИЙ--------
        public virtual void OnCollectionCountChanged(CollectionHandlerEventArgs e)
        {
            CollectionCountChanged?.Invoke(this, e);
        }

        public virtual void OnCollectionReferenceChanged(CollectionHandlerEventArgs e)
        {
            CollectionReferenceChanged?.Invoke(this, e);
        }


//---------ПЕРЕГРУЖЕННЫЕ МЕТОДЫ MyCollection---------
        public override void Add(T item)
        {
            base.Add(item);
            OnCollectionCountChanged(new CollectionHandlerEventArgs(Name, "Добавление одного элемента", this.ToString(), item));
        }

        // КАК СДЕЛАТЬ ТАК, ЧТОБЫ ЭТОТ МЕТОД РОДИТЕЛЯ ВЫЗЫВАЛ СВОЙ МЕТОД MyCollection.Add(), А НЕ ПЕРЕГРУЖЕННЫЙ
        public override void AddMany(T[] items)
        {
            base.AddMany(items);
            OnCollectionCountChanged(new CollectionHandlerEventArgs(Name, 
                $"Добавление {(items.Length % 10 == 1 ? "элемента" :  "элементов")}", 
                this.ToString(), items[0]));
        }

        public override bool Remove(int index)
        {
            T temp;
            try
            {
                temp = this[index];
            }
            catch (Exception)
            {
                return false;
            }

            if (base.Remove(index))
            {
                OnCollectionCountChanged(new CollectionHandlerEventArgs(Name, "Удаление одного элемента", this.ToString(), temp));
                return true;
            }

            return false;
        }

        public override bool Remove(T item)
        {
            if (base.Remove(item))
            {
                OnCollectionCountChanged(new CollectionHandlerEventArgs(Name, "Удаление одного элемента", this.ToString(), item));
                return true;
            }

            return false;
        }


//---------ПЕРЕГРУЖЕННЫЕ МЕТОДЫ Object---------
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
