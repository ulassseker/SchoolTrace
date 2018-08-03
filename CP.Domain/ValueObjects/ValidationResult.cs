using System.Collections.Generic;
using System.Linq;

namespace CP.Domain.ValueObjects
{
    public class ValidationResult
    {
        private readonly List<ValidationError> _errors = new List<ValidationError>();

        public string Message { get; set; }
        public bool IsValid { get { return _errors.Count == 0; } }

        public IEnumerable<ValidationError> Erros { get { return this._errors; } }
        public void AddError(ValidationError error)
        {
            _errors.Add(error);
        }
        public void RemoveError(ValidationError error)
        {
            if (_errors.Contains(error))
                _errors.Remove(error);
        }

        public void AddError(params ValidationResult[] resultValidation)
        {
            if (resultValidation == null) return;

            foreach (var validationResult in resultValidation.Where(result => result != null))
                this._errors.AddRange(validationResult.Erros);
        }
    }
}
