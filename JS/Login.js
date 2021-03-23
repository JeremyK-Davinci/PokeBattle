const Form = document.querySelector(".loginForm"),
loginButton = document.querySelector(".btnLogin"),
errorDisplay = document.querySelector(".errorDisplay");

Form.onsubmit = (e)=>{
    e.preventDefault();
}

loginButton.onclick = ()=>{
    var xhr = new XMLHttpRequest(); // <- Create a new XHR instance
    xhr.open("POST", "../SQL/UserFunctions/LogFunc.php", true); // <- Using the XHR instance, asynchronomously send a post request to the given url
    xhr.onload = ()=>{
        if(xhr.readyState === XMLHttpRequest.DONE){
            if(xhr.status === 200){
                var data = xhr.response;
                if(data == "success"){ // <- If the request finished and returned a success response, complete login and go to index
                    location.href = "../Index.php";
                }
                else{ // <- If the request finished and returned a non-success response, display an error
                    errorDisplay.textContent = data;
                    errorDisplay.style.display = "block";
                }
            }
        }
    }
    var fd = new FormData(Form); // <- Create a FormData object from the input form;
    xhr.send(fd); // <- Start the XHR request with the formdata
}