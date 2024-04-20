using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace crud
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string PublisherName { get; set; }
        public string AuthorName { get; set; }
        public string CategoryName { get; set; }

        string connectionString = "Data Source=DESKTOP-COKF0ND\\MYSQL;Initial Catalog=Library;Integrated Security=True;Encrypt=False;Trust Server Certificate=True";
        //readonly string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

        public List<Book> GetBooks()
        {
            List<Book> booklist = new List<Book>();

            SqlConnection con = new SqlConnection(connectionString);

            string selectSQL = "SELECT BookId,Title,ISBN,PublisherName,AuthorName,CategoryName FROM GetBookData";

            con.Open();

            SqlCommand cmd = new SqlCommand(selectSQL, con);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr != null)
            {
                while (dr.Read())
                {
                    Book book = new Book();

                    book.BookId = Convert.ToInt32(dr["BookId"]);
                    book.Title = dr["Title"].ToString();
                    book.ISBN = dr["ISBN"].ToString();
                    book.PublisherName = dr["PublisherName"].ToString();
                    book.AuthorName = dr["AuthorName"].ToString();
                    book.CategoryName = dr["CategoryName"].ToString();

                    booklist.Add(book);
                }
            }
            return booklist;
        }

        public void CreateBook(Book book)
        {
            SqlConnection con = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("CreateBook", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@Title", book.Title));
            cmd.Parameters.Add(new SqlParameter("@Isbn", book.ISBN));
            cmd.Parameters.Add(new SqlParameter("@PublisherName", book.PublisherName));
            cmd.Parameters.Add(new SqlParameter("@CategoryName", book.CategoryName));
            cmd.Parameters.Add(new SqlParameter("@AuthorName", book.AuthorName));

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();


        }


        public Book GetBookData(int bookId)
        {
            SqlConnection con = new SqlConnection(connectionString);

            string selectSQL = "select BookId, Title, ISBN, PublisherName, AuthorName, CategoryName from GetBookData where BookId = " + bookId;

            con.Open();

            SqlCommand cmd = new SqlCommand(selectSQL, con);

            SqlDataReader dr = cmd.ExecuteReader();

            Book book = new Book();
            if (dr != null)
                while (dr.Read())
                {
                    book.BookId = Convert.ToInt32(dr["BookId"]);
                    book.Title = dr["Title"].ToString();
                    book.ISBN = dr["ISBN"].ToString();
                    book.PublisherName = dr["PublisherName"].ToString();
                    book.AuthorName = dr["AuthorName"].ToString();
                    book.CategoryName = dr["CategoryName"].ToString();

                }
            return book;
        }

        public void EditBook(Book book)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("UpdateBook", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@BookId", book.BookId));
                cmd.Parameters.Add(new SqlParameter("@Title", book.Title));
                cmd.Parameters.Add(new SqlParameter("@ISBN", book.ISBN));
                cmd.Parameters.Add(new SqlParameter("@PublisherName", book.PublisherName));
                cmd.Parameters.Add(new SqlParameter("@AuthorName", book.AuthorName));
                cmd.Parameters.Add(new SqlParameter("@CategoryName", book.CategoryName));

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void DeleteBook (int bookId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("DeleteBook", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@BookId", bookId));

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();    
        }
    }
}
