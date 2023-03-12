using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WeDoDigital.PhoneBook.Core.Interfaces;
using WeDoDigital.PhoneBook.Infrastructure.Context;

namespace WeDoDigital.PhoneBook.Infrastructure.Repositories
{
    public class PhoneBookRepository : IPhoneBookRepository
    {
        private readonly PhoneBookDBContext _phoneBookDbContext;

        public PhoneBookRepository(PhoneBookDBContext phoneBookDbContext)
        {
            _phoneBookDbContext = phoneBookDbContext;
        }

        public async Task<bool> AddPhoneBook(Core.Models.PhoneBook phoneBook)
        {
            bool isAdded = false;

            // Id is Identity column
            phoneBook.Id = 0;

            _phoneBookDbContext.PhoneBooks.Add(phoneBook);
            var result = await _phoneBookDbContext.SaveChangesAsync();

            if (result == 1)
            {
                isAdded = true;
            }

            return isAdded;
        }

        public async Task<bool> DeletePhoneBook(int id)
        {
            bool isDeleted = false;

            var phoneBook = await _phoneBookDbContext.PhoneBooks.FirstOrDefaultAsync(a=>a.Id == id);
            _phoneBookDbContext.PhoneBooks.Remove(phoneBook);
            var result = await _phoneBookDbContext.SaveChangesAsync();

            if (result == 1)
            {
                isDeleted = true;
            }

            return isDeleted;
        }

        public async Task<Core.Models.PhoneBook> GetPhoneBookById(int id)
        {
            var phoneBook = await _phoneBookDbContext.PhoneBooks.FirstOrDefaultAsync(a => a.Id == id);
            return phoneBook;
        }

        public async Task<List<Core.Models.PhoneBook>> GetPhoneBooks()
        {
            return await _phoneBookDbContext
                         .PhoneBooks
                         .AsNoTracking()
                         .ToListAsync();
        }

        public async Task<List<Core.Models.PhoneBook>> GetPhoneBooksByName(string name)
        {
            return await _phoneBookDbContext
                         .PhoneBooks
                         .AsNoTracking()
                         .Where(a=>a.FirstName.Contains(name) || a.LastName.Contains(name))
                         .ToListAsync();
        }

        public async Task<bool> UpdatePhoneBook(Core.Models.PhoneBook phoneBook)
        {
            bool isUpdated = false;

            _phoneBookDbContext.PhoneBooks.Add(phoneBook);
            _phoneBookDbContext.Entry(phoneBook).State = EntityState.Modified;
            var result = await _phoneBookDbContext.SaveChangesAsync();

            if (result == 1)
            {
                isUpdated = true;
            }

            return isUpdated;
        }
    }
}
