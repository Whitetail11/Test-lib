using AutoMapper;
using BusinessLayer.DTOs;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>()
                .ForMember(j => j.Books, opt => opt.MapFrom(
                    route => route.UsersBooks.ToList().Select(
                            el => new BookDTO
                            {
                                Name = el.Book.Name,
                                Id = el.Book.Id
                            }
                        )
                    ));
                ;
            CreateMap<Book, BookDTO>()
                .ForMember(j => j.Authors, opt => opt.MapFrom(
                    route => route.BookAuthors.ToList().Select(
                        el => new AuthorDTO
                        {
                            Name = el.Authors.Name,
                            Id = el.Authors.Id
                        }
                        )))
                .ForMember(j => j.Users, opt => opt.MapFrom(
                    route => route.UsersBooks.ToList().Select(
                        el => new UserDTO
                        {
                            Name = el.User.UserName
                        }
                        )
                    ));

        }
    }
}
