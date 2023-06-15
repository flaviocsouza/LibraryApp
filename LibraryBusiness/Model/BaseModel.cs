using System;

namespace LibraryBusiness.Model
{
    public abstract class BaseModel
    {
        public BaseModel()
        {
            Id = Guid.NewGuid();
            CreateDate = DateTime.Now;
            UpdateDate = DateTime.Now;
            DeleteDate = null;
        }

        public Guid Id {get; set;}
        public DateTime CreateDate {get; set;}
        public DateTime UpdateDate {get; set;}
        public DateTime? DeleteDate {get; set;}
        public bool IsActive {
            get 
            {
                return DeleteDate == null;
            }
        }
    }
}