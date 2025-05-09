using WebApi.BookOperations.GetBookDetail;
using WebApi.BookOperations.GetBooks;

namespace WebApi.Common
{
    using AutoMapper;
    using WebApi.BookOperations.CreateBook;
 


    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookCommand.CreateBookModel, Book>();
            CreateMap<Book, GetBookDetailQuery.BookDetailViewModel>().ForMember(dest => dest.GenreId,
                opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
            CreateMap<Book, GetBooksQuery.BooksViewModel>().ForMember(dest => dest.Genre,
                opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
        }
    }
}