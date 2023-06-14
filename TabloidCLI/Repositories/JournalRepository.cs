using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabloidCLI.Models;

namespace TabloidCLI.Repositories
{
    internal class JournalRepository : DatabaseConnector, IRepository<JournalEntry>
    {
        public JournalRepository(string connectionString) : base(connectionString) { }

        public List<JournalEntry> GetAll()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Id, Title, Content, CreateDateTime FROM Journal";
                    List<JournalEntry> entries = new List<JournalEntry>();

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        JournalEntry entry = new JournalEntry()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Title = reader.GetString(reader.GetOrdinal("Title")),
                            Content = reader.GetString(reader.GetOrdinal("Content")),
                            CreateDateTime = reader.GetDateTime(reader.GetOrdinal("CreateDateTime"))
                            
                        };
                        entries.Add(entry);
                    }

                    reader.Close();

                    return entries;
                }
            }
        }

        public JournalEntry Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(JournalEntry post)
        {
            throw new NotImplementedException();
        }

        public void Update(JournalEntry post)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
