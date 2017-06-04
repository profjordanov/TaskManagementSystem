using AutoMapper;
using TaskManagementSystem.Models.BindingModels;
using TaskManagementSystem.Models.EntityModels;
using TaskManagementSystem.Models.ViewModels;

namespace TaskManagementSystem.Services
{
    public static class AutoMapperWebConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<AddCommentBm, Comment>();
                expression.CreateMap<Comment, AllCommentsVm>()
                    .ForMember(vm => vm.TaskDescription,
                    configurationExpression =>
                        configurationExpression.MapFrom(com => com.TaskModel.TaskDescription));
                expression.CreateMap<AddCommentBm, Comment>();
                expression.CreateMap<Comment, EditCommentVm>();
                expression.CreateMap<Comment, DeleteCommentVm>();


            });

        }
    }
}