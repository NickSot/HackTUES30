﻿document.addEventListener('DOMContentLoaded', function () {

    var messageInput = document.getElementById('message');

    // Get the user name and store it to prepend to messages.
    var name = $("#userneim").val();
    // Set initial focus to message input box.
    messageInput.focus();

    // Start the connection.
    startConnection('/chat', function (connection) {
            // Create a function that the hub can call to broadcast messages.
            connection.on('broadcastMessage', function (name, message) {
                // Html encode display name and message.
                var encodedName = name;
                var encodedMsg = message;
                // Add the message to the page.
                var liElement = document.createElement('li');
                liElement.id = "msg";
                liElement.innerHTML = '<strong>' + encodedName + '</strong>:&nbsp;&nbsp;' + encodedMsg + '<br>';
                document.getElementById('discussion').appendChild(liElement);
            });
        })
        .then(function (connection) {
            console.log('connection started');
            document.getElementById('sendmessage').addEventListener('click', function (event) {
                // Call the Send method on the hub.
                connection.invoke('send', name, messageInput.value);

                // Clear text box and reset focus for next comment.
                messageInput.value = '';
                messageInput.focus();
                event.preventDefault();
            });
        })
        .catch(error => {
            console.error(error.message);
        });

    // Starts a connection with transport fallback - if the connection cannot be started using
    // the webSockets transport the function will fallback to the serverSentEvents transport and
    // if this does not work it will try longPolling. If the connection cannot be started using
    // any of the available transports the function will return a rejected Promise.
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