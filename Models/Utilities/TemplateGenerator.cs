using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public static class TemplateGenerator
    {
        public static string GetHTMLString()
        {
            

            var sb = new StringBuilder();
            sb.Append(@"<html>
<head>
<style>
.text{
font-family: 'Calibri';
}
</style>
</head>
<body>
<p style = 'text-align: center;' >< img src='http://rent2auto.pl/wp-content/uploads/2019/02/logoR2A_v2-e1549486435940.png' alt='' style='float: left;' width='182' height='59' /><br /><br /><br />Protok&oacute;ł zdawczo-odbiorczy<br /> Załącznik nr 1 do Umowy Wynajmu Pojazdu</p>
<table style = 'border-collapse: collapse; width: 100%;' border='1'>
<tbody>
<tr>
<td class='text' style='width: 100%;'>Klient:</td>
</tr>
</tbody>
</table>
<table style='border-collapse: collapse; width: 100%;' border='1'>
<tbody>
<tr>
<td style='width: 42.8571%;'>Marka i model:</td>
<td style='width: 23.8095%;'>Nr rej.:</td>
<td style='width: 33.3333%; text-align: center;'>Rodzaj paliwa:</td>
</tr>
</tbody>
</table>
<table style='border-collapse: collapse; width: 100%;' border='1'>
<tbody>
<tr>
<td style='width: 33.3333%;'>Użytkownik:</td>
<td style='width: 33.3333%;'>Nr tel.:</td>
<td style='width: 33.3333%;'>Mail:</td>
</tr>
</tbody>
</table>
<p style='text-align: center;'><strong>WYDANIE SAMOCHODU<br /></strong></p>
<table style='border-collapse: collapse; width: 100%;' border='1'>
<tbody>
<tr>
<td style='width: 47.7591%;'>Data i godzina:</td>
<td style='width: 27.1708%;'>Ilość paliwa:</td>
<td style='width: 25.07%;'>Przebieg:</td>
</tr>
</tbody>
</table>
<table style='border-collapse: collapse; width: 100%;' border='1'>
<tbody>
<tr>
<td style='width: 100%;'>Uwagi:</td>
</tr>
</tbody>
</table>
<p></p>
<p></p>
<p></p>
<p></p>
<p></p>
<p></p>
<p></p>
<p>________________&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ________________</p>
<p>Podpis Lease2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Podpis Klienta</p>
<p style='text-align: center;'><strong>ZDANIE SAMOCHODU<br /></strong></p>
<table style='border-collapse: collapse; width: 100%;' border='1'>
<tbody>
<tr>
<td style='width: 47.7591%;'>Data i godzina:</td>
<td style='width: 27.1708%;'>Ilość paliwa:</td>
<td style='width: 25.07%;'>Przebieg:</td>
</tr>
</tbody>
</table>
<table style='border-collapse: collapse; width: 100%;' border='1'>
<tbody>
<tr>
<td style='width: 100%;'>Uwagi:</td>
</tr>
</tbody>
</table>
<p></p>
<p></p>
<p></p>
<p></p>
<p></p>
<p></p>
<p>________________&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ________________</p>
<p>Podpis Lease2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Podpis Klienta</p>
                                
</body>
</html>");
            return sb.ToString();
        }
    }
}
