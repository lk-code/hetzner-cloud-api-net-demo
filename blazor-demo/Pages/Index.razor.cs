using System;
namespace blazor_demo.Pages;

public partial class Index
{
    public Dictionary<string, string> Breadcrumbs = new Dictionary<string, string>()
    {
        { "/", "Übersicht" }
    };
}