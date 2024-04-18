using CinePlus.Domain.Models;
using FluentValidation;

namespace CinePlus.Domain.Validators;

public class MovieValidator : AbstractValidator<Movie>
{
    public MovieValidator()
    {
        RuleFor(movie => movie.Name)
            .NotEmpty()
            .MinimumLength(2)
            .WithMessage("O campo nome é obrigatório e deve possuir ao menos 2 caracteres.");

        RuleFor(movie => movie.Image)
            .NotEmpty()
            .WithMessage("O campo imagem é obrigatório");

        RuleFor(movie => movie.DurationInMinutes)
            .GreaterThan(0)
            .WithMessage("A duração em minutos do filme deve ser informada.");
    }
}