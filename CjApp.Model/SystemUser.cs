using SqlSugar;

namespace CjApp.Model;

public class SystemUser : BaseEntity
{
    [SugarColumn(IsPrimaryKey = true, ColumnDataType = "varchar(21)", ColumnName = "system_userid")]
    public string SystemUserId { get; set; }

    [SugarColumn(ColumnDataType = "varchar(50)", ColumnName = "full_name")]
    public string FullName { get; set; }
    
    [SugarColumn(ColumnDataType = "varchar(30)", ColumnName = "email")]
    public string Email { get; set; }
    
    [SugarColumn(ColumnDataType = "varchar(11)", ColumnName = "phone")]
    public string Phone { get; set; }
    
    [SugarColumn(ColumnDataType = "varchar(32)", ColumnName = "password")]
    public string Password { get; set; }
}