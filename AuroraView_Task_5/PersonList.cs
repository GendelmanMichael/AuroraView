using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace AuroraView_Task_5
{

    // The main idea is to start several Tasks that will allow us
    // to make as mutch verifications in parralel as possible.
    // Not sure that next implementation is the best but maybe it's anough

    public class PersonList
    {

        IEnumerable<Person> persons;

        public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Id { get; set; }

            public bool Verify(string FirstName)
            {
                Thread.Sleep(1000);
                return this.FirstName == FirstName;
            }
        }

        public IEnumerable<Person> FindFive(string  FirstName)
        {
            return persons.AsParallel()
                .Select(p => new { Person = p, Verified = p.Verify(FirstName) })
                .Where(x => x.Verified).Take(5).Select(x => x.Person);
        }

    }
}
