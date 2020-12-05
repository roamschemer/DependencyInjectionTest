using System;
using System.Collections.Generic;
using System.Linq;

namespace DependencyInjectionTest {

    class Program {
        static void Main(string[] args) {
        }
    }

    public class Person {
        public string FastName { get; }
        public string LastName { get; }
        public Person(string fastName, string lastName) {
            FastName = fastName;
            LastName = lastName;
        }
        public string FullName() => $"{LastName} {FastName}";
    }

    public class Vtuber {
        public Person Person { get; }
        public string Attribute { get; }
        public Vtuber(Person person, string attribute) {
            Person = person;
            Attribute = attribute;
        }
        public string Infomation() => $"{Person.FullName()} Attribute:{Attribute}";
    }

    public class VTuberGroup {

    }
}
