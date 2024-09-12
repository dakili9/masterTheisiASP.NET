using System;
using FluentValidation;
using MasterThesisASP.NET.Data;
using MasterThesisASP.NET.Dtos.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MasterThesisASP.NET.Validators.Tasks;

public class CreateTaskRequestDtoValidator : AbstractValidator<CreateTaskRequestDto>
{
        private readonly ApplicationDbContext _context;

        public CreateTaskRequestDtoValidator(ApplicationDbContext context)
        {
            _context = context;

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(255).WithMessage("Name cannot be longer than 255 characters.");

            RuleFor(x => x.Description)
                .MaximumLength(1000).WithMessage("Description cannot be longer than 1000 characters.");

            RuleFor(x => x.Status)
                .NotNull().WithMessage("Status is required.");

            RuleFor(x => x.DueDate)
                .NotNull().WithMessage("Due date is required.")
                .Must(BeAValidDate).WithMessage("Due date must be today or a future date.");

            RuleFor(x => x.UserId)
                .NotNull().WithMessage("UserId is required.")
                .MustAsync(UserExists).WithMessage("UserId does not exist.");

            RuleFor(x => x.CategoryId)
                .NotNull().WithMessage("CategoryId is required.")
                .MustAsync(CategoryExists).WithMessage("CategoryId does not exist.");
        }

        private bool BeAValidDate(DateOnly dueDate)
        {
            return dueDate >= DateOnly.FromDateTime(DateTime.Now);
        }

        private async Task<bool> UserExists(Guid userId, CancellationToken token)
        {
            return await _context.Users.AnyAsync(u => u.Id == userId, token);
        }

        private async Task<bool> CategoryExists(Guid categoryId, CancellationToken token)
        {
            return await _context.Categories.AnyAsync(c => c.Id == categoryId, token);
        }
}
