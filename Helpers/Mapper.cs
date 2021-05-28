using AutoMapper;
using MyBookApi.Data;
using MyBookApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookApi.Helpers
{
    public class Mapper:Profile
    {

        public Mapper()
        {
            CreateMap<Book, BookModel>().ReverseMap();
        }
    }
}
