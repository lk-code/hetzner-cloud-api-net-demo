using System;
using Microsoft.AspNetCore.Components;

namespace blazor_demo.Components;

public partial class WizardContainer
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; } = null;
}