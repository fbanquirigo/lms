using FluentNHibernate.Mapping;
using SaG.Business.Models; 

namespace SaG.Data.NHibernate.Mappings {
    
    
    public class TransactionMap : ClassMap<Transaction> {
        
        public TransactionMap() {
			Table("tblTransactions");
            Not.LazyLoad();
			Id(x => x.EventId).GeneratedBy.Identity().Column("Event_ID");
			Map(x => x.EventType).Column("Event_Type");
			Map(x => x.TransCode).Column("Trans_Code");
			Map(x => x.RetCode).Column("Ret_Code");
			Map(x => x.Posted).Column("Posted");
			Map(x => x.ReqCount).Column("Req_Count");
			Map(x => x.DispId).Column("Disp_ID");
			Map(x => x.LockId).Column("Lock_ID");
			Map(x => x.AtmId).Column("ATM_ID");
			Map(x => x.UserId).Column("User_ID");
			Map(x => x.RouteId).Column("Route_ID");
			Map(x => x.TkId).Column("Tk_ID");
			Map(x => x.OperDate).Column("Oper_Date");
			Map(x => x.OperHour).Column("Oper_Hour");
			Map(x => x.OperHourLimit).Column("Oper_Hour_Limit");
			Map(x => x.LockStat).Column("Lock_Stat");
			Map(x => x.StatusRet).Column("Status_Ret");
			Map(x => x.OperCode).Column("Oper_Code");
			Map(x => x.OperRet).Column("Oper_Ret");
			Map(x => x.OperResult).Column("Oper_Result");
			Map(x => x.Description).Column("Description");
            this.MapAuditable();
        }
    }
}
