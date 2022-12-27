using System;
using Microsoft.AspNetCore.Components;

namespace blazor_demo.Components;

public partial class WizardSidebar
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; } = null;
}