using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ExecutablesLibrary
{
    public class PublisherComp : IEqualityComparer<Publisher>
    {
        public bool Equals([AllowNull] Publisher x, [AllowNull] Publisher y)
        {
            return Publisher.Equals(x, y);
        }

        public int GetHashCode([DisallowNull] Publisher obj)
        {
            return obj.GetHashCode();
        }
    }
}