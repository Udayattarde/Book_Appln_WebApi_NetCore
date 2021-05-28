using Microsoft.AspNetCore.JsonPatch;
using MyBookApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookApi.Repository
{
    public interface IBookRepository
    {
        Task<List<BookModel>> GetAllBooks();
        Task<BookModel> GetBookById(int id);
        Task<int> AddBook(BookModel model);
       // Task updatePatch(int id, JsonPatchDocument bookmodel);
        Task UpdateAll(BookModel model, int id);
        Task Delete(int id);

    }
}
