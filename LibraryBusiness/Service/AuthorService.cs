using LibraryBusiness.Interface.Notificator;
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
    public class AuthorService : BaseService, IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;

        public AuthorService(
            INotificator notificator, 
            IAuthorRepository authorRepository,
            IBookRepository bookRepository
        ) : base(notificator)
        {
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
        }

        public async Task Insert(Author author)
        {
            if(!ExecuteValidation(new AuthorValidator(), author)) return;
            
            var hasSameName = await _authorRepository.Find(a =>
             string.Equals(a.Name, author.Name));

            if (hasSameName.Any()) Notificate("There is already an Author registered with that name");
            else  await _authorRepository.Insert(author);

        }
        public async Task Update(Author author)
        {
            if (!ExecuteValidation(new AuthorValidator(), author)) return;

            var hasSameName = await _authorRepository.Find(a =>
             string.Equals(a.Name, author.Name) && author.Id != a.Id);

            if (hasSameName.Any()) Notificate("There is already an Author registered with that name");

            await _authorRepository.Update(author);
        }

        public async Task Delete(Guid id)
        {
            if((await _bookRepository.Find(b => b.AuthorId == id)).Any())
            {
                Notificate("This Author has books registered in his name");
                return;
            }

            await _authorRepository.Delete(id);
        }
    }
}
