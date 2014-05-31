using FluentNHibernate.Mapping;
using SaG.Business.Models; 

namespace SaG.Data.NHibernate.Mappings {
    
    
    public class LockMap : ClassMap<Lock> {
        
        public LockMap() {
			Table("tblLocks");
            Not.LazyLoad();
			Id(x => x.LockEntity).GeneratedBy.Identity().Column("LockEntity");
			References(x => x.Owner).Column("OwnerEntity");
			Map(x => x.LockId).Column("LockID");
			Map(x => x.KeyLockOwner0).Column("KeyLockOwner0");
			Map(x => x.KeyLockOwner1).Column("KeyLockOwner1");
			Map(x => x.BankModeStatus).Column("BankModeStatus");
			Map(x => x.BankModeStart).Column("BankModeStart");
			Map(x => x.BankModeEnd).Column("BankModeEnd");
			Map(x => x.TampResetStatus).Column("TampResetStatus");
			Map(x => x.AuditStatus).Column("AuditStatus");
			Map(x => x.LockInitialize).Column("LockInitialize").Not.Nullable();
			Map(x => x.PCcode).Column("PCcode");
			Map(x => x.OCcode).Column("OCcode");
			Map(x => x.ErasePcoc).Column("ErasePCOC").Not.Nullable();
			Map(x => x.PendBankModeStatus).Column("PendBankModeStatus");
			Map(x => x.PendBankModeStart).Column("PendBankModeStart");
			Map(x => x.PendBankModeEnd).Column("PendBankModeEnd");
			Map(x => x.PendTampResetStatus).Column("PendTampResetStatus");
			Map(x => x.PendAuditStatus).Column("PendAuditStatus");
			Map(x => x.PendLockInitialize).Column("PendLockInitialize").Not.Nullable();
			Map(x => x.PendLockUnInstall).Column("PendLockUnInstall").Not.Nullable();
			Map(x => x.PendPCcode).Column("PendPCcode");
			Map(x => x.PendOCcode).Column("PendOCcode");
			Map(x => x.PendErasePcoc).Column("PendErasePCOC").Not.Nullable();
			Map(x => x.UpdateDate).Column("UpdateDate");
			Map(x => x.ChangeStatus).Column("ChangeStatus").Not.Nullable();
			Map(x => x.SetClockCalSeqNo).Column("SetClockCalSeqNo");
			Map(x => x.LocationId).Column("LocationID");
            this.MapAuditable();
        }
    }
}
