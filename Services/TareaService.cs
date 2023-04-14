using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.Models;

namespace webapi.Services
{
    public class TareaService : ITareaService
    {
        TareasContext context;

        public TareaService(TareasContext dbcontext)
        {
            context = dbcontext;
        }
        public IEnumerable<Tarea> Get()
        {
            return context.Tareas;
        }

        public async Task Save(Tarea Tarea)
        {
            context.Add(Tarea);
            await context.SaveChangesAsync();
        }

        public async Task Update(Guid id, Tarea Tarea)
        {
            var TareaActual = context.Tareas.Find(id);

            if (TareaActual != null)
            {
                TareaActual.Titulo = Tarea.Titulo;
                TareaActual.CategoriaId = Tarea.CategoriaId;
                TareaActual.PrioridadTarea = Tarea.PrioridadTarea;
                context.Update(Tarea);
                await context.SaveChangesAsync();
            }

        }

        public async Task Delete(Guid id, Tarea Tarea)
        {
            var TareaActual = context.Tareas.Find(id);

            if (TareaActual != null)
            {
                context.Remove(Tarea);
                await context.SaveChangesAsync();
            }

        }
    }

    public interface ITareaService
    {
        IEnumerable<Tarea> Get();
        Task Save(Tarea Tarea);
        Task Update(Guid id, Tarea Tarea);
        Task Delete(Guid id, Tarea Tarea);
    }
}