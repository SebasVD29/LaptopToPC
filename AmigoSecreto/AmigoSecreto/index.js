const familia = [
"Enio VD", "Yesenia VD", "Sebastian VD",
"Elena VV", "Jhonny VV" , "Fabian VV", "Esteban VV",
"Brayan RV", "Ana Paula RV",
"Joaquin VA", "Juan Pablo VA", "Mirian VA",
"Tia Alba AA","Tia Ines AA", "Tia Marta AA"
]

const amigosSecretos = [
"Enio VD", "Yesenia VD", "Sebastian VD",
"Elena VV", "Jhonny VV" , "Fabian VV", "Esteban VV",
"Brayan RV", "Ana Paula RV",
"Joaquin VA", "Juan Pablo VA", "Mirian VA",
"Tia Alba AA","Tia Ines AA", "Tia Marta AA"
]

function actualizarSelect() {
    const select = document.getElementById("participantes");
    select.innerHTML = ""; // Limpiar las opciones actuales

    familia.forEach((persona) => {
        const option = document.createElement("option");
        option.value = persona;
        option.textContent = persona;
        select.appendChild(option);
    });
}

function seleccionarAmigoSecreto() {
    const select = document.getElementById("participantes");
    const participante = select.value;
    let amigoSecreto = "";

    do {
        const amigoRandom = Math.floor(Math.random() * amigosSecretos.length);
        amigoSecreto = amigosSecretos[amigoRandom];

        // Verificar que no sea el mismo participante y que no tenga la misma terminación
        if (participante !== amigoSecreto && !amigoSecreto.endsWith(participante.slice(-2))) {
            break;
        }
    } while (true);
    
    eliminarDeArray(amigosSecretos, amigoSecreto);
    eliminarDeArray(familia, participante);

    // Actualizar el select
    actualizarSelect();

    // Mostrar resultado
    document.getElementById("resultado").innerHTML = 
    `Participante: ${participante}<br><strong>Amigo Secreto: ${amigoSecreto}</strong>`;
}

function eliminarDeArray(array, elemento) {
    const indice = array.indexOf(elemento);
    if (indice !== -1) {
        array.splice(indice, 1); // Eliminar el elemento
    }
}

document.addEventListener("DOMContentLoaded", () => {
    actualizarSelect(); // Llenar el select al cargar la página
    document.getElementById("seleccionar").addEventListener("click", seleccionarAmigoSecreto);
});