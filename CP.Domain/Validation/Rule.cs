using CP.Domain.Interfaces.Specification;
using CP.Domain.Interfaces.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.Domain.Validation
{
    public class Rule<TEntity> : IRule<TEntity>
    {
        private readonly ISpecification<TEntity> _specificationRule;
        public string MessageError { get; private set; }

        public Rule(ISpecification<TEntity> rule, string messageError)
        {
            this._specificationRule = rule;
            this.MessageError = messageError;
        }

        public bool Validate(TEntity entity)
        {
            return this._specificationRule.IsSatisfiedBy(entity);
        }
    }
}
