using FluentValidation;

namespace WebApi.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidator:AbstractValidator<CreateAuthorCommand>
    {
       public CreateAuthorCommandValidator()
       {
           RuleFor(command=>command.model.Name).NotEmpty();
           RuleFor(command=>command.model.Surname).NotEmpty();
           RuleFor(command=>command.model.BirthDate).NotEmpty().LessThan(System.DateTime.Now.Date);
        }
    }
}