namespace Assignement;

public static class AssignementConsts
{
    public const string DbTablePrefix = "App";
    private const string DefaultSorting = "{0}Name asc";

    public static string GetDefaultSorting(bool withEntityName)
    {
        return string.Format(DefaultSorting, withEntityName ? "Name." : string.Empty);
    }

    public const string DbSchema = null;
}
