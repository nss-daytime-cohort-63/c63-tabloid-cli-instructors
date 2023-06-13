using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabloidCLI.Models;

namespace TabloidCLI.Repositories
{
    internal class BlogRepository : DatabaseConnector, IRepository<Blog>
    {
        public BlogRepository( string connectionString) : base(connectionString)
        {}

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Blog Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetAll()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    // cmd.CommandText = @"SELECT id,
                    //                            Title,
                    //                            Url
                    //                       FROM Blog";
                    cmd.CommandText = @"SELECT b.Id AS BlogId,
                                               b.Title,
                                               b.Url,
                                               t.Id AS TagId,
                                               t.Name
                                          FROM Blog b
                                               LEFT JOIN BlogTag bt ON b.Id = bt.BlogId
                                               LEFT JOIN Tag t ON t.Id = bt.TagId";

                    SqlDataReader reader = cmd.ExecuteReader();

                    Dictionary<int, Blog> blogs = new Dictionary<int, Blog>();
                    while (reader.Read())
                    {
                        int blogId = reader.GetInt32(reader.GetOrdinal("BlogId"));
                        if (!blogs.ContainsKey(blogId))
                        {
                            Blog blog = new Blog()
                            {
                                Id = blogId,
                                Title = reader.GetString(reader.GetOrdinal("Title")),
                                Url = reader.GetString(reader.GetOrdinal("Url")),
                            };

                            blogs.Add(blogId, blog);
                        }

                        Blog fromDictionary = blogs[blogId];

                        if (!reader.IsDBNull(reader.GetOrdinal("TagId")))
                        {
                            Tag tag = new Tag()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("TagId")),
                                Name = reader.GetString(reader.GetOrdinal("Name"))
                            };

                            fromDictionary.Tags.Add(tag);
                        }
                    }

                    reader.Close();

                    return blogs.Values.ToList();   
                }

            }
        }

        public void Insert(Blog entry)
        {
            throw new NotImplementedException();
        }

        public void Update(Blog entry)
        {
            throw new NotImplementedException();
        }
    }
}
