using CinePlus.Domain.Enums;
using CinePlus.Domain.Models;
using FluentValidation;

namespace CinePlus.Domain.Validators;

public class SessionSeatValidator : AbstractValidator<SessionSeat>
{
    public SessionSeatValidator()
    {
        RuleFor(seat => seat.Seat)
            .NotEmpty()
            .MinimumLength(2)
            .WithMessage("O campo assento é obrigatório e deve possuir ao menos 2 caracteres.");

        RuleFor(seat => seat.SessionId)
            .GreaterThan(0)
            .WithMessage("O campo ID da sessão deve ser maior que zero.");

        RuleFor(seat => seat.Document)
            .NotEmpty()
            .When(seat => seat.Status != SessionSeatStatus.Available)
            .WithMessage("O campo documento é obrigatório após uma reserva ter sido realizada.");

        RuleFor(seat => seat.Document)
            .Null()
            .When(seat => seat.Status == SessionSeatStatus.Available)
            .WithMessage("O campo documento não pode ser preenchido em um assento disponível.");
    }
}