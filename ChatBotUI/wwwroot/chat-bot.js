var botui = new BotUI('chat-bot')
var loadingMsgIndex;
var API = '/api/chat/';

botui.message.add({
    content: 'Hi there!',
    delay: 500
}).then(waitingResponse);


function displayActionText() {
    botui.action.text({
        delay: 250,
        action: {
            size: 30,
            placeholder: ''
        }
    }).then(function (res) {
        loadingMsgIndex = botui.message.bot({
            delay: 0,
            loading: true
        }).then(function (index) {
            loadingMsgIndex = index;
            sendXHR(res.value, handleServerResponse)
        });
    });
}

function waitingResponse(res) {
    displayActionText();
}

function handleServerResponse(res) {
    botui.message.update(loadingMsgIndex, {
        content: res.content
    }).then(waitingResponse(res));
}

function sendXHR(humanResponse, callback) {
    var xhr = new XMLHttpRequest();
    var self = this;
    xhr.open('GET', API + humanResponse);
    xhr.onload = function () {
        var res = JSON.parse(xhr.responseText)
        callback(res);
    }
    xhr.send();
}