﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace IssuesWithNonGenericCollection
{
    class PersonCollection: IEnumerable
    {
        private ArrayList arPeople = new ArrayList();

        // Cast for caller.
        public Person GetPerson(int pos)
        { return (Person)arPeople[pos]; }

        // Insert only Person objects.
        public void AddPerson(Person p)
        { arPeople.Add(p); }
        
        public void ClearPeople()
        { arPeople.Clear(); }

        public int Count
        { get { return arPeople.Count; } }

        // Foreach enumeration support
        IEnumerator IEnumerable.GetEnumerator()
        { return arPeople.GetEnumerator(); }
    }
}
