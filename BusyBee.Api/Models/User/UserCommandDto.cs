using BusyBee.Api.Common;

namespace BusyBee.Api.Models.User;

public class UserCommandDto : IFormFileDto
{
    public IFormFile? File { get; set; }
}