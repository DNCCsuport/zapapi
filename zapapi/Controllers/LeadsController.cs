using Microsoft.AspNetCore.Mvc;
using zapapi.Method;
using zapapi.model;
using zapapi.Method;

using System.Data;
using System.Reflection;


[ApiController]
[Route("[controller]")]
public class LeadsController : ControllerBase
{
    [HttpPost]
    public IActionResult CreateLead(Lead lead)
    {
        int productId=0;
        int LpId=0;
        int pubID=0;
        String mobile = "";
        // Logic to save lead to database or perform other actions
        // For simplicity, I'll just return the received lead
       Connection db = new Connection();
        DataTable dt =new DataTable();
       dt = db.GetProdId(lead.prodid);
        if (dt.Rows.Count > 0)
        {
            productId = Convert.ToInt32(dt.Rows[0]["pk_proddet_id"]);
        }
       dt = db.GetLPId(lead.lpid);
        if (dt.Rows.Count > 0)
        {
            LpId = Convert.ToInt32(dt.Rows[0]["pk_lp_id"]);
        }
       dt = db.GetPubId(lead.pubid);
        if (dt.Rows.Count > 0)
        {
            pubID = Convert.ToInt32(dt.Rows[0]["pk_pubdet_id"]);
        }

        if (lead.mobile != null)
        {
            mobile = lead.mobile;
            mobile = mobile.Replace("P:+91", "");
            mobile = mobile.Replace("P: 91", "");
            mobile = mobile.Replace("P: ", "");
            mobile = mobile.Replace("p: 91", "");
            mobile = mobile.Replace("p: ", "");
            mobile = mobile.Replace("p:", "");
        }
        Boolean ts = db.LeaddetInsert(lead.utc, lead.utmsource, lead.utmterm, lead.name, mobile, lead.email, lead.lrd_rmks, productId, LpId, Convert.ToInt32(lead.srcid), pubID, lead.date, pubID, lead.preftime, lead.schedtime);
        string stts = "";
        if (ts == true)
        {
            stts = "Success";
        }
        if (ts == false)
        {
            stts = "fail";
        }
        // return Ok(lead);
        return Ok(new { stts = stts });
    }
}