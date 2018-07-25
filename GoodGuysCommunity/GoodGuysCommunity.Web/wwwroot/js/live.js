document.addEventListener('DOMContentLoaded', function () {

    var messageInput = document.getElementById('message');

    var name = $("#userneim").val();
    var currentroom = $("#room").val();
    
    messageInput.focus();

    
    startConnection('/chat', function (connection) {
            
            connection.on('broadcastMessage', function (name, message, room) {
                
                var encodedName = name;
                var encodedMsg = message;
               
                if (currentroom == room) {
                    
                    var liElement = document.createElement('li');
                    liElement.id = "msg";
                    liElement.innerHTML = '<strong>' + encodedName + '</strong>:&nbsp;&nbsp;' + encodedMsg + '<br>';
                    document.getElementById('discussion').appendChild(liElement);
                    $discussion = $('#discussion');
                    $discussion.scrollTop($discussion[0].scrollHeight + 15);
                }
                
            });
        })
        .then(function (connection) {
            console.log('connection started');
            document.getElementById('sendmessage').addEventListener('click', function (event) {
                
                connection.invoke('send', name, messageInput.value, currentroom);

                messageInput.value = '';
                messageInput.focus();
                event.preventDefault();
            });
        })
        .catch(error => {
            console.error(error.message);
        });


    function startConnection(url, configureConnection) {
        return function start(transport) {
            console.log(`Starting connection using ${signalR.TransportType[transport]} transport`)
            var connection = new signalR.HubConnection(url, { transport: transport });
            if (configureConnection && typeof configureConnection === 'function') {
                configureConnection(connection);
            }

            return connection.start()
                .then(function () {
                    return connection;
                })
                .catch(function (error) {
                    console.log(`Cannot start the connection use ${signalR.TransportType[transport]} transport. ${error.message}`);
                    if (transport !== signalR.TransportType.LongPolling) {
                        return start(transport + 1);
                    }

                    return Promise.reject(error);
                });
        }(signalR.TransportType.WebSockets);
    }
});