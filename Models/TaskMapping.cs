using tasks.BussniseObjects;
using tasks.Entities;
using tasks.Resources;

namespace tasks.Models
{
    public static class TaskMapping
    {
         public static TaskBO MapModelToBO(this TaskModel model, int? id)
        {
            if (model != null)
            {
                return new TaskBO()
                {
                    Id = id ?? 0,
                    Title = model.Title,
                    Description = model.Description,
                    Date = model.Date,
                    Status = model.Status
                };
            }
            return null;
        }

        public static TaskResource MapBOToResource(this TaskBO model)
        {
            if (model != null)
            {
                return new TaskResource()
                {
                    Title = model.Title,
                    Description = model.Description,
                    Date = model.Date,
                    Status = model.Status
                };
            }
            return null;
        }

        public static TaskEntity MapBOToEntity(this TaskBO model)
        {
            if (model != null)
            {
                return new TaskEntity()
                {
                    Title = model.Title,
                    Description = model.Description,
                    Date = model.Date,
                    Status = model.Status
                };
            }
            return null;
        }

        public static TaskBO MapEntityToBO(this TaskEntity model)
        {
            if (model != null)
            {
                return new TaskBO()
                {
                    Title = model.Title,
                    Description = model.Description,
                    Date = model.Date,
                    Status = model.Status
                };
            }
            return null;
        }

        public static TaskResource MapEntityToResource(this TaskEntity model)
        {
            if (model != null)
            {
                return new TaskResource()
                {
                    Title = model.Title,
                    Description = model.Description,
                    Date = model.Date,
                    Status = model.Status
                };
            }
            return null;
        }
    }
}