using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// IHotLink 的摘要描述
/// </summary>
public interface IHotLinkService
{
    IEnumerable<HotLinkDTO> GetHotSrc(string SortNumber);
}