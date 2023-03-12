namespace WeDoDigital.PhoneBook.Core.Interfaces
{
    public interface IPhoneBookRepository
    {
        Task<List<Core.Models.PhoneBook>> GetPhoneBooks();

        Task<List<Core.Models.PhoneBook>> GetPhoneBooksByName(string name);

        Task<Core.Models.PhoneBook> GetPhoneBookById(int id);

        Task<bool> AddPhoneBook(Core.Models.PhoneBook phoneBook);

        Task<bool> UpdatePhoneBook(Core.Models.PhoneBook phoneBook);

        Task<bool> DeletePhoneBook(int id);
    }
}
