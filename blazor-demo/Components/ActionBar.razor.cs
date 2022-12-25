using System;
using Microsoft.AspNetCore.Components;

namespace blazor_demo.Components;

public partial class ActionBar
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; } = null;

    protected override void OnInitialized()
    {
        base.OnInitialized();
    }
}