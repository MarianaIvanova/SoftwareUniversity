using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        //private List<Person> people;

        public Family()
        {
            this.People = new List<Person>();//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        }

        public List<Person> People { get; set; }
        
        public void AddMember(Person member)
        {
            this.People.Add(member);
        }

        public Person GetOldestMember()
        {
            Person maxAgePerson = null;
            int maxAge = int.MinValue;

            foreach (var person in People)
            {
                int currentAge = person.Age;
                if(maxAge < currentAge)
                {
                    maxAge = currentAge;
                    maxAgePerson = person;
                }
            }

            //this.People.OrderByDescending(x => x.Age);
            //maxAgePerson = this.People.OrderByDescending(x => x.Age).First();

            return maxAgePerson;
        }
    }
}
