using CP.Domain.Interfaces.Validation;
using CP.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.Domain.Validation.Base
{
    public class FiscalBase<TEntity> : IFiscal<TEntity> where TEntity : class
    {
        private readonly Dictionary<string, IRule<TEntity>> _validations = new Dictionary<string, IRule<TEntity>>();

        protected virtual void AddRule(string nomeRegra, IRule<TEntity> rule)
        {
            _validations.Add(nomeRegra, rule);
        }

        protected virtual void RemoveRule(string nameRule)
        {
            _validations.Remove(nameRule);
        }

        protected IRule<TEntity> GetRule(string nameRule)
        {
            IRule<TEntity> rule;
            _validations.TryGetValue(nameRule, out rule);
            return rule;
        }

        public ValidationResult Validate(TEntity entity)
        {
            var result = new ValidationResult();
            foreach (var x in _validations.Keys)
            {
                var rule = _validations[x];
                if (!rule.Validate(entity))
                    result.AddError(new ValidationError(rule.MessageError));
            }

            return result;
        }


    }
}
