using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeDoDigital.PhoneBook.Core.Common.Wrappers;
using WeDoDigital.PhoneBook.Core.Interfaces;

namespace WeDoDigital.PhoneBook.Core.Requests.Commands
{
    public class UpdatePhoneBookRequest : IRequest<bool>
    {
        public Core.Models.PhoneBook PhoneBook { get; set; }

        public UpdatePhoneBookRequest(Core.Models.PhoneBook phoneBook)
        {
            PhoneBook = phoneBook;
        }
    }

    public class UpdatePhoneBookHandler : IRequestHandler<UpdatePhoneBookRequest, bool>
    {
        private readonly IPhoneBookRepository _phoneBookRepository;

        public UpdatePhoneBookHandler(IPhoneBookRepository phoneBookRepository)
        {
            _phoneBookRepository = phoneBookRepository;
        }

        public async Task<bool> Handle(UpdatePhoneBookRequest request, CancellationToken cancellationToken)
        {
            var result = await this._phoneBookRepository.UpdatePhoneBook(request?.PhoneBook).ConfigureAwait(false);
            return result;
        }
    }
}
