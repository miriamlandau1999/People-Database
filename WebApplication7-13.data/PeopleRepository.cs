using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication7_13.data
{
    public class PeopleRepository
    {
        private string _connectionString;

        public PeopleRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public IEnumerable<Person> GetPeople()
        {
            using (var context = new MyDBDataContext(_connectionString))
            {
                return context.Persons.ToList();
            }           
        }
        public void Add(Person person)
        {
            using (var context = new MyDBDataContext(_connectionString))
            {
                context.Persons.InsertOnSubmit(person);
                context.SubmitChanges();
            }
        }
        public Person GetPerson(int id)
        {
            using (var context = new MyDBDataContext(_connectionString))
            {
                return context.Persons.FirstOrDefault(c => c.Id == id);
            }
        }
        public void EditPerson(Person person)
        {
            using (var context = new MyDBDataContext(_connectionString))
            {
                context.Persons.Attach(person);
                context.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, person);
                context.SubmitChanges();
            }
        }
        public void DeletePerson(int Id)
        {
            using (var context = new MyDBDataContext(_connectionString))
            {
                context.ExecuteCommand("Delete From People Where Id = {0}", Id);
            }
        }
    }
}
