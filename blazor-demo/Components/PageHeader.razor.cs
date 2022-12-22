using System;
using Microsoft.AspNetCore.Components;

namespace blazor_demo.Components;

public partial class PageHeader
{
    [Parameter]
    public string Title { get; set; } = "";
    [Parameter]
    public Dictionary<string, string> Breadcrumbs { get; set; } = new();

    protected override void OnInitialized()
    {

    }
}