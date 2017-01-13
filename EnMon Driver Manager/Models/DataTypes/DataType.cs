namespace EnMon_Driver_Manager.Models.DataTypes
{
    public class DataType
    {
        public string Name { get; set; }

        public byte ID { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
