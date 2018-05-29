using Engine;

namespace Framework.PackageExtractor
{
    public interface IResourceLocator
    {
        bool TryFindObject(string absolutePath, out UObject obj);
        void RegisterExportedResource(string absolutePath, UObject obj);
    }
}
