<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_161109_WebForms_Intro.Default" %>

<%-- Burası Server Kısmı Bizim Google'a yazdığımız adres ise Client Kısmı(Görüntülediğimiz kısım) --%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <style>
        #area {
            width: 60%;
            margin: auto;
            padding: 5%;
            box-sizing: border-box;
        }

        #result {
            min-height: 40px;
            background-color: lightgray;
            border: 1px solid gray;
            line-height: 38px;
            font-size: 20px;
            /*font-weight: bold;*/
            text-align: center;
            border-radius: 5px;
        }
        #result div span{
            font-weight:bold;
        }
    </style>
</head>
<body>
    <%-- Adım 1 : Result div'ine doğrudan server tarafından random bir sayı göndermek istiyorum Bu random sayı Page Load olduğunda result div'inde görülecek.--%>
    <%-- RunAt = "server" neden var? (performans kaygısı) --%>
    <%-- Id ="result" (code behind'da çağırabilmek için) --%>

    <%-- Adım 2 : Page Load'da değil de,bir button'un click event'inde random bir sayı üretilsin --%>
    <%-- serverda çalışan özel eventler lazım. --%>
    <%-- code behind'da ise windowsForm'daki gibi event'ın çalıştıracağı methodlar yazılır.  (code behind --> Default.aspx.cs)  --%>

    <%-- Adım 3 : Random değer üretmek için iki adet aralık almak adına iki adet textbox (input) ekliyorum. Bu iki inputtan aralık alınıp, buton click'de o aralıkta değer üretilecek. --%>

    <%-- Adım 4 : Bir loto seneryosu üzerine 6 adet random sayı talep edicem. Her butona tıklandığında bir random sayı ve yanında kaç adet random sayı talep edildiğini gösteren sayaç olacak. Sayaç 6 olduğunda random sayı yerine "Bitti" yazılacak. --%>
    <%-- [[[STATELESS]]] : (Durumsuz) Durumunu korumayan : Her talep yeni bir page demektir. Haliyle her yeni page içerisinde tanımlanan global değişkenleri tekrardan tanımlar. (Arkada yazdığımız global int rndCount değerini arttıramıyoruz. Çünkü sayfa yenilendikçe onu tekrardan 0'a çekiyor.) --%>

    <%-- Adım 5 : Her zaman server'dan bir sayı değeri çekmeyeceğiz. Veritabanından data da çekebiliriz ve hatta çektiğimiz dataları result ekranına da basabiliriz. --%>

    <%-- Adım 6 : Stok sınırlamasına bir de kategori ekleyelim. Forma bir select ekleyelim ve bu selecti page load'da dolduralım --%>
    <%-- Sayfa yenilenmesinde 2 tip işlem vardır:
        [[[PostBack]]] : Bir form submit buton vasıtasıyla server'a gidip server işlemleri sonucunda tekrar html sayfa yükleniyorsa, bu sayfanın PostBack olduğunu gösterir.
        [[[Request]]] : Url yazarak sayfayı sunucundan talep edersek, yani form post işlemiyle alakasız bir şekilde sayfa talep edilirse, bu request'tir. Html sayfa tekrar yüklenir. --%>
    <%-- [[[ViewState]]] : PostBack durumunda form inputlarının içerisindeki değerleri korumasını sağlayan yapıdır. (ARAŞTIRIN!) --%>
    <%-- [[[Page.IsPostBack]]] : Sayfanın PostBack durumunda olup olmadığını kontrol etmek için kullanılır. --%>

    <%-- Her id'ye runat="server" verirsek arka planda sürekli gelir. Buda bizim Ram'i şişirmesine ve karışmasına hatta performans kaybına neden olur. --%>
    <form id="form1" runat="server">
        <div id="area">
            <%-- Adım 5 : --%>
            <label>Listelenecek ürünlerin stok aralığını giriniz :</label>


            <input id="firstNumber" runat="server" class="form-control" type="text" value="" placeholder="İlk Sayı..." />
            <br />
            <input id="secondNumber" runat="server" class="form-control" type="text" value="" placeholder="İkinci Sayı..." /><br />
            <br />
            <%-- Arkada yazdığımız metotları butonların click'inde çağırmak için onSrverClick diyoruz ve metot direk geliyor. --%>

            <select id="categoryList" runat="server" class="form-control"></select> <br />
            <br />

            <%-- Biz burda button'a type="button" desekte sonuç olarak bu submit'dir. Çünkü runat="server"'dır. Eğer button'da bu varsa otomatikman button submit oluyor.O yüzden orda yazdığımız  type="button" bir anlam ifade etmez. --%>

            <%-- Request --> Çubuğa yazınca aynı linki form-load'ına gelen değerler temizce gelir. Ancak; --%>
            <%-- PostBack --> (Submit buttonundan kaynaklı) Button'a bastığımızda da yenileniyor sayfa. Fakat içindeki değerler saklanıyor. Yani CategoryName'ler her buttona bastıkça geliyor. (Kaç kera bastıysan o kere tekrarlanmış oluyor.) --%>

            <button type="button" id="btnRun" runat="server" class="btn btn-primary center-block" onserverclick="btnRunClick">Üret</button><br />
            <br />
            <%--onclick="JavaScriptKoduBurası"--%>

            <%-- Adım 1: Adım 2: Adım 3: Adım 5: için geçerli --%>
            <div id="result" runat="server"></div>
       
        <%--Arkaplanda erişmek istiyorsak buna runat="server" dememiz gerekiyor. --%>

        <%-- Adım 4 : --%>
        <%--<div id="result" runat="server"> 
            <div class="col-md-6">
                Sayı Adedi : <span runat="server" id="count">0</span>
            </div>
            <div class="col-md-6">
                Random Sayı : <span runat="server" id="newResult"> - </span>
            </div>
        </div>--%>
    </form>



    <script src="Scripts/jquery-1.9.1.js"></script>
    <script src="Scripts/bootstrap.js"></script>
</body>
</html>
