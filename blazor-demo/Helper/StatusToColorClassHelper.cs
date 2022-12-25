using System;
using lkcode.hetznercloudapi.Enums;

namespace blazor_demo.Helper;

public static class StatusToColorClassHelper
{
    public static string ToColorClass(this ServerStatus status)
    {
        switch (status)
        {
            case ServerStatus.Deleting:
                {
                    return "bg-success";
                }
            case ServerStatus.Initializing:
                {
                    return "bg-muted";
                }
            case ServerStatus.Migrating:
                {
                    return "bg-muted";
                }
            case ServerStatus.Off:
                {
                    return "bg-muted";
                }
            case ServerStatus.Rebuilding:
                {
                    return "bg-warning";
                }
            case ServerStatus.Running:
                {
                    return "bg-success";
                }
            case ServerStatus.Starting:
                {
                    return "bg-warning";
                }
            case ServerStatus.Stopping:
                {
                    return "bg-warning";
                }
            case ServerStatus.Unknown:
            default:
                {
                    return "bg-gray-lighter";
                }
        }
    }
}