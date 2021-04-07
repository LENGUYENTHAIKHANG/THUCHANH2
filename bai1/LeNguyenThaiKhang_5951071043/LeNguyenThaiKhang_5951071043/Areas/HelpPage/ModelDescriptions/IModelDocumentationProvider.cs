using System;
using System.Reflection;

namespace LeNguyenThaiKhang_5951071043.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}