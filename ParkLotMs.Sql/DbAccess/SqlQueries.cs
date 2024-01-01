namespace ParkLotMs.DataAccess.DbAccess;
public class SqlQueries
{
    //public static string GetAll => "SELECT * FROM {0} WHERE \"DeletedAt\" IS NULL @Filter ORDER BY @OrderBy LIMIT @Limit OFFSET @Offset ;";
    public static string GetAll => "SELECT * FROM {0} WHERE \"DeletedAt\" IS NULL ;";
    public static string GetJoin => "SELECT * FROM @Table @Join WHERE \"DeletedAt\" IS NULL @Filter ORDER BY @OrderBy LIMIT @Limit OFFSET @Offset ;";
    public static string Get => "SELECT @Columns FROM @Table WHERE \"DeletedAt\" IS NULL AND @Filter ;";
    public static string Insert => "INSERT INTO @Table (@Key) VALUES (@Values) ;";
    public static string Update => "UPDATE @Table SET @UpdateItem WHERE @Conditions ;";
    public static string Delete => "DELETE @Table WHERE @Conditions ;";
    public static string SoftDelete => "UPDATE @Table SET \"DeletedAt\" = NOW() WHERE @Conditions ;";
}
