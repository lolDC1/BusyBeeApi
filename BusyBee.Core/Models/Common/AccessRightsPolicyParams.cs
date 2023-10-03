using BusyBee.Core.Interfaces;

namespace BusyBee.Core.Models.Common;

public class AccessRightsPolicyParams
{
    public IUser User { get; set; } = null!;
}