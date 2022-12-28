var connection = new signalR.HubConnectionBuilder()
    .withUrl('/game')
    .build();

connection.on('ReceivePosition', function (json) {

    const position = JSON.parse(json);

    var box = document.querySelector('.box');

    box.style.top = position.top;
    box.style.left = position.left;
    box.style.backgroundColor = position.color;

});

connection.start()
    .then(function () {
        console.log('Connected!');
        document.body.addEventListener('mousemove', mouseMove);
    })
    .catch(function (err) {
        return console.error(err.toString());
    });


let box = null;

function mouseMove(e) {

    if (box == null) {
        box = document.querySelector('.box');
    }

    if (box == null || box == undefined) {
        return;
    }

    const { clientX, clientY } = e;

    let obj = {
        top: `${clientY}px`,
        left: `${clientX}px`,
        color: `rgb(${(clientX + clientY) % 255},${clientX % 255},${clientY % 255})`
    }

    const objJson = JSON.stringify(obj);

    connection.invoke('SendPosition', objJson);

    box.style.top = obj.top;
    box.style.left = obj.left;
    box.style.backgroundColor = obj.color;
}