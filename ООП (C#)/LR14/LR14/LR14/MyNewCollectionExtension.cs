using System.Collections.Generic;
using ExecutablesLibrary;
using System.Linq;
using LR13;
using System;

namespace ListExtensionMethods
{
    public static class MyNewCollectionExtension
    {
        public static IEnumerable<File> PublisherFilesLINQ(this List<MyNewCollection<File>> listOfCollections, Publisher p)
        {
            return from collection in listOfCollections
                   from file in collection
                   where file.Publisher.Id == p.Id
                   orderby file.Id
                   select file;
        }

        public static IEnumerable<File> PublisherFilesExtensionMethod(this List<MyNewCollection<File>> listOfCollections, Publisher p)
        {
            return listOfCollections
                .SelectMany(collection => collection)
                .Where(file => file.Publisher.Id == p.Id)
                .OrderBy(file => file.Id)
                .Select(file => file);
        }

        public static int CountLessThanSizeLINQ(this List<MyNewCollection<File>> listOfCollections, int size)
        {
            return (from collection in listOfCollections
                   from file in collection
                   where file.Size < size
                   select file).Count();
        }

        public static int CountLessThanSizeExtensionMethod(this List<MyNewCollection<File>> listOfCollections, int size)
        {
            return listOfCollections.SelectMany(collection => collection).Where(file => file.Size < size).Count();
        }

        public static IEnumerable<string> IntersectPublishersLINQ(this List<MyNewCollection<File>> listOfCollections, int index1, int index2)
        {
            var group1 = from file in listOfCollections[index1]
                         group file by file.Publisher into g1
                         select g1.Key;

            var group2 = from file in listOfCollections[index2]
                         group file by file.Publisher into g2
                         select g2.Key;

            return       from pub1 in group1
                         join pub2 in group2 on pub1.Id equals pub2.Id
                         select pub1.Name;
        }

        public static IEnumerable<string> IntersectPublishersExtensionMethod(this List<MyNewCollection<File>> listOfCollections, int index1, int index2)
        {
            return listOfCollections[index1]
                .Select(file => file.Publisher)
                .Intersect(listOfCollections[index2].Select(file => file.Publisher), new PublisherComp())
                .Select(pub => pub.Name);
        }

        public static double AvgFileSizeByTypeLINQ(this List<MyNewCollection<File>> listOfCollections, Type type)
        {
            try
            {
               var sizes = from collection in listOfCollections
                           from file in collection
                           where type.IsInstanceOfType(file)
                           select file.Size;

                int count = 0;
                double sum = 0;

                foreach (var size in sizes)
                {
                    count++;
                    sum += size;
                }

                return sum / count;
            }
            catch
            {
                return 0;
            }
        }

        public static double AvgFileSizeByTypeExtensionMethod(this List<MyNewCollection<File>> listOfCollections, Type type)
        {
            try
            {
                return listOfCollections
                    .SelectMany(collection => collection)
                    .Where(file => type.IsInstanceOfType(file))
                    //.OfType<>()
                    .Select(file => file.Size)
                    .Average();
            }
            catch
            {
                return 0;
            }
        }

        public static IOrderedEnumerable<IGrouping<int, File>> FilesByPublishersLINQ(this List<MyNewCollection<File>> listOfCollections)
        {
            return from collection in listOfCollections
                   from file in collection
                   group file by file.Publisher.Id into g
                   orderby g.Key
                   select g;
        }

        public static IOrderedEnumerable<IGrouping<Publisher, File>> FilesByPublishersExtensionMethod(this List<MyNewCollection<File>> listOfCollections)
        {
            return listOfCollections
                .SelectMany(collection => collection)
                .GroupBy(file => file.Publisher)
                .OrderBy(group => group.Key);
        }

    }
}
