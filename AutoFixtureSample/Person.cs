using System;
using System.ComponentModel.DataAnnotations;

namespace AutoFixtureSample
{
    public class Person
    {
        public Guid Id { get; set; }

        [StringLength(10)]
        public string Name { get; set; }

        [Range(18, 80)]
        public int Age { get; set; }

        public int Test { get; set; }

        public DateTime CreateTime { get; set; }
    }
}