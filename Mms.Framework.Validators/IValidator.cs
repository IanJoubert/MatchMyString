namespace Mms.Framework.Validators
{
    public interface IValidator<in T>
    {
        bool Validate(T item);
    }
}
