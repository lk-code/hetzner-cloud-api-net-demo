using lkcode.hetznercloudapi;
using Microsoft.AspNetCore.Components;

namespace blazor_demo.Pages;

public partial class Index
{
    [Inject]
    IHetznerCloudService HetznerCloudService { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        //this.HetznerCloudService.LoadToken("");
    }
}
