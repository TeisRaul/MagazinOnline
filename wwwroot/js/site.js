    document.addEventListener("DOMContentLoaded", function () {
            var dragDropArea = document.getElementById("drag-drop-area");
    var fileInput = document.getElementById("file-input");
    var dragDropText = document.getElementById("drag-drop-text");

    if (dragDropArea && fileInput && dragDropText) {
        dragDropArea.addEventListener("dragover", function (e) {
            e.preventDefault();
            dragDropArea.classList.add("drag-over");
            dragDropText.textContent = "Eliberați fișierele pentru încărcare";
        });

    dragDropArea.addEventListener("dragleave", function () {
        dragDropArea.classList.remove("drag-over");
    dragDropText.textContent = "Trageți și lăsați fișierele aici sau faceți clic pentru a le selecta.";
                });

    dragDropArea.addEventListener("drop", function (e) {
        e.preventDefault();
    dragDropArea.classList.remove("drag-over");
    dragDropText.textContent = "Trageți și lăsați fișierele aici sau faceți clic pentru a le selecta.";

    var files = e.dataTransfer.files;
    fileInput.files = files;
                });

    fileInput.addEventListener("change", function () {
                    if (fileInput.files.length > 0) {
        dragDropText.textContent = fileInput.files[0].name;
                    }
                });
            }
        });