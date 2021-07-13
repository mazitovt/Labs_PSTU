using System;
using System.Collections.Generic;
using System.Collections;

namespace LR13
{

    public class Journal: IEnumerable<JournalRecord>
    {
        public string Name { get; init; }

        public int Count { get => records.Count; }

        private List<JournalRecord> records = new List<JournalRecord>();


// ЗАЧЕМ ДВА РАЗНЫХ МЕТОДА??
        public void CollectionCountChanged(object source, CollectionHandlerEventArgs e)
        {
            records.Add(new JournalRecord { 
                CollectionName = e.CollectionName,
                CollectionChanges = e.CollectionChanges,
                CollectionInfo = e.CollectionInfo,
                ObjectInfo = e.ObjectReference.ToString()
            });
            //Console.WriteLine("Record was saved from CollectionCountChanged.");
        }

// ЗАЧЕМ НУЖНА ССЫЛКА НА ОБЪЕКТ?? 
        public void CollectionReferenceChanged(object source, CollectionHandlerEventArgs e)
        {
            records.Add(new JournalRecord {
                CollectionName = e.CollectionName,
                CollectionChanges = e.CollectionChanges,
                CollectionInfo = e.CollectionInfo,
                ObjectInfo = e.ObjectReference.ToString()
            });
            //Console.WriteLine("Record was saved from CollectionReferenceChanged.");
        }

        public IEnumerator<JournalRecord> GetEnumerator()
        {
            return records.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
