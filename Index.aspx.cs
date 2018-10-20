using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections.Generic;

public partial class Index : BasePage
{ 
    private readonly IHotLinkService _HotLinkService;

    public Index()//沒導入DI 容器，先用Ioc控制反轉
    {
        _HotLinkService = new HotLinkService(new ConnDB());
    }

    protected void Page_Load(object sender, EventArgs e)
    {     
        if (!IsPostBack)
        {
            List<string> listHotSortNum = new List<string>();
            listHotSortNum.Add("1");//最小
            listHotSortNum.Add("10");//最大


            var hotLinkDTOs = _HotLinkService.GetHotSrc(listHotSortNum);
            if (hotLinkDTOs.Any())
            {
                foreach (Control c in Panel_link.Controls)
                {
                    if (c.GetType() == typeof(LinkButton))
                    {
                        ((LinkButton)(c)).Text = hotLinkDTOs.Where(x => x.Sort == c.ID.ToString()).Select(x => x.title).SingleOrDefault();
                        ((LinkButton)(c)).ToolTip = hotLinkDTOs.Where(x => x.Sort == c.ID.ToString()).Select(x => x.src).SingleOrDefault();
                    }
                }
            }
        }
    }
}