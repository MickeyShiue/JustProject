using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Index : System.Web.UI.Page
{ 
    private DataTable dt;
    private readonly IHotLinkService _HotLinkService;

    private string SessionAccount
    {
        get
        {
            return Session["帳號"] != null ? Session["帳號"].ToString() : "";
        }
    }

    public Index()//沒導入DI 容器，勉強這樣做
    {
        _HotLinkService = new HotLinkService(new ConnDB());
    }


    protected void Page_Load(object sender, EventArgs e)
    {      
        string listHotSortNum = string.Empty;

        if (!IsPostBack)
        {
            foreach (Control c in Panel_link.Controls)
            {
                if (c.GetType() == typeof(LinkButton))
                {
                    listHotSortNum += "'" + (((LinkButton)(c)).ID.Replace("linkbtn", "")) + "'" + ",";
                }
            }

            var hotLinkDTOs = _HotLinkService.GetHotSrc(listHotSortNum.Trim(','));
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