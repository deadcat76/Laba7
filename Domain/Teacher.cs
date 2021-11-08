using System;

namespace Domain
{
    public class Teacher
    {
        public Teacher(string name, string institute, string distantLearningService)
        {
            Name = name;
            Institute = institute;
            DistantLearningService = distantLearningService;
        }
        public string Institute { get; set; }
        public string DistantLearningService { get; set; }
        public string Name { get; set; }
    }
}
