using TaskManagementSystem.Data;

namespace TaskManagementSystem.Services
{
    public class Service
    {
        protected TaskManagementSystemContext Context;

        public Service()
        {
            this.Context = new TaskManagementSystemContext();
        }
    }
}