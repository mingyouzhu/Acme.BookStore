using System.ComponentModel.DataAnnotations;

namespace Acme.BookStore;
/// <summary>
/// 分页参数
/// </summary>
public class RequestPage
{
    /// <summary>
    /// 页号
    /// </summary>
    [Required(ErrorMessage = "不能为空")]
    [Range(1, 2147483647, ErrorMessage = "正确输入范围1至2147483647")]
    public int PageNo { get; set; }
    /// <summary>
    /// 页大小
    /// </summary>
    [Required(ErrorMessage = "不能为空")]
    [Range(1, 100, ErrorMessage = "正确输入范围1至100")]
    public int PageSize { get; set; }
}