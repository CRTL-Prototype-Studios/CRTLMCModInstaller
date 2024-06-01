namespace CRTLMCModInstaller.Core.Foundation.Modrinth;

public class ModrinthFoundations
{
    public enum ModrinthCategories
    {
        Forge = 1,
        Fabric = 2,
        NeoForge = 3
    }
    
    public static string GetCategoryString(ModrinthCategories category)
    {
        switch (category)
        {
            case ModrinthCategories.Forge:
                return "forge";
            case ModrinthCategories.Fabric:
                return "fabric";
            case ModrinthCategories.NeoForge:
                return "neoforge";
            default:
                throw new ArgumentOutOfRangeException(nameof(category), category, null);
        }
    }
}