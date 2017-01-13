namespace EnMon_Driver_Manager.Models.StatusTexts
{

    public class StatusText

    {

        public string Name { get; set; }

        public uint StatusID { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
