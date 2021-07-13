using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace LR8_Forms
{
    public class FileWorker<T>
    {
        public string CurrentFile { get; set; }
        private string DIR { get; set; }

        private readonly BinaryFormatter binFormater;
        public Stream FileWorkerStream { get; set; }

        public FileWorker(string dir)
        {
            DIR = dir;
            binFormater = new BinaryFormatter();
        }

        public string[] GetFiles()
        {
            return Directory.GetFiles(DIR);
        }

        public T OpenFile(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            return (T)binFormater.Deserialize(fs);
        }
        public Group OpenFileTXT(string path)
        {
            CurrentFile = path;

            //FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader sr = File.OpenText(path);

            Group group = new Group
            {
                Name = sr.ReadLine(),
                Semestr = Convert.ToInt32(sr.ReadLine()),
                Curator = sr.ReadLine()
            };
            group.Students = new List<Student>();

            foreach (var row in sr.ReadToEnd().Split("\r\n", StringSplitOptions.RemoveEmptyEntries))
            {
                string[] p = row.Split(" ");
                var st = new Student
                {
                    StudentId = p[0],
                    LastName = p[1],
                    FirstName = p[2],
                    Rating = Convert.ToDouble(p[3])
                };
                group.Students.Add(st);
            }

            sr.Close();
            return group;

            //while (!sr.EndOfStream)
            //{
            //    string[] p = sr.ReadLine().Split(" ");
            //    Student st = new Student
            //    {
            //        second_name = p[0],
            //        first_name = p[1],
            //        rating = Convert.ToInt32(p[2])
            //    };
            //    group.Students.Add(st);
            //}

        }

        public void SaveFile(T obj, Stream stream)
        {
            binFormater.Serialize(stream, obj);
            stream.Close();
        }
        public bool SaveFile(T obj, string file)
        {
            string path = DIR + file;

            if (!File.Exists(path))
            {
                FileStream fs = new FileStream(path, FileMode.CreateNew, FileAccess.Write); // CreateNew or Create?
                binFormater.Serialize(fs, obj);
                fs.Close();
                return true;
            }
            else
                return false;
        }
        public void SaveFileTXT(Group group, Stream stream)
        {
            StreamWriter sw = new StreamWriter(stream);

            sw.WriteLine(group.Name);
            sw.WriteLine(group.Semestr);
            sw.Write(group.Curator);

            foreach (Student st in group.Students)
            {
                sw.WriteLine();
                sw.Write(String.Join(" ", st.StudentId, st.LastName, st.FirstName, st.Rating));
            }
            sw.Close();
            stream.Close();
        }

        public void AddStudent(int index, params string[] p)
        {
            Group group = OpenFileTXT(CurrentFile);
            group.Students.Insert(index, new Student(p));
            FileStream fs = new FileStream(CurrentFile, FileMode.Create, FileAccess.Write);
            SaveFileTXT(group, fs);

            //using (StreamWriter sw = new StreamWriter(CurrentFile, true))
            //{
            //    using (StreamReader sr = new StreamReader(CurrentFile))
            //    {
            //        foreach (var _ in Enumerable.Range(1, index))
            //            sr.ReadLine();
            //        sr.Close();
            //    }
            //    sw.WriteLine(srTemp.ReadLine());
            //    sw.Close();
            //}
            //srTemp.Close();
        }

        public void DeleteStudent(int index)
        {
            Group group = OpenFileTXT(CurrentFile);
            group.Students.RemoveAt(index);
            FileStream fs = new FileStream(CurrentFile, FileMode.Create, FileAccess.Write);
            SaveFileTXT(group, fs);
        }

        public bool DeleteStudent(string id)
        {
            Group group = OpenFileTXT(CurrentFile);
            if (group.Students.RemoveAll((student) => student.StudentId == id) > 0)
            {
                FileStream fs = new FileStream(CurrentFile, FileMode.Create, FileAccess.Write);
                SaveFileTXT(group, fs);
                return true;
            }
            else return false;
        }

        public string[] GetStudentInfo(string id)
        {
            Group group = OpenFileTXT(CurrentFile);
            Student st = group.Students.Find((student) => student.StudentId == id);
            if (st != null)
                return new string[] { st.StudentId, st.LastName, st.FirstName, st.Rating.ToString() };
            else
                return new string[0];
        }
        public string[] GetStudentInfo(int index)
        {
            Group group = OpenFileTXT(CurrentFile);
            Student st = group.Students[index];
            if (st != null)
                return new string[] { st.StudentId, st.LastName, st.FirstName, st.Rating.ToString() };
            else
                return new string[0];
        }
        public void EditStudent(int index, params string[] p)
        {
            Group group = OpenFileTXT(CurrentFile);

            //Student st = group.Students[index];
            group.Students[index].StudentId = p[0];
            group.Students[index].LastName = p[1];
            group.Students[index].FirstName = p[2];
            group.Students[index].Rating = Convert.ToDouble(p[3]);

            FileStream fs = new FileStream(CurrentFile, FileMode.Create, FileAccess.Write);
            SaveFileTXT(group, fs);
        }
        public void EditStudent(string id, params string[] p)
        {
            Group group = OpenFileTXT(CurrentFile);

            int index = group.Students.FindIndex((student) => student.StudentId == id);
            group.Students[index].StudentId = p[0];
            group.Students[index].LastName = p[1];
            group.Students[index].FirstName = p[2];
            group.Students[index].Rating = Convert.ToDouble(p[3]);

            FileStream fs = new FileStream(CurrentFile, FileMode.Create, FileAccess.Write);
            SaveFileTXT(group, fs);
        }

        public Group GetFirstYearGroup()
        {
            Group output = new Group
            {
                Name = "Первый курс",
                Semestr = 1,
                Curator = "",
                Students = new List<Student>()
            };

            Group[] groups = GetFiles().Select(file => OpenFileTXT(file)).ToArray();
            Array.ForEach(groups, group => output.Students.AddRange(group.Students));
            output.Students.Sort((st1, st2) => String.Compare(st1.LastName, st2.LastName));
            //var fdg  = groups.Select(group => group.Students.Select(student => student)).ToList();

            return output;
        }
    }
}
