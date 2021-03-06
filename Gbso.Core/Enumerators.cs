﻿namespace Gbso.Core.Enumerators
{
    public enum ActionStateEnum
    {
        //Null,
        Created,
        CreationOnHold,
        Original,
        OriginalPartial,
        Modified,
        ModificationOnHold,
        Deleted
    }

    public enum ModelEstate
    {
        Enabled = 1,
        Disabled = 0,
        Deleted = -1,
    }

    public enum SqlAction
    {
        Set = 1,
        Get = 2,
        Update = 3,
        Delete = 4,
        RegisterAndReturnModel = 5,
        UpdateAndReturnModel = 6,
    }

    public enum SqlDefaultColumns
    {
        Key,
        State,
        TimeStamp,
        IpLastChange,
        UserLastChange,
    }

    public enum SqlTypesColumn
    {
        Default,
        PrimaryKey,
        ForeignKey,
        PrimaryAndForeignKey,
        AppController,
        Marker
    }

}
