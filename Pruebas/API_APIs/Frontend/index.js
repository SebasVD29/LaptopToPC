
async function getData() {
    try {
        const response = await fetch("http://localhost:5224/Apis/ListarAPIs", {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
            },
            datatype: 'jsonp',
        });
        const data = await response.json();
        console.log(data);
    } catch (error) {
        console.error("Error al obtener datos:", error);
    }
}

getData();