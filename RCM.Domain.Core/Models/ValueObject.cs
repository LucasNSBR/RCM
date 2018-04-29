using System.ComponentModel.DataAnnotations.Schema;

namespace RCM.Domain.Core.Models
{
    public abstract class ValueObject
    {
        [NotMapped]
        //EF DOESN'T ALLOW NULL OWNED TYPES
        //THIS WILL WORK LIKE A NULL CHECK
        public virtual bool IsEmpty
        {
            get
            {
                var properties = GetType().GetProperties();

                foreach (var property in properties)
                {
                    if (property.Name == nameof(IsEmpty))
                        continue;

                    if (property.GetValue(this) != null)
                        return false;
                }

                return true;
            }
        }
    }
}
