using FluentValidation;

namespace WebApi.Application.BookOperations.Commands.CreateBook
{
    public class CreateBookCommandValidator:AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(command=> command.Model.GenreID).GreaterThan(0);
            RuleFor(command=> command.Model.Pagecount).GreaterThan(0);
            RuleFor(command=> command.Model.PublishDate.Date).NotEmpty().LessThan(System.DateTime.Now.Date);
            RuleFor(command=> command.Model.Title).NotEmpty().MinimumLength(4);          

        }
    }
}