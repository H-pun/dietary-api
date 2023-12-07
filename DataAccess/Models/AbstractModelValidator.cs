using FluentValidation;

namespace Dietary.DataAccess.Models
{
    public abstract class AbstractModelValidator<T> : AbstractValidator<T> where T : class { }
}
