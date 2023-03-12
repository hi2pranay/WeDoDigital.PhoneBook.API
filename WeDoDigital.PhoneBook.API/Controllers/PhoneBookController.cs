using MediatR;
using Microsoft.AspNetCore.Mvc;
using WeDoDigital.PhoneBook.Core.Common.Wrappers;
using WeDoDigital.PhoneBook.Core.Requests.Commands;
using WeDoDigital.PhoneBook.Core.Requests.Queries;

namespace WeDoDigital.PhoneBook.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    public class PhoneBookController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public PhoneBookController(IMediator mediator, ILogger<PhoneBookController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [Route("getphonebooks")]
        [HttpGet]
        public async Task<IActionResult> GetPhoneBooks()
        {
            var phonebookList = await _mediator.Send(new GetPhoneBooksRequest()).ConfigureAwait(false);
            return Ok(phonebookList);
        }

        [Route("getphonebooksbyname")]
        [HttpGet]
        public async Task<IActionResult> GetPhoneBooksByName(string name)
        {
            var phonebookList = await _mediator.Send(new GetPhoneBooksByNameRequest(name)).ConfigureAwait(false);
            return Ok(phonebookList);
        }

        [Route("getphonebook")]
        [HttpGet]
        public async Task<IActionResult> GetPhoneBook(int id)
        {
            var phonebook = await _mediator.Send(new GetPhoneBookRequest(id)).ConfigureAwait(false);
            return Ok(phonebook);
        }

        [Route("addphonebook")]
        [HttpPost]
        public async Task<IActionResult> AddPhoneBook(Core.Models.PhoneBook phoneBook)
        {
            if (phoneBook == null)
            {
                return BadRequest("Cannot be empty");
            }

            var isAdded = await _mediator.Send(new AddPhoneBookRequest(phoneBook)).ConfigureAwait(false);
            return Ok(isAdded);
        }

        [Route("updatephonebook")]
        [HttpPatch]
        public async Task<IActionResult> UpdatePhoneBook(Core.Models.PhoneBook phoneBook)
        {
            if (phoneBook == null)
            {
                return BadRequest("Cannot be empty");
            }

            var isUpdated = await _mediator.Send(new UpdatePhoneBookRequest(phoneBook)).ConfigureAwait(false);
            return Ok(isUpdated);
        }


        [Route("deletephonebook")]
        [HttpDelete]
        public async Task<IActionResult> DeletePhoneBook(int id)
        {
            var isDeleted = await _mediator.Send(new DeletePhoneBookRequest(id)).ConfigureAwait(false);
            return Ok(isDeleted);
        }
    }
}
