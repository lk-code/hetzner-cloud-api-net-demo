using System;
using lkcode.hetznercloudapi.Instances.Server;
using Microsoft.AspNetCore.Components;

namespace blazor_demo.Components;

public partial class ContentBlock
{
    [Parameter]
    public string @class { get; set; } = "";
    [Parameter]
    public string Title { get; set; } = "";
    [Parameter]
    public string AdditionalTitle { get; set; } = "";
    [Parameter]
    public string HeaderBackgroundClass { get; set; } = "bg-gray-lighter";
    [Parameter]
    public RenderFragment? ChildContent { get; set; } = null;
    [Parameter]
    public EventCallback OnClickCallback { get; set; }

    protected override void OnInitialized()
    {
        base.OnInitialized();
    }
}