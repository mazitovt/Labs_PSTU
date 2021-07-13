using System.Collections;
using System.ComponentModel;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FacultyISBackend.EntityFrameworkController
{
    public class ControllerEF : IFacultyISController
    {
        private FacultyContext _db = new();
        
        public IList Students 
        {
            get
            {
                _db = new FacultyContext();
                _db.Students.Load();
                return _db.Students.Local.ToBindingList();
            }
        }
        
        public IList Groups 
        {
            get
            {
                _db = new FacultyContext();
                _db.Groups.Load();
                return _db.Groups.Local.ToBindingList();
            }
        }

        public ControllerEF()
        {
            _db.Groups.Load();
            _db.Students.Load();
        }

        private void DiscardChanges()
        {
            _db.DiscardChanges();
        }
        
        public void SaveChanges()
        {
            _db.SaveChanges();
        }
        
        public IList QueryStudentsWithYear(int year)
        {
            var res =
                from g in _db.Groups
                join s in _db.Students
                    on g.Id equals s.GroupId
                where g.Year == year
                orderby s.Name ascending 
                select new {StudentId = s.Id, StudentName = s.Name, StudentRating = s.Rating, GroupName = g.Name};

            var r = res.ToList();
            return res.ToList();
        }
    }
}


