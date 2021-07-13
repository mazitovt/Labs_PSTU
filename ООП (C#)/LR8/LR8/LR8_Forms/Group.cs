using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace LR8_Forms
{
    [Serializable]
    public class Group
    {
        [JsonPropertyName("group_name")]
        public string Name { get; set; }

        [JsonPropertyName("semestr")]
        public int Semestr { get; set; }

        [JsonPropertyName("curator")]
        public string Curator { get; set; }

        [JsonPropertyName("students")]
        public List<Student> Students { get; set; }

        //[NonSerialized]
        public override string ToString()
        {
            return String.Join("\n", Name, Semestr, Curator) + "\n" +
                    String.Join("\n", Students
                    .Select(student => student
                    .ToString())
                    .ToArray());
        }
    }
}
