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

        //we pass the conection to the Microsoft Server
        string connectionString = "Data Source=DESKTOP-COKF0ND\\MYSQL;Initial Catalog=Library;Integrated Security=True;Encrypt=False;Trust Server Certificate=True";
        //readonly string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

        //creation of a function that will conect than display the list of books in the grid if its not empty
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
        
        //creation of a function that adds new books, it takes the info that I insert in the textBox and insert into the Microsoft Server
        public void CreateBook(Book book)
        {
            SqlConnection con = new SqlConnection(connectionString);

            //calls the function there and inserts it
            SqlCommand cmd = new SqlCommand("CreateBook", con);
            cmd.CommandType = CommandType.StoredProcedure;

            //take the parameters from the textBoxs and insert into the Server
            cmd.Parameters.Add(new SqlParameter("@Title", book.Title));
            cmd.Parameters.Add(new SqlParameter("@Isbn", book.ISBN));
            cmd.Parameters.Add(new SqlParameter("@PublisherName", book.PublisherName));
            cmd.Parameters.Add(new SqlParameter("@CategoryName", book.CategoryName));
            cmd.Parameters.Add(new SqlParameter("@AuthorName", book.AuthorName));

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();


        }


        //takes take the information inside a specific Id, if i click one specific line
        //it will read the id and pass all the complementary info
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

        //takes the new info that is inserted into the camps and apply them,after that it takes back
        //to the main and shows the changes
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
        
        //deletes the Book using the id as a info point, similiar to the GetBookId function, but it deletes 
        public void DeleteBook (int bookId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            //search for the command
            SqlCommand cmd = new SqlCommand("DeleteBook", con);
            //call of the procedure
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@BookId", bookId));

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();    
        }
    }
}
