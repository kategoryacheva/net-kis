using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesApp
{
    public class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return $"Имя: {Name} Возраст: {Age}";
        }
    }

    // Тут нужно реализовать методы-заглушки
    // О том, какие аргументы нужно использовать в методах подумайте сами
    public class PersonContainer
    {
        public Person[] People { get; set; }
        
        public Person GetOne(Func<Person, bool> func)
        {
            foreach(Person p in People)
            {
                if (func(p))
                    return p;
            }
            return null;
        }

        public IEnumerable<Person> GetAll(Func<Person, bool> func)
        {
            foreach(Person p in People)
            {
                if (func(p))
                    yield return p;
            }
        }

        public bool Contains(Func<Person, bool> func)
        {
            foreach(Person p in People)
            {
                if (func(p))
                    return true;
            }
            return false;
        }
    }
}
