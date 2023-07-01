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
    public class LibraryService : BaseService, ILibraryService
    {
        private ILibraryRepository _libraryRepository;
        public LibraryService(INotificator notificator,
            ILibraryRepository libraryRepository) : base(notificator)
        {
            _libraryRepository = libraryRepository;
        }

        public async Task Insert(Library library)
        {
            if (!ExecuteValidation(new LibraryValidator(), library)) return;

            await _libraryRepository.Insert(library);

        }

        public async Task Update(Library library)
        {

            if (!ExecuteValidation(new LibraryValidator(), library)) return;

            await _libraryRepository.Update(library);
        }

        public Task Delete(Guid id)
        {
            return _libraryRepository.Delete(id);
        }
    }
}
