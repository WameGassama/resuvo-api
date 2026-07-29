namespace GraphQL.Contracts.Models
{
    public record Resume(
        [property: GraphQLType(typeof(NonNullType<IdType>))] string Id,
        [property: GraphQLType(typeof(NonNullType<IdType>))] string UserId,
        string Title,
        [property: GraphQLType(typeof(NonNullType<IdType>))] string TemplateId,
        PersonalDetails PersonalDetails,
        DateTime CreatedAt,
        DateTime UpdatedAt);
}
