using System;
using System.Reflection;

namespace HTTP5101_Assignment_2_N01442097.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}