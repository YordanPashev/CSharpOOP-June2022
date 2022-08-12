namespace Book.Tests
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class Tests
    {
        [TestCase("Bratq Karamazovi", "F.M. Dostoyvsky")]
        [TestCase("Chovekyt koito se smee", "V.Hugo")]
        public void Test_Constructor_Must_Greate_New_Book_With_Given_Values
            (string bookName, string author)
        {
            Book book = new Book(bookName, author);

            Assert.That(book != null && book.BookName == bookName &&
                        book.Author == author && book.FootnoteCount == 0,
                        "The constructor does not greate a book with the given values.");
        }

        [TestCase("", "F.M. Dostoyvsky")]
        [TestCase(null, "V.Hugo")]
        public void Test_BookName_Property_Must_Throw_Error
            (string bookName, string author)
        {
            Assert.Throws<ArgumentException>(() => new Book(bookName, author),
                        "Must Throw error because the book name is null.");
        }

        [TestCase("Chovekyt koito se smee", "")]
        [TestCase("Bratq Karamazovi", null)]
        public void Test_Author_Property_Must_Throw_Error
            (string bookName, string author)
        {
            Assert.Throws<ArgumentException>(() => new Book(bookName, author),
                        "Must Throw error because the author is null.");
        }


        [TestCase("Bratq Karamazovi", "F.M. Dostoyvsky", 1, "assafasfrtq")]
        [TestCase("Chovekyt koito se smee", "V.Hugo", int.MaxValue, "note")]
        public void Test_AddFootnote_Method_Must_Increase_The_Collection_Of_Footnotes_By_One
            (string bookName, string author, int footNoteNumber, string text)
        {
            Book book = new Book(bookName, author);
            int expectedFootNote = 1;

            book.AddFootnote(footNoteNumber, text);

            Assert.That(book.FootnoteCount == expectedFootNote,
                        $"The collection must have {expectedFootNote} elements.");
        }

        [TestCase("Bratq Karamazovi", "F.M. Dostoyvsky", 1, "assafasfrtq")]
        [TestCase("Chovekyt koito se smee", "V.Hugo", int.MaxValue, "note")]
        public void Test_AddFootnote_Method_Must_Throw_Error
            (string bookName, string author, int footNoteNumber, string text)
        {
            Book book = new Book(bookName, author);
            book.AddFootnote(footNoteNumber, text);

            Assert.Throws<InvalidOperationException>(() => book.AddFootnote(footNoteNumber, text),
                        "Must Throw error because the footnote is alredy exist in the collection.");
        }

        [TestCase("Bratq Karamazovi", "F.M. Dostoyvsky", 3, "assafasfrtq")]
        [TestCase("Chovekyt koito se smee", "V.Hugo", 1243125124, "note")]
        public void Test_FindFootnote_Method_Must_Return_Chosen_Footnote_Info
            (string bookName, string author, int footNoteNumber, string text)
        {
            Book book = new Book(bookName, author);
            string expectedResult = $"Footnote #{footNoteNumber}: {text}";

            book.AddFootnote(footNoteNumber, text);
            string actualResult = book.FindFootnote(footNoteNumber);

            Assert.That(actualResult == expectedResult,
                        $"The method should return: Footnote \"#{footNoteNumber}: {text}.\"");
        }

        [TestCase("Bratq Karamazovi", "F.M. Dostoyvsky", 11)]
        [TestCase("Chovekyt koito se smee", "V.Hugo", int.MaxValue)]
        public void Test_FindFootnote_Method_Must_Throw_Error
            (string bookName, string author, int footNoteNumber)
        {
            Book book = new Book(bookName, author);

            Assert.Throws<InvalidOperationException>(() => 
                        book.FindFootnote(footNoteNumber),
                        "Must Throw error because the footnote does not exist.");
        }

        [TestCase("Bratq Karamazovi", "F.M. Dostoyvsky", 3, "assafasfrtq", "12123")]
        [TestCase("Chovekyt koito se smee", "V.Hugo", 1243125124, "note", "note2.0")]
        public void Test_FindFootnote_Method_Must_Return_Chosen_Footnote_Info
            (string bookName, string author, int footNoteNumber, string text, string newTextForCurrNote)
        {
            Book book = new Book(bookName, author);
            string expectedResult = $"Footnote #{footNoteNumber}: {newTextForCurrNote}";

            book.AddFootnote(footNoteNumber, text);
            book.AlterFootnote(footNoteNumber, newTextForCurrNote);
            string actualResult = book.FindFootnote(footNoteNumber);

            Assert.That(actualResult == expectedResult,
                        $"The method should return: Footnote \"#{footNoteNumber}: {text}.\"");
        }

        [TestCase("Bratq Karamazovi", "F.M. Dostoyvsky", 11, "123124")]
        [TestCase("Chovekyt koito se smee", "V.Hugo", int.MaxValue, "note2.0")]
        public void Test_FindFootnote_Method_Must_Throw_Error
            (string bookName, string author, int footNoteNumber, string newTextForCurrNote)
        {
            Book book = new Book(bookName, author);

            Assert.Throws<InvalidOperationException>(() =>
                        book.AlterFootnote(footNoteNumber, newTextForCurrNote),
                        "Must Throw error because the footnote does not exist.");
        }
    }
}