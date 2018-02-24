using StructureMap;
using StructureMap.Graph;

namespace PlayingWithBootstrap.Infrastructure
{
    public class StandardRegistry : Registry
    {
        public StandardRegistry()
        {
            Scan(scan =>
            {
                scan.Assembly("PlayingWithBootstrap");
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();
            });
        }
    }
}