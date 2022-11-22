using lkcode.hetznercloudapi.Instances.Server;
using lkcode.hetznercloudapi.Interfaces;
using lkcode.hetznercloudapi.ParameterObjects.Sort;
using Microsoft.AspNetCore.Components;

namespace blazor_demo.Pages;

public partial class Index
{
    [Inject]
    IServerService ServerService { get; set; } = null!;
    [Inject]
    NavigationManager NavigationManager { get; set; } = null!;

    private List<Server> _servers = new List<Server>();

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        var servers = await this.ServerService.GetAllAsync(
            1,
            25,
            new List<IFilter>
            {
                //new NameFilter("lk")
            },
            new ServerSort(ServerSortField.NAME, SortDirection.DESC));

        _servers = servers.Items.ToList();
    }

    public async Task OnServerClick(Server server)
    {
        this.NavigationManager.NavigateTo($"/server/{server.Id}");
    }
}
