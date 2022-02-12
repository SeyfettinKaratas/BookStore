using FluentValidation;

namespace WebApi.Application.BookOperations.Queries.GetBooks
{
    public class GetBooksQueryValidator:AbstractValidator<GetBooksQuery>
    {
        public GetBooksQueryValidator()
        {
            
        }
    }
}