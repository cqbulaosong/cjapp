using CjApp.Model;
using SqlSugar;

namespace CjApp.Model;

[SugarTable("article")]
public class Article : BaseEntity
{
    [SugarColumn(IsPrimaryKey = true, ColumnDataType = "varchar(21)", ColumnName = "article_id")]
    public string ArticleId { get; set; }

    [SugarColumn(ColumnDataType = "varchar(50)", ColumnName = "article_title")]
    public string ArticleTitle { get; set; }

    [SugarColumn(ColumnDataType = "varchar(50)", ColumnName = "article_sub_title")]
    public string ArticleSubTitle { get; set; }

    [SugarColumn(ColumnDataType = "varchar(50)", ColumnName = "article_author")]
    public string ArticleAuthor { get; set; }

    [SugarColumn(ColumnDataType = "varchar(50)", ColumnName = "article_content")]
    public string ArticleContent { get; set; }
}