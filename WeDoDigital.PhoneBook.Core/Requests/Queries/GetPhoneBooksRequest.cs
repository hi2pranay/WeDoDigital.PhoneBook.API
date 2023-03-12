using MediatR;
using WeDoDigital.PhoneBook.Core.Common.Wrappers;
using WeDoDigital.PhoneBook.Core.Interfaces;

namespace WeDoDigital.PhoneBook.Core.Requests.Queries
{
    public class GetPhoneBooksRequest : IRequest<Response<List<Core.Models.PhoneBook>>>
    {
        public GetPhoneBooksRequest()
        {

        }
    }

    public class GetPhoneBooksHandler : IRequestHandler<GetPhoneBooksRequest, Response<List<Core.Models.PhoneBook>>>
    {
        private readonly IPhoneBookRepository _phoneBookRepository;

        public GetPhoneBooksHandler(IPhoneBookRepository phoneBookRepository)
        {
            _phoneBookRepository = phoneBookRepository;
        }

        public async Task<Response<List<Models.PhoneBook>>> Handle(GetPhoneBooksRequest request, CancellationToken cancellationToken)
        {
            var result = await _phoneBookRepository.GetPhoneBooks();
            return new Response<List<Core.Models.PhoneBook>>(result, "OK");
        }
    }
}
