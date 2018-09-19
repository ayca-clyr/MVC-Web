var currentPersonId = 1; //otomatik artan bir değer lazım

//JSON Nesnesi

//var person_v2 = {
//    "Id":0,
//    "İsim": "",
//    "Soyisim": "",
//    "Telefonlar":[]
//}
//person_v2.Id = "1";
//person_v2.İsim = "Mahmut";
//person_v2.Soyisim = "Tuncer";
//person_v2.Telefonlar.push("2312312");


var Person = function () {
    this.Id = 0;
    this.FirstName = "";
    this.LastName = "";
    this.Phones = [];  //Birden cok telefon eklemek için.
}

//Telefon ekle(+) butonu
function AddPhoneBlock(sender) {

    //Yukardaki buton oluşturmayı buraya kopyalıyoruz.(+) deyince 2. telefonda ekleyebilecek
    //Aralardaki enter silinecek(tek satır gibi yazılacak)
    var newPhoneBlock = '<div class="form-inline"> <input class="form-control" type="text" name="Phone" value="" placeholder="Phone...." /> <input type="button" class="btn btn-success" value="+" onclick="AddPhoneBlock(this)"/> <input type="button" class="btn btn-warning" value="-"onclick="RemovePhoneBlock(this)" /> </div>'

    var phoneArea = document.getElementById("phone-area");

    //1. Yöntem
    //a
    // phoneArea.innerHTML += newPhoneBlock; //Sıfırlanıyor
    /* İnner HTML divler arasında kalan phone-inline'inin içindekilerin hepsi*/

    //b
    //sender.parentElement.parentElement.innerHTML += newPhoneBlock; //inputun tıklanan butonun parentElementi phone-Area olan div.Sıfırlanıyor.

    //2. Yöntem
    // sender.parentElement.outerHTML += newPhoneBlock; //sender'ın parentElementi form-inline olan div.Kaydedince sıfırlanıyor.
    /* outerHTML divlerin hepsi yani  phone-area içindekilerin hepsi*/

    //3. Yöntem(en uygun olanı) //Kaydedince telefonlar sıfırlanmaz
    var yeniElement = document.createElement("div") //Div oluşturulur.

    //içine oluşturulacak butonlar atılır.Yukardan alındı
    //İnnerHTML demek div'in için
    yeniElement.innerHTML = '<input class="form-control" type="text" name="Phone" value="" placeholder="Phone...." /> <input type="button" class="btn btn-success" value="+" onclick="AddPhoneBlock(this)" /> <input type="button" class="btn btn-warning" value="-"onclick="RemovePhoneBlock(this)" />';

    //Class ismi verildi
    yeniElement.className = "form-inline";


    sender.parentElement.parentElement.appendChild(yeniElement);
}

//Telefon sil(-) butonu
function RemovePhoneBlock(sender) {

    sender.parentElement.outerHTML = "";//outerHTML : div'in kendisi dahil içindekilerde demek.
    // romevenin parentElement'i form-inline outher diyince komplesi geliyor.
}

//Kişilerin listesi
var peopleList = [];

//inner demek içi, outher kendi ile içi.

function SavePerson(event) {
    /* var a = 0;
    undefined
    var b = a++;
    undefined
    b
    0
    a
    1
    b = a++;
    1
    b = ++a;
    3
    */
    //http://stackoverflow.com/questions/135718/event-preventdefault-vs-return-false
    //event.target // Eventin bağlı olduğu tag'i kasteder.Yani buton'a ait



    event.preventDefault();// Sayfanın yenilenmemesi için


    //Button elementi submit ise, varsayılan olarak click eventi form içerisindeki inputların değerlerini serve^'a gönderdiğinden sayfa yenilenir.Bu sebeple submite atanmış bir fonksiyon çalışmaz.Submitin varsayılan bu davranışını engellmek için aşagıdaki kodu yazdık.
    event.stopPropagation();  // Bir yere tıkladığımızda hem satır hem sütun hem table etkileniyor. Bu onun ayrımı için.


    var newPerson;

    var isUpdate = false;

    if (event.target.getAttribute("data-personId")) {
        // data-personId'de değer varsa
        for (var i = 0; i < peopleList.length; i++) {
            if (peopleList[i].Id == event.target.getAttribute("data-personId")) {
                newPerson = peopleList[i];
                isUpdate = true;
                break;
            }
        }
    }
    else {
        // data-personId diye bir attribute yoksa ya da değeri null ise buraya düşer ve YENİ KAYIT işlemi yapılacak demektir.

        newPerson = new Person();
        newPerson.Id = currentPersonId++;
    }


    newPerson.FirstName = document.getElementById("firstName").value; //Adı alır

    newPerson.LastName = document.getElementById("lastName").value;  //Soyadı alır


    // querySelector func returns firs element of selector text
    // (querySelector fonskiyonu selector tanımına uyan ilk elementi döndürür.)
    // var phoneInput = document.querySelector("form input[name=phone]");

    // querySelector func returns all elements of selector text
    // (querySelector fonskiyonu selector tanımına uyan bütün elementleri döndürür.)

    var phoneInputs = document.querySelectorAll("form input[name=Phone]") //All :Listesi
    newPerson.Phones = [];

    //Ekleme yapıyoruz
    for (var i = 0; i < phoneInputs.length; i++) {
        newPerson.Phones.push(phoneInputs[i].value);
    }
    if (!isUpdate) {


        peopleList.push(newPerson) //Listeye bilgileri girilen kişiyi attık
    }
    else {
        //event.target.removeAttribute("data-personId");
        ClearForm(document.querySelector("form .btn-danger"));

    }
    ClearForm();

    RefreshList();


    alert("Başarıyla Kaydedilmiştir!");
    SavePeopleToLocalStorage();
}

function ClearForm(cancelButton) {
    //Form içerisindeki inputları temizleyecek.
    var formInputs = document.querySelectorAll("form input[type=text]");
    for (var i = 0; i < formInputs.length; i++) {
        formInputs[i].value = "";
    }

    var phoneBlocks = document.querySelectorAll("form .form-inline");
    for (var i = 0; i < phoneBlocks.length; i++) {
        if (phoneBlocks[i].getAttribute("data-osman") != "kalıcı") { //eger osman diye kalıcı bir attiributwe yoksa sil
            phoneBlocks[i].remove();

        }
    }

    if (cancelButton) {
        cancelButton.remove();
    }
    document.querySelector("form button").textContent = "Save";
    document.querySelector("form button").removeAttribute("data-personId");


}
function RefreshList() {
    //Tablonun içerisindeki kişi datalarını tekrar yükleyecek


    var table = document.getElementById("people-list")
    table.tBodies[0].innerHTML = ""; //Varsa sil

    for (var i = 0; i < peopleList.length; i++) { //Listeyi don.

        var tr = document.createElement("tr");//Satır oluşturdum


        //innerText = textContent : yazdığımız herşeyi text diye algılar ve yorumlamaz
        //innerHTML : yazdıgımız textler içinde geçen HTML kodlarını algılar ve okur.

        //FirstName
        var tdName = document.createElement("td");//td oluşturdum
        //tdName.innerHTML // içinde var olan küçük,büyük işaretleri HTML olarak algıladığı için görmüyor.
        //tdName.innerText = textCotent// İçinde var olan küçük,büyük işaretleri text olarak algıladığı için çıktısında görür.
        tdName.textContent = peopleList[i].FirstName; //sırasın gelenin adı
        tr.appendChild(tdName); //satırın ilk sutununa ekledim.

        //LastName
        var tdSurname = document.createElement("td");
        tdSurname.textContent = peopleList[i].LastName;
        tr.appendChild(tdSurname);

        //Phones
        var tdPhones = document.createElement("td");
        for (var j = 0; j < peopleList[i].Phones.length; j++) {
            tdPhones.textContent += peopleList[i].Phones[j] + " | "; //Sonda iki boşluk '|' karakter var
        }
        tdPhones.textContent = tdPhones.textContent.substring(0, tdPhones.textContent.length - 3); // Sondaki | işareti silmek için.Son 3 karakter.
        tr.appendChild(tdPhones);
        //tr.Children.Add(tdPhone)  C#'daki yazım stili.

        //# (İşlmeler)
        var tdOther = document.createElement("td");
        tdOther.innerHTML = "<a href='#' onclick='FillForm({PERSONID}, event)'>Update</a> | <a href='#' onclick='RemovePerson({PERSONID}, event)'>Remove</a>".replace("{PERSONID}", peopleList[i].Id)
        .replace("{PERSONID}", peopleList[i].Id);

        tr.appendChild(tdOther);

        table.tBodies[0].appendChild(tr);

    }
}

function FillForm(id, event) {
    ClearForm();
    //http://stackoverflow.com/questions/135718/event-preventdefault-vs-return-false
    event.preventDefault();

    var person;
    for (var i = 0; i < peopleList.length; i++) {

        /*
        var a=5
        undefined
        a
        5
        if(a=6){console.log("DOĞRU")}
        VM82:1 DOĞRU
        undefined
        a
        6
        */
        if (peopleList[i].Id == id) {  // Tek eşittirde direk atama yapıyor ve if'i direk çalıştırır. Ama iki eşittirde
            person = peopleList[i];
            break;
        }
    }
    document.getElementById("firstName").value = person.FirstName;
    document.getElementById("lastName").value = person.LastName;
    document.querySelector("form input[name=Phone]").value = person.Phones[0];

    if (person.Phones.length > 1) {
        for (var i = 1; i < person.Phones.length; i++) { // İlkini zaten yukarda atadığımız için 1'den başlattık.
            var phoneArea = document.getElementById("phone-area");
            var phoneBlock = document.createElement("div");   // Ram üzerinde oluşturuyor.
            phoneBlock.className = "form-inline";
            phoneBlock.innerHTML = '<input class="form-control" type="text" name="Phone" value="{VALUE}" placeholder="Phone...." /> <input type="button" class="btn btn-success" value="+" onclick="AddPhoneBlock(this)"/> <input type="button" class="btn btn-warning" value="-"onclick="RemovePhoneBlock(this)"/>'.replace("{VALUE}", person.Phones[i]);
            phoneArea.appendChild(phoneBlock);  // Buda Ram üzerindeki oluşturulanı ekliyor.

        }
    }

    var saveButton = document.querySelector("form button");
    saveButton.textContent = "Update";  // text.content yukardaki Save olan elementler arası yazı demek.

    var cancelButton = document.createElement("button");
    cancelButton.className = "btn btn-danger";
    cancelButton.textContent = "Cancel";
    cancelButton.addEventListener("click", function () {
        ClearForm(this);  // this = cancelButton
    });
    // Birden fazla Cancel butonu eklenmesini önlemek adına bu alttaki koşulu ekledik.
    if (document.querySelectorAll("form button").length < 2) {  // Tıkladıktan sonra oluşan buton sayısını 2 yaptık 2'den fazla yapmıcaz.
        saveButton.after(cancelButton);  // after: Hemen sonrasına ekliyor.
    }


    saveButton.setAttribute("data-personId", person.Id.toString());

}

function RemovePerson(id, event) {
    event.preventDefault();

    var result = confirm("Are you sure about killing this guys information? :/") //MessageBox gibi true,false gibi.
    if (result) {
        for (var i = 0; i < peopleList.length; i++) {
            if (peopleList[i].Id == id) {
                peopleList.splice(i, 1);
                break;

            }

        }
    }
    RefreshList();
    SavePeopleToLocalStorage();
}

function SavePeopleToLocalStorage() {
    localStorage.setItem("currentPersonId", currentPersonId);
    localStorage.setItem("peopleList", JSON.stringify(peopleList));  // Direk JSON'a çeviriyor.

}

function GetPeopleFromLocalStorage() {
    if (localStorage.getItem("peopleList")) {
        var stringJSON = localStorage.getItem("peopleList");
        peopleList = JSON.parse(stringJSON);
        RefreshList();

    }
    if (localStorage.getItem("currentPersonId ")) {
        currentPersonId = parseInt(localStorage.getItem("currentPersonId"));
    }
    RefreshList();
}