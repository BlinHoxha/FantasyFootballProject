using FluentValidation;
using System;
using System.Linq.Expressions;

public abstract class BaseValidator<T> : AbstractValidator<T>
{
    protected BaseValidator()
    {
        RuleFor(x => x).NotNull().WithMessage("{PropertyName} cannot be null.");
    }

    protected void ValidateStringProperty(Expression<Func<T, string>> propertyExpression, string propertyName)
    {
        RuleFor(propertyExpression)
            .NotEmpty().WithMessage($"{propertyName} is required.")
            .MaximumLength(100).WithMessage($"{propertyName} cannot be longer than 100 characters.");
    }

    protected void ValidateDateProperty(Expression<Func<T, DateTime>> propertyExpression, string propertyName)
    {
        RuleFor(propertyExpression)
            .NotEmpty().WithMessage($"{propertyName} is required.")
            .LessThan(DateTime.Now).WithMessage($"{propertyName} must be a past date.");
    }

    protected void ValidateEmailProperty(Expression<Func<T, string>> propertyExpression)
    {
        RuleFor(propertyExpression)
            .NotEmpty().WithMessage("Email Address is required.")
            .EmailAddress().WithMessage("A valid email address is required.");
    }
}
