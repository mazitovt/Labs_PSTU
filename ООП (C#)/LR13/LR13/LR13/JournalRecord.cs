using System;

namespace LR13
{
    //открытое автореализуемое свойство типа string с названием коллекции, в которой произошло событие; 
    //открытое автореализуемое свойство типа string с информацией о типе изменений в коллекции;
    //открытое автореализуемое свойство типа string c данными объекта, с которым связаны изменения в коллекции; 
    //конструктор для инициализации полей класса; 
    //перегруженную версию метода string ToString(). 
    //всех элементах массива.
    public class JournalRecord
    {


        //-----------СВОЙСТВА-----------
        public string ChangesTime { get; set; }
        
        public string CollectionName { get; set; }

        public string CollectionInfo { get; set; }

        public string CollectionChanges { get; set; }

        public string ObjectInfo{ get; set; }


        //-----------КОНСТРУТКОРЫ-----------
        public JournalRecord()
        {
            ChangesTime = DateTime.Now.ToString();
        }

        public JournalRecord(string name, string changes, string colinfo, string objinfo)
        {
            (CollectionName, CollectionChanges, CollectionInfo, ObjectInfo, ChangesTime) = (name, changes, colinfo, objinfo, DateTime.Now.ToString());
        }


        //-----------МЕТОДЫ КЛАССА OBJECT-----------
        public override string ToString()
        {
            return 
                $"\n1. Время: {ChangesTime};" + 
                $"\n2. Название коллекции: {CollectionName};" + 
                $"\n3. Сведения о коллекции: {CollectionInfo};" + 
                $"\n4. Событие: {CollectionChanges};" + 
                $"\n5. Краткие сведения о элементе:\n {ObjectInfo}";
        }
    }
}
