using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Modeler.Models.SqlRepository
{
    public class QueryStrings
    {
        protected string changeVQuery = "INSERT Top(1) INTO  Client_Survey (" +
      "[user_id] " +
      ",[gender] " +
      ",[lambda] " +
      ",[HR] " +
      ", [v] " +
      ",[inserted_dtm] ) " +
      "SELECT[user_id] " +
      ",[gender] " +
      ",[lambda] " +
      ",[HR] " +
      ", _SPEED_" +
      ",' _DATE_ '" +
      "FROM[Modeler].[dbo].[Client_Survey] " +
      "where v>0 and user_id = '_USERID_' and inserted_dtm = (select max(inserted_dtm) from Client_Survey where user_id = '_USERID_' and v>0);";
    }
}