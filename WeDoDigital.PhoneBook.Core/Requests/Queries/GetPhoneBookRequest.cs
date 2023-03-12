using MediatR;
using WeDoDigital.PhoneBook.Core.Common.Wrappers;
using WeDoDigital.PhoneBook.Core.Interfaces;

namespace WeDoDigital.PhoneBook.Core.Requests.Queries
{
    public class GetPhoneBookRequest : IRequest<Response<Core.Models.PhoneBook>>
    {
        public int PhoneBookId { get; set; }

        public GetPhoneBookRequest(int phoneBookId)
        {
            this.PhoneBookId = phoneBookId;
        }
    }

    public class GetPhoneBookHandler : IRequestHandler<GetPhoneBookRequest, Response<Core.Models.PhoneBook>>
    {
        private readonly IPhoneBookRepository _phoneBookRepository;

        public GetPhoneBookHandler(IPhoneBookRepository phoneBookRepository)
        {
            _phoneBookRepository = phoneBookRepository;
        }

        public async Task<Response<Core.Models.PhoneBook>> Handle(GetPhoneBookRequest request, CancellationToken cancellationToken)
        {
            var result = await _phoneBookRepository.GetPhoneBookById(request.PhoneBookId);
            return new Response<Core.Models.PhoneBook>(result, "OK");
        }
    }
}
