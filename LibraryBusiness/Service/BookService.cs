﻿using LibraryBusiness.Interface.Notificator;
using LibraryBusiness.Interface.Repository;
using LibraryBusiness.Interface.Service;
using LibraryBusiness.Model;
using LibraryBusiness.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBusiness.Service
{
    public class BookService : BaseService, IBookService
    {

        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IPublisherRepository _publisherRepository;

        public BookService(
            INotificator notificator,
            IAuthorRepository authorRepository,
            IBookRepository bookRepository,
            IPublisherRepository publisherRepository) : base(notificator)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _publisherRepository = publisherRepository;
        }

        public async Task RegisterBook(Book book)
        {
            var valid = true;
            if (!ExecuteValidation(new BookValidator(), book)) valid = false;
            if (book.Author is not null && !ExecuteValidation(new AuthorValidator(), book.Author)) valid = false; 
            if (book.Publisher is not null && !ExecuteValidation(new PublisherValidator(), book.Publisher)) valid = false;
            if (!valid) return;

            await InsertOrUpdateAuthor(book.Author);
            await InsertOrUpdatePublisher(book.Publisher);

            await _bookRepository.Insert(book);

        }

        public async Task UpdateBook(Book book)
        {
            var valid = true;
            if (!ExecuteValidation(new BookValidator(), book)) valid = false; 
            if (book.Author is not null && !ExecuteValidation(new AuthorValidator(), book.Author)) valid = false; 
            if (book.Publisher is not null && !ExecuteValidation(new PublisherValidator(), book.Publisher)) valid = false;
            if (!valid) return;

            var bookToUpdate = await _bookRepository.GetById(book.Id);
            
            if (bookToUpdate == null)
            {
                Notificate("Book Not Found");
                return;
            }

            if(bookToUpdate.AuthorId != book.AuthorId) 
                await InsertOrUpdateAuthor(bookToUpdate.Author);
            
            if(bookToUpdate.PublisherId != book.PublisherId) 
                await InsertOrUpdatePublisher(bookToUpdate.Publisher);

            await _bookRepository.Update(book);
        }

        public Task Delete(Guid id)
        {
            return _bookRepository.Delete(id);
        }

        private async Task InsertOrUpdateAuthor(Author author)
        {
            if (author is null) return;
            var RegisteredAuthor = await _authorRepository.Find(a =>
             string.Equals(a.Name, author.Name, StringComparison.OrdinalIgnoreCase));

            if (RegisteredAuthor is null) await _authorRepository.Insert(author);
            await _authorRepository.Update(author);
        }

        private async Task InsertOrUpdatePublisher(Publisher publisher)
        {
            if (publisher is null) return;
            var RegisteredPublisher = await _publisherRepository.Find(p =>
            string.Equals(p.Name, publisher.Name, StringComparison.OrdinalIgnoreCase));

            if (RegisteredPublisher is null) await _publisherRepository.Insert(publisher);
            await _publisherRepository.Update(publisher);
        }

    }
}
