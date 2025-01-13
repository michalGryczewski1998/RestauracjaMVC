const inputElement = document.getElementById("PlikZdjecia");
const textarea = document.getElementById("Zdjecie");

inputElement.addEventListener("change", function () {
    const file = inputElement.files[0]; // Pobierz wybrany plik
    if (file) {
        const reader = new FileReader();
        // Gdy plik zostanie wczytany
        reader.onload = function (event) {
            const base64String = event.target.result.split(",")[1]; // Pobierz Base64 bez nagłówka
            console.log("Base64:", base64String); // Podgląd Base64 w konsoli
            textarea.value = base64String; // Zapisz Base64 w ukrytym polu
        };
        reader.readAsDataURL(file); // Odczytaj plik jako DataURL
    }
});