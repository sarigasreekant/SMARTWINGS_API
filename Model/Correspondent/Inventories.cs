using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForexModel
{
    public class Inventories
    {
        public string RefNo { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        //public string ServOrgCode { get; set; } = string.Empty;
        //public string CurCode { get; set; } = string.Empty;
        //public string ServCode { get; set; } = string.Empty;
    }



    public class InventoriesValidator : AbstractValidator<Inventories>
    {
        private readonly IEnumerable<ServiceRules> _serviceRules;

        public InventoriesValidator(IEnumerable<ServiceRules> serviceRules)
        {
            _serviceRules = serviceRules;
            RuleFor(Inventories => Inventories.RefNo).NotEmpty().WithMessage("Please enter the RefNo Name");
            // Apply validation rules based on service rules
            if (_serviceRules != null)
            {
                foreach (var rule in _serviceRules)
                {

                    if (rule.FieldName == "RefNo")
                        RuleFor(Inventories => Inventories.RefNo).NotEmpty().WithMessage("Please enter the RefNo Name");
                    if (rule.FieldName == "Address")
                        RuleFor(Inventories => Inventories.Address).NotEmpty().WithMessage("Please enter the Address Name");
                    if (rule.FieldName == "Phone")
                        RuleFor(Inventories => Inventories.Phone).NotEmpty().WithMessage("Please enter the Phone Name");



                    // Add more rules based on other conditions
                }
            }
        }
        //public InventoriesValidator(IEnumerable<ServiceRules> serviceRules)
        //{
        //    _serviceRules = serviceRules ?? throw new ArgumentNullException(nameof(serviceRules));
        //    RuleFor(inventory => inventory.RefNo).NotEmpty().WithMessage("Please enter the RefNo.");

        //    if (_serviceRules.Any())
        //    {
        //        foreach (var rule in _serviceRules)
        //        {
        //            switch (rule.FieldName)
        //            {
        //                case "RefNo":
        //                    RuleFor(inventory => inventory.RefNo).NotEmpty().WithMessage("Please enter the RefNo.");
        //                    break;
        //                case "Address":
        //                    RuleFor(inventory => inventory.Address).NotEmpty().WithMessage("Please enter the Address.");
        //                    break;
        //                case "Phone":
        //                    RuleFor(inventory => inventory.Phone).NotEmpty().WithMessage("Please enter the Phone.");
        //                    break;
        //                // Add more cases based on other conditions
        //                default:
        //                    // Handle unknown field names or log a warning
        //                    break;
        //            }
        //        }
        //    }
        //}
        private Expression<Func<Inventories, object>> GetPropertyExpression(string propertyName)
        {
            var parameter = Expression.Parameter(typeof(Inventories), "x");
            var property = Expression.Property(parameter, propertyName);
            var conversion = Expression.Convert(property, typeof(object));
            return Expression.Lambda<Func<Inventories, object>>(conversion, parameter);
        }
    }

}

