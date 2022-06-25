namespace Assignement.Permissions;

public static class AssignementPermissions
{
    public const string GroupName = "Assignement";

    //Add your own permission names. Example:
    //Cutomer Permission
    public static class Customers
    {
        public const string Default = GroupName + ".Customers";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
    //Order Permission
    public static class Orders
    {
        public const string Default = GroupName + ".Orders";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
    //public const string MyPermission1 = GroupName + ".MyPermission1";
}
