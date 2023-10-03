using AutoMapper;
using BusyBee.Core.Entities;
using BusyBee.Core.Models.Task;
using BusyBee.Core.Models.Task.TaskData;
using Task = BusyBee.Core.Entities.Task;

namespace BusyBee.Api.Mappings;

public class TaskProfile : Profile
{
    public TaskProfile()
    {
        CreateMap<TaskCreateCommand, Task>()
            .ForMember(x => x.TaskDataValues, opt => opt.MapFrom(x => x.Strings))
            .ForMember(x => x.TaskDataTemplateItemValues, opt => opt.MapFrom(x => x.Selections))
            .ForMember(x => x.Date, opt => opt.MapFrom(x => DateOnly.FromDateTime(x.Date)));
        CreateMap<TaskUpdateCommand, Task>()
            .ForMember(x => x.Date, opt => opt.MapFrom(x => DateOnly.FromDateTime(x.Date)));

        CreateMap<TaskStringDataValueCommand, TaskDataValue>();
        CreateMap<TaskSelectionDataValueCommand[], List<TaskDataTemplateItemValue>>()
            .ConvertUsing(src => src.SelectMany(selections => selections.Values.Select(selection => new TaskDataTemplateItemValue
            {
                DataTemplateItemId = selections.DataTemplateItemId,
                DataTemplateItemValueId = selection
            })).ToList());

        CreateMap<Task, TaskResponse>()
            .ForMember(x => x.Strings, opt => opt.MapFrom(x => x.TaskDataValues))
            .ForMember(x => x.Selections, opt => opt.MapFrom(x => x.TaskDataTemplateItemValues));
        CreateMap<TaskDataValue, TaskStringDataValueResponse>();
        CreateMap<TaskDataTemplateItemValue, TaskSelectionDataValueResponse>()
            .ForMember(x => x.DataTemplateItemId, opt => opt.MapFrom(x => x.DataTemplateItemId))
            .ForMember(x => x.DataTemplateItemValueId, opt => opt.MapFrom(x => x.DataTemplateItemValueId));
    }
}