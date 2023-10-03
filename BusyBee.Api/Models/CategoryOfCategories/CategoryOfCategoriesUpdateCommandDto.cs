using BusyBee.Api.Common;
using BusyBee.Core.Models.CategoryOfCategories;

namespace BusyBee.Api.Models.CategoryOfCategories;

public class CategoryOfCategoriesUpdateCommandDto : CategoryOfCategoriesUpdateCommand, IFormFileDto
{
    public IFormFile? File { get; set; }
}