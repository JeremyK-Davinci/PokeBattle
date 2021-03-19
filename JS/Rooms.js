const container = document.querySelector(".container"),
Form = document.querySelector(".roomForm"),
title = document.querySelector(".title"),
errorDisplay = document.querySelector(".errorDisplay");

var joinButtons = document.querySelectorAll(".btnJoin");
var oldData = null;
var roomCount = 0;

setInterval(getRooms(), 10000);

function getRooms(){
    var xhr = new XMLHttpRequest();
    xhr.open("GET", "../XHR/Get_Rooms.php", true);
    xhr.onload = ()=>{
        if(xhr.readyState === XMLHttpRequest.DONE){
            if(xhr.status === 200){
                var data = xhr.response;
                if(data != oldData){
                    oldData = data;
                    container.innerHTML = data;
                    roomCount = container.children.length;
                    if(roomCount == 1){
                        title.textContent = `${roomCount} Room available`;
                    }
                    else{
                        title.textContent = `${roomCount} Rooms available`;
                    }
                    joinButtons = document.querySelectorAll(".btnJoin");
                    joinButtons.forEach(btn =>{
                        btn.addEventListener("click", joinRoom);
                    });
                }
                else return;
            }
        }
    }
    xhr.send();
}

function joinRoom(){
    var roomIdHolder = document.getElementById("roomIdHolder");
    roomIdHolder.value = this.value;

    var xhr = new XMLHttpRequest();
    xhr.open("POST", "../XHR/Post_Room.php", true);
    xhr.onload = ()=>{
        if(xhr.readyState === XMLHttpRequest.DONE){
            if(xhr.status === 200){
                var data = xhr.response;
                if(data == "success"){
                    location.href = "../Game/Room.php";
                }
                else{
                    errorDisplay.textContent = data;
                    errorDisplay.style.display = "block";
                }
            }
        }
    }
    
    var fd = new FormData(Form);
    xhr.send(fd);
}

getRooms();