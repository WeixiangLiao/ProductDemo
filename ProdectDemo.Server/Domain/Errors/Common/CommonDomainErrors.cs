using ErrorOr;

namespace ProductDemo.Server.Domain.Errors.Common;

public static partial class CommonDomainErrors
{

    /// <summary>
    /// NotFound is used when the entity is not found in the database.
    /// </summary>
    /// <param name="entityName">The name of the entity class. Recommended to use "nameof".</param>
    /// <returns>A NotFound error with the entity name and description</returns>
    public static Error NotFound(string entityName)
    {

        return Error.NotFound(
            code: $"{entityName}.NotFound",
            description: $"{entityName} not found"
        );
    }


    /// <summary>
    /// NotFoundBy is used when the entity is not found in the database by the given property.
    /// </summary>
    /// <param name="entityName">The name of the entity class. Recommended to use "nameof".</param>
    /// <param name="queryPropertyName">The name of the queried property in the entity class, Recommended to use "nameof"</param>
    /// <returns>A NotFound error with the entity name and description</returns>
    public static Error NotFoundBy(string entityName, string queryPropertyName)
    {

        return Error.NotFound(
            code: $"{entityName}.NotFound",
            description: $"{entityName} not found by {queryPropertyName}"
        );
    }

    /// <summary>
    /// Gone is used when the entity is found in the database but it is deactivated.
    /// </summary>
    /// <param name="entityName">The name of the entity class. Recommended to use "nameof".</param>
    /// <returns>A Gone error with the entity name and description</returns>
    public static Error Gone(string entityName)
    {

        return Error.Custom(
            type: CustomErrorTypes.Gone,
            code: $"{entityName}.Gone",
            description: $"{entityName} has been deactivated"
        );
    }


    /// <summary>
    /// InvalidId is used when a collection of entities is tried to be ordered by an invalid field.
    /// </summary>
    /// <param name="entityName">The name of the entity class. Recommended to use "nameof".</param>
    /// <param name="validFields">The list of valid fields to by ordered by</param>
    /// <returns>A InvalidOrderFiled error with entity and valid fields to order</returns>
    public static Error InvalidOrderField(string entityName, IEnumerable<string> validFields)
    {
        var description = "The field you tried to order by is invalid. The valid fields are: ";

        foreach (var field in validFields)
            description += $"{field}, ";

        // Remove the last comma and space
        description = description[..^2];

        return Error.Validation(
            code: $"{entityName}.InvalidOrderField",
            description: description
        );
    }


    /// <summary>
    /// ConflictWithReferenceConstraints is used when the ReferenceConstraintException is caught.
    /// Usually when the entity is tried to be deleted but it is referenced by another entity.
    /// or when the entity is tried to be inserted but it references another entity that does not exist.
    /// </summary>
    public static Error ConflictWithReferenceConstraints => Error.Conflict(
        code: "Conflict",
        description: "Your operation conflicts with some Reference Constrains. " +
                     "A possible reason is that an entity is tried to be inserted but it references another entity that does not exist "
    );
}