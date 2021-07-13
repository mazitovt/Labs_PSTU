using System;

namespace LR13
{
    public class CollectionHandlerEventArgs: EventArgs
    {
        public string CollectionName { get; set; }

        public string CollectionChanges { get; set; }

        public string CollectionInfo { get; set; }

        public object ObjectReference { get; set; }

        public CollectionHandlerEventArgs()
        {
        
        }

        public CollectionHandlerEventArgs(string name, string changes, string colinfo, object reference)
        {
            (CollectionName, CollectionChanges, CollectionInfo, ObjectReference) = (name, changes, colinfo, reference);
        }


        public override string ToString()
        {
            return
                $"\n1. Название коллекции: {CollectionName};" +
                $"\n2. Сведения о коллекции: {CollectionInfo};" +
                $"\n3. Событие: {CollectionChanges};";
        }
    }
}
