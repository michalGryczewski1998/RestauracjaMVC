document.getElementById("PlikZdjecia").addEventListener("change", function () {
    const file = this.files[0]; // Pobierz wybrany plik
    if (file) {
        const reader = new FileReader();
        reader.onload = function (e) {
            const base64String = e.target.result; // Konwersja na Base64
            document.getElementById("Zdjecie").value = base64String; // Ustawienie ukrytego pola
            console.log("Tu jestem " + base64String);
        };
        reader.readAsDataURL(file); // Odczyt pliku jako Base64
    }
});