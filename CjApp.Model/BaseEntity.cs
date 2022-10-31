using SqlSugar;

namespace CjApp.Model;

public class BaseEntity
{
    [SugarColumn(ColumnDataType = "datetime", ColumnName = "gmt_create")]
    public DateTime GmtCreate { get; set; }

    [SugarColumn(ColumnDataType = "datetime", ColumnName = "gmt_modified")]
    public DateTime GmtModified { get; set; }

    [SugarColumn(ColumnDataType = "tinyint", ColumnName = "is_deleted")]
    public bool IsDeleted { get; set; }

    [SugarColumn(ColumnDataType = "varchar(21)", ColumnName = "create_user_id")]
    public string CreateUserId { get; set; }

    [SugarColumn(ColumnDataType = "varchar(21)", ColumnName = "modified_user_id")]
    public string ModifiedUserId { get; set; }
}