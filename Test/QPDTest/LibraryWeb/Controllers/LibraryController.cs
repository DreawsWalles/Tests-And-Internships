using LibraryWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWeb.Controllers
{
    public class LibraryController : Controller
    {
        LibraryContext dataBase;
        public LibraryController(LibraryContext context)
        {
            dataBase = context;
        }
        public IActionResult Index()
        {
            string name = "";
            ViewData["Name"] = name;
            return View();
        }
        public IActionResult PrintBooks()
        {
            ViewData["Books"] = dataBase.Books.ToList();
            return View();
        }
        public IActionResult PrintJournals()
        {
            ViewData["Journals"] = dataBase.Journals.ToList();
            return View();
        }
        public RedirectToActionResult AddBook(Book book)
        {
            addBook(book);
            dataBase.SaveChanges();
            return RedirectToAction("PrintBooks");
        }
        private void addBook(Book book)
        {
            foreach (Book element in dataBase.Books)
                if (element.CompareTo(book))
                {
                    element.Count += book.Count;
                    dataBase.Entry(element).State = EntityState.Modified;
                    return;
                }
            dataBase.Books.Add(book);
        }
        public RedirectToActionResult AddJournal(Journal journal)
        {
            addJournal(journal);
            dataBase.SaveChanges();
            return RedirectToAction("PrintJournals");
        }
        private void addJournal(Journal journal)
        {
            foreach (Journal element in dataBase.Journals)
                if (element.CompareTo(journal))
                {
                    element.Count += journal.Count;
                    dataBase.Entry(element).State = EntityState.Modified;
                    return;
                }
            dataBase.Journals.Add(journal);
        }
        public RedirectToActionResult EditBook(Book book)
        {
            editBook(book);
            dataBase.SaveChanges();
            return RedirectToAction("PrintBooks");
        }
        public RedirectToActionResult EditJournal(Journal journal)
        {
            editJournal(journal);
            dataBase.SaveChanges();
            return RedirectToAction("PrintJournals");
        }
        private void editJournal(Journal journal)
        {
            int index = journal.id;
            dataBase.Entry(journal).State = EntityState.Modified;
            foreach (Journal element in dataBase.Journals)
            {
                if (element.CompareTo(journal) && index != element.id)
                {
                    element.Count += journal.Count;
                    dataBase.Entry(element).State = EntityState.Modified;
                    dataBase.Journals.Remove(journal);
                    return;
                }
            }
        }
        private void editBook(Book book)
        {
            int index = book.id;
            dataBase.Entry(book).State = EntityState.Modified;
            foreach(Book element in dataBase.Books)
            {
                if (element.CompareTo(book) && index != element.id)
                {
                    element.Count += book.Count;
                    dataBase.Entry(element).State = EntityState.Modified;
                    dataBase.Books.Remove(book);
                    return;
                }
            }
        }
        public RedirectToActionResult DeleteBook(Book book)
        {
            dataBase.Books.Remove(book);
            dataBase.SaveChanges();
            return RedirectToAction("PrintBooks");
        }
        public RedirectToActionResult DeleteJoural(Journal journal)
        {
            dataBase.Journals.Remove(journal);
            dataBase.SaveChanges();
            return RedirectToAction("PrintJournals");
        }
        public IActionResult AllSearch(string name)
        {
            Model model = new Model();
            foreach (Book element in dataBase.Books)
                if (element.CompareTo(new Product { Name = name }))
                    model.Books.Add(element);
            foreach (Journal element in dataBase.Journals)
                if (element.CompareTo(new Product { Name = name }))
                    model.Journals.Add(element);
            return View(model);
        }
        public IActionResult SearchBooks(string name)
        {
            List<Book> books = new List<Book>();
            foreach (Book element in dataBase.Books)
                if (element.CompareTo(new Product { Name = name }))
                    books.Add(element);
            return View(books);
        }
        public IActionResult SearchJournals(string name)
        {
            List<Journal> journals = new List<Journal>();
            foreach (Journal element in dataBase.Journals)
                if (element.CompareTo(new Product { Name = name }))
                    journals.Add(element);
            return View(journals);
        }
    }
}
