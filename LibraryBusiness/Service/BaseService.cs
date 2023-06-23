using FluentValidation;
using FluentValidation.Results;
using LibraryBusiness.Interface.Notificator;
using LibraryBusiness.Model;
using LibraryBusiness.Notificator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LibraryBusiness.Service
{
    public abstract class BaseService
    {
        private readonly INotificator _notificator;
        public BaseService(INotificator notificator)
        {
            _notificator = notificator;
        }
        protected void Notificate(string errorMessage)
        {
            _notificator.HandleNotification(new Notification(errorMessage));
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

        protected bool IsValid()
        {
            return !_notificator.HasNotification();
        }

        protected bool CheckExists<TEntity>(TEntity entity)
            where TEntity : BaseModel
        {
            if (entity is not null) return true;
            Notificate(string.Format("{0} Not Found", typeof(TEntity).Name));
            return false; 
        }
    }
}
