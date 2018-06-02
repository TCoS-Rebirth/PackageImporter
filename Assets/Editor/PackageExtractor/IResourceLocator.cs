using Engine;

namespace Framework.PackageExtractor
{
    public interface IResourceLocator
    {
        bool TryFindObject(string absolutePath, out UObject obj);
        bool RegisterExportedResource(string absolutePath, UObject obj);
    }
}
