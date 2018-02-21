using Dapper.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var repository = new Repository();

            Console.WriteLine("INSERT PERSON");
            Person newPerson = Factory.Create(NameGenerator.Generate(), "Doe", 30);
            int noOfRows = repository.Insert(newPerson);
            Console.WriteLine("No of Rows inserted: {0}", noOfRows);

            Console.WriteLine("");
            Console.WriteLine("***********************");
            Console.WriteLine("");           
            

            Console.WriteLine("GET ALL PEOPLE");
            IReadOnlyList<Person> people = repository.GetAll();
            foreach (Person p in people) {
                Console.WriteLine(p);
            }

            Console.WriteLine("");
            Console.WriteLine("***********************");
            Console.WriteLine("");


            Console.WriteLine("GET PERSON BY ID");
            Guid id = repository.GetAll().FirstOrDefault().Id;
            Person person = repository.GetById(id);
            Console.WriteLine(person);

            Console.WriteLine("");
            Console.WriteLine("***********************");
            Console.WriteLine("");


            Console.WriteLine("UPDATE PERSON");
            id = repository.GetAll().FirstOrDefault().Id;
            person = repository.GetById(id);
            person.Age = 50;
            noOfRows = repository.Update(person);
            Console.WriteLine("No of Rows updated: {0}", noOfRows);

            Console.WriteLine("");
            Console.WriteLine("***********************");
            Console.WriteLine("");


            Console.WriteLine("DELETE PERSON");
            person = repository.GetAll().FirstOrDefault();
            noOfRows = repository.Delete(person);
            Console.WriteLine("No of Rows deleted: {0}", noOfRows);

            Console.WriteLine("");
            Console.WriteLine("***********************");
            Console.WriteLine("");


            Console.WriteLine("GET ALL PEOPLE");
            people = repository.GetAll();
            foreach (Person p in people) {
                Console.WriteLine(p);
            }

            Console.ReadLine();
        }
    }
}
