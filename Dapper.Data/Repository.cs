using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Dapper.Data
{
    public class Repository
    {
        readonly string _databaseConnection;
        public Repository()
        {
            _databaseConnection = ConfigurationManager.ConnectionStrings["DapperConnection"].ConnectionString;
        }

        public Person GetById(Guid guid)
        {
            Person person = null;
            const string sqlQuery = "SELECT Id, FirstName, LastName, Age FROM Person WHERE Id = @Guid";
            using (IDbConnection db = new SqlConnection(_databaseConnection)) {
                person = db.Query<Person>(sqlQuery, new { Guid = guid }).FirstOrDefault();
            }

            return person;
        }

        public IReadOnlyList<Person> GetAll()
        {
            IReadOnlyList<Person> persons = null;
            const string sqlQuery = "SELECT Id, FirstName, LastName, Age FROM Person";
            using (IDbConnection db = new SqlConnection(_databaseConnection)) {
                persons = db.Query<Person>(sqlQuery).OrderBy(p => p.LastName).ToList();
            }

            return persons;
        }

        public int Insert(Person personToAdd) {
            const string insertStatement = "INSERT INTO PERSON (FirstName, LastName, Age) VALUES (@FirstName, @LastName, @Age)";
            int noOfRows;
            using (IDbConnection db = new SqlConnection(_databaseConnection)) {
                noOfRows = db.Execute(insertStatement, personToAdd);
            }

            return noOfRows;
        }

        public int Update(Person personToUpdate)
        {
            const string updateStatement = "UPDATE PERSON SET LastName = @LastName, Age = @Age WHERE Id = @Id";
            int noOfRows;
            using (IDbConnection db = new SqlConnection(_databaseConnection)) {
                noOfRows = db.Execute(updateStatement, personToUpdate);
            }

            return noOfRows;
        }

        public int Delete(Person personToDelete)
        {
            const string deletStatement = "DELETE FROM PERSON WHERE Id = @Id";
            int noOfRows;
            using (IDbConnection db = new SqlConnection(_databaseConnection)) {
                noOfRows = db.Execute(deletStatement, personToDelete);
            }

            return noOfRows;
        }
    }
}
