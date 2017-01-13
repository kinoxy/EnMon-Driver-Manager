namespace EnMon_Driver_Manager.Models.ArchivePeriods
{

    public class ArchivePeriod

    {
        public string Description { get; set; }

        public uint ID { get; set; }

        public uint Period { get; set; }

        public override string ToString()
        {
            return Description;
        }

    }
}
