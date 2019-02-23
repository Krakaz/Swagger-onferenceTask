using System.ComponentModel;

namespace DAL.Enums
{
    public enum Pizza
    {
        [Description("XXL")]
        Xxl = 1,

        [Description("БананZzа")]
        Bananza = 2,

        [Description("Сардиния")]
        Sardinia = 3,

        [Description("Пицца Татарская")]
        Tatar = 4,

        [Description("Славянская")]
        Slavan = 5,
    }
}
