
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
    public class PublisherService : BaseService, IPublisherService
    {
        private readonly IPublisherRepository _publisherRepository;

        public PublisherService(INotificator notificator,
            IPublisherRepository publisherRepository) : base(notificator)
        {
            _publisherRepository = publisherRepository;
        }

        public async Task Insert(Publisher publisher)
        {
            if (!ExecuteValidation(new PublisherValidator(), publisher) ||
                !ExecuteValidation(new AddressValidator(), publisher.Address)) return;

            await _publisherRepository.Insert(publisher);
        }

        public async Task Update(Publisher publisher)
        {
            if (!ExecuteValidation(new PublisherValidator(), publisher) ||
                !ExecuteValidation(new AddressValidator(), publisher.Address)) return;

            await _publisherRepository.Update(publisher);
        }
        public async Task Delete(Guid id)
        {
            await _publisherRepository.Delete(id);
        }
    }
}
