const //UserInfo Constants
FormUserInfo = document.querySelector(".updateUserForm"),
InfoTitle = document.querySelector(".user-info-title"),
InfoSuccess = document.querySelector(".responseSuccess"),
InfoFail = document.querySelector(".responseFail"),
NameInput = document.querySelector(".updateName"),
MailInput = document.querySelector(".updateMail"),
PassInput = document.querySelector(".updatePass"),
UpdateUserButton = document.querySelector(".btnUpdateUser");

var //UserInfo Variables
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

const //UserPokemon Constants
PokemonTitle = document.querySelector(".user-pokemon-title"),
PokemonContainer = document.querySelector(".pokeContainer"),
TestButton = document.querySelector(".btnTest"),
TransferObject = document.querySelector(".JSTransfer");

var //UserPokemon Variables
SelectFirstPokemonButtons = document.querySelectorAll(".FirstPokemonButton");

var //UserPokemon Arrays
StarterPokemon = [];

TestButton.onclick = ()=>{
    /*if(PokemonContainer.children.length <= 0){
        
    }*/
    createSelectFirstPokemonOverlay();
}

function createSelectFirstPokemonOverlay(){
    var overlay = document.createElement("div");
    overlay.classList.add("firstPokemonOverlay");

    var overlayContainer = document.createElement("div");
    overlayContainer.classList.add("col-lg-6", "col-12", "offset-lg-3", "border", "border-light", "rounded", "mb-5", "firstPokemonContainer", "reveal");

    var TitleText = document.createElement("h1");
    TitleText.textContent = "Looks like you don't have any pokemon yet. Let's change that now!";
    TitleText.classList.add("text-center", "text-light");

    var secondaryText = document.createElement("h3");
    secondaryText.textContent = "Please select your first pokemon from this list";
    secondaryText.classList.add("text-center", "text-light");

    overlayContainer.appendChild(TitleText);
    overlayContainer.appendChild(secondaryText);

    StarterPokemon.forEach(Pokemon => {
        var PokemonButton = document.createElement("button");
        PokemonButton.classList.add("btn", "btn-outline-light", "col-lg-1", "col-4", "ml-lg-5", "mt-3", "mb-5", "pt-3", "pt-4", "FirstPokemonButton");

        var PokemonImage = document.createElement("img");
        PokemonImage.classList.add("img-fluid", "img-Pokemon");
        PokemonImage.src = `https://img.pokemondb.net/sprites/bank/normal/${Pokemon['name'].toLowerCase()}.png`;
        PokemonImage.alt = `${Pokemon['name']}`;

        var PokemonName = document.createElement("p");
        PokemonName.classList.add("pokemonName");
        PokemonName.textContent = `${Pokemon['name']}`;

        PokemonButton.appendChild(PokemonImage);
        PokemonButton.appendChild(PokemonName);

        overlayContainer.appendChild(PokemonButton);
    });

    SelectFirstPokemonButtons = document.querySelectorAll(".FirstPokemonButton");

    overlay.appendChild(overlayContainer);

    document.body.append(overlay);
}

function closeSelectFirstPokemonOverlay(){
    var overlay = document.querySelector(".firstPokemonOverlay");
    if(overlay != null){
        document.body.removeChild(overlay);
    }
}

function selectThisPokemon(){
    
}

document.body.onload = ()=>{
    StarterPokemon = JSON.parse(TransferObject.value);
    TransferObject.value = '';
    console.log(StarterPokemon);
}