const Form = document.querySelector(".registerForm"),
registerButton = document.querySelector(".btnRegister"),
errorDisplay = document.querySelector(".errorDisplay");

Form.onsubmit = (e)=>{
    e.preventDefault();
}

registerButton.onclick = ()=>{
    var xhr = new XMLHttpRequest();
    xhr.open("POST", "../SQL/UserFunctions/RegFunc.php", true);
    xhr.onload = ()=>{
        if(xhr.readyState === XMLHttpRequest.DONE){
            if(xhr.status === 200){
                var data = xhr.response;
                if(data == "success"){
                    location.href = "../Index.php";
                }
                else{
                    errorDisplay.textContent = data;
                    errorDisplay.style.display = "block"
                }
            }
        }
    }
    var fd = new FormData(Form);
    xhr.send(fd);
}