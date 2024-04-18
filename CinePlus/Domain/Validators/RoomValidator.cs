using CinePlus.Domain.Models;
using FluentValidation;

namespace CinePlus.Domain.Validators;

public class RoomValidator: AbstractValidator<Room>
{
    public RoomValidator()
    {
        RuleFor(room => room.Name)
            .NotEmpty()
            .MinimumLength(2)
            .WithMessage("O campo nome é obrigatório e deve possuir ao menos 2 caracteres.");

        RuleFor(room => room.RowsCount)
            .GreaterThan(0)
            .WithMessage("O campo quantidade de fileiras deve ser maior que zero.");
        
        RuleFor(room => room.SeatsByRow)
            .GreaterThan(0)
            .WithMessage("O campo assentos por fileira deve ser maior que zero.");
    }
}