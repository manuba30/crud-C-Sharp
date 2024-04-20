using System.Collections.Generic;
using System.Windows.Forms;

namespace crud  
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            FillGridView();
        }

        void FillGridView()
        {
            List<Book> booklist = new List<Book>();

            Book book = new Book();

            booklist = book.GetBooks();

            dataGridViewBooks.DataSource = booklist;
        }

        private void dataGridViewBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                 

        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            NewBookForm formNewBook = new NewBookForm();
            formNewBook.ShowDialog();
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {

        }

        private void MainForm_Activated(object sender, System.EventArgs e)
        {
            FillGridView();
        }

        private void btnEdit_Click(object sender, System.EventArgs e)
        {
            EditBook();
        }

        void EditBook()
        {
            int bookId;

            bookId = (int)dataGridViewBooks.CurrentRow.Cells[0].Value;

            EditBookForm formEditBook = new EditBookForm(bookId);
            formEditBook.ShowDialog();
        }

        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            DeleteBook();
        }

        void DeleteBook()
        {
            int bookId;

            bookId = (int)dataGridViewBooks.CurrentRow.Cells[0].Value;
            string bookTitle = dataGridViewBooks.CurrentRow.Cells[1].Value.ToString();

            string message = "are you sure that you want to delete '" + bookTitle + "'?";
            DialogResult dr = MessageBox.Show(message, "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Book book = new Book();

                book.DeleteBook(bookId);
                FillGridView(); 
            }

        }

        void AdjustGridView()
        {
            dataGridViewBooks.Columns[0].HeaderText = "BookId" ;

            dataGridViewBooks.Columns[1].HeaderText = "Title";

            dataGridViewBooks.Columns[2].HeaderText = "ISBN" ;

            dataGridViewBooks.Columns[3].HeaderText = "Publisher";

            dataGridViewBooks.Columns[4].HeaderText = "Author";

            dataGridViewBooks.Columns[5].HeaderText = "Category";

            dataGridViewBooks.Columns[0].Width = 50;

            dataGridViewBooks.Columns[1].Width = 200;

            dataGridViewBooks.Columns[2].Width = 90;

            dataGridViewBooks.Columns[3].Width = 120;

            dataGridViewBooks.Columns[4].Width = 120;

            dataGridViewBooks.Columns[5].Width = 120;

        }



    }

}
