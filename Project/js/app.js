const openButton = document.querySelector('.chatbox__button');
const chatBox = document.querySelector('.chatbox__support');
const sendButton = document.querySelector('.send__button');

var state = true;
openButton.addEventListener('click', () => toggleState(chatBox))


function toggleState(chatbox) {
    if(state) {
        chatbox.classList.add('chatbox--active')
        state = false;
    } else {
        chatbox.classList.remove('chatbox--active')
        state = true;
    }
}