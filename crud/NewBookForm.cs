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
    public partial class NewBookForm : Form
    {
        public NewBookForm()
        {
            InitializeComponent();
        }

        private void NewBookForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            
        }

        void SaveBookData()
        {
            Book book = new Book();

            book.Title = txtTitle.Text;
            book.ISBN = txtISBN.Text;
            book.PublisherName = txtPublisher.Text;
            book.AuthorName = txtAuthor.Text;
            book.CategoryName = txtCategory.Text;

            book.CreateBook(book);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveBookData();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}