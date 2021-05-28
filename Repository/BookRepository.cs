using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using MyBookApi.Data;
using MyBookApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookApi.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookContext context;
        private readonly IMapper mapper;

        public BookRepository(BookContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }



        public async Task<List<BookModel>> GetAllBooks()
        {
            //var result = await context.Books.Select(x => new BookModel
            //{
            //    id = x.id,
            //    name = x.name,
            //    description = x.description

            //}).ToListAsync();

            //return result;

            //with auto mapper
            var result = await context.Books.ToListAsync();
            return mapper.Map<List<BookModel>>(result);
        }

        public async Task<BookModel> GetBookById(int id)
        {
            //var result = await context.Books.Where(x => x.id == id).Select(x => new BookModel
            //{
            //    id = x.id,
            //    name = x.name,
            //    description = x.description

            //}).FirstOrDefaultAsync();

            //return result;

            //with automapper
            var books = await context.Books.FindAsync();
            return mapper.Map<BookModel>(books);

        }
        public async Task<int> AddBook(BookModel model)
        {
            var result = new Book()
           { 
                name=model.name,
                description=model.description
            };

            context.Books.Add(result);
           await context.SaveChangesAsync();
            return result.id;

        }

        public async Task UpdateAll(BookModel model,int id)
        {

            //var book = await context.Books.FindAsync(id);
            //if(book != null)
            //{
            //    book.name = model.name;
            //    book.description = model.description;

            //    await context.SaveChangesAsync();

            //}

            //second method to update

            var book = new Book
            {
                id = id,
                name = model.name,
                description = model.description
            };
            context.Books.Update(book);
            await context.SaveChangesAsync();
        }

        //public async Task updatePatch(int id,JsonPatchDocument bookmodel)
        //{
        //    var book = await context.Books.FindAsync(id);
        //    if(book !=null)
        //    {
        //        bookmodel.ApplyTo(book);
        //        await context.SaveChangesAsync();
        //    }
        //}

        public async Task Delete(int id)
        {
            var book = new Book { id = id };

            context.Books.Remove(book);
            await context.SaveChangesAsync();
        }
    }
    }
