using FluentValidation;
using FluentValidation.Results;
using LibraryBusiness.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LibraryBusiness.Service
{
    public abstract class BaseService
    {
        protected void Notificate(string errorMessage)
        {
            //TODO: Take the error message to the presentation layer
            return;
        }

        protected void Notificate(ValidationResult result)
        {
            foreach(var error in result.Errors)
                Notificate(error.ErrorMessage);

        }

        protected bool ExecuteValidation<TValidador, TEntity>(TValidador validator, TEntity entity)
            where TValidador : AbstractValidator<TEntity>
            where TEntity : BaseModel
        {
            var result =  validator.Validate(entity);
            
            if (result.IsValid) return true;
            Notificate(result);
            return false;

        }
    }
}
