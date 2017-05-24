using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using AutoMapper;
using TaskManagementSystem.Models.BindingModels;
using TaskManagementSystem.Models.EntityModels;
using TaskManagementSystem.Models.ViewModels;

namespace TaskManagementSystem.Services
{
    public class CommentsService : Service
    {
        public IEnumerable<AddCommentTaskVm> GetTasks()
        {
            return this.Context.Tasks.Select(task => new AddCommentTaskVm()
            {
                Id = task.Id,
                TaskDescription = task.TaskDescription
            });
        }

        public void AddComment(AddCommentBm bind)
        {
            Comment comment = Mapper.Map<AddCommentBm, Comment>(bind);
            TaskModel wantedTask = this.Context.Tasks.Find(bind.TaskId);
            comment.TaskModel = wantedTask;
            comment.DateAdded = DateTime.Now;
            this.Context.Comments.Add(comment);
            this.Context.SaveChanges();
        }

        public IEnumerable<AllCommentsVm> GetAllCommentsVms()
        {
            IEnumerable<Comment> comments = this.Context.Comments;
            IEnumerable<AllCommentsVm> vms = Mapper.Map<IEnumerable<Comment>, IEnumerable<AllCommentsVm>>(comments);
            return vms;
        }

        public DeleteCommentVm GetDeleteVm(int id)
        {
            Comment model = this.Context.Comments.Find(id);
            DeleteCommentVm vm = Mapper.Map<Comment, DeleteCommentVm>(model);
            return vm;
        }

        public void DeleteComment(DeleteCommentBm bind)
        {
            Comment comment = this.Context.Comments.Find(bind.CommentId);
            this.Context.Comments.Remove(comment);
            this.Context.SaveChanges();
        }

        public EditCommentVm GetEditVm(int id)
        {
            Comment comment = this.Context.Comments.Find(id);
            EditCommentVm vm = Mapper.Map<Comment, EditCommentVm>(comment);
            return vm;
        }

        public void EditComment(EditCommentBm bind)
        {
            Comment model = this.Context.Comments.Find(bind.Id);
            model.CommentDescription = bind.CommentDescription;
            model.CommentType = bind.CommentType;
            model.ReminderDate = bind.ReminderDate;

            try
            {
                // Your code...
                // Could also be before try if you know the exception occurs in SaveChanges

                this.Context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }
    }
}