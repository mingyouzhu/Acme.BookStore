using System;
using System.Collections.Generic;
using System.Linq;

namespace Acme.BookStore;
/// <summary>
/// 分页结构
/// </summary>
/// <typeparam name="T"></typeparam>
public class ResponsePage<T>
{
    public IList<T> Collection { get; private set; }
    /// <summary>
    /// 页号
    /// </summary>
    public int PageNo { get; private set; }
    /// <summary>
    /// 页大小
    /// </summary>
    public int PageSize { get; private set; }
    /// <summary>
    /// 总页
    /// </summary>
    public int TotalPage { get; private set; }
    /// <summary>
    /// 总条数
    /// </summary>
    public int TotalCount { get; private set; }
    /// <summary>
    /// 是否有上一页
    /// </summary>
    public bool HasPrevious { get => PageNo > 0; }
    /// <summary>
    /// 是否有下一页
    /// </summary>
    public bool HasNext { get => PageNo < TotalPage; }

    /// <summary>
    /// 
    /// </summary>
    public ResponsePage() { }

    public ResponsePage(IList<T> values)
    {
        Collection = values;
        PageNo = 1;
        PageSize = values.Count;
        TotalCount = values.Count;
        TotalPage = 1;
    }

    public ResponsePage(IList<T> values, RequestPage param, int totalCount, int totalPage)
    {
        Collection = values;
        this.PageNo = param.PageNo;
        this.PageSize = param.PageSize;
        this.TotalPage = totalPage;
        this.TotalCount = totalCount;
    }

    /// <summary>
    /// 从数据源和分页构造实例
    /// </summary>
    /// <param name="source"></param>
    /// <param name="param"></param>
    public ResponsePage(IQueryable<T> source, RequestPage param)
    {
        var count = source.Count();
        this.PageNo = param.PageNo;
        this.PageSize = param.PageSize;
        this.TotalPage = (int)Math.Ceiling(count / (double)param.PageSize);
        this.TotalCount = count;

        Collection = source.Skip(
            (param.PageNo - 1) * param.PageSize)
            .Take(param.PageSize)
            .ToList();
    }

    /// <summary>
    /// 将Collection属性动态转换到O类型 其他不变
    /// </summary>
    /// <typeparam name="O">目标类型</typeparam>
    /// <param name="converter">自定义转换策略</param>
    /// <returns></returns>
    public ResponsePage<O> ConvertTo<O>(Func<IList<T>, IList<O>> converter)
    {
        var list = converter(this.Collection);
        return new ResponsePage<O>
        {
            Collection = list,
            PageNo = this.PageNo,
            PageSize = this.PageSize,
            TotalPage = this.TotalPage,
            TotalCount = this.TotalCount
        };
    }
}
