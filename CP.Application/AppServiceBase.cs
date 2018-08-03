using CP.Application.Interfaces;
using CP.Application.Validation;
using CP.Domain.ValueObjects;
using CP.Data.Interfaces;

namespace CP.Application
{
    public class AppServiceBase : IAppServiceBase
    {
        private IUnitOfWork _uow;
        public AppServiceBase(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public void BeginTransaction()
        {
            _uow.BeginTransaction();
        }

        public void Commit()
        {
            _uow.SaveChanges();
        }

        protected ValidationAppResult DomainToApplicationResult(ValidationResult result)
        {
            var validationAppResult = new ValidationAppResult();

            foreach (var validationError in result.Erros)
            {
                validationAppResult.Erros.Add(new ValidationAppError(validationError.Message));
            }
            validationAppResult.IsValid = result.IsValid;

            return validationAppResult;
        }
    }
}
