namespace SaG.Business.Models {
    
    public class Cmd : BaseEntity {
        public int CmdId { get; set; }
        public Level Level { get; set; }
        public string CmdHex { get; set; }
        public string Description { get; set; }
        public short? CmdSeqNo { get; set; }
        public string CmdSeqHex { get; set; }
    }
}
