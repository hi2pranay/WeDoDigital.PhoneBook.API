using MediatR;
using WeDoDigital.PhoneBook.Core.Interfaces;

namespace WeDoDigital.PhoneBook.Core.Requests.Commands
{
    public class AddPhoneBookRequest : IRequest<bool>
    {
        public Core.Models.PhoneBook PhoneBook { get; set; }

        public AddPhoneBookRequest(Core.Models.PhoneBook phoneBook)
        {
            PhoneBook = phoneBook;
        }
    }

    public class AddPhoneBookHandler : IRequestHandler<AddPhoneBookRequest, bool>
    {
        private readonly IPhoneBookRepository _phoneBookRepository;

        public AddPhoneBookHandler(IPhoneBookRepository phoneBookRepository)
        {
            _phoneBookRepository = phoneBookRepository;
        }

        public async Task<bool> Handle(AddPhoneBookRequest request, CancellationToken cancellationToken)
        {
            var result = await this._phoneBookRepository.AddPhoneBook(request?.PhoneBook).ConfigureAwait(false);
            return result;
        }
    }
}
