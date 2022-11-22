using lkcode.hetznercloudapi.Exceptions;
using lkcode.hetznercloudapi.Instances.Server;
using lkcode.hetznercloudapi.Interfaces;
using Microsoft.AspNetCore.Components;

namespace blazor_demo.Pages;

public partial class ServerDetail
{
    [Parameter]
    public long Id { get; set; }

    [Inject]
    IServerService ServerService { get; set; } = null!;
    [Inject]
    NavigationManager NavigationManager { get; set; } = null!;

    private bool IsLoading { get; set; } = false;
    private Server Server { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        try
        {
            this.IsLoading = true;

            // load server
            Server server = await this.ServerService.GetByIdAsync(this.Id);

            this.Server = server;
        }
        catch (ResourceNotFoundException exception)
        {
            // server not found
        }
        catch (Exception exception)
        {
            // display error

            int i = 0;
        }
        finally
        {
            this.IsLoading = false;
        }
    }
}
