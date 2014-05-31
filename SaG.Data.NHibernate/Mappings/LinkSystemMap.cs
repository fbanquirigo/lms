using FluentNHibernate.Mapping;
using SaG.Business.Models; 

namespace SaG.Data.NHibernate.Mappings {
    
    
    public class LinkSystemMap : ClassMap<LinkSystem> {
        
        public LinkSystemMap() {
			Table("tblLinkSystem");
            Not.LazyLoad();
			Id(x => x.Id).GeneratedBy.Identity().Column("ID");
			Map(x => x.PollingTime).Column("Polling_Time");
			Map(x => x.PathTransDir).Column("Path_Trans_Dir");
			Map(x => x.RecordTransactions).Column("Record_Transactions");
			Map(x => x.Encrypt).Column("Encrypt");
			Map(x => x.SendExtension).Column("Send_Extension");
			Map(x => x.ReceiveExtension).Column("Receive_Extension");
            this.MapAuditable();
        }
    }
}
