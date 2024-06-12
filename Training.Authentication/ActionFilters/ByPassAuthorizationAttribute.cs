using Microsoft.AspNetCore.Mvc.Filters;

namespace Training.Authentication.ActionFilters
{
    internal class ByPassAuthorizationAttribute : Attribute, IFilterMetadata
    {

    }
}
