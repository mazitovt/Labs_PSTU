using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace LR8_Forms
{
    [Serializable]
    public class Student
    {
        [JsonPropertyName("studentid")]
        public string StudentId { get; set; }

        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("second_name")]
        public string LastName { get; set; }

        [JsonPropertyName("rating")]
        public double Rating { get; set; }

        public Student()
        {

        }
        public Student(params string[] p)
        {
            StudentId = p[0];
            LastName = p[1];
            FirstName = p[2];
            Rating = Convert.ToDouble(p[3]);
        }

        //[NonSerialized]
        public override string ToString()
        {
            return String.Join(" ", StudentId, LastName, FirstName, Rating);
        }
    }
}
