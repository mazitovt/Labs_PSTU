using System.Collections;

namespace FacultyISBackend
{
    public interface IFacultyISController
    {
        public IList Students { get; }
        public IList Groups { get; }


        public IList QueryStudentsWithYear(int year);

        public void SaveChanges();
    }
}