using FluentValidation;

namespace WebApi.BookOperations.GetBooks
{
    public class GetBooksQueryValidator:AbstractValidator<GetBooksQuery>
    {
        public GetBooksQueryValidator()
        {
           
        }
    }
}