using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManagementSystem.Models.BindingModels;
using TaskManagementSystem.Models.EntityModels;
using TaskManagementSystem.Models.ViewModels;
using TaskManagementSystem.Services;

namespace TaskManagementSystem.Web.Controllers
{
    public class CommentsController : Controller
    {
        private CommentsService service;
        public CommentsController()
        {
            this.service = new CommentsService();
        }
        // GET: Comments
        [HttpGet]
        public ActionResult Add()
        {
            var vms = this.service.GetTasks();
            return View(vms);
        }

        [HttpPost]
        public ActionResult Add([Bind(Include = "taskId, CommentDescription, CommentType, ReminderDate")] AddCommentBm bind)
        {
            if (this.ModelState.IsValid)
            {
                this.service.AddComment(bind);
                return this.Redirect("All");
            }
            var vms = this.service.GetTasks();
            return View(vms);
        }

        [HttpGet]
        public ActionResult All()
        {
            IEnumerable<AllCommentsVm> vms = this.service.GetAllCommentsVms();
            return this.View(vms);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            DeleteCommentVm vm = this.service.GetDeleteVm(id);
            return this.View(vm);
        }

        [HttpPost]
        public ActionResult Delete([Bind(Include = "CommentId")] DeleteCommentBm bind)
        {
            if (this.ModelState.IsValid)
            {
                this.service.DeleteComment(bind);
                return this.RedirectToAction("All");
            }

            DeleteCommentVm vm = this.service.GetDeleteVm(bind.CommentId);
            return this.View(vm);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            EditCommentVm vm = this.service.GetEditVm(id);
            return this.View(vm);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id, CommentDescription,CommentType,ReminderDate")] EditCommentBm bind)
        {
            if (this.ModelState.IsValid)
            {
                this.service.EditComment(bind);
                return this.RedirectToAction("All");
            }
            EditCommentVm vm = this.service.GetEditVm(bind.Id);
            return this.View(vm);
        }
    }
}