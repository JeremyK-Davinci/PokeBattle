const //Constants
FormUserInfo = document.querySelector(".updateUserForm"),
InfoTitle = document.querySelector(".user-info-title"),
PokemonTitle = document.querySelector(".user-pokemon-title"),
InfoSuccess = document.querySelector(".responseSuccess"),
InfoFail = document.querySelector(".responseFail"),
NameInput = document.querySelector(".updateName"),
MailInput = document.querySelector(".updateMail"),
PassInput = document.querySelector(".updatePass"),
UpdateUserButton = document.querySelector(".btnUpdateUser");

var
formUserPassInfo = document.querySelector(".updateUserPassForm"),
updatePassButton = document.querySelector(".btnUpdatePass");

FormUserInfo.onsubmit = (e)=>{
    e.preventDefault();
}

UpdateUserButton.onclick = ()=>{
    if(PassInput.value !== "########"){
        createPasswordOverlay();
        return;
    }
    else{
        var xhr = new XMLHttpRequest();
        xhr.open("POST", "../SQL/UserFunctions/UpdateInfoFunc.php", true);
        xhr.onload = ()=>{
            if(xhr.readyState === XMLHttpRequest.DONE){
                if(xhr.status === 200){
                    var data = xhr.response;
                    console.log(data);
                    if(data == "success"){
                        InfoTitle.textContent = NameInput.value;
                        PokemonTitle.textContent = `${NameInput.value}'s Pokemon`;
                        InfoSuccess.textContent = "Succesfully updated";
                        InfoSuccess.style.display = "block";
                        setTimeout(()=>{
                            InfoSuccess.style.display = "none";
                        }, 5000);
                        return;
                    }
                    else{
                        InfoFail.textContent = "Failed updating : " + data;
                        InfoFail.style.display = "block";
                        setTimeout(()=>{
                            InfoFail.style.display = "none";
                        }, 10000);
                        return;
                    }
                }
            }
        }
        var fd = new FormData(FormUserInfo);
        xhr.send(fd);
    }
}


function createPasswordOverlay(){
    var overlay = document.createElement("div");
    overlay.classList.add("passwordUpdateOverlay");

    var closeButton = document.createElement("button");
    closeButton.classList.add("btn", "btnCloseOverlay");
    closeButton.innerHTML = "<i class='fas fa-2x fa-times'></i>";
    closeButton.addEventListener("click", closeOverlay);

    var passUpdateContainer = document.createElement("div");
    passUpdateContainer.classList.add("col-lg-4", "col-12", "offset-lg-4", "border", "border-light", "rounded", "bg-dark", "passwordUpdateContainer");

    var failInfo = document.createElement("p");
    failInfo.classList.add("border", "rounded", "bg-danger", "text-light", "text-center", "responseFail", "mx-3");

    var passUpdateForm = document.createElement("form");
    passUpdateForm.classList.add("updateUserPassForm");
    passUpdateForm.action = "#";
    passUpdateForm.enctype = "multipart/form-data";
    passUpdateForm.type = "post";

    var labelNewPass = document.createElement("label");
    labelNewPass.classList.add("text-left", "text-light", "h3", "pt-3");
    labelNewPass.htmlFor = "newPassword";
    labelNewPass.textContent = "New Password : ";

    var inputNewPass = document.createElement("input");
    inputNewPass.classList.add("form-control", "inputNewPass");
    inputNewPass.type = "password";
    inputNewPass.name = "newPassword";
    inputNewPass.value = PassInput.value;
    inputNewPass.addEventListener("focusin", showPass);
    inputNewPass.addEventListener("focusout", hidePass);

    var labelConfirmNewPass = document.createElement("label");
    labelConfirmNewPass.classList.add("text-left", "text-light", "h3", "pt-3");
    labelConfirmNewPass.htmlFor = "confirmNewPassword";
    labelConfirmNewPass.textContent = "Confirm Password : ";

    var inputConfirmNewPass = document.createElement("input");
    inputConfirmNewPass.classList.add("form-control", "inputConfirmNewPass");
    inputConfirmNewPass.type = "password";
    inputConfirmNewPass.name = "confirmNewPassword";
    inputConfirmNewPass.addEventListener("focusin", showPass);
    inputConfirmNewPass.addEventListener("focusout", hidePass);

    var inputSubmit = document.createElement("input");
    inputSubmit.classList.add("btn", "btn-outline-light", "col-6", "offset-3", "rounded", "mt-5", "mb-3", "btnUpdatePass");
    inputSubmit.type = "submit";
    inputSubmit.name = "UpdatePass";
    inputSubmit.value = "UpdatePass";

    passUpdateForm.appendChild(labelNewPass);
    passUpdateForm.appendChild(inputNewPass);
    passUpdateForm.appendChild(labelConfirmNewPass);
    passUpdateForm.appendChild(inputConfirmNewPass);
    passUpdateForm.appendChild(inputSubmit);
    
    passUpdateContainer.appendChild(passUpdateForm);

    overlay.appendChild(passUpdateContainer);
    overlay.appendChild(closeButton);

    document.body.appendChild(overlay);

    formUserPassInfo = document.querySelector(".updateUserPassForm");
    updatePassButton = document.querySelector(".btnUpdatePass");

    formUserPassInfo.onsubmit = (e)=>{
        e.preventDefault();
    }

    updatePassButton.onclick = ()=>{
        var xhr = new XMLHttpRequest();
        xhr.open("POST", "../SQL/UserFunctions/UpdatePassFunc.php", true);
        xhr.onload = ()=>{
            if(xhr.readyState === XMLHttpRequest.DONE){
                if(xhr.status === 200){
                    var data = xhr.response;
                    if(data == "success"){
                        closeOverlay();
                        InfoSuccess.textContent = "Succesfully updated password";
                        InfoSuccess.style.display = "block";
                        setTimeout(()=>{
                            InfoSuccess.style.display = "none";
                        }, 5000);
                        return;
                    }
                    else{
                        failInfo.textContent = "Failed updating passworda : " + data;
                        failInfo.style.display = "block";
                        setTimeout(()=>{
                            failInfo.style.display = "none";
                        }, 10000);
                        return;
                    }
                }
            }
        }
        var fd = new FormData(formUserPassInfo);
        xhr.send(fd);
    }
}

function closeOverlay(){
    var overlay = document.querySelector(".passwordUpdateOverlay");
    if(overlay != null){
        document.body.removeChild(overlay);
    }
}

function showPass(){
    this.type = "text";
}

function hidePass(){
    this.type = "password";
}