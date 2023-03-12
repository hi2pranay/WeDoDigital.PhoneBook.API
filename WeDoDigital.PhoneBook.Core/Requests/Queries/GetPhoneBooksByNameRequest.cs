using MediatR;
using WeDoDigital.PhoneBook.Core.Common.Wrappers;
using WeDoDigital.PhoneBook.Core.Interfaces;

namespace WeDoDigital.PhoneBook.Core.Requests.Queries
{
    public class GetPhoneBooksByNameRequest : IRequest<Response<List<Core.Models.PhoneBook>>>
    {
        public string Name { get; set; }
        public GetPhoneBooksByNameRequest(string name)
        {
            Name = name;
        }
    }

    public class GetPhoneBooksByNameHandler : IRequestHandler<GetPhoneBooksByNameRequest, Response<List<Core.Models.PhoneBook>>>
    {
        private readonly IPhoneBookRepository _phoneBookRepository;

        public GetPhoneBooksByNameHandler(IPhoneBookRepository phoneBookRepository)
        {
            _phoneBookRepository = phoneBookRepository;
        }

        public async Task<Response<List<Models.PhoneBook>>> Handle(GetPhoneBooksByNameRequest request, CancellationToken cancellationToken)
        {
            var result = await _phoneBookRepository.GetPhoneBooksByName(request.Name);
            return new Response<List<Core.Models.PhoneBook>>(result, "OK");
        }
    }
}
