using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;
using System.Threading.Tasks;

namespace game_api.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LifecycleIdController : ControllerBase
    {
        public readonly IExempleSingleton _exempleSingleton1;
        public readonly IExempleSingleton _exempleSingleton2;

        public readonly IExempleScoped _exempleScoped1;
        public readonly IExempleScoped _exempleScoped2;

        public readonly IExempleTransient _exempleTransient1;
        public readonly IExempleTransient _exempleTransient2;

        public LifecycleIdController(IExempleSingleton exempleSingleton1,
                                       IExempleSingleton exempleSingleton2,
                                       IExempleScoped exempleScoped1,
                                       IExempleScoped exempleScoped2,
                                       IExempleTransient exempleTransient1,
                                       IExempleTransient exempleTransient2)
        {
            _exempleSingleton1 = exempleSingleton1;
            _exempleSingleton2 = exempleSingleton2;
            _exempleScoped1 = exempleScoped1;
            _exempleScoped2 = exempleScoped2;
            _exempleTransient1 = exempleTransient1;
            _exempleTransient2 = exempleTransient2;
        }

        [HttpGet]
        public Task<string> Get()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Singleton 1: {_exempleSingleton1.Id}");
            stringBuilder.AppendLine($"Singleton 2: {_exempleSingleton2.Id}");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"Scoped 1: {_exempleScoped1.Id}");
            stringBuilder.AppendLine($"Scoped 2: {_exempleScoped2.Id}");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine($"Transient 1: {_exempleTransient1.Id}");
            stringBuilder.AppendLine($"Transient 2: {_exempleTransient2.Id}");

            return Task.FromResult(stringBuilder.ToString());
        }

    }

    public interface IGeneralExemple
    {
        public Guid Id { get; }
    }

    public interface IExempleSingleton : IGeneralExemple
    { }

    public interface IExempleScoped : IGeneralExemple
    { }

    public interface IExempleTransient : IGeneralExemple
    { }

    public class LifecycleExemple : IExempleSingleton, IExempleScoped, IExempleTransient
    {
        private readonly Guid _guid;

        public LifecycleExemple()
        {
            _guid = Guid.NewGuid();
        }

        public Guid Id => _guid;
    }
}