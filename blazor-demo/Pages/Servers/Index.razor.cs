using System.Threading;
using lkcode.hetznercloudapi.Instances.Server;
using lkcode.hetznercloudapi.Interfaces;
using lkcode.hetznercloudapi.ParameterObjects.Sort;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting.Server;

namespace blazor_demo.Pages.Servers;

public partial class Index : IDisposable
{
    [Inject]
    IServerService ServerService { get; set; } = null!;
    [Inject]
    NavigationManager NavigationManager { get; set; } = null!;

    private CancellationTokenSource _cancellationToken = new CancellationTokenSource();
    private List<Server> _servers = new List<Server>();

    public void Dispose()
    {
        this._cancellationToken?.Cancel();
        this._cancellationToken?.Dispose();
    }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        var servers = await this.ServerService.GetAllAsync(
            this._cancellationToken.Token,
            1,
            25,
            new List<IFilter>
            {
                //new NameFilter("lk")
            },
            new Sorting<ServerSortField>(ServerSortField.Name, SortingDirection.DESC)); ;

        _servers = servers.Items.ToList();
    }

    public void OnServerClick(Server server)
    {
        this.NavigationManager.NavigateTo($"/server/{server.Id}");
    }

    public void OnAddServerClick()
    {
        this.NavigationManager.NavigateTo($"/server/add");
    }
}