using CinePlus.Domain.Models;
using FluentValidation;

namespace CinePlus.Domain.Validators;

public class SessionValidator : AbstractValidator<Session>
{
    public SessionValidator()
    {
        RuleFor(session => session.Price)
            .GreaterThanOrEqualTo(0)
            .WithMessage("O preço deve ser maior ou igual a zero.");

        RuleFor(session => session.DateTime)
            .GreaterThanOrEqualTo(DateTime.Today)
            .WithMessage("Não é possível criar uma sessão com data inferior a hoje.");

        RuleFor(session => session.MovieId)
            .GreaterThan(0)
            .WithMessage("O Id do filme deve ser maior que zero.");
        
        RuleFor(session => session.RoomId)
            .GreaterThan(0)
            .WithMessage("O Id da sala deve ser maior que zero.");
    }
}