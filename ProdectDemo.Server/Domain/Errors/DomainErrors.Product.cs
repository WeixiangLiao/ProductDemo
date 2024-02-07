using ErrorOr;
using ProductDemo.Server.Domain.Errors.Common;

namespace ProductDemo.Server.Domain.Errors;

public static partial class DomainErrors
{
    public static class Product
    {
        private const string EntityName = "Product";
        public static Error NotFound => Error.NotFound(
            code: EntityName + ".NotFound",
            description: EntityName + " not found"
        );

        public static Error NotFoundWithPhoneNumber => Error.NotFound(
            code: EntityName + ".NotFound",
            description: EntityName + " not found with phone number"
        );

        public static Error Gone => Error.Custom(
            type: CustomErrorTypes.Gone,
            code: EntityName + ".Gone",
            description: EntityName + " has been deactivated"
        );

        public static Error ExistingConflict => Error.Conflict(
            code: EntityName + ".ExistingConflict",
            description: EntityName + " already exists"
        );

        public static Error ProductTypeConflict => Error.Conflict(
            code: EntityName + ".ProductTypeConflict",
            description: EntityName + " ProductType conflicting with the request"
        );

        public static Error ForeignKeyInvalid(IList<string> fields)
        {
            var description = "The fields ";

            if (fields.Count == 1) description = $"The field {fields.First()} is referring to invalid data";
            else
            {
                foreach (var field in fields) description += $"{field}, ";

                description = description[..^2];
                description += " are referring invalid data";
            }

            return Error.Validation(
                code: EntityName + ".ForeignKeyInvalid",
                description: description
            );
        }

        public static Error InvalidOrderField(IEnumerable<string> validFields)
        {
            var description = "The Field you try to order by is invalid, here are the valid fields: ";

            foreach (var field in validFields)
                description += $"{field}, ";

            description = description[..^2];

            return Error.Validation(
                code: EntityName + ".InvalidOrderField",
                description: description
                );
        }
    }
}