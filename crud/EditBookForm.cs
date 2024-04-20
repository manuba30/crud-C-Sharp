using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crud
{
    public partial class EditBookForm : Form
    {
        int selectedBookId;
        public EditBookForm(int bookId)
        {
            InitializeComponent();
            selectedBookId= bookId;
            GetBookData();
        }

        private void EditBookForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            EditBookData();    
            this.Close();
        }
        void GetBookData()
        {
            Book book = new Book();
            book = book.GetBookData(selectedBookId);

            txtTitle.Text = book.Title;
            txtISBN.Text = book.ISBN;
            txtPublisher.Text = book.PublisherName;
            txtAuthor.Text = book.AuthorName;
            txtCategory.Text = book.CategoryName;
        }

        void EditBookData()
        {
            Book book = new Book(); 

            book.BookId = selectedBookId;
            book.Title = txtTitle.Text;
            book.ISBN = txtISBN.Text;
            book.PublisherName = txtPublisher.Text;
            book.AuthorName = txtAuthor.Text;
            book.CategoryName = txtCategory.Text;

            book.EditBook(book);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
