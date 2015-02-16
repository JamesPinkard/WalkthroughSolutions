using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace StringIndexer
{
    class PersonCollection : IEnumerable
    {
        private Dictionary<string, Person> listPeople = new Dictionary<string, Person>();


        // Custom indexer for this class.
        public Person this[string name]
        {
            get { return (Person)listPeople[name]; }
            set { listPeople[name] = value; }
        }

        public void ClearPeople()
        { listPeople.Clear(); }

        public int Count
        { get { return listPeople.Count; } }

        public IEnumerator GetEnumerator()
        {
            return listPeople.GetEnumerator();
        }
    }
}
