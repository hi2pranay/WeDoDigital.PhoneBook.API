using MediatR;
using WeDoDigital.PhoneBook.Core.Common.Wrappers;
using WeDoDigital.PhoneBook.Core.Interfaces;

namespace WeDoDigital.PhoneBook.Core.Requests.Commands
{
    public class DeletePhoneBookRequest : IRequest<Response<bool>>
    {
        public int PhoneBookId { get; set; }

        public DeletePhoneBookRequest(int phoneBookId)
        {
            this.PhoneBookId = phoneBookId;
        }
    }

    public class DeletePhoneBookHandler : IRequestHandler<DeletePhoneBookRequest, Response<bool>>
    {
        private readonly IPhoneBookRepository _phoneBookRepository;

        public DeletePhoneBookHandler(IPhoneBookRepository phoneBookRepository)
        {
            _phoneBookRepository = phoneBookRepository;
        }

        public async Task<Response<bool>> Handle(DeletePhoneBookRequest request, CancellationToken cancellationToken)
        {
            var result = await _phoneBookRepository.DeletePhoneBook(request.PhoneBookId);
            return new Response<bool>(result, "OK"); ;
        }
    }
}
