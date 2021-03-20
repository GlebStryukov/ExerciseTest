using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ExerciseTest.Datas
{
    
    public class DatabaseTable
    {
        SqlConnection sQLConnection;
        /// <summary>
        /// Construct SQL connection with local server db
        /// </summary>
        public DatabaseTable()
        {
            var configuration = GetConfiguration();
            sQLConnection = new SqlConnection(configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value);
        }
        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }
        /// <summary>
        /// SQL querry for database
        /// </summary>
        /// <returns>Return dataset with data</returns>
        public DataTable GetRecord()
        {
            SqlCommand com = new SqlCommand("BooksAuthors", sQLConnection);
            com.CommandType = CommandType.Text;
            //SQL Querry
            com.CommandText = "Select Books.Title, Books.Edition, Books.Publeshid_At, Books.Description, Authors.FullName, Authors.DoB From Books, Authors, BooksAuthors Where  Authors.Id = BooksAuthors.AuthorId  and Books.Id=BooksAuthors.BookId;";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(com);
            DataTable ds = new DataTable();
            dataAdapter.Fill(ds);
            return ds;
        }
    }
}
