using TraceOptimizer.Domain;

namespace TraceOptimizer.Optimization.Construct
{
    public interface IConstructOptimizer
    {
        BotProgram Optimize(Model3D modelToBuild);
    }
}