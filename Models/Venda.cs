
namespace DesafioFinal.Models
{

     public class Venda
    {
      public int Id { get; set; }
      public DateTime Data { get; set; }  
      public EnumStatusVenda Status { get; set; }
      public Vendedor Vendedor { get; set; }
      public string ItensVendidos { get; set; }
    }
}